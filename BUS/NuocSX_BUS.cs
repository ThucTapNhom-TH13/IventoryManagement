using DALL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NuocSX_BUS
    {
        public static DataView NuocSX_getAll()
        {
            return NuocSX_DAO.getAll();
        }

        public static bool insert(string tennuoc)
        {
            return NuocSX_DAO.insert(tennuoc);
        }

        public static bool edit(string manuoc, string tennuoc)
        {
            return NuocSX_DAO.edit(manuoc, tennuoc);
        }

        public static bool delete(string manuoc)
        {
            return NuocSX_DAO.delete(manuoc);
        }
    }
}
