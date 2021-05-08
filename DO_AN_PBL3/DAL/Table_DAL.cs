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
        private StoreEntity db;
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
            db = new StoreEntity();
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
            return db.BANs.ToList();
        }

        public List<BAN> GetList(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(BAN before, BAN after)
        {
            throw new NotImplementedException();
        }

        public void Sync()
        {
            throw new NotImplementedException();
        }
    }
}
