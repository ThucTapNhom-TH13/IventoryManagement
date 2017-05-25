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
    public class Hanghoa_BUS
    {
        public static DataTable loadHangHoa()
        {
            return Hanghoa_DAO.loadHanghoa();
        }
        public static DataSet getHangHoa()
        {
            return Hanghoa_DAO.getHangHoa();
        }
        public static void addHangHoa(Hanghoa hh)
        {
            Hanghoa_DAO.ThemHangHoa(hh);
        }
        public static void updateHangHoa(Hanghoa hh)
        {
            Hanghoa_DAO.SuaHangJoa(hh);
        }
        public static void deleteHangHoa(int mahang)
        {
            Hanghoa_DAO.XoaHangHoa(mahang);
        }
    }
}
