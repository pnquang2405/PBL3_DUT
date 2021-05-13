using DO_AN_PBL3.BLL;
using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_PBL3.View
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            LoadMenu();
        }

        void LoadMenu()
        {
            flpMenu.Controls.Clear();
            List<HANGHOA> list = Merchandise_BLL.Instance.GetList();

            foreach (HANGHOA item in list)
            {
                PictureBox pic = new PictureBox { Width = 100, Height = 100 };
                MemoryStream stream = new MemoryStream(item.picture.ToArray());
                Image image = Image.FromStream(stream);
                pic.Image = image;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                Bitmap bitmap = new Bitmap(pic.Image);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawString(item.Gia.ToString(), new Font("Tahoma", 60), Brushes.White, bitmap.Width - 350, 0);
                g.DrawString(item.Ten_HH, new Font("Tahoma", 60), Brushes.White, bitmap.Width - 430, bitmap.Height - 90);
                pic.Image = (Image)bitmap;

                flpMenu.Controls.Add(pic);
            }
        }

        private void btnAddGoods_Click(object sender, EventArgs e)
        {
            FormProfileGoods f = new FormProfileGoods("");
            f.Show();
        }
    }
}
