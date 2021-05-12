
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddStaff = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.Gender = new System.Windows.Forms.GroupBox();
            this.rbFeMale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.btnEditStaff = new System.Windows.Forms.Button();
            this.btnDelStaff = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.Gender.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Họ tên";
            // 
            // btnAddStaff
            // 
            this.btnAddStaff.Location = new System.Drawing.Point(18, 325);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(93, 26);
            this.btnAddStaff.TabIndex = 2;
            this.btnAddStaff.Text = "Thêm";
            this.btnAddStaff.UseVisualStyleBackColor = true;
            this.btnAddStaff.Click += new System.EventHandler(this.BtnAddStaff_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Phone Number";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(122, 30);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(126, 20);
            this.txtTenNV.TabIndex = 4;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(122, 79);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(126, 20);
            this.txtPhoneNumber.TabIndex = 5;
            // 
            // Gender
            // 
            this.Gender.Controls.Add(this.rbFeMale);
            this.Gender.Controls.Add(this.rbMale);
            this.Gender.Location = new System.Drawing.Point(340, 15);
            this.Gender.Name = "Gender";
            this.Gender.Size = new System.Drawing.Size(147, 84);
            this.Gender.TabIndex = 6;
            this.Gender.TabStop = false;
            this.Gender.Text = "Gender";
            // 
            // rbFeMale
            // 
            this.rbFeMale.AutoSize = true;
            this.rbFeMale.Location = new System.Drawing.Point(8, 53);
            this.rbFeMale.Name = "rbFeMale";
            this.rbFeMale.Size = new System.Drawing.Size(60, 17);
            this.rbFeMale.TabIndex = 1;
            this.rbFeMale.TabStop = true;
            this.rbFeMale.Text = "FeMale";
            this.rbFeMale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(8, 19);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(48, 17);
            this.rbMale.TabIndex = 0;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // btnEditStaff
            // 
            this.btnEditStaff.Location = new System.Drawing.Point(195, 325);
            this.btnEditStaff.Name = "btnEditStaff";
            this.btnEditStaff.Size = new System.Drawing.Size(93, 26);
            this.btnEditStaff.TabIndex = 8;
            this.btnEditStaff.Text = "Sửa ";
            this.btnEditStaff.UseVisualStyleBackColor = true;
            this.btnEditStaff.Click += new System.EventHandler(this.btnEditStaff_Click);
            // 
            // btnDelStaff
            // 
            this.btnDelStaff.Location = new System.Drawing.Point(371, 325);
            this.btnDelStaff.Name = "btnDelStaff";
            this.btnDelStaff.Size = new System.Drawing.Size(93, 26);
            this.btnDelStaff.TabIndex = 9;
            this.btnDelStaff.Text = "Xóa";
            this.btnDelStaff.UseVisualStyleBackColor = true;
            this.btnDelStaff.Click += new System.EventHandler(this.btnDelStaff_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvStaff);
            this.panel1.Controls.Add(this.txtTenNV);
            this.panel1.Controls.Add(this.btnDelStaff);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnEditStaff);
            this.panel1.Controls.Add(this.txtPhoneNumber);
            this.panel1.Controls.Add(this.btnAddStaff);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Gender);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 377);
            this.panel1.TabIndex = 10;
            // 
            // dgvStaff
            // 
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Location = new System.Drawing.Point(18, 151);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.Size = new System.Drawing.Size(496, 150);
            this.dgvStaff.TabIndex = 10;
            this.dgvStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellClick);
            // 
            // FormStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 394);
            this.Controls.Add(this.panel1);
            this.Name = "FormStaff";
            this.Text = "FormStaff";
            this.Gender.ResumeLayout(false);
            this.Gender.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddStaff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.GroupBox Gender;
        private System.Windows.Forms.RadioButton rbFeMale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.Button btnEditStaff;
        private System.Windows.Forms.Button btnDelStaff;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvStaff;
    }
}