using DALL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhaCungCap_BUS
    {
        public static DataView NhaCungCap_getAll()
        {
            return NhaCungCap_DAO.NhaCungCap_getAll();
        }
    }
}
