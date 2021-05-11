using DO_AN_PBL3.DAL;
using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.BLL
{
    class CHI_TIET_HOA_DON_BLL
    {
        private static CHI_TIET_HOA_DON_BLL _Instance;
        public static CHI_TIET_HOA_DON_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CHI_TIET_HOA_DON_BLL();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public void update(int idBill, String tenHH, int soLuong)
        {
            CHI_TIET_HOA_DON_DAL.Instance.Update(idBill, tenHH, soLuong);
            CHI_TIET_HOA_DON_DAL.Instance.Sync();
        }

        public void insert(int idBill, String tenHH, int soLuong)
        {
            int idHH = Merchandise_DAL.Instance.GetIDByName(tenHH);
            CHI_TIET_HOA_DON chitietHD = new CHI_TIET_HOA_DON
            {
                ID_HD = idBill,
                ID_HH = idHH,
                soluong = soLuong
            };

            CHI_TIET_HOA_DON_DAL.Instance.Add(chitietHD);
            CHI_TIET_HOA_DON_DAL.Instance.Sync();
        }

        public void delete(int idBill, String tenHH)
        {
            int idHH = Merchandise_DAL.Instance.GetIDByName(tenHH);
            CHI_TIET_HOA_DON chitiet = new CHI_TIET_HOA_DON
            {
                ID_HD = idBill,
                ID_HH = idHH,
            };
            CHI_TIET_HOA_DON_DAL.Instance.Delete(chitiet);
            CHI_TIET_HOA_DON_DAL.Instance.Sync();
        }

    }

}
