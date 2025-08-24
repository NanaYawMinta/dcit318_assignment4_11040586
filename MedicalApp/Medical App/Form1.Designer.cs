using System.Windows.Forms;

namespace MedicalApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnDoctors;
        private Button btnBook;
        private Button btnManage;




        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnDoctors = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnManage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDoctors
            // 
            this.btnDoctors.Location = new System.Drawing.Point(40, 30);
            this.btnDoctors.Name = "btnDoctors";
            this.btnDoctors.Size = new System.Drawing.Size(220, 40);
            this.btnDoctors.TabIndex = 0;
            this.btnDoctors.Text = "View Doctors";
            this.btnDoctors.UseVisualStyleBackColor = true;
            this.btnDoctors.Click += new System.EventHandler(this.btnDoctors_Click);
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(40, 90);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(220, 40);
            this.btnBook.TabIndex = 1;
            this.btnBook.Text = "Book Appointment";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnManage
            // 
            this.btnManage.Location = new System.Drawing.Point(40, 150);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(220, 40);
            this.btnManage.TabIndex = 2;
            this.btnManage.Text = "Manage Appointments";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(300, 230);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnDoctors);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medical Appointment System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }
    }
}
