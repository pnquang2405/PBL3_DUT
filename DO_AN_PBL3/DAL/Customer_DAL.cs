﻿using DO_AN_PBL3.Entity;
using DO_AN_PBL3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.DAL
{
    class Customer_DAL : IGeneral<KHACHHANG>
    {
        private PBL3_QLTraSuaEntities db;
        private static Customer_DAL _Instance;
        public static Customer_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Customer_DAL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public Customer_DAL()
        {
            db = new PBL3_QLTraSuaEntities();
        }

        public List<KHACHHANG> GetList()
        {
            List<KHACHHANG> list = (db.KHACHHANGs).ToList();
            return list;
        }

        public List<KHACHHANG> GetList(int key)
        {
            throw new NotImplementedException();
        }

        public KHACHHANG GetKHByID(int id)
        {
            KHACHHANG kh = db.KHACHHANGs.FirstOrDefault(p => p.ID_KH == id);

            return kh;
        }

        public KHACHHANG GetKHByInfo(String inForKH)
        {
            KHACHHANG kh = db.KHACHHANGs.FirstOrDefault(p => p.PhoneNumber == inForKH || p.Ten_KH == inForKH);

            return kh;
        }

        public void Add(KHACHHANG temp)
        {
            db.KHACHHANGs.Add(temp);
        }

        public void Delete(KHACHHANG temp)
        {
            db.KHACHHANGs.Remove(temp);
        }


        public void UpdateDTL(KHACHHANG khachhang,int dtl)
        {
            KHACHHANG kh = db.KHACHHANGs.First(p => p.ID_KH == khachhang.ID_KH);
            kh.Diemtichluy += dtl;

            if (kh.Diemtichluy > 200) kh.ID_LKH = 1;

        }

        public void UpdateKH(KHACHHANG kh)
        {
            KHACHHANG cus = db.KHACHHANGs.First(p => p.ID_KH == kh.ID_KH);
            cus.Ten_KH = kh.Ten_KH;
            cus.Diachi = kh.Diachi;
            cus.PhoneNumber = kh.PhoneNumber;
        }

        public void Sync()
        {
            db.SaveChanges();
        }
        public int? getIDbyInfo(String info)
        {
            KHACHHANG cus = db.KHACHHANGs.FirstOrDefault(p => p.PhoneNumber == info);
            if (cus != null)
                return cus.ID_KH;
            else return null;
        }

        public bool checkSDT(String sdt)
        {
            KHACHHANG cus = db.KHACHHANGs.FirstOrDefault(p => p.PhoneNumber == sdt);
            
            return false ? cus.PhoneNumber == null : true;
        }
    }
}
 
