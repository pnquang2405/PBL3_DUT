using DO_AN_PBL3.DAL;
using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.BLL
{
    class Table_BLL
    {
        private static Table_BLL _Instance;
        public static Table_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Table_BLL();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public List<BAN> GetTable()
        {
            return Table_DAL.Instance.GetList();
        }
        public BAN gettable(int idban)
        {
            return Table_DAL.Instance.gettable(idban);
        }
        public string GetnameTable(int idban)
        {

            return Table_DAL.Instance.getNameTable(idban);
        }
        public void update(int id, bool tinhTrang)
        {
            Table_DAL.Instance.Update(id, tinhTrang);
            Table_DAL.Instance.Sync();
        }
    }
}
