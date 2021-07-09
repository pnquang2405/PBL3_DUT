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
    public partial class FormChangeAccount : Form
    {
        private int User;
        public delegate void changeInfo(String name);
        private changeInfo d;

        public changeInfo D { get => d; set => d = value; }

        public FormChangeAccount(int user)
        {
            InitializeComponent();
            User = user;
            SetGUI();
        }
        private void SetGUI()
        {
            NHANVIEN nv = BLL.Staff_BLL.Instance.Staff_ID_BLL(User);
            tbName.Text = nv.Ten_NV;
            tbUserName.Text = nv.PhoneNumber;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool check = Account_BLL.Instance.Login_BLL(tbUserName.Text, tbPassWord.Text, 0);
            if (check == true)
            {
                if (tbNewPass.Text != null && tbNewPass.Text == tbRePass.Text)
                {
                    Staff_BLL.Instance.ChangeInf_BLL(tbUserName.Text, tbName.Text, tbNewPass.Text);
                    MessageBox.Show("Thay doi thanh cong");
                    d(FormMain.subString(tbName.Text));
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Mat khau khong khop");
                }
            }
            else
            {
                MessageBox.Show("Mat khau khong dung");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
