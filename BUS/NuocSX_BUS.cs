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
    }
}
