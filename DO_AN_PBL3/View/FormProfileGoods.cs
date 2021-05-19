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
        private String hh;
        public delegate void MyDel(int idLHH);
        private MyDel d;

        public MyDel D { get => d; set => d = value; }

        public FormProfileGoods(String TenHH)
        {
            InitializeComponent();
            hh = TenHH;
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
            int index = 0;
            if (hh != "")
            {
                HANGHOA hanghoa = Merchandise_BLL.Instance.GetHHByName(hh);
                for (int i = 0; i < cbLHH.Items.Count; i++)
                {
                    if(((CBBItem)cbLHH.Items[i]).Value == hanghoa.ID_LHH)
                    {
                        index = i;
                        break;
                    }
                }
                txtNameGoods.Text = hh;
                txtPrice.Text = hanghoa.Gia.ToString();

                MemoryStream stream = new MemoryStream(hanghoa.picture.ToArray());
                Image image = Image.FromStream(stream);
                ptrGoods.Image = image;

            }

            cbLHH.SelectedIndex = index;


        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNameGoods.Text != "" && txtPrice.Text != "" && cbLHH.SelectedItem != null && ptrGoods.Image != null)
                {
                    MemoryStream stream = new MemoryStream();
                    ptrGoods.Image.Save(stream, ImageFormat.Jpeg);
                    HANGHOA merchandise = new HANGHOA
                    {
                        ID_LHH = ((CBBItem)cbLHH.SelectedItem).Value,
                        Ten_HH = txtNameGoods.Text,
                        picture = stream.ToArray(),
                        Gia = Convert.ToDecimal(txtPrice.Text),
                        tinhTrang = 1
                    };
                    if (hh == "")
                    {
                            if (Merchandise_BLL.Instance.GetHHByName(txtNameGoods.Text) == null)
                            {
                                Merchandise_BLL.Instance.Add(merchandise);
                            }
                            else
                            {
                                if (MessageBox.Show("Hàng hóa đã tồn tại. Xác nhận thay đổi!", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                                {
                                    Merchandise_BLL.Instance.update(merchandise, txtNameGoods.Text);
                                }
                            }
                    }
                    else
                    {
                        Merchandise_BLL.Instance.update(merchandise, hh);
                    }

                    MessageBox.Show("Thao tác thành công");
                    D(-1);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
            }
            catch
            {
                MessageBox.Show("Thao tác thất bại");
            }
        }


    }
}
