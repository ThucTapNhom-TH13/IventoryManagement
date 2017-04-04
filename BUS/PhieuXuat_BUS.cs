using DALL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BUS
{
    public class PhieuXuat_BUS
    {
        public static DataView PhieuXuat_getAll()
        {
            return PhieuXuat_DAO.PhieuXuat_getAll();
        }

        public static bool insert(PhieuXuat phieuxuat)
        {
            return PhieuXuat_DAO.insert(phieuxuat);
        }

        public static bool edit(PhieuXuat phieuxuat)
        {
            return PhieuXuat_DAO.edit(phieuxuat);
        }
    }
}
