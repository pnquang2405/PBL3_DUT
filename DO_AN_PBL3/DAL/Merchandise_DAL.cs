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
        private StoreEntity db;
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
            db = new StoreEntity();
        }

        public void Add(HANGHOA temp)
        {
            db.HANGHOAs.Add(temp);
        }

        public void Delete(HANGHOA temp)
        {
            throw new NotImplementedException();
        }

        public List<HANGHOA> GetList()
        {
            return db.HANGHOAs.ToList();
        }

        public List<HANGHOA> GetList(int key)
        {
            var l2 = db.HANGHOAs.Where(p => p.ID_LHH == key);

            return l2.ToList();
        }

        public void Update(HANGHOA before, HANGHOA after)
        {
            throw new NotImplementedException();
        }

        public void Sync()
        {
            db.SaveChanges();
        }
    }
}
