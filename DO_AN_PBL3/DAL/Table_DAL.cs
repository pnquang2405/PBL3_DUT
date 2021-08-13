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
            get{
        
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
        Table_DAL()
        {
            db = new PBL3_QLTraSuaEntities();
        }

        ~Table_DAL()
        {
            db.Dispose();
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
            List<BAN> list = (db.BANs).ToList();
            return list;
        }
        public BAN gettable(int idban)
        {
            db = new PBL3_QLTraSuaEntities();
            return db.BANs.FirstOrDefault(p => p.ID_BAN == idban);
        }
        public string getNameTable(int IDBAN)
        {
            db = new PBL3_QLTraSuaEntities();
            BAN ban = db.BANs.FirstOrDefault(p => p.ID_BAN == IDBAN);
            if (ban == null) return "";
            else return ban.Tenban;
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
        }
        public void updateID_chuyen(int idban,int? idchuyen)
        {
            BAN ban = db.BANs.First(p => p.ID_BAN == idban);
            ban.ID_ban_chuyen = idchuyen;
            Sync();
        }
      
        public void Sync()
        {
            db.SaveChanges();
        }
    }
}
