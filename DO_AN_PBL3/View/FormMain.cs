using DO_AN_PBL3.BLL;
using DO_AN_PBL3.Entity;
using DO_AN_PBL3.View;
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
    public partial class FormMain : Form
    {
        private HANGHOA hangHoa;
        public FormMain()
        {
            InitializeComponent();
            button1_Click(new object(), new EventArgs());
            SetGUI();
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelChildForm.Controls.Add(childForm);
            PanelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTable());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMenu());
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Bàn", btnTable);
        }


        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if(panelAdmin.Visible == true)
            {
                panelAdmin.Hide();
            }
            else
            {
                panelAdmin.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void SetGUI()
        {
            List<Loai_HANGHOA> list = Category_Merchandise_BLL.Instance.GetLHH_BLL();
            Loai_HANGHOA hh = new Loai_HANGHOA {
                ID_LHH = -1,
                Ten_LHH = "Tất cả"
            };
            listBox1.Items.Add(hh);
            foreach (Loai_HANGHOA item in list)
            {
                listBox1.Items.Add(item);
            }
            listBox1.DisplayMember = "Ten_LHH";
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Loai_HANGHOA lhh = (Loai_HANGHOA)listBox1.SelectedItem;
            List<HANGHOA> list = Merchandise_BLL.Instance.GetList(lhh.ID_LHH);
            lsvHH.Items.Clear();

            foreach (HANGHOA item in list)
            {
                ListViewItem lsvItem = new ListViewItem(item.Ten_HH);
                lsvItem.SubItems.Add(item.Gia.ToString());
                lsvItem.Tag = item;

                lsvHH.Items.Add(lsvItem);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(hangHoa != null)
            {
                ListViewItem lsvItem = new ListViewItem(hangHoa.Ten_HH);
                lsvItem.SubItems.Add(nmrsoLuong.Value.ToString());
                lsvItem.SubItems.Add(hangHoa.Gia.ToString());
                lsvItem.SubItems.Add((Convert.ToDouble(hangHoa.Gia.Value.ToString()) * (int)nmrsoLuong.Value).ToString());
                lsvItem.Tag = hangHoa;

                lsvTemp.Items.Add(lsvItem);
                hangHoa = null;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn món");
            }
        }

        private void lsvHH_MouseClick(object sender, MouseEventArgs e)
        {
            hangHoa = (HANGHOA)lsvHH.SelectedItems[0].Tag;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panelSotien.Show();
        }

        private void ghiChúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSotien.Hide();
        }
    }
}
