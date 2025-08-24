using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalApp
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            Load += AppointmentForm_Load;
            btnBook.Click += BtnBook_Click;
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            LoadDoctors();
            LoadPatients();
            dtpDate.Value = DateTime.Now.AddHours(1);
        }

        private void LoadDoctors()
        {
            try
            {
                using (var conn = Db.GetConnection())
                using (var cmd = new SqlCommand(
                    "SELECT DoctorID, FullName FROM Doctors WHERE Availability = 1 ORDER BY FullName", conn))
                {
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(rdr);
                        cmbDoctor.DataSource = dt;
                        cmbDoctor.DisplayMember = "FullName";
                        cmbDoctor.ValueMember = "DoctorID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load doctors.\n" + ex.Message);
            }
        }

        private void LoadPatients()
        {
            try
            {
                using (var conn = Db.GetConnection())
                using (var cmd = new SqlCommand(
                    "SELECT PatientID, FullName FROM Patients ORDER BY FullName", conn))
                {
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(rdr);
                        cmbPatient.DataSource = dt;
                        cmbPatient.DisplayMember = "FullName";
                        cmbPatient.ValueMember = "PatientID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load patients.\n" + ex.Message);
            }
        }

        private void BtnBook_Click(object sender, EventArgs e)
        {
            if (cmbDoctor.SelectedValue == null || cmbPatient.SelectedValue == null)
            {
                MessageBox.Show("Please select a doctor and a patient.");
                return;
            }

            var doctorId = (int)cmbDoctor.SelectedValue;
            var patientId = (int)cmbPatient.SelectedValue;
            var apptDate = dtpDate.Value;
            var notes = txtNotes.Text.Trim();

            try
            {
                using (var conn = Db.GetConnection())
                {
                    conn.Open();

                    // 1) Check doctor availability flag (redundant with WHERE but good UX)
                    using (var checkAvail = new SqlCommand(
                        "SELECT Availability FROM Doctors WHERE DoctorID=@D", conn))
                    {
                        checkAvail.Parameters.AddWithValue("@D", doctorId);
                        var available = (bool?)checkAvail.ExecuteScalar() ?? false;
                        if (!available)
                        {
                            MessageBox.Show("Selected doctor is not available.");
                            return;
                        }
                    }

                    // 2) Check time clash
                    using (var clash = new SqlCommand(
                        "SELECT COUNT(1) FROM Appointments WHERE DoctorID=@D AND AppointmentDate=@T", conn))
                    {
                        clash.Parameters.AddWithValue("@D", doctorId);
                        clash.Parameters.AddWithValue("@T", apptDate);
                        var count = (int)clash.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("That time is already booked for this doctor.");
                            return;
                        }
                    }

                    // 3) Insert
                    using (var insert = new SqlCommand(
                        @"INSERT INTO Appointments(DoctorID, PatientID, AppointmentDate, Notes)
                          VALUES(@D, @P, @T, @N)", conn))
                    {
                        insert.Parameters.AddWithValue("@D", doctorId);
                        insert.Parameters.AddWithValue("@P", patientId);
                        insert.Parameters.AddWithValue("@T", apptDate);
                        insert.Parameters.AddWithValue("@N", (object)notes ?? DBNull.Value);

                        var rows = insert.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Appointment booked successfully!");
                            txtNotes.Clear();
                        }
                        else
                        {
                            MessageBox.Show("No rows inserted.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Booking failed.\n" + ex.Message, "Error");
            }
        }
    }
}
