﻿using DO_AN_PBL3.DAL;
using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.BLL
{
    class HOA_DON_BLL
    {
        private static HOA_DON_BLL _Instance;
        public static HOA_DON_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HOA_DON_BLL();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public bool checkHoaDon(int idTable)
        {
            int hang = HOA_DON_DAL.Instance.GetList(idTable).Count;
            if (HOA_DON_DAL.Instance.GetList(idTable).Count <= 0) return false;
            return true;
        }

        public void InsertHOADON(int idBAN, int? idKH, int idNV)
        {
            HOA_DON hoadon = new HOA_DON
            {
                ID_BAN = idBAN,
                ID_KH = idKH,
                ID_NV = idNV,
                Gio_den = DateTime.Now,
                Gio_di = null,
                Tong_tien = 0,
                discount = 0, 
              //  Diem_TL = 0
            };

            HOA_DON_DAL.Instance.Add(hoadon);
            HOA_DON_DAL.Instance.Sync();
        }

        public int GetIdByTable(int idTable)
        {
            int id = HOA_DON_DAL.Instance.GetList(idTable).First().ID_HD;
            return id;
        }

        public HOA_DON getHOADONbyID(int ID_HOADON)
        {
            return HOA_DON_DAL.Instance.Get_HOA_DON(ID_HOADON);
        }

        public void delete(int idBill)
        {
            HOA_DON hoadon = HOA_DON_DAL.Instance.Get_HOA_DON(idBill);

            HOA_DON_DAL.Instance.Delete(hoadon);
            HOA_DON_DAL.Instance.Sync();
        }

        public void Thanhtoan(int idbill, decimal tongtien, int? IDKH, decimal discount)
        {
            if (IDKH == null)
            {
                HOA_DON_DAL.Instance.Thanhtoan(idbill, tongtien, null, discount);
            }
            else
            {
                HOA_DON_DAL.Instance.Thanhtoan(idbill, tongtien, (int)IDKH, discount);
            }

            HOA_DON_DAL.Instance.Sync();
        }

        public List<HOA_DON> GetListHOADONByDate(DateTime checkIn, DateTime checkOut)
        {
            return HOA_DON_DAL.Instance.GetListByDate(checkIn, checkOut);
        }

        public int getIDByKH(KHACHHANG kh)
        {
            return HOA_DON_DAL.Instance.GetIDByKH(kh);
        }

        public void UpdateKH(int idBill, KHACHHANG kh)
        {
            HOA_DON_DAL.Instance.UpdateKH(idBill, kh);
            HOA_DON_DAL.Instance.Sync();
        }

        public void UpdateIDKH(int idKH)
        {
            HOA_DON_DAL.Instance.UpdateIDKH(idKH);
            HOA_DON_DAL.Instance.Sync();
        }

        public double getTotalBillInMonth(DateTime firstMonth, DateTime endMonth)
        {
            return HOA_DON_DAL.Instance.getTotalBillInMonth_DAL(firstMonth, endMonth);
        }
    }
}
