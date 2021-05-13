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
        public BILL(int IDHOADON, int type)
        {
            this.type = type;
            ID_BAN = IDHOADON;
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
            txbNV.Text = "NHAP";
            txbthoigian.Text = DateTime.Now.ToString();
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
            txbchietkhau.Text = hd.discount.ToString();
            txbThanhtien.Text = (tongcong - (tongcong * (double)hd.discount.Value) / 100).ToString();

        }




    }

}
