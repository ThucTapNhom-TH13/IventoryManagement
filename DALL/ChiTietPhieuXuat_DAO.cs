using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class ChiTietPhieuXuat_DAO
    {
        public static DataView chiTietPhieuXuat_findOne(int mapx)
        {
            SqlConnection connection = SqlConnect.Connect();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("chiTietPhieuXuat_findOne", connection);
            da.SelectCommand.Parameters.Add("@mapx", SqlDbType.Int);
            da.SelectCommand.Parameters["@mapx"].Value = mapx;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            return dv;
        }
    }
}
