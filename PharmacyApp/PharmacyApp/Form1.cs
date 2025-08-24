using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PharmacyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Add medicine
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                using (var cmd = new SqlCommand("AddMedicine", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Category", txtCategory.Text.Trim());
                    cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text.Trim()));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicine added.");
                    LoadMedicines();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding medicine:\n" + ex.Message);
            }
        }

        // Search medicine
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                using (var cmd = new SqlCommand("SearchMedicine", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SearchTerm", txtSearch.Text.Trim());

                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(rdr);
                        dgvMedicines.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching:\n" + ex.Message);
            }
        }

        // Update stock
        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            if (dgvMedicines.CurrentRow == null)
            {
                MessageBox.Show("Select a medicine first.");
                return;
            }

            var id = (int)dgvMedicines.CurrentRow.Cells["MedicineID"].Value;
            var qty = int.Parse(txtQuantity.Text.Trim());

            try
            {
                using (var conn = DbHelper.GetConnection())
                using (var cmd = new SqlCommand("UpdateStock", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MedicineID", id);
                    cmd.Parameters.AddWithValue("@Quantity", qty);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Stock updated.");
                    LoadMedicines();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating stock:\n" + ex.Message);
            }
        }

        // Record sale
        private void btnRecordSale_Click(object sender, EventArgs e)
        {
            if (dgvMedicines.CurrentRow == null)
            {
                MessageBox.Show("Select a medicine first.");
                return;
            }

            var id = (int)dgvMedicines.CurrentRow.Cells["MedicineID"].Value;
            var qtySold = int.Parse(txtQuantity.Text.Trim());

            try
            {
                using (var conn = DbHelper.GetConnection())
                using (var cmd = new SqlCommand("RecordSale", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MedicineID", id);
                    cmd.Parameters.AddWithValue("@QuantitySold", qtySold);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sale recorded.");
                    LoadMedicines();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error recording sale:\n" + ex.Message);
            }
        }

        // View all
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadMedicines();
        }

        private void LoadMedicines()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                using (var cmd = new SqlCommand("GetAllMedicines", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(rdr);
                        dgvMedicines.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading medicines:\n" + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
