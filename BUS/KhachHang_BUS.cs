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
    public class KhachHang_BUS
    {
        public static DataTable loadKhachHang()
        {
            return KhachHang_DAO.loadKhachHang();
        }
        public static void addKhachHang(KhachHang kh)
        {
            KhachHang_DAO.ThemKhachHang(kh);
        }
        public static void updateKhachHang(KhachHang kh)
        {
            KhachHang_DAO.SuaKhachHang(kh);
        }
        public static void deleteKhachHang(int makh)
        {
            KhachHang_DAO.XoaHangHoa(makh);
        }
    }
}
