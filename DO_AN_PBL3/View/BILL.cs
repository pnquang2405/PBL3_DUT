using DO_AN_PBL3.BLL;
using DO_AN_PBL3.Entity;
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

namespace DO_AN_PBL3.View
{
    public partial class BILL : Form
    {
        private int ID_BAN { get; set; }
        private int type { get; set; }
        private String info { get; set; }
        public BILL(int IDHOADON, int type,String infoKH)
        {
            this.type = type;
            ID_BAN = IDHOADON;
            info = infoKH;
            InitializeComponent();
            SETGUI();
        }
   
       
        private void SETGUI()
        {
            if (type == 0)
                lbBill.Text = "Tạm Thanh Toán";
            else lbBill.Text = "Thanh Toán";

            HOA_DON hd = HOA_DON_BLL.Instance.getHOADONbyID(ID_BAN);

            txbID.Text = ID_BAN.ToString();
            txbBan.Text = Table_BLL.Instance.GetnameTable(hd.ID_BAN.Value);
            txbNV.Text = Staff_BLL.Instance.getname((int)hd.ID_NV);
            txbthoigian.Text = DateTime.Now.ToString();
            txbKH.Text = info;

            CultureInfo culture = new CultureInfo("vi-VN");
            List<BillInfo> listbillinfo = BillInfo_BLL.Instance.GetList(Table_BLL.Instance.gettable(hd.ID_BAN.Value));
            double tongcong = 0;

            foreach (BillInfo item in listbillinfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.MatHang);
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.DonGia.ToString("c", culture));
                lsvItem.SubItems.Add(item.TongTien.ToString("c", culture));
                tongcong += item.TongTien;
                HANGHOA hh = new HANGHOA
                {
                    Ten_HH = item.MatHang,
                    Gia = Convert.ToDecimal(item.DonGia),
                };
                lsvItem.Tag = hh;

                lsvbill.Items.Add(lsvItem);
            }
            txbTongcong.Text = tongcong.ToString();
            txbchietkhau.Text = "0";
            if (info != "")
            {
                KHACHHANG kh = Customer_BLL.Instance.GetKHByInfo(info);

                if (kh.ID_LKH == 0 && kh.Diemtichluy > 20)
                {
                    txbchietkhau.Text = ((tongcong * 5) / 100).ToString();
                }
                else if (kh.ID_LKH == 1)
                {
                    txbchietkhau.Text = ((tongcong * 10) / 100).ToString();
                }
            }

            txbThanhtien.Text = (tongcong - Convert.ToDouble(txbchietkhau.Text)).ToString();
            int? idkh = Customer_BLL.Instance.getIDbyInfo(info);

            if (idkh == null)
            {
                HOA_DON_BLL.Instance.Thanhtoan(ID_BAN/* ID_BAN=ID_HOADON nha hehe*/, Convert.ToDecimal(txbThanhtien.Text), null, Convert.ToDecimal(txbchietkhau.Text));
            }
            else
            {
                HOA_DON_BLL.Instance.Thanhtoan(ID_BAN/* ID_BAN=ID_HOADON nha hehe*/, Convert.ToDecimal(txbThanhtien.Text), idkh, Convert.ToDecimal(txbchietkhau.Text));
            }

        }
    }

}
