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
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
            LoadDL(Customer_BLL.Instance.GetList());
        }

        public void LoadDL(List<KHACHHANG> list)
        {
            dtgvCustomer.Rows.Clear();

            if(dtgvCustomer.Rows.Count == 0)
            {
                DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
                col1.HeaderText = "STT";
                dtgvCustomer.Columns.Add(col1);

                DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
                col2.HeaderText = "Tên Khách Hàng";
                dtgvCustomer.Columns.Add(col2);

                DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
                col3.HeaderText = "Địa chỉ";
                dtgvCustomer.Columns.Add(col3);

                DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
                col4.HeaderText = "SĐT";
                dtgvCustomer.Columns.Add(col4);

                DataGridViewColumn col5 = new DataGridViewTextBoxColumn();
                col5.HeaderText = "Loại";
                dtgvCustomer.Columns.Add(col5);

                DataGridViewColumn col6 = new DataGridViewTextBoxColumn();
                col6.HeaderText = "Điểm tích lũy";
                dtgvCustomer.Columns.Add(col6);

            }

            if (list.Count > 0)
            {
                //DataGridViewRow row = new DataGridViewRow();
                //row.CreateCells(dtgvCustomer);
                //row.Cells[0].Value = 1 + "";
                //row.Cells[1].Value = list[0].Ten_HH;
                //row.Cells[2].Value = list[0].Gia;
                //row.Cells[3].Value = list[0].Loai_HANGHOA.Ten_LHH;

                //dtgvGoods.Rows.Add(row);

                for (int i = 0; i < list.Count; i++)
                {
                    DataGridViewRow row1 = new DataGridViewRow();
                    row1.CreateCells(dtgvCustomer);

                    row1.Cells[0].Value = (i + 1) + "";
                    row1.Cells[1].Value = list[i].Ten_KH;
                    row1.Cells[2].Value = list[i].Diachi;
                    row1.Cells[3].Value = list[i].PhoneNumber;
                    row1.Cells[4].Value = list[i].LOAI_KHACH_HANG.Ten_LKH;
                    row1.Cells[5].Value = list[i].Diemtichluy;

                    dtgvCustomer.Rows.Add(row1);
                }
            }

            dtgvCustomer.Columns[0].Width = 70;
            dtgvCustomer.Columns[1].Width = 170;
            lbTotal.Text = "Tổng hồ sơ: " + (dtgvCustomer.Rows.Count - 1).ToString();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || txtPhone.Text.Length >= 11)
            {
                e.Handled = true;
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            List<KHACHHANG> list = Customer_BLL.Instance.GetList();

            var search = (from x in list where x.PhoneNumber.Contains(txtPhone.Text) select x).ToList();

            LoadDL(search);
        }
    }
}
