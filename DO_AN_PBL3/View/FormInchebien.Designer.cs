
namespace DO_AN_PBL3.View
{
    partial class FormInchebien
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
            this.lsvItemp = new System.Windows.Forms.ListView();
            this.ten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbName = new System.Windows.Forms.Label();
            this.NV = new System.Windows.Forms.Label();
            this.lbban = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lsvItemp
            // 
            this.lsvItemp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ten,
            this.SL});
            this.lsvItemp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lsvItemp.HideSelection = false;
            this.lsvItemp.Location = new System.Drawing.Point(22, 85);
            this.lsvItemp.Name = "lsvItemp";
            this.lsvItemp.Size = new System.Drawing.Size(293, 277);
            this.lsvItemp.TabIndex = 10;
            this.lsvItemp.UseCompatibleStateImageBehavior = false;
            this.lsvItemp.View = System.Windows.Forms.View.Details;
            // 
            // ten
            // 
            this.ten.Text = "Name";
            this.ten.Width = 150;
            // 
            // SL
            // 
            this.SL.Text = "SL";
            this.SL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SL.Width = 100;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.ForeColor = System.Drawing.Color.Blue;
            this.lbName.Location = new System.Drawing.Point(85, 56);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(46, 17);
            this.lbName.TabIndex = 9;
            this.lbName.Text = "label2";
            // 
            // NV
            // 
            this.NV.AutoSize = true;
            this.NV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NV.Location = new System.Drawing.Point(33, 55);
            this.NV.Name = "NV";
            this.NV.Size = new System.Drawing.Size(35, 18);
            this.NV.TabIndex = 8;
            this.NV.Text = "NV:";
            // 
            // lbban
            // 
            this.lbban.AutoSize = true;
            this.lbban.ForeColor = System.Drawing.Color.Blue;
            this.lbban.Location = new System.Drawing.Point(117, 27);
            this.lbban.Name = "lbban";
            this.lbban.Size = new System.Drawing.Size(46, 17);
            this.lbban.TabIndex = 7;
            this.lbban.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "BÁO CHẾ BIẾN";
            // 
            // FormInchebien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 384);
            this.Controls.Add(this.lsvItemp);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.NV);
            this.Controls.Add(this.lbban);
            this.Controls.Add(this.label1);
            this.Name = "FormInchebien";
            this.Text = "FormInchebien";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvItemp;
        private System.Windows.Forms.ColumnHeader ten;
        private System.Windows.Forms.ColumnHeader SL;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label NV;
        private System.Windows.Forms.Label lbban;
        private System.Windows.Forms.Label label1;
    }
}