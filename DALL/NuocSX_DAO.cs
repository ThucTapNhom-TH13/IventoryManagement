using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class NuocSX_DAO
    {
        public static DataView getAll()
        {
            SqlConnection connection = SqlConnect.Connect();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("NuocSX_getAll", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            return dv;
        }

        public static bool delete(string manuoc)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("NuocSX_delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maNuoc", Int32.Parse(manuoc)));
            int msg = cmd.ExecuteNonQuery();
            if (msg > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool edit(string manuoc, string tennuoc)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("NuocSX_edit", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maNuoc", Int32.Parse(manuoc)));
            cmd.Parameters.Add(new SqlParameter("@tenNuoc", tennuoc));
            int msg = cmd.ExecuteNonQuery();
            if (msg > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool insert(string tennuoc)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("NuocSX_insert", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tenNuoc", tennuoc));
            int msg = cmd.ExecuteNonQuery();
            if (msg > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
