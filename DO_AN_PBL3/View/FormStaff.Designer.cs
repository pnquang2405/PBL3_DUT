﻿
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnResetPass = new System.Windows.Forms.Button();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.cbbview = new System.Windows.Forms.ComboBox();
            this.Gender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(126, 40);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(126, 20);
            this.txtTenNV.TabIndex = 14;
            // 
            // btnDelStaff
            // 
            this.btnDelStaff.Location = new System.Drawing.Point(216, 334);
            this.btnDelStaff.Name = "btnDelStaff";
            this.btnDelStaff.Size = new System.Drawing.Size(68, 26);
            this.btnDelStaff.TabIndex = 18;
            this.btnDelStaff.Text = "Del";
            this.btnDelStaff.UseVisualStyleBackColor = true;
            this.btnDelStaff.Click += new System.EventHandler(this.btnDelStaff_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Full Name";
            // 
            // btnEditStaff
            // 
            this.btnEditStaff.Location = new System.Drawing.Point(117, 335);
            this.btnEditStaff.Name = "btnEditStaff";
            this.btnEditStaff.Size = new System.Drawing.Size(74, 26);
            this.btnEditStaff.TabIndex = 17;
            this.btnEditStaff.Text = "Edit";
            this.btnEditStaff.UseVisualStyleBackColor = true;
            this.btnEditStaff.Click += new System.EventHandler(this.btnEditStaff_Click);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(126, 89);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(126, 20);
            this.txtPhoneNumber.TabIndex = 15;
            // 
            // btnAddStaff
            // 
            this.btnAddStaff.Location = new System.Drawing.Point(22, 335);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(78, 26);
            this.btnAddStaff.TabIndex = 12;
            this.btnAddStaff.Text = "Add";
            this.btnAddStaff.UseVisualStyleBackColor = true;
            this.btnAddStaff.Click += new System.EventHandler(this.BtnAddStaff_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Phone Number";
            // 
            // Gender
            // 
            this.Gender.Controls.Add(this.rbFeMale);
            this.Gender.Controls.Add(this.rbMale);
            this.Gender.Location = new System.Drawing.Point(368, 31);
            this.Gender.Name = "Gender";
            this.Gender.Size = new System.Drawing.Size(116, 75);
            this.Gender.TabIndex = 16;
            this.Gender.TabStop = false;
            this.Gender.Text = "Gender";
            // 
            // rbFeMale
            // 
            this.rbFeMale.AutoSize = true;
            this.rbFeMale.Location = new System.Drawing.Point(8, 52);
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
            // btnResetPass
            // 
            this.btnResetPass.Location = new System.Drawing.Point(308, 335);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(69, 26);
            this.btnResetPass.TabIndex = 20;
            this.btnResetPass.Text = "ResetPass";
            this.btnResetPass.UseVisualStyleBackColor = true;
            this.btnResetPass.Click += new System.EventHandler(this.btnResetPass_Click);
            // 
            // dgvStaff
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dgvStaff.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStaff.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStaff.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStaff.EnableHeadersVisualStyles = false;
            this.dgvStaff.Location = new System.Drawing.Point(24, 142);
            this.dgvStaff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaff.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStaff.RowHeadersVisible = false;
            this.dgvStaff.RowHeadersWidth = 4;
            this.dgvStaff.RowTemplate.Height = 24;
            this.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.Size = new System.Drawing.Size(496, 170);
            this.dgvStaff.TabIndex = 21;
            this.dgvStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellClick);
            // 
            // cbbview
            // 
            this.cbbview.FormattingEnabled = true;
            this.cbbview.Location = new System.Drawing.Point(399, 339);
            this.cbbview.Name = "cbbview";
            this.cbbview.Size = new System.Drawing.Size(121, 21);
            this.cbbview.TabIndex = 22;
            this.cbbview.SelectedIndexChanged += new System.EventHandler(this.ModeView);
            // 
            // FormStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(540, 386);
            this.Controls.Add(this.cbbview);
            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.btnResetPass);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.btnDelStaff);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditStaff);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.btnAddStaff);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Gender);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStaff";
            this.Gender.ResumeLayout(false);
            this.Gender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Button btnResetPass;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.ComboBox cbbview;
    }
}