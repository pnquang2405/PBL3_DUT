using DO_AN_PBL3.Entity;
using DO_AN_PBL3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DO_AN_PBL3.DAL
{
    class HOA_DON_DAL : IGeneral<HOA_DON>
    {
        private PBL3_QLTraSuaEntities db;
        private static HOA_DON_DAL _Instance;
        public static HOA_DON_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HOA_DON_DAL();
                }
                return _Instance;
            }
            private set
            {



            }
        }
        public HOA_DON_DAL()
        {
            db = new PBL3_QLTraSuaEntities();
        }



        public List<HOA_DON> GetList()
        {
            throw new NotImplementedException();
        }



        public List<HOA_DON> GetListByDate(DateTime checkIn, DateTime checkOut)
        {
            List<HOA_DON> list = (from hoadon in db.HOA_DON
                                  where hoadon.Gio_den >= checkIn && hoadon.Gio_di <= checkOut
                                  select hoadon).ToList();



            return list;



        }



        public List<HOA_DON> GetList(int key)
        {
            List<HOA_DON> list = (from hoadon in db.HOA_DON
                                  where hoadon.ID_BAN == key && hoadon.Gio_di == null
                                  select hoadon).ToList();

            return list;
        }



        public HOA_DON Get_HOA_DON(int id)
        {
            HOA_DON hoadon = db.HOA_DON.First(p => p.ID_HD == id);



            return hoadon;
        }



        public void Add(HOA_DON temp)
        {
            db.HOA_DON.Add(temp);
        }



        public void Delete(HOA_DON temp)
        {
            db.HOA_DON.Remove(temp);
        }



        public void Update(HOA_DON before, HOA_DON after)
        {
            throw new NotImplementedException();
        }



        public void Sync()
        {
            db.SaveChanges();
        }



        public void Thanhtoan(int idbill, decimal tongtien, int? IDKH, decimal discount)
        {
            HOA_DON tempt = db.HOA_DON.FirstOrDefault(p => p.ID_HD == idbill);
            tempt.Gio_di = DateTime.Now;
            tempt.Tong_tien = tongtien;
            tempt.ID_KH = IDKH;
            tempt.discount = discount;
            Table_DAL.Instance.Update((int)tempt.ID_BAN, true);
            List<BAN> listban = Table_DAL.Instance.GetList();
            foreach (BAN item in listban)
            {
                if (item.ID_ban_chuyen == tempt.ID_BAN)
                {
                    Table_DAL.Instance.Update((int)item.ID_BAN, true);
                    Table_DAL.Instance.updateID_chuyen(item.ID_BAN, null);
                }
            }
            Table_DAL.Instance.Sync();



        }



        public int GetIDByKH(KHACHHANG kh)
        {
            HOA_DON hd = db.HOA_DON.FirstOrDefault(p => p.ID_KH == kh.ID_KH);



            return hd.ID_HD;
        }



        public void UpdateKH(int idBill, KHACHHANG kh)
        {
            HOA_DON hd = db.HOA_DON.FirstOrDefault(p => p.ID_HD == idBill);



            hd.ID_KH = kh.ID_KH;
        }



        public void UpdateIDKH(int idKH)
        {
            var list = from p in db.HOA_DON where p.ID_KH == idKH select p;
            foreach (HOA_DON item in list)
            {
                item.ID_KH = null;
            }
        }



        public double getTotalBillInMonth_DAL(DateTime firstMonth, DateTime endMonth)
        {
            var list = from p in db.HOA_DON
                       where p.Gio_den >= firstMonth
                       && p.Gio_di <= endMonth
                       select p.Tong_tien;
            var sum = list.ToList().Sum();



            return Convert.ToDouble(sum);
        }
    }
}