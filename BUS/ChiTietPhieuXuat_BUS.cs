using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietPhieuXuat_BUS
    {
        public static DataView chiTietPhieuXuat_findOne(String mapx)
        {
            int maPhieuXuat = Convert.ToInt32(mapx);
            return DALL.ChiTietPhieuXuat_DAO.chiTietPhieuXuat_findOne(maPhieuXuat);
        }

        public static Boolean add(ChiTietPhieuXuat chiTiet)
        {
            return DALL.ChiTietPhieuXuat_DAO.add(chiTiet);
        }

        public static bool edit(ChiTietPhieuXuat chiTiet)
        {
            return DALL.ChiTietPhieuXuat_DAO.edit(chiTiet);
        }

        public static bool delete(int mahang)
        {
            return DALL.ChiTietPhieuXuat_DAO.delete(mahang);
        }
    }
}
