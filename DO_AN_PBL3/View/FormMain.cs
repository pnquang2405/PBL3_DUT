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
        private int user;
      
        public FormMain(int username)
        {
            InitializeComponent(); 
            user = username;
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
            NHANVIEN nv = BLL.Staff_BLL.Instance.Staff_ID_BLL(user);
            lbChangeAccount.Text = subString(nv.Ten_NV);

        }
        public static String subString(String text)
        {
            int i = text.LastIndexOf(" ");
            if (i == -1)
            {
                return text.Substring(0);
            }
            else return text.Substring(i);
        }
        void changeInfo(String info)
        {
            lbChangeAccount.Text = info;
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

                HANGHOA hh = new HANGHOA
                {
                    Ten_HH = item.MatHang,
                    Gia = Convert.ToDecimal(item.DonGia),
                };
                lsvItem.Tag = hh;

                lsvTemp.Items.Add(lsvItem);
            }
            
            txtTienhang.Text = thanhTien.ToString("c", culture);
            txtThanhTien.Text = (thanhTien - thanhTien * (int)nmrDiscount.Value).ToString();
        }


        #endregion

        #region Event

        private void button1_Click(object sender, EventArgs e)
        {
            FormTable f = new FormTable(user);
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
            NHANVIEN nv = Staff_BLL.Instance.Staff_ID_BLL(user);
            if(nv.Phanquyen == true)
            {
                if (panelAdmin.Visible == true)
                {
                    panelAdmin.Hide();
                }
                else
                {
                    panelAdmin.Show();
                }
            }
            else
            {
                MessageBox.Show("Không phải admin");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Loai_HANGHOA lhh = (Loai_HANGHOA)listBox1.SelectedItem;
            if(lhh == null)
            {
                return;
            }
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
                    HOA_DON_BLL.Instance.InsertHOADON(ban.ID_BAN, null, user);
                    Table_BLL.Instance.update(ban.ID_BAN, false);

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
                        ShowBill(ban);
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
                ShowBill(ban);
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
                int idBill = HOA_DON_BLL.Instance.GetIdByTable(ban.ID_BAN);
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
                            CHI_TIET_HOA_DON_BLL.Instance.delete(idBill, item.SubItems[0].Text, Convert.ToInt32(item.SubItems[1].Text));
                            if (lsvTemp.Items.Count == 0)
                            {
                                Table_BLL.Instance.update(ban.ID_BAN, true);
                                HOA_DON_BLL.Instance.delete(idBill);
                            }
                            button1_Click(new object(), new EventArgs());

                            break;
                        }
                        item.SubItems[1].Text = soLuong.ToString();
                        item.SubItems[3].Text = (hangHoa1.Gia * soLuong).ToString();
                        hangHoa1 = null;
                        nmrsoLuong.Value = 1;

                        CHI_TIET_HOA_DON_BLL.Instance.update(idBill, item.SubItems[0].Text, soLuong);
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
                        int idBill = HOA_DON_BLL.Instance.GetIdByTable(ban.ID_BAN);
                        lsvTemp.Items.Remove(item);
                        CHI_TIET_HOA_DON_BLL.Instance.delete(idBill, item.SubItems[0].Text, Convert.ToInt32(item.SubItems[1].Text));

                        if(lsvTemp.Items.Count == 0) 
                        { 
                            Table_BLL.Instance.update(ban.ID_BAN, true);
                            HOA_DON_BLL.Instance.delete(idBill);
                        }

                        button1_Click(new object(), new EventArgs());

                        return;
                    }
                }
            }
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            Loai_HANGHOA lhh = (Loai_HANGHOA)listBox1.SelectedItem;
            List<HANGHOA> list = null;
            if (listBox1.SelectedIndex < 1)
            {
                list = Merchandise_BLL.Instance.GetList(-1);
            }
            else
            {
                int a = lhh.ID_LHH;
                list = Merchandise_BLL.Instance.GetList(lhh.ID_LHH);
            }
            var search = (from x in list where x.Ten_HH.ToLower().Contains(txbSearch.Text) select x).ToList();
            lsvHH.Items.Clear();
            foreach (HANGHOA x in search)
            {
                ListViewItem lsvItem = new ListViewItem(x.Ten_HH);
                lsvItem.SubItems.Add(x.Gia.ToString());
                lsvItem.Tag = x;
                if (lsvHH.Items.Contains(lsvItem) == false)
                {
                    lsvHH.Items.Add(lsvItem);
                }
            }
        }
        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            Form_QLGoods f = new Form_QLGoods();
            f.ShowDialog();
        }


        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {

            if (ban != null && BLL.HOA_DON_BLL.Instance.checkHoaDon(ban.ID_BAN))
            {
               

                if(txtPhoneCustomer.Text != "")
                {
                    int dtl = Convert.ToInt32(txtThanhTien.Text) / 10000;
                    KHACHHANG kh = Customer_BLL.Instance.GetKHByInfo(txtPhoneCustomer.Text);
                    if(kh != null)
                    {
                        Customer_BLL.Instance.updateDTL(kh, dtl);
                    }
                    else
                    {
                        Customer_BLL.Instance.AddCustomer_BLL(txtPhoneCustomer.Text, dtl);
                    }
                }

            
                BILL bill = new BILL(BLL.HOA_DON_BLL.Instance.GetIdByTable(ban.ID_BAN), 1, txtPhoneCustomer.Text);
                txtPhoneCustomer.Text = "";
                button1_Click(new object(), new EventArgs());

                bill.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chua chon ban can thanh toan hoac ban khong co du lieu!!!");
            }
        }

        private void btnTamThanhToan_Click_1(object sender, EventArgs e)
        {
            if (ban != null && BLL.HOA_DON_BLL.Instance.checkHoaDon(ban.ID_BAN))
            {
                BILL bill = new BILL(BLL.HOA_DON_BLL.Instance.GetIdByTable(ban.ID_BAN), 0, txtPhoneCustomer.Text);

                bill.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chua chon ban can thanh toan hoac ban khong co du lieu!!!");
            }
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            FormRevenues f = new FormRevenues();
            f.Show();
        }

        private void btnTachBan_Click(object sender, EventArgs e)
        {
            if (ban != null && BLL.HOA_DON_BLL.Instance.checkHoaDon(ban.ID_BAN))
            {
                DetailTable f2 = new DetailTable(HOA_DON_BLL.Instance.GetIdByTable(ban.ID_BAN), user);

                f2.ShowDialog();
                button1_Click(new object(), new EventArgs());
            }
            else
            {
                MessageBox.Show("Vui long chon ban hoac ban chua duoc order!!!");
            }
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (ban != null && BLL.HOA_DON_BLL.Instance.checkHoaDon(ban.ID_BAN))
            {
                TableTach f2 = new TableTach(ban.ID_BAN, null, user);
                f2.ShowDialog();
                button1_Click(new object(), new EventArgs());
            }
            else
            {
                MessageBox.Show("Vui  long chon ban!!!");
            }
        }

        private void btnInCheBien_Click(object sender, EventArgs e)
        {
            if (ban != null && BLL.HOA_DON_BLL.Instance.checkHoaDon(ban.ID_BAN))
            {
                FormInchebien f2 = new FormInchebien(HOA_DON_BLL.Instance.GetIdByTable(ban.ID_BAN),user);
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chua chon ban can thanh toan hoac ban khong co du lieu!!!");
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            FormStaff f = new FormStaff(user);
            f.D = changeInfo;
            f.ShowDialog();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FormCustomer f = new FormCustomer();
            f.Show();
        }

        private void txtPhoneCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || txtPhoneCustomer.Text.Length >= 11)
            {
                e.Handled = true;
            }
        }

        private void lbChangeAccount_Click(object sender, EventArgs e)
        {
            FormChangeAccount f = new FormChangeAccount(user);
            f.D = changeInfo;
            f.ShowDialog();
        }

        #endregion

        private void showPanel(object sender, EventArgs e)
        {
            //panelAdmin.Hide();
        }
        private void hidePanel(object sender, EventArgs e)
        {
            //panelAdmin.Hide();
        }
    }
}
