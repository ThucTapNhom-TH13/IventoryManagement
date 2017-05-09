using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

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

        public static bool update(NhaCungCap ncc)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("NhaCungCap_update", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maNhaCC", ncc.maNhaCC));
            cmd.Parameters.Add(new SqlParameter("@tenNhaCC", ncc.tenNhaCC));
            cmd.Parameters.Add(new SqlParameter("@diachi", ncc.diachi));
            cmd.Parameters.Add(new SqlParameter("@dienthoai", ncc.dienthoai));
            cmd.Parameters.Add(new SqlParameter("@maNuoc", ncc.maNuoc));
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

        public static bool insert(NhaCungCap ncc)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("NhaCungCap_insert", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tenNhaCC", ncc.tenNhaCC));
            cmd.Parameters.Add(new SqlParameter("@diachi", ncc.diachi));
            cmd.Parameters.Add(new SqlParameter("@dienthoai", ncc.dienthoai));
            cmd.Parameters.Add(new SqlParameter("@maNuoc", ncc.maNuoc));
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
