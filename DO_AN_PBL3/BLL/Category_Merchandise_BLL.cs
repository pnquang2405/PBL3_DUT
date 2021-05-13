using DO_AN_PBL3.DAL;
using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.BLL
{
    class Category_Merchandise_BLL
    {
        private static Category_Merchandise_BLL _Instance;
        public static Category_Merchandise_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Category_Merchandise_BLL();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public List<CBBItem> GetCBB()
        {
            List<CBBItem> list = new List<CBBItem>();
            foreach (Loai_HANGHOA item in Category_Merchandise_DAL.Instance.GetList())
            {
                list.Add(new CBBItem
                {
                    Value = item.ID_LHH,
                    Text = item.Ten_LHH
                });
            }
            return list;
        }

        public List<Loai_HANGHOA> GetLHH_BLL()
        {
            return Category_Merchandise_DAL.Instance.GetList();
        }
        

    }
}
