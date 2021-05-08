using DO_AN_PBL3.BLL;
using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_PBL3.View
{
    public partial class FormProfileGoods : Form
    {
        public FormProfileGoods()
        {
            InitializeComponent();
            LoadCBB();
        }

        private void btnPic_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            String file = openFileDialog1.FileName;
            if (string.IsNullOrEmpty(file)) return;

            Image myImage = Image.FromFile(file);
            ptrGoods.Image = myImage;
        }

        public void LoadCBB()
        {
            cbLHH.Items.AddRange(Category_Merchandise_BLL.Instance.GetCBB().ToArray());
            cbLHH.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                MemoryStream stream = new MemoryStream();
                ptrGoods.Image.Save(stream, ImageFormat.Jpeg);
                HANGHOA merchandise = new HANGHOA
                {
                    ID_LHH = ((CBBItem)cbLHH.SelectedItem).Value,
                    Ten_HH = txtNameGoods.Text,
                    picture = stream.ToArray(),
                    Gia = Convert.ToDecimal(txtPrice.Text)
                };

                Merchandise_BLL.Instance.Add(merchandise);
                MessageBox.Show("Thao tác thành công");
            }
            catch
            {
                MessageBox.Show("Thao tác thất bại");
            }
        }
    }
}
