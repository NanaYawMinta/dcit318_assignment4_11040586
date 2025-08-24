using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalApp
{
    public partial class ManageAppointmentsForm : Form
    {
        private DataSet _ds;
        private SqlDataAdapter _da;

        public ManageAppointmentsForm()
        {
            InitializeComponent();
            Load += ManageAppointmentsForm_Load;
            btnRefresh.Click += (s, e) => LoadAppointments();
            txtSearch.TextChanged += (s, e) => LoadAppointments(txtSearch.Text.Trim());
            btnUpdateDate.Click += BtnUpdateDate_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void ManageAppointmentsForm_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments(string term = "")
        {
            try
            {
                using (var conn = Db.GetConnection())
                using (var cmd = new SqlCommand(@"
SELECT a.AppointmentID, d.FullName AS Doctor, p.FullName AS Patient,
       a.AppointmentDate, a.Notes, a.DoctorID, a.PatientID
FROM Appointments a
JOIN Doctors d  ON a.DoctorID = d.DoctorID
JOIN Patients p ON a.PatientID = p.PatientID
WHERE (@term = '' OR d.FullName LIKE '%'+@term+'%' OR p.FullName LIKE '%'+@term+'%')
ORDER BY a.AppointmentDate DESC;", conn))
                {
                    cmd.Parameters.AddWithValue("@term", term ?? "");
                    _da = new SqlDataAdapter(cmd);
                    _ds = new DataSet();

                    conn.Open();
                    _da.Fill(_ds, "Appts");
                    dgvAppts.DataSource = _ds.Tables["Appts"];

                    if (dgvAppts.Columns.Contains("DoctorID")) dgvAppts.Columns["DoctorID"].Visible = false;
                    if (dgvAppts.Columns.Contains("PatientID")) dgvAppts.Columns["PatientID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load appointments.\n" + ex.Message);
            }
        }

        private int? SelectedAppointmentId()
        {
            if (dgvAppts.CurrentRow == null) return null;
            return Convert.ToInt32(dgvAppts.CurrentRow.Cells["AppointmentID"].Value);
        }

        private void BtnUpdateDate_Click(object sender, EventArgs e)
        {
            var id = SelectedAppointmentId();
            if (id == null) { MessageBox.Show("Select an appointment first."); return; }

            var current = Convert.ToDateTime(dgvAppts.CurrentRow.Cells["AppointmentDate"].Value);
            var picker = new DateTimePicker { Value = current };
            var host = new Form { Text = "Select new date/time", Width = 260, Height = 90, StartPosition = FormStartPosition.CenterParent };
            picker.Dock = DockStyle.Fill;
            host.Controls.Add(picker);

            if (host.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var conn = Db.GetConnection())
                    using (var cmd = new SqlCommand(
                        "UPDATE Appointments SET AppointmentDate=@T WHERE AppointmentID=@ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@T", picker.Value);
                        cmd.Parameters.AddWithValue("@ID", id.Value);
                        conn.Open();
                        var rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows > 0 ? "Updated." : "No change.");
                        LoadAppointments(txtSearch.Text.Trim());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update failed.\n" + ex.Message);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var id = SelectedAppointmentId();
            if (id == null) { MessageBox.Show("Select an appointment first."); return; }

            if (MessageBox.Show("Delete this appointment?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = Db.GetConnection())
                    using (var cmd = new SqlCommand("DELETE FROM Appointments WHERE AppointmentID=@ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id.Value);
                        conn.Open();
                        var rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows > 0 ? "Deleted." : "Not found.");
                        LoadAppointments(txtSearch.Text.Trim());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete failed.\n" + ex.Message);
                }
            }
        }
    }
}
