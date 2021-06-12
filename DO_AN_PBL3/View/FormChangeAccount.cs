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
            NHANVIEN before = BLL.Staff_BLL.Instance.Staff_ID_BLL(User);
            if (tbNewPass.Text == tbPassWord.Text || tbNewPass.Text != tbRePass.Text)
            {
                MessageBox.Show("Nhập Lại");
            }
            else if (Convert.ToString(before.PhoneNumber) == tbUserName.Text && before.password == FormStaff.passWord(tbPassWord.Text))
            {

                NHANVIEN after = new NHANVIEN();
                after.ID_NV = before.ID_NV;
                after.Ten_NV = tbName.Text;
                after.PhoneNumber = before.PhoneNumber;
                after.password = FormStaff.passWord(tbNewPass.Text);
                after.Gender = before.Gender;
                after.Phanquyen = after.Phanquyen;
                BLL.Account_BLL.Instance.ChangeAccount(before.ID_NV, after);
                MessageBox.Show("Thành Công");

            }
            else
            {
                MessageBox.Show("Nhập Lại");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
