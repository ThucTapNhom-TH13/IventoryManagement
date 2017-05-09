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
    public class NhaCungCap_BUS
    {
        public static DataView NhaCungCap_getAll()
        {
            return NhaCungCap_DAO.NhaCungCap_getAll();
        }

        public static bool insert(NhaCungCap ncc)
        {
            return NhaCungCap_DAO.insert(ncc);
        }

        public static bool update(NhaCungCap ncc)
        {
            return NhaCungCap_DAO.update(ncc);
        }
    }
}
