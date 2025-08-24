using System;
using System.Windows.Forms;

namespace MedicalApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional: add any startup logic here
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
