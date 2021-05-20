using DO_AN_PBL3.Entity;
using DO_AN_PBL3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_PBL3.DAL
{
    class Staff_DAL
    {
        private PBL3_QLTraSuaEntities db;
        private static Staff_DAL _Instance;
        public static Staff_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Staff_DAL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public Staff_DAL()
        {
            db = new PBL3_QLTraSuaEntities();
        }

        public bool Add(NHANVIEN temp)
        {
            try
            {
                using (var newStaff = new PBL3_QLTraSuaEntities())
                {

                    newStaff.Entry(temp).State = System.Data.Entity.EntityState.Added;
                    newStaff.SaveChanges();
                    MessageBox.Show("Thành Công");
                    return true;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
                return false;
            }

        }

        public bool Delete(NHANVIEN temp)
        {
            try
            {
                using (var newStaff = new PBL3_QLTraSuaEntities())
                {

                    newStaff.Entry(temp).State = System.Data.Entity.EntityState.Deleted;
                    newStaff.SaveChanges();
                    MessageBox.Show("Thành Công");
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
                return false;
            }
        }

        public NHANVIEN Staff_ID_DAL(int id)
        {
            using (var staff = new PBL3_QLTraSuaEntities())
            {
                return staff.NHANVIENs.Where(p => (p.ID_NV) == id).FirstOrDefault();
            }

        }
        public List<NHANVIEN> GetList()
        {
            PBL3_QLTraSuaEntities db = new PBL3_QLTraSuaEntities();

            List<NHANVIEN> list = db.NHANVIENs.ToList();
            List<NHANVIEN> listStaff = new List<NHANVIEN>();
            NHANVIEN temp = new NHANVIEN();
            foreach (var item in list)
            {
                listStaff.Add(new NHANVIEN
                {

                    ID_NV = item.ID_NV,
                    Phanquyen = item.Phanquyen,
                    Gender = item.Gender,
                    password = item.password,
                    Ten_NV = item.Ten_NV,
                    PhoneNumber = item.PhoneNumber
                });

            }

            return list;
        }

        public List<NHANVIEN> GetList(int key)
        {
            throw new NotImplementedException();
        }

        public void Sync()
        {
            throw new NotImplementedException();
        }

        public bool Update(NHANVIEN after)    //NHANVIEN before
        {
            try
            {
                using (var newStaff = new PBL3_QLTraSuaEntities())
                {

                    newStaff.Entry(after).State = System.Data.Entity.EntityState.Modified;

                    newStaff.SaveChanges();
                    MessageBox.Show("Thành Công");
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi ");
                return false;
            }

        }
    }
}
