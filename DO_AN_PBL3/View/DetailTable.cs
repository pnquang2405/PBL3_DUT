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
    public partial class DetailTable : Form
    {
        private int ID_HD { get; set; }
        private int user { get; set; }
        public DetailTable(int IDHD, int user)
        {
            this.user = user;
            ID_HD = IDHD;
            InitializeComponent();
            SETGUI();
        }
        private void SETGUI()
        {

            HOA_DON hd = HOA_DON_BLL.Instance.getHOADONbyID(ID_HD);

            CultureInfo culture = new CultureInfo("vi-VN");
            List<BillInfo> listbillinfo = BillInfo_BLL.Instance.GetList(Table_BLL.Instance.gettable(hd.ID_BAN.Value));
            foreach (BillInfo item in listbillinfo)
            {

                this.dtgDetail.Rows.Add(item.MatHang.ToString(), item.SoLuong.ToString());

            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            HOA_DON hd = HOA_DON_BLL.Instance.getHOADONbyID(ID_HD);
            List<BillInfo> listtach = new List<BillInfo>();
            int dem = 0;
            List<BillInfo> listbillInfo = BillInfo_BLL.Instance.GetList(Table_BLL.Instance.gettable((int)hd.ID_BAN));
            for (int i = 0; i < dtgDetail.Rows.Count - 1; i++)
            {
                BillInfo a = new BillInfo();
                a.MatHang = dtgDetail.Rows[i].Cells["Ten"].Value.ToString();

                if (Convert.ToInt32(dtgDetail.Rows[i].Cells["SL"].Value) < 0 || Convert.ToInt32(dtgDetail.Rows[i].Cells["SL"].Value) > listbillInfo[i].SoLuong)
                {
                    MessageBox.Show("So luong cua mon  " + a.MatHang.ToString() + " khong phu hop");
                    ++dem;
                }
                else
                {
                    a.SoLuong = Convert.ToInt32(dtgDetail.Rows[i].Cells["SL"].Value);
                    listtach.Add(a);
                }
            }
            if (dem == 0)
            {
                TableTach f = new TableTach((int)hd.ID_BAN, listtach, user);
                f.ShowDialog();
                this.Dispose();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
