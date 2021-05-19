using DO_AN_PBL3.BLL;
using DO_AN_PBL3.Entity;
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
            List<HOA_DON> list = HOA_DON_BLL.Instance.GetListHOADONByDate(checkIn, checkOut);

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

            if(list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
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

                    if(kh != null) row1.Cells[8].Value = kh.Ten_KH;

                    dtgvRevenue.Rows.Add(row1);
                }

                dtgvRevenue.Columns[0].Width = 40;
                dtgvRevenue.Columns[1].Width = 70;
                dtgvRevenue.Columns[5].Width = 100;
                dtgvRevenue.Columns[2].Width = 190;
                dtgvRevenue.Columns[3].Width = 190;
            }
        }

    }
}
