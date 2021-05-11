using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO_AN_PBL3.Entity;
using DO_AN_PBL3.Interface;

namespace DO_AN_PBL3.DAL
{
    class Table_DAL : IGeneral<BAN>
    {
        private PBL3_QLTraSuaEntities db;
        private static Table_DAL _Instance;
        public static Table_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Table_DAL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public Table_DAL()
        {
            db = new PBL3_QLTraSuaEntities();
        }
        public void Add(BAN temp)
        {
            throw new NotImplementedException();
        }

        public void Delete(BAN temp)
        {
            throw new NotImplementedException();
        }

        public List<BAN> GetList()
        {
            List<BAN> list = (from p in db.BANs
                       select p).ToList();

            return list;
        }

        public List<BAN> GetList(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, bool tinhTrang)
        {
            BAN ban = db.BANs.First(p => p.ID_BAN == id);
            ban.TinhTrang = tinhTrang;

            List<BAN> list = db.BANs.ToList();

            Console.WriteLine("123");
        }

        public void Sync()
        {
            db.SaveChanges();
        }
    }
}
