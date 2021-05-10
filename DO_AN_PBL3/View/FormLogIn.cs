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

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
           int username = Convert.ToInt32(txtUserName.Text);
            string password = txtPassword.Text;
            if (BLL.Account_BLL.Instance.Login_BLL(username,password))
            {
                this.Hide();
                FormMain f = new FormMain();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tai khoan!!!!!!!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
