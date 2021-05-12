using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
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
            List<NHANVIEN> staffList = BLL.Staff_BLL.Instance.getStaff();
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
            

            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.DataPropertyName = "password";
            col6.HeaderText = "Mật Khẩu";

            DataGridView d = new DataGridView();

            d.Columns.Add(col1);
            d.Columns.Add(col2);
            d.Columns.Add(col3);
            d.Columns.Add(col4);
            d.Columns.Add(col5);
            d.Columns.Add(col6);

            d.DataSource = staffList;
            dgvStaff.Columns.Add(col6);

            dgvStaff.DataSource = staffList;

        }

        private void BtnAddStaff_Click(object sender, EventArgs e) {
            String TenNV = txtTenNV.Text;
            String PhoneNumber = txtPhoneNumber.Text;
            Boolean gender;
            if (rbMale.Equals(true))
            {
                gender = true;
            }
            else gender = false;
            NHANVIEN nv = new NHANVIEN
            {
                Gender = gender,
                Ten_NV = TenNV,
                PhoneNumber = PhoneNumber,
                password = passWord(),
                Phanquyen = false,
            };
            BLL.Staff_BLL.Instance.AddStaff_BLL(nv);
            LoadStaff();
        }
        private String passWord()
        {
            return "12111";
            
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >0)
            {
                DataGridViewRow row = this.dgvStaff.Rows[e.RowIndex];
                txtTenNV.Text = row.Cells[1].Value.ToString();
                txtPhoneNumber.Text = row.Cells[3].Value.ToString();
                if (row.Cells[2].Value.Equals(true))
                { rbMale.Checked = true; }
                else rbFeMale.Checked = true;
            }
        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.Ten_NV = this.txtTenNV.Text;
            nv.PhoneNumber = this.txtPhoneNumber.Text;
            if (rbMale.Checked.Equals(true))
            { nv.Gender = true; }
            else { nv.Gender = false; }
            BLL.Staff_BLL.Instance.EditStaff_BLL(nv);
            LoadStaff();
        }

        private void btnDelStaff_Click(object sender, EventArgs e)
        {
            if(dgvStaff.SelectedCells.Count > 0)
            {
                int id = Convert.ToInt32(dgvStaff.SelectedCells[0].OwningRow.Cells["ID_NV"].Value) ;
            
                NHANVIEN nv = BLL.Staff_BLL.Instance.Staff_ID_BLL(id);
                BLL.Staff_BLL.Instance.DelStaff_BLL(nv);
            }
            LoadStaff();
            
        }
    }
}
