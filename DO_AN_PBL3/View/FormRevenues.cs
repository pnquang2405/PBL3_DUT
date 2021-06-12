using DO_AN_PBL3.BLL;
using DO_AN_PBL3.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_PBL3.View
{
    public partial class FormRevenues : Form
    {
        private int pageNumber = 1;
        private List<HOA_DON> list;
        public FormRevenues()
        {
            InitializeComponent();
            LoadListBillByDateDefault();
            LoadListBillByDate(dtpkFrom.Value, dtpkTo.Value);
        }


        public void LoadListBillByDateDefault()
        {
            DateTime today = DateTime.Now;
            dtpkFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtpkTo.Value = dtpkFrom.Value.AddMonths(1).AddDays(-1);
        }

        public void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvRevenue.Rows.Clear();
            pageNumber = 1;
            List<HOA_DON> listHD = HOA_DON_BLL.Instance.GetListHOADONByDate(checkIn, checkOut);
            list = listHD;

            if (dtgvRevenue.Columns.Count == 0)
            {
                DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
                col1.HeaderText = "STT";
                dtgvRevenue.Columns.Add(col1);

                DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
                col2.HeaderText = "Tên Bàn";
                dtgvRevenue.Columns.Add(col2);

                DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
                col3.HeaderText = "Giờ Đến";
                dtgvRevenue.Columns.Add(col3);

                DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
                col4.HeaderText = "Giờ Đi";
                dtgvRevenue.Columns.Add(col4);

                DataGridViewColumn col5 = new DataGridViewTextBoxColumn();
                col5.HeaderText = "Giảm giá(%)";
                dtgvRevenue.Columns.Add(col5);

                DataGridViewColumn col6 = new DataGridViewTextBoxColumn();
                col6.HeaderText = "Tổng Tiền";
                dtgvRevenue.Columns.Add(col6);

                DataGridViewColumn col7 = new DataGridViewTextBoxColumn();
                col7.HeaderText = "Nhân Viên thanh toán";
                dtgvRevenue.Columns.Add(col7);

                DataGridViewColumn col8 = new DataGridViewTextBoxColumn();
                col8.HeaderText = "Điểm tích lũy";
                dtgvRevenue.Columns.Add(col8);

                DataGridViewColumn col9 = new DataGridViewTextBoxColumn();
                col9.HeaderText = "Khách Hàng";
                dtgvRevenue.Columns.Add(col9);
            }

            ShowDL();
        }

        public void ShowDL()
        {
            dtgvRevenue.Rows.Clear();
            if (list.Count > 0)
            {
                int firstProfile = 0;
                int lastProfile = list.Count;
                if (list.Count > 32) lastProfile = 32;

                if (pageNumber > 1)
                {
                    firstProfile = lastProfile + 1;
                    if (pageNumber == list.Count / 32 + 1)
                    {
                        lastProfile = list.Count;
                    }
                    else { lastProfile = firstProfile + 32; }
                }

                for (int i = firstProfile; i < lastProfile; i++)
                {
                    KHACHHANG kh = null;
                    if (list[i].ID_KH != null) { kh = Customer_BLL.Instance.GetKHByID((int)(list[i].ID_KH)); }
                    NHANVIEN nv = Account_BLL.Instance.GetNVByID((int)(list[i].ID_NV));
                    BAN ban = Table_BLL.Instance.gettable((int)(list[i].ID_BAN));

                    DataGridViewRow row1 = new DataGridViewRow();
                    row1.CreateCells(dtgvRevenue);

                    row1.Cells[0].Value = (i + 1) + "";
                    row1.Cells[1].Value = ban.Tenban;
                    row1.Cells[2].Value = list[i].Gio_den;
                    row1.Cells[3].Value = list[i].Gio_di;
                    row1.Cells[4].Value = list[i].discount;
                    row1.Cells[5].Value = list[i].Tong_tien;
                    row1.Cells[6].Value = nv.Ten_NV;
                    row1.Cells[7].Value = list[i].Diem_TL;

                    if (kh != null) row1.Cells[8].Value = kh.Ten_KH;

                    dtgvRevenue.Rows.Add(row1);
                }

                dtgvRevenue.Columns[0].Width = 40;
                dtgvRevenue.Columns[1].Width = 70;
                dtgvRevenue.Columns[5].Width = 100;
                dtgvRevenue.Columns[2].Width = 190;
                dtgvRevenue.Columns[3].Width = 190;
            }
            txtPage.Text = pageNumber.ToString();
            lb1.Text = "/" + (list.Count / 32 + 1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpkFrom_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateFrom = dtpkFrom.Value;
            DateTime dateTo = dtpkTo.Value;
            LoadListBillByDate(dateFrom, dateTo);
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if(pageNumber > 1)
            {
                --pageNumber;
                ShowDL();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageNumber <= list.Count / 32)
            {
                ++pageNumber;
                ShowDL();
            }
        }

        private void txtPage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(Convert.ToInt32(txtPage.Text) > 0 && Convert.ToInt32(txtPage.Text) <= list.Count / 32 + 1)
                {
                    pageNumber = Convert.ToInt32(txtPage.Text);
                    ShowDL();
                }
                else
                {
                    MessageBox.Show("Trang không hợp lệ!");
                    txtPage.Text = pageNumber.ToString();
                }
            }
        }

        private void txtPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || txtPage.Text.Length >= 3)
            {
                e.Handled = true;
            }
        }

        private void FormRevenues_Click(object sender, EventArgs e)
        {
            if (txtPage.Text == "") txtPage.Text = pageNumber.ToString();
        }
    }
}
