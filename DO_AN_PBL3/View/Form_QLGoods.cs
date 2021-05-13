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
    public partial class Form_QLGoods : Form
    {
        public Form_QLGoods()
        {
            InitializeComponent();
            Load_DL(-1);
            LoadCBB();
        }


        public void Load_DL(int idLHH)
        {
            dtgvGoods.Rows.Clear();
            List<HANGHOA> list = new List<HANGHOA>();
            list = Merchandise_BLL.Instance.GetList(idLHH);

            if (dtgvGoods.Columns.Count == 0)
            {
                DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
                col1.HeaderText = "STT";
                dtgvGoods.Columns.Add(col1);

                DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
                col2.HeaderText = "Tên hàng hóa";
                dtgvGoods.Columns.Add(col2);

                DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
                col3.HeaderText = "Giá";
                dtgvGoods.Columns.Add(col3);

                DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
                col4.HeaderText = "Loại hàng hóa";
                dtgvGoods.Columns.Add(col4);
            }
            if (list.Count > 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvGoods);
                row.Cells[0].Value = 1 + "";
                row.Cells[1].Value = list[0].Ten_HH;
                row.Cells[2].Value = list[0].Gia;
                row.Cells[3].Value = list[0].Loai_HANGHOA.Ten_LHH;

                dtgvGoods.Rows.Add(row);

                for (int i = 1; i < list.Count; i++)
                {
                    DataGridViewRow row1 = new DataGridViewRow();
                    row1.CreateCells(dtgvGoods);

                    row1.Cells[0].Value = (i + 1) + "";
                    row1.Cells[1].Value = list[i].Ten_HH;
                    row1.Cells[2].Value = list[i].Gia;
                    row1.Cells[3].Value = list[i].Loai_HANGHOA.Ten_LHH;

                    dtgvGoods.Rows.Add(row1);
                }

                dtgvGoods.Columns[0].Width = 70;                
            }
            lbTotal.Text = "Tổng số món: " + (dtgvGoods.Rows.Count - 1).ToString();
        }

        public void LoadCBB()
        {
            cbLHH.Items.Add(new CBBItem
            {
                Text = "Tất cả",
                Value = -1,
            });
            cbLHH.Items.AddRange(Category_Merchandise_BLL.Instance.GetCBB().ToArray());
            cbLHH.SelectedIndex = 0;
        }

        private void cbLHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idLHH = (int)((CBBItem)cbLHH.SelectedItem).Value;
            Load_DL(idLHH);
        }

        private void sửaMónNàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Ten_HH = dtgvGoods.SelectedRows[0].Cells[1].Value.ToString();
            FormProfileGoods f = new FormProfileGoods(Ten_HH);
            f.D += new FormProfileGoods.MyDel(Load_DL);
            f.Show();
        }

        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProfileGoods f = new FormProfileGoods("");
            f.D += new FormProfileGoods.MyDel(Load_DL);
            f.Show();
        }

        private void xóaMónNàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Ten_HH = dtgvGoods.SelectedRows[0].Cells[1].Value.ToString();
            HANGHOA hanghoa = Merchandise_BLL.Instance.GetHHByName(Ten_HH);
            Merchandise_BLL.Instance.delete(hanghoa);


            Load_DL((int)((CBBItem)cbLHH.SelectedItem).Value);
        }
    }
}
