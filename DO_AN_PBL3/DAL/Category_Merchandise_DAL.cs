using DO_AN_PBL3.Interface;
using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.DAL
{
    class Category_Merchandise_DAL : IGeneral<Loai_HANGHOA>
    {
        private StoreEntity db;
        private static Category_Merchandise_DAL _Instance;
        public static Category_Merchandise_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Category_Merchandise_DAL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public Category_Merchandise_DAL()
        {
            db = new StoreEntity();
        }
        public void Add(Loai_HANGHOA temp)
        {
            throw new NotImplementedException();
        }

        public void Delete(Loai_HANGHOA temp)
        {
            throw new NotImplementedException();
        }

        public List<Loai_HANGHOA> GetList()
        {
            return db.Loai_HANGHOA.ToList();
        }

        public List<Loai_HANGHOA> GetList(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(Loai_HANGHOA before, Loai_HANGHOA after)
        {
            throw new NotImplementedException();
        }

        public void Sync()
        {
            throw new NotImplementedException();
        }
    }
}
