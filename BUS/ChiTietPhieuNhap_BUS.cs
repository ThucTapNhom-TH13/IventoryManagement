using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BUS
{
    public class ChiTietPhieuNhap_BUS
    {
        public static DataView chiTietPhieuNhap_find(int mapn)
        {
            return DALL.ChiTietPhieuNhap_DAO.chiTietPhieuNhap_find(mapn);
        }

        public static bool insert(ChiTietPhieuNhap ctpn)
        {
            return DALL.ChiTietPhieuNhap_DAO.insert(ctpn);
        }

        public static bool update(ChiTietPhieuNhap ctpn)
        {
            return DALL.ChiTietPhieuNhap_DAO.update(ctpn);
        }

        public static bool delete(int mapn)
        {
            return DALL.ChiTietPhieuNhap_DAO.delete(mapn);
        }
    }
}
