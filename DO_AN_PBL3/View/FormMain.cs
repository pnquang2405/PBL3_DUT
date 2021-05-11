using DO_AN_PBL3.BLL;
using DO_AN_PBL3.Entity;
using DO_AN_PBL3.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_PBL3
{
    public partial class FormMain : Form
    {
        private HANGHOA hangHoa;
        private HANGHOA hangHoa1;
        private BAN ban;
        public FormMain()
        {
            InitializeComponent();
            button1_Click(new object(), new EventArgs());
            SetGUI();
        }

        #region Method

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelChildForm.Controls.Add(childForm);
            PanelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        void SetGUI()
        {
            List<Loai_HANGHOA> list = Category_Merchandise_BLL.Instance.GetLHH_BLL();
            Loai_HANGHOA hh = new Loai_HANGHOA
            {
                ID_LHH = -1,
                Ten_LHH = "Tất cả"
            };
            listBox1.Items.Add(hh);
            foreach (Loai_HANGHOA item in list)
            {
                listBox1.Items.Add(item);
            }
            listBox1.DisplayMember = "Ten_LHH";
        }

        void ShowBill(BAN table)
        {
            this.ban = table;
            lsvTemp.Items.Clear();
            CultureInfo culture = new CultureInfo("vi-VN");
            List<BillInfo> listBillInfo = BillInfo_BLL.Instance.GetList(ban);
            double thanhTien = 0;
            foreach (BillInfo item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.MatHang);
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.DonGia.ToString("c", culture));
                lsvItem.SubItems.Add(item.TongTien.ToString("c", culture));
                thanhTien += item.TongTien;

                lsvTemp.Items.Add(lsvItem);
            }
            
            txtTienhang.Text = thanhTien.ToString("c", culture);
            txtThanhTien.Text = (thanhTien - thanhTien * (int)nmrDiscount.Value).ToString();
        }

        #endregion

        #region Event

        private void button1_Click(object sender, EventArgs e)
        {
            FormTable f = new FormTable();
            f.getTable = ShowBill;
            OpenChildForm(f);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMenu());                                                                                                                      
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Bàn", btnTable);
        }


        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if(panelAdmin.Visible == true)
            {
                panelAdmin.Hide();
            }
            else
            {
                panelAdmin.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Loai_HANGHOA lhh = (Loai_HANGHOA)listBox1.SelectedItem;
            List<HANGHOA> list = Merchandise_BLL.Instance.GetList(lhh.ID_LHH);
            lsvHH.Items.Clear();

            foreach (HANGHOA item in list)
            {
                ListViewItem lsvItem = new ListViewItem(item.Ten_HH);

                lsvItem.SubItems.Add(item.Gia.ToString());
                lsvItem.Tag = item;

                lsvHH.Items.Add(lsvItem);
            }
        }

        private void lsvHH_MouseClick(object sender, MouseEventArgs e)
        {
            hangHoa = (HANGHOA)lsvHH.SelectedItems[0].Tag;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(hangHoa != null && ban != null)
            {
                if (HOA_DON_BLL.Instance.checkHoaDon(ban.ID_BAN) == false) 
                {
                    HOA_DON_BLL.Instance.InsertHOADON(ban.ID_BAN, null, 0);
                    button1_Click(new object(), new EventArgs());
                }

                int idBill = HOA_DON_BLL.Instance.GetIdByTable(ban.ID_BAN);
                foreach (ListViewItem item in lsvTemp.Items)
                {
                    if (item.SubItems[0].Text.Equals(hangHoa.Ten_HH))
                    {
                        int soLuong = Convert.ToInt32(item.SubItems[1].Text) + (int)nmrsoLuong.Value;
                        item.SubItems[1].Text = soLuong.ToString();
                        item.SubItems[3].Text = (hangHoa.Gia * soLuong).ToString();
                        hangHoa = null;
                        nmrsoLuong.Value = 1;

                        CHI_TIET_HOA_DON_BLL.Instance.update(idBill, item.SubItems[0].Text, soLuong);
                        
                        return;
                    }
                }

                ListViewItem lsvItem = new ListViewItem(hangHoa.Ten_HH);

                lsvItem.SubItems.Add(nmrsoLuong.Value.ToString());
                lsvItem.SubItems.Add(hangHoa.Gia.ToString());
                lsvItem.SubItems.Add((Convert.ToDouble(hangHoa.Gia.Value.ToString()) * (int)nmrsoLuong.Value).ToString());
                lsvItem.Tag = hangHoa;
                CHI_TIET_HOA_DON_BLL.Instance.insert(idBill, hangHoa.Ten_HH, (int)nmrsoLuong.Value);

                lsvTemp.Items.Add(lsvItem);
                hangHoa = null;
                nmrsoLuong.Value = 1;
                FormTable f = new FormTable();
                f.Show();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn món, chọn bàn");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panelSotien.Show();
        }

        private void ghiChúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSotien.Hide();
        }

        private void lsvTemp_MouseClick(object sender, MouseEventArgs e)
        {
            hangHoa1 = (HANGHOA)lsvTemp.SelectedItems[0].Tag;
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {
            if(hangHoa1 != null)
            {
                foreach (ListViewItem item in lsvTemp.Items)
                {
                    if (item.SubItems[0].Text.Equals(hangHoa1.Ten_HH))
                    {
                        int soLuong = Convert.ToInt32(item.SubItems[1].Text) - (int)nmrsoLuong.Value;
                        if(soLuong <= 0)
                        {
                            lsvTemp.Items.Remove(item);
                            hangHoa1 = null;
                            nmrsoLuong.Value = 1;

                            break;
                        }
                        item.SubItems[1].Text = soLuong.ToString();
                        item.SubItems[3].Text = (hangHoa1.Gia * soLuong).ToString();
                        hangHoa1 = null;
                        nmrsoLuong.Value = 1;
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(hangHoa1 != null)
            {
                foreach (ListViewItem item in lsvTemp.Items)
                {
                    if (item.SubItems[0].Text.Equals(hangHoa1.Ten_HH))
                    {
                        lsvTemp.Items.Remove(item);
                        return;
                    }
                }
            }
            
        }

        #endregion
    }
}
