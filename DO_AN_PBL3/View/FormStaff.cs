using DO_AN_PBL3.BLL;
using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DO_AN_PBL3.View
{
    public partial class FormStaff : Form
    {
      
        public FormStaff()
        {
            InitializeComponent();            
            LoadStaff();
            
        }


        public void LoadStaff()
        {
            dgvStaff.Rows.Clear();
            dgvStaff.Columns.Clear();
            //n
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "ID_NV";
            col1.HeaderText = "Mã NV";

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "Ten_NV";
            col2.HeaderText = "Tên NV";

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.DataPropertyName = "PhoneNumber";
            col3.HeaderText = "Phone Number";

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.DataPropertyName = "Gender";
            col4.HeaderText = "Gender";

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.DataPropertyName = "Phanquyen";
            col5.HeaderText = "Phân Quyền";


            //DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            //col6.DataPropertyName = "password";
            //col6.HeaderText = "Mật Khẩu";

            dgvStaff.Columns.Add(col1);
            dgvStaff.Columns.Add(col2);
            dgvStaff.Columns.Add(col3);
            dgvStaff.Columns.Add(col4);
            dgvStaff.Columns.Add(col5);
            //dgvStaff.Columns.Add(col6);


            List<NHANVIEN> staffList = BLL.Staff_BLL.Instance.getStaff();
            if (staffList.Count > 0)
            {
                for (int i = 0; i < staffList.Count; i++)
                {
                    NHANVIEN nv = null;
                    if (staffList[i].ID_NV != 0)
                    {
                        nv = Staff_BLL.Instance.Staff_ID_BLL(staffList[i].ID_NV);
                        DataGridViewRow row1 = new DataGridViewRow();
                        row1.CreateCells(dgvStaff);
                        row1.Cells[0].Value = staffList[i].ID_NV;
                        row1.Cells[1].Value = staffList[i].Ten_NV;
                        row1.Cells[2].Value = staffList[i].PhoneNumber;
                        if (staffList[i].Gender == true)
                        {
                            row1.Cells[3].Value = "Nam";
                        }
                        else row1.Cells[3].Value = "Nữ";
                        if (staffList[i].Phanquyen == true)
                        {
                            row1.Cells[4].Value = "Admin";
                        }
                        else
                            row1.Cells[4].Value = "Staff";

                        dgvStaff.Rows.Add(row1);
                    }
                    dgvStaff.Columns[0].Width = 50;
                    dgvStaff.Columns[1].Width = 150;
                    dgvStaff.Columns[2].Width = 110;
                    dgvStaff.Columns[3].Width = 75;
                    dgvStaff.Columns[4].Width = 70;

                }
            }

        }


        private static bool CheckPhone(String phone)
        {
            var isNumeric = !string.IsNullOrEmpty(phone) && phone.All(Char.IsDigit);
            return isNumeric;
        }

        private Boolean CheckPhone2(String PhoneNumber)
        {
            int k = 0;
            List<NHANVIEN> list = BLL.Staff_BLL.Instance.getStaff();
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].PhoneNumber == PhoneNumber)
                    {
                        k++;
                    }
                }
                if (k == 0) return true;
                else {
                    MessageBox.Show("Số Điện thoại này đã được đăng ký");
                    return false; }
            }
            else return false;

        }
        private void BtnAddStaff_Click(object sender, EventArgs e)
        {

                if (txtPhoneNumber.Text != "" && txtTenNV.Text != "" && CheckPhone2(txtPhoneNumber.Text) && CheckPhone(txtPhoneNumber.Text))
                {
                    String TenNV = txtTenNV.Text;
                    String PhoneNumber = txtPhoneNumber.Text;
                    Boolean gender;
                    Boolean phanquyen;
                    if (rbMale.Checked==true)
                    {
                        gender = true;
                    }
                    else gender = false;
                    phanquyen = false;
                    NHANVIEN nv = new NHANVIEN
                    {
                        Gender = gender,
                        Ten_NV = TenNV,
                        PhoneNumber = PhoneNumber,
                        password = passWord("1"),
                        Phanquyen = phanquyen,
                    };
                    Staff_BLL.Instance.AddStaff_BLL(nv);
                    LoadStaff();
                }
                else
                {
                    MessageBox.Show("Vui Lòng Nhập Lại");
                }
            
        }
        public static String passWord(String password)
        {
            byte[] tempt = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(tempt);
            string hashpass = "";
            foreach (byte item in hashData)
            {
                hashpass += item;
            }
            return hashpass;
        }


        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvStaff.Rows[e.RowIndex];
                if (row.Cells[1].Value != null)
                {
                    txtTenNV.Text = row.Cells[1].Value.ToString();
                    txtPhoneNumber.Text = row.Cells[2].Value.ToString();
                    if (row.Cells[3].Value.Equals("Nam"))
                    { rbMale.Checked = true; }
                    else rbFeMale.Checked = true;
                }
            }
        }
       
        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.Ten_NV = txtTenNV.Text;
            if (rbMale.Checked.Equals(true))
            {
                nv.Gender = true;
            }
            else
            {
                nv.Gender = false;
            }
            if (CheckPhone(txtPhoneNumber.Text))
            {
                nv.PhoneNumber = txtPhoneNumber.Text;
            }
            else
            {
                MessageBox.Show("Lỗi sdt");
                return;
            }
            nv.password = passWord("1");
            nv.Phanquyen = false;

            if (dgvStaff.SelectedCells.Count > 0)
            {
                int id = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells[0].Value);
                NHANVIEN before = BLL.Staff_BLL.Instance.Staff_ID_BLL(id);
                nv.password = before.password;
                BLL.Staff_BLL.Instance.EditStaff_BLL(before, nv);
            }

            LoadStaff();
        }


        private void btnDelStaff_Click(object sender, EventArgs e)
        {
         
            if (dgvStaff.SelectedCells.Count > 0)
            {
                int id = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells[0].Value);

                NHANVIEN nv = BLL.Staff_BLL.Instance.Staff_ID_BLL(id);
                BLL.Staff_BLL.Instance.DelStaff_BLL(nv);
            }
            LoadStaff();

        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {                  
            if (dgvStaff.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells[0].Value);
                NHANVIEN nv = Staff_BLL.Instance.Staff_ID_BLL(id);
              bool check=  Account_BLL.Instance.Login_BLL(nv.PhoneNumber, "1", 1);
                if (check == true)
                    MessageBox.Show("Đã reset");
                else MessageBox.Show("Loi");
            }
            else
            {
                MessageBox.Show("Vui long cho nhan vien");
            }

        }

    }
}
