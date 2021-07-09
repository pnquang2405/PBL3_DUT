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
    public partial class FormInchebien : Form
    {
        private int IDBILL { get; set; }
        private int User;
        public FormInchebien(int idbill, int user)
        {
            IDBILL = idbill;
            InitializeComponent();
            User = user;
            SETGUI();
        }
        private void SETGUI()
        {
            HOA_DON tempt = HOA_DON_BLL.Instance.getHOADONbyID(IDBILL);
            lbban.Text = Table_BLL.Instance.GetnameTable((int)tempt.ID_BAN);
            NHANVIEN nv = Staff_BLL.Instance.Staff_ID_BLL(User);
            lbName.Text = nv.Ten_NV;
            CultureInfo culture = new CultureInfo("vi-VN");
            List<BillInfo> listbillinfo = BillInfo_BLL.Instance.GetList(Table_BLL.Instance.gettable(tempt.ID_BAN.Value));
            foreach (BillInfo item in listbillinfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.MatHang);
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItemp.Items.Add(lsvItem);
            }
        }
    }
}
