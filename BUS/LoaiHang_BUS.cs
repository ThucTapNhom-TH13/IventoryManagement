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
    public class LoaiHang_BUS
    {
        public static DataTable loadLoaiHang()
        {
            return LoaiHang_DAO.loadLoaiHang();
        }
        public static void addLoaiHang(LoaiHang lh)
        {
            LoaiHang_DAO.ThemLoaiHang(lh);
        }
        public static void updateLoaiHang(LoaiHang lh)
        {
            LoaiHang_DAO.SuaLoaiHang(lh);
        }
        public static void deleteLoaiHang(int malh)
        {
            LoaiHang_DAO.XoaLoaiHang(malh);
        }
    }
}
