using System;
using System.Windows.Forms;

namespace MedicalApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Optional: Any initialization code for MainForm
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            using (var form = new DoctorListForm())
            {
                form.ShowDialog();
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            using (var form = new AppointmentForm())
            {
                form.ShowDialog();
            }
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            using (var form = new ManageAppointmentsForm())
            {
                form.ShowDialog();
            }
        }
    }
}
