using DALL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhieuXuat_BUS
    {
        public static DataView PhieuXuat_getAll()
        {
            return PhieuXuat_DAO.PhieuXuat_getAll();
        }
    }
}
