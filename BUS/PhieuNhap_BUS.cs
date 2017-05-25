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
        public static DataSet getMaPN()
        {
            return PhieuNhap_DAL.getPhieuNhap();
        }
    }
}
