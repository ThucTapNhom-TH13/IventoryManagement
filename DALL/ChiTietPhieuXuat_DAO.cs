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
       
        public static bool delete(int mahang)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("ChiTietPhieuXuat_delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mahang", mahang));
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

        public static bool edit(ChiTietPhieuXuat chiTiet)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("ChiTietPhieuXuat_edit", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maPX", chiTiet.MaPhieuXuat));
            cmd.Parameters.Add(new SqlParameter("@maHang", chiTiet.MaHang));
            cmd.Parameters.Add(new SqlParameter("@soLuong", chiTiet.SoLuong));
            cmd.Parameters.Add(new SqlParameter("@donGia", chiTiet.DonGia));
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

        public static bool add(ChiTietPhieuXuat chiTiet)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("ChiTietPhieuXuat_add", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maPX", chiTiet.MaPhieuXuat));
            cmd.Parameters.Add(new SqlParameter("@maHang", chiTiet.MaHang));
            cmd.Parameters.Add(new SqlParameter("@soLuong", chiTiet.SoLuong));
            cmd.Parameters.Add(new SqlParameter("@donGia", chiTiet.DonGia));
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
