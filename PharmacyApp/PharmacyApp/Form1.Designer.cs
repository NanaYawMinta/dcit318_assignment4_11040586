namespace PharmacyApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.UpdateStock = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.ViewAll = new System.Windows.Forms.Button();
            this.dgvMedicines = new System.Windows.Forms.DataGridView();
            this.Nam = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.Searc = new System.Windows.Forms.Label();
            this.Category = new System.Windows.Forms.Label();
            this.Quality = new System.Windows.Forms.Label();
            this.Medicines = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(97, 71);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(465, 73);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(100, 20);
            this.txtCategory.TabIndex = 1;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(97, 119);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 2;
            this.txtPrice.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(465, 123);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(97, 163);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 4;
            // 
            // Add
            // 
            this.Add.AccessibleName = "";
            this.Add.Location = new System.Drawing.Point(63, 214);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 5;
            this.Add.Text = "Add Medicine";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(169, 214);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 6;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.button2_Click);
            // 
            // UpdateStock
            // 
            this.UpdateStock.Location = new System.Drawing.Point(268, 214);
            this.UpdateStock.Name = "UpdateStock";
            this.UpdateStock.Size = new System.Drawing.Size(81, 23);
            this.UpdateStock.TabIndex = 7;
            this.UpdateStock.Text = "UpdateStock";
            this.UpdateStock.UseVisualStyleBackColor = true;
            this.UpdateStock.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(366, 214);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "RecordSale";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // ViewAll
            // 
            this.ViewAll.Location = new System.Drawing.Point(465, 214);
            this.ViewAll.Name = "ViewAll";
            this.ViewAll.Size = new System.Drawing.Size(75, 23);
            this.ViewAll.TabIndex = 9;
            this.ViewAll.Text = "ViewAll";
            this.ViewAll.UseVisualStyleBackColor = true;
            // 
            // dgvMedicines
            // 
            this.dgvMedicines.AccessibleName = "Medicines";
            this.dgvMedicines.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvMedicines.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicines.Location = new System.Drawing.Point(190, 257);
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.Size = new System.Drawing.Size(240, 150);
            this.dgvMedicines.TabIndex = 10;
            this.dgvMedicines.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Nam
            // 
            this.Nam.AccessibleName = "";
            this.Nam.AutoSize = true;
            this.Nam.Location = new System.Drawing.Point(41, 76);
            this.Nam.Name = "Nam";
            this.Nam.Size = new System.Drawing.Size(38, 13);
            this.Nam.TabIndex = 11;
            this.Nam.Text = "Name:";
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(45, 123);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(34, 13);
            this.Price.TabIndex = 12;
            this.Price.Text = "Price:";
            // 
            // Searc
            // 
            this.Searc.AutoSize = true;
            this.Searc.Location = new System.Drawing.Point(42, 169);
            this.Searc.Name = "Searc";
            this.Searc.Size = new System.Drawing.Size(44, 13);
            this.Searc.TabIndex = 13;
            this.Searc.Text = "Search:";
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Location = new System.Drawing.Point(343, 78);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(52, 13);
            this.Category.TabIndex = 14;
            this.Category.Text = "Category:";
            // 
            // Quality
            // 
            this.Quality.AutoSize = true;
            this.Quality.Location = new System.Drawing.Point(343, 130);
            this.Quality.Name = "Quality";
            this.Quality.Size = new System.Drawing.Size(49, 13);
            this.Quality.TabIndex = 15;
            this.Quality.Text = "Quantity:";
            // 
            // Medicines
            // 
            this.Medicines.AutoSize = true;
            this.Medicines.Location = new System.Drawing.Point(249, 414);
            this.Medicines.Name = "Medicines";
            this.Medicines.Size = new System.Drawing.Size(143, 13);
            this.Medicines.TabIndex = 16;
            this.Medicines.Text = "List of all available medicines";
            // 
            // Form1
            // 
            this.AccessibleName = "dgvMedicines";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Medicines);
            this.Controls.Add(this.Quality);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Searc);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Nam);
            this.Controls.Add(this.dgvMedicines);
            this.Controls.Add(this.ViewAll);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.UpdateStock);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtName);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button UpdateStock;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button ViewAll;
        private System.Windows.Forms.DataGridView dgvMedicines;
        private System.Windows.Forms.Label Nam;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label Searc;
        private System.Windows.Forms.Label Category;
        private System.Windows.Forms.Label Quality;
        private System.Windows.Forms.Label Medicines;
    }
}

