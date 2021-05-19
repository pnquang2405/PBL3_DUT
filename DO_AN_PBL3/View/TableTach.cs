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
    public partial class TableTach : Form
    {
        private int idban { get; set; }
        private int newIDBAN { get; set; }
        private List<BillInfo> listhh { get; set; }
        private int user { get; set; }
        public TableTach(int id, List<BillInfo> list, int user)
        {
            this.user = user;
            listhh = list;
            idban = id;
            InitializeComponent();
            LoadTable();
        }
        public void LoadTable()
        {
            flpTable.Controls.Clear();
            List<BAN> tableList = Table_BLL.Instance.GetTable();

            foreach (BAN item in tableList)
            {
                Button btn = new Button() { Width = 68, Height = 68, BackColor = Color.Gray, ForeColor = Color.White };
                if (item.TinhTrang == false) btn.BackColor = Color.Red;
                btn.Text = item.Tenban;
                btn.Tag = item;
                btn.Click += Btn_Click;

                flpTable.Controls.Add(btn);
            }

        }
        private void Btn_Click(object sender, EventArgs e)
        {
            BAN table = (sender as Button).Tag as BAN;
            if (table.ID_BAN == idban)
            {
                MessageBox.Show("Khong hop le");
            }
            else
            {
                newIDBAN = table.ID_BAN;
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (listhh != null)
            {
                List<BillInfo> listBillInfo = BillInfo_BLL.Instance.GetList(Table_BLL.Instance.gettable(idban));

                for (int i = 0; i < listBillInfo.Count; i++)
                {
                    listBillInfo[i].SoLuong = listBillInfo[i].SoLuong - listhh[i].SoLuong;

                    if (listBillInfo[i].SoLuong <= 0)
                    {
                        CHI_TIET_HOA_DON_BLL.Instance.delete(HOA_DON_BLL.Instance.GetIdByTable(idban), listBillInfo[i].MatHang, listBillInfo[i].SoLuong);

                    }
                    else CHI_TIET_HOA_DON_BLL.Instance.update(HOA_DON_BLL.Instance.GetIdByTable(idban), listBillInfo[i].MatHang, listBillInfo[i].SoLuong);
                }

                if (BillInfo_BLL.Instance.GetList(Table_BLL.Instance.gettable(idban)).Count <= 0)
                {
                    Table_BLL.Instance.update(idban, true);
                    HOA_DON_BLL.Instance.delete(HOA_DON_BLL.Instance.GetIdByTable(idban));
                }
            }
            else
            {
                listhh = BillInfo_BLL.Instance.GetList(Table_BLL.Instance.gettable(idban));
                Table_BLL.Instance.update(idban, true);
                for (int i = 0; i < listhh.Count; i++)
                {
                    CHI_TIET_HOA_DON_BLL.Instance.delete(HOA_DON_BLL.Instance.GetIdByTable(idban), listhh[i].MatHang, listhh[i].SoLuong);
                }
                HOA_DON_BLL.Instance.delete(HOA_DON_BLL.Instance.GetIdByTable(idban));
            }
            if (HOA_DON_BLL.Instance.checkHoaDon(newIDBAN) == false)
            {
                HOA_DON_BLL.Instance.InsertHOADON(newIDBAN, null, user);
                Table_BLL.Instance.update(newIDBAN, false);
            }
            int idbill = HOA_DON_BLL.Instance.GetIdByTable(newIDBAN);
            List<BillInfo> listbillinfo = BillInfo_BLL.Instance.GetList(Table_BLL.Instance.gettable(newIDBAN));
            int k = 0;
            foreach (BillInfo item in listhh)
            {
                if (item.SoLuong > 0)
                {
                    foreach (BillInfo i in listbillinfo)
                    {
                        k = 0;
                        if (item.MatHang == i.MatHang)
                        {
                            CHI_TIET_HOA_DON_BLL.Instance.update(idbill, item.MatHang, item.SoLuong + i.SoLuong);
                            k = 1;
                            break;
                        }
                    }
                    if (k == 0)
                        CHI_TIET_HOA_DON_BLL.Instance.insert(idbill, item.MatHang, item.SoLuong);
                }
            }
            this.Dispose();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
