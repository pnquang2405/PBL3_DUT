using DO_AN_PBL3.DAL;
using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.BLL
{
    class BillInfo_BLL
    {
        private static BillInfo_BLL _Instance;
        public static BillInfo_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BillInfo_BLL();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public List<Entity.BillInfo> GetList(BAN table)
        {
            return BillInfo_DAL.Instance.GetBillInfo(table);
        }

    }
}
