using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL;
using Entity;
using System.Data;
namespace BUS
{
    public class CTVT_BUS
    {
        public static DataTable loadCTVT()
        {
            return ChiTietVatTu_DALL.loadChiTietVatTu();
        }
        public static DataTable ThongKe()
        {
            return ChiTietVatTu_DALL.thongke();
        }
        public static void addCTVT(tblChiTietVatTu ctvt)
        {
            ChiTietVatTu_DALL.ThemCTVT(ctvt);
        }
        public static void updateCTVT(tblChiTietVatTu ctvt)
        {
            ChiTietVatTu_DALL.SuaCTVT(ctvt);
        }
        public static void deleteCTVT(int mahang,int mapx, int mapn)
        {
            ChiTietVatTu_DALL.XoaCTVT(mahang, mapx, mapn);
        }
    }
}
