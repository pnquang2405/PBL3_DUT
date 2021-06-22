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
    public partial class FormProfileCustomer : Form
    {
        private KHACHHANG kh;
        public MyDel D { get => d; set => d = value; }

        public delegate void MyDel(List<KHACHHANG> list);
        private MyDel d;

        public FormProfileCustomer(KHACHHANG khachhang)
        {
            InitializeComponent();
            kh = khachhang;
            SetGui();
        }

        void SetGui()
        {
            txtName.Text = kh.Ten_KH;
            txtDiaChi.Text = kh.Diachi;
            txtPhone.Text = kh.PhoneNumber;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận lưu thông tin", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if(txtName.Text != kh.Ten_KH || txtDiaChi.Text != kh.Diachi || txtPhone.Text != kh.PhoneNumber)
                {
                    if(Customer_BLL.Instance.checkSDT(txtPhone.Text) == false || Customer_BLL.Instance.GetKHByInfo(txtPhone.Text).ID_KH == kh.ID_KH)
                    {
                        kh.Ten_KH = txtName.Text;
                        kh.Diachi = txtDiaChi.Text;
                        kh.PhoneNumber = txtPhone.Text;

                        Customer_BLL.Instance.UpdateKH(kh);
                    }
                    else
                    {
                        if (MessageBox.Show("Số điện thoại đã tồn tại, Xác nhận cộng dồn điểm tích lũy?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            int dtl = Convert.ToInt32(kh.Diemtichluy);
                            KHACHHANG khachhang = Customer_BLL.Instance.GetKHByInfo(txtPhone.Text);
                            int idBill = HOA_DON_BLL.Instance.getIDByKH(kh);

                            HOA_DON_BLL.Instance.UpdateKH(idBill, khachhang);
                            Customer_BLL.Instance.Delete(kh);
                            Customer_BLL.Instance.updateDTL(khachhang, dtl);
                        }
                    }

                    List<KHACHHANG> list = Customer_BLL.Instance.GetList();
                    D(list);
                }
                this.Close();
            }
        }
    }
}
