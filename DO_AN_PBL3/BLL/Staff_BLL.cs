using DO_AN_PBL3.DAL;
using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.BLL
{
    class Staff_BLL
    {
        private static Staff_BLL _Instance;
        public static Staff_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Staff_BLL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public List<NHANVIEN> getStaff()
        {
            return DAL.Staff_DAL.Instance.GetList();
        }

        public void AddStaff_BLL(NHANVIEN nv)
        {
            DAL.Staff_DAL.Instance.Add(nv);
        }
        public void EditStaff_BLL(NHANVIEN before, NHANVIEN after)
        {
            DAL.Staff_DAL.Instance.Update(before, after);
        }
        public NHANVIEN Staff_ID_BLL(int id)
        {
            return DAL.Staff_DAL.Instance.Staff_ID_DAL(id);
        }
        public void DelStaff_BLL(NHANVIEN nv)
        {
            DAL.Staff_DAL.Instance.Delete(nv);
        }
        public void ResetPass_BLL(int id, String pass)
        {
            DAL.Staff_DAL.Instance.ResetPass_DAL(id, pass);
        }

        public String getname(int IDNV)
        {
            return Staff_DAL.Instance.getname(IDNV);
        }
    }
}
