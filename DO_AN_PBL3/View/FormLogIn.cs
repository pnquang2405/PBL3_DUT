using DO_AN_PBL3.BLL;
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
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text != "" && txtUserName.Text != "")
            {
                string username = txtUserName.Text;
                string password = txtPassword.Text;
                if (BLL.Account_BLL.Instance.Login_BLL(username, password, 0))
                {
                    
                    FormMain f = new FormMain(Staff_BLL.Instance.getID_BLL(username));
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sai tai khoan!!!!!!!");
                }
            }
            else
            {
                MessageBox.Show("VUi long nhap day du thong tin");
            }
        }
    }
}
