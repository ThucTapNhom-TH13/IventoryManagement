using DALL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhoHang_BUS
    {
        public static DataTable loadKhoHang()
        {
            return KhoHang_DAL.loadHanghoa();
        }
        public static DataSet getMakho()
        {
            return KhoHang_DAL.getMakho();
        }
        public static void addKhoHang(KhoHang kh)
        {
            KhoHang_DAL.ThemKho(kh);
        }
        public static void updateKho(KhoHang kh)
        {
            KhoHang_DAL.SuaKho(kh);
        }
        public static void deleteKho(int makh)
        {
            KhoHang_DAL.XoaKho(makh);
        }
    }
}
