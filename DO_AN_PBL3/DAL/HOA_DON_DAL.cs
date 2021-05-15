using DO_AN_PBL3.Entity;
using DO_AN_PBL3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.DAL
{
    class HOA_DON_DAL:IGeneral<HOA_DON>
    {
        private PBL3_QLTraSuaEntities db;
        private static HOA_DON_DAL _Instance;
        public static HOA_DON_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HOA_DON_DAL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public HOA_DON_DAL()
        {
            db = new PBL3_QLTraSuaEntities();
        }

        public List<HOA_DON> GetList()
        {
            throw new NotImplementedException();
        }

        public List<HOA_DON> GetList(int key)
        {
            List<HOA_DON> list = (from hoadon in db.HOA_DON 
                                  where hoadon.ID_BAN == key && hoadon.Gio_di == null
                                  select hoadon).ToList();
         
            return list;
        }

        public HOA_DON Get_HOA_DON(int id)
        {
            HOA_DON hoadon = db.HOA_DON.First(p => p.ID_HD == id);

            return hoadon;
        }

        public void Add(HOA_DON temp)
        {
            db.HOA_DON.Add(temp);
        }

        public void Delete(HOA_DON temp)
        {
            db.HOA_DON.Remove(temp);
        }

        public void Update(HOA_DON before, HOA_DON after)
        {
            throw new NotImplementedException();
        }

        public void Sync()
        {
            db.SaveChanges();
        }
        public void Thanhtoan(int idbill, decimal tongtien)
        {
            HOA_DON tempt= db.HOA_DON.FirstOrDefault(p => p.ID_HD == idbill);
            tempt.Gio_di = DateTime.Now;
            tempt.Tong_tien = tongtien;
            Table_DAL.Instance.Update((int)tempt.ID_BAN, true);
            db.SaveChanges();
        }
    }
}
