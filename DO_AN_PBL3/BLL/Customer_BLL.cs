using DO_AN_PBL3.DAL;
using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.BLL
{
    class Customer_BLL
    {
        private static Customer_BLL _Instance;
        public static Customer_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Customer_BLL();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public KHACHHANG GetKHByID(int idKH)
        {
            return Customer_DAL.Instance.GetKHByID(idKH);
        }

        public KHACHHANG GetKHByInfo(String inForKH)
        {
            return Customer_DAL.Instance.GetKHByInfo(inForKH);
        }

        public void updateDTL(KHACHHANG kh, int dtl)
        {
            Customer_DAL.Instance.UpdateDTL(kh, dtl);
            Customer_DAL.Instance.Sync();
        }

        public void AddCustomer_BLL(String info, int dtl)
        {
            int i;
            if (dtl < 200) i = 0;
            else i = 1;
            KHACHHANG kh = new KHACHHANG
            {
                Ten_KH = "",
                ID_LKH = i,
                Diachi = "",
                PhoneNumber = info,
                Diemtichluy = dtl
            };
            Customer_DAL.Instance.Add(kh);
            Customer_DAL.Instance.Sync();
        }

        public List<KHACHHANG> GetList()
        {
            return Customer_DAL.Instance.GetList();
        }

        public void UpdateKH(KHACHHANG kh)
        {
            Customer_DAL.Instance.UpdateKH(kh);
            Customer_DAL.Instance.Sync();
        }

        public void Delete(KHACHHANG kh)
        {
            Customer_DAL.Instance.Delete(kh);
            Customer_DAL.Instance.Sync();
        }
    }
}
