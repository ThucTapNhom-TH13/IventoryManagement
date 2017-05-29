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
    public class PhieuNhap_BUS
    {
        public static DataView PhieuNhap_getAll()
        {
            return PhieuNhap_DAL.PhieuNhap_getAll();
        }

        public static bool addPhieuNhap(PhieuNhap phieuNhap)
        {
            return PhieuNhap_DAL.PhieuNhap_add(phieuNhap);
        }

        public static bool editPhieuNhap(PhieuNhap phieuNhap)
        {
            return PhieuNhap_DAL.PhieuNhap_edit(phieuNhap);
        }

        public static bool deletePhieuNhap(int mapn)
        {
            return PhieuNhap_DAL.PhieuNhap_delete(mapn);
        }
    }
}
