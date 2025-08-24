using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalApp
{
    public partial class DoctorListForm : Form
    {
        public DoctorListForm()
        {
            InitializeComponent();
            Load += DoctorListForm_Load;
        }

        private void DoctorListForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = Db.GetConnection())
                using (var cmd = new SqlCommand(
                    "SELECT DoctorID, FullName, Specialty, Availability FROM Doctors ORDER BY FullName", conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    conn.Open();
                    da.Fill(dt);
                    dgvDoctors.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load doctors.\n" + ex.Message, "Error");
            }
        }
    }
}
