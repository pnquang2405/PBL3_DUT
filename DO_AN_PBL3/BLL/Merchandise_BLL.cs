using DO_AN_PBL3.DAL;
using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.BLL
{
    class Merchandise_BLL
    {
        private static Merchandise_BLL _Instance;
        public static Merchandise_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Merchandise_BLL();
                }
                return _Instance;
            }
            private set
            {

            }
        }


        public void Add(HANGHOA hh)
        {
            Merchandise_DAL.Instance.Add(hh);
            Merchandise_DAL.Instance.Sync();
        }

        public List<HANGHOA> GetList()
        {
            return Merchandise_DAL.Instance.GetList();
        }

        public List<HANGHOA> GetList(int id)
        {
            if(id == -1)
            {
                return Merchandise_DAL.Instance.GetList();
            }
            return Merchandise_DAL.Instance.GetList(id);
        }

        public HANGHOA GetHHByName(String name)
        {
            return Merchandise_DAL.Instance.GetHHByName(name);
        }

        public void update(HANGHOA hh, String name)
        {
            Merchandise_DAL.Instance.Update(hh, name);
            Merchandise_DAL.Instance.Sync();
        }
    }
}
