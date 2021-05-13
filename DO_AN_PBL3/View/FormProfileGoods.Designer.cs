
namespace DO_AN_PBL3.View
{
    partial class FormProfileGoods
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
            this.cbLHH = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameGoods = new System.Windows.Forms.TextBox();
            this.btnPic = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ptrGoods = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptrGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLHH
            // 
            this.cbLHH.FormattingEnabled = true;
            this.cbLHH.Location = new System.Drawing.Point(134, 27);
            this.cbLHH.Name = "cbLHH";
            this.cbLHH.Size = new System.Drawing.Size(136, 24);
            this.cbLHH.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loại Hàng hóa: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Hàng hóa: ";
            // 
            // txtNameGoods
            // 
            this.txtNameGoods.Location = new System.Drawing.Point(134, 66);
            this.txtNameGoods.Name = "txtNameGoods";
            this.txtNameGoods.Size = new System.Drawing.Size(136, 22);
            this.txtNameGoods.TabIndex = 3;
            // 
            // btnPic
            // 
            this.btnPic.Location = new System.Drawing.Point(402, 193);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(109, 23);
            this.btnPic.TabIndex = 6;
            this.btnPic.Text = "Chọn hình ảnh";
            this.btnPic.UseVisualStyleBackColor = true;
            this.btnPic.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Giá: ";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(134, 101);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(136, 22);
            this.txtPrice.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(272, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 45);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ptrGoods
            // 
            this.ptrGoods.Location = new System.Drawing.Point(381, 27);
            this.ptrGoods.Name = "ptrGoods";
            this.ptrGoods.Size = new System.Drawing.Size(146, 160);
            this.ptrGoods.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptrGoods.TabIndex = 4;
            this.ptrGoods.TabStop = false;
            // 
            // FormProfileGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 362);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPic);
            this.Controls.Add(this.ptrGoods);
            this.Controls.Add(this.txtNameGoods);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLHH);
            this.Name = "FormProfileGoods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormProfileGoods";
            ((System.ComponentModel.ISupportInitialize)(this.ptrGoods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLHH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameGoods;
        private System.Windows.Forms.PictureBox ptrGoods;
        private System.Windows.Forms.Button btnPic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}