using DO_AN_PBL3.Entity;
using DO_AN_PBL3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.DAL
{
    class CHI_TIET_HOA_DON_DAL:IGeneral<CHI_TIET_HOA_DON>
    {
        private PBL3_QLTraSuaEntities db;
        private static CHI_TIET_HOA_DON_DAL _Instance;
        public static CHI_TIET_HOA_DON_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CHI_TIET_HOA_DON_DAL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public CHI_TIET_HOA_DON_DAL()
        {
            db = new PBL3_QLTraSuaEntities();
        }

        public List<CHI_TIET_HOA_DON> GetList()
        {
            throw new NotImplementedException();
        }

        public List<CHI_TIET_HOA_DON> GetList(int key)
        {
            throw new NotImplementedException();
        }

        public void Add(CHI_TIET_HOA_DON temp)
        {
            db.CHI_TIET_HOA_DON.Add(temp);
        }

        public int GetID(int idBill, int idHH)
        {
            CHI_TIET_HOA_DON chitiet = db.CHI_TIET_HOA_DON.First(p => p.ID_HD == idBill && p.ID_HH == idHH);
            return chitiet.ID_CTHD;
        }

        public void Delete(CHI_TIET_HOA_DON temp)
        {
            CHI_TIET_HOA_DON chitiet = db.CHI_TIET_HOA_DON.First(p => p.ID_CTHD == temp.ID_CTHD);
            db.CHI_TIET_HOA_DON.Remove(chitiet);
        }

        public void Update(int idBill, String TenHH, int soLuong)
        {
            CHI_TIET_HOA_DON current = db.CHI_TIET_HOA_DON.First(p => p.ID_HD == idBill && p.HANGHOA.Ten_HH == TenHH);

            current.soluong = soLuong;
        }

        public void Sync()
        {
            db.SaveChanges();
        }
    }
}
