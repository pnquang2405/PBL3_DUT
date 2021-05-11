using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.DAL
{
    class BillInfo_DAL
    {
        private StoreEntity db;
        private static BillInfo_DAL _Instance;
        public static BillInfo_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BillInfo_DAL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public BillInfo_DAL()
        {
            db = new StoreEntity();
        }

        public List<BillInfo> GetBillInfo(BAN table)
        {
            var list = from hanghoa in db.HANGHOAs
                       from hoadon in db.HOA_DON
                       from hoadonChitiet in db.CHI_TIET_HOA_DON
                       where hanghoa.ID_HH == hoadonChitiet.ID_HH
                       where hoadon.ID_HD == hoadonChitiet.ID_HD
                       where hoadon.ID_BAN == table.ID_BAN
                       let tongTien = hoadonChitiet.soluong * (double)hanghoa.Gia
                       select new { hanghoa.Ten_HH, hoadonChitiet.soluong, hanghoa.Gia, tongTien};

            List<BillInfo> listBillIn = new List<BillInfo>();

            foreach (var item in list)
            {
                BillInfo temp = new BillInfo
                {
                    MatHang = item.Ten_HH,
                    SoLuong = (int)item.soluong,
                    DonGia = (double)item.Gia,
                    TongTien = (double)item.tongTien
                };
                listBillIn.Add(temp);
            }

            return listBillIn;

        }

    }
}
