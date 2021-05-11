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

namespace DO_AN_PBL3
{
    public partial class FormTable : Form
    {
        public Action<BAN> getTable;
        public FormTable()
        {
            InitializeComponent();
            LoadTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadTable()
        {
            flpTable.Controls.Clear();
            List<BAN> tableList = Table_BLL.Instance.GetTable();

            foreach (BAN item in tableList)
            {
                Button btn = new Button() { Width = 68, Height = 68 , BackColor = Color.Gray, ForeColor = Color.White};
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
            FormMain f = new FormMain();
            getTable.Invoke(table);
        }
    }
}
