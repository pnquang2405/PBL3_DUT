namespace DO_AN_PBL3.View
{
    partial class FormStaff
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
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.btnDelStaff = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditStaff = new System.Windows.Forms.Button();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.btnAddStaff = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Gender = new System.Windows.Forms.GroupBox();
            this.rbFeMale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.Gender.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStaff
            // 
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Location = new System.Drawing.Point(29, 198);
            this.dgvStaff.Margin = new System.Windows.Forms.Padding(4);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.RowHeadersWidth = 51;
            this.dgvStaff.Size = new System.Drawing.Size(661, 185);
            this.dgvStaff.TabIndex = 19;
            this.dgvStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellClick);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(168, 49);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(167, 22);
            this.txtTenNV.TabIndex = 14;
            // 
            // btnDelStaff
            // 
            this.btnDelStaff.Location = new System.Drawing.Point(500, 412);
            this.btnDelStaff.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelStaff.Name = "btnDelStaff";
            this.btnDelStaff.Size = new System.Drawing.Size(124, 32);
            this.btnDelStaff.TabIndex = 18;
            this.btnDelStaff.Text = "Xóa";
            this.btnDelStaff.UseVisualStyleBackColor = true;
            this.btnDelStaff.Click += new System.EventHandler(this.btnDelStaff_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Họ tên";
            // 
            // btnEditStaff
            // 
            this.btnEditStaff.Location = new System.Drawing.Point(265, 412);
            this.btnEditStaff.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditStaff.Name = "btnEditStaff";
            this.btnEditStaff.Size = new System.Drawing.Size(124, 32);
            this.btnEditStaff.TabIndex = 17;
            this.btnEditStaff.Text = "Sửa ";
            this.btnEditStaff.UseVisualStyleBackColor = true;
            this.btnEditStaff.Click += new System.EventHandler(this.btnEditStaff_Click);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(168, 110);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(167, 22);
            this.txtPhoneNumber.TabIndex = 15;
            // 
            // btnAddStaff
            // 
            this.btnAddStaff.Location = new System.Drawing.Point(29, 412);
            this.btnAddStaff.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(124, 32);
            this.btnAddStaff.TabIndex = 12;
            this.btnAddStaff.Text = "Thêm";
            this.btnAddStaff.UseVisualStyleBackColor = true;
            this.btnAddStaff.Click += new System.EventHandler(this.BtnAddStaff_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Phone Number";
            // 
            // Gender
            // 
            this.Gender.Controls.Add(this.rbFeMale);
            this.Gender.Controls.Add(this.rbMale);
            this.Gender.Location = new System.Drawing.Point(459, 31);
            this.Gender.Margin = new System.Windows.Forms.Padding(4);
            this.Gender.Name = "Gender";
            this.Gender.Padding = new System.Windows.Forms.Padding(4);
            this.Gender.Size = new System.Drawing.Size(196, 103);
            this.Gender.TabIndex = 16;
            this.Gender.TabStop = false;
            this.Gender.Text = "Gender";
            // 
            // rbFeMale
            // 
            this.rbFeMale.AutoSize = true;
            this.rbFeMale.Location = new System.Drawing.Point(11, 65);
            this.rbFeMale.Margin = new System.Windows.Forms.Padding(4);
            this.rbFeMale.Name = "rbFeMale";
            this.rbFeMale.Size = new System.Drawing.Size(75, 21);
            this.rbFeMale.TabIndex = 1;
            this.rbFeMale.TabStop = true;
            this.rbFeMale.Text = "FeMale";
            this.rbFeMale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(11, 23);
            this.rbMale.Margin = new System.Windows.Forms.Padding(4);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(59, 21);
            this.rbMale.TabIndex = 0;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // FormStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 475);
            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.btnDelStaff);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditStaff);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.btnAddStaff);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Gender);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormStaff";
            this.Text = "FormStaff";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.Gender.ResumeLayout(false);
            this.Gender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Button btnDelStaff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditStaff;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Button btnAddStaff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox Gender;
        private System.Windows.Forms.RadioButton rbFeMale;
        private System.Windows.Forms.RadioButton rbMale;
    }
}