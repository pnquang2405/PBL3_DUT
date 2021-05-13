using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO_AN_PBL3.Entity;
using DO_AN_PBL3.Interface;

namespace DO_AN_PBL3.DAL
{
    class Merchandise_DAL : IGeneral<HANGHOA>
    {
        private PBL3_QLTraSuaEntities db;
        private static Merchandise_DAL _Instance;
        public static Merchandise_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Merchandise_DAL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public Merchandise_DAL()
        {
            db = new PBL3_QLTraSuaEntities();
        }

        public void Add(HANGHOA temp)
        {
            db.HANGHOAs.Add(temp);
        }

        public void Delete(HANGHOA temp)
        {
            HANGHOA current = db.HANGHOAs.First(p => p.ID_HH == temp.ID_HH);
            current.tinhTrang = 0;
        }

        public List<HANGHOA> GetList()
        {
            return db.HANGHOAs.Where(p=>p.tinhTrang == 1).ToList();
        }

        public List<HANGHOA> GetList(int key)
        {
            var l2 = db.HANGHOAs.Where(p => p.ID_LHH == key && p.tinhTrang == 1);
            
            return l2.ToList();
        }

        public void Update(HANGHOA hanghoaThayDoi, String name)
        {
            HANGHOA current = db.HANGHOAs.First(p => p.Ten_HH == name && p.tinhTrang == 1);
            current.Ten_HH = hanghoaThayDoi.Ten_HH;
            current.picture = hanghoaThayDoi.picture;
            current.ID_LHH = hanghoaThayDoi.ID_LHH;
            current.Gia = hanghoaThayDoi.Gia;
        }

        public int GetIDByName(String name)
        {
            HANGHOA hh = db.HANGHOAs.First(p => p.Ten_HH == name && p.tinhTrang == 1);

            return hh.ID_HH;
        }

        public HANGHOA GetHHByName(String name)
        {
            HANGHOA hh = db.HANGHOAs.FirstOrDefault(p => p.Ten_HH == name && p.tinhTrang == 1);

            return hh;
        }

        public void Sync()
        {
            db.SaveChanges();
        }
    }
}
