using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class NhaCungCap_DAO
    {
        public static DataView NhaCungCap_getAll()
        {
            SqlConnection connection = SqlConnect.Connect();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("NhaCungCap_getAll", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            return dv;
        }
    }
}
