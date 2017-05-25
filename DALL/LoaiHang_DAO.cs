using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;
using System.Data.SqlClient;

namespace DALL
{
    public class LoaiHang_DAO
    {
        public static DataTable loadLoaiHang()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("XEM_LOAI_HANG", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static DataSet getLoaiHang()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Loai_Hang", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.SelectCommand = command;
            DataSet dt = new DataSet();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static void ThemLoaiHang(LoaiHang Lh)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("THEM_LOAI_HANG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LOAI_HANG", SqlDbType.NVarChar, 50);
            cmd.Parameters["@LOAI_HANG"].Value = Lh.Tenlh;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void SuaLoaiHang(LoaiHang Lh)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("SUA_LOAI_HANG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_LOAI_HANG", SqlDbType.Int);
            cmd.Parameters.Add("@LOAI_HANG", SqlDbType.NVarChar, 50);
            cmd.Parameters["@MA_LOAI_HANG"].Value = Lh.Malh;
            cmd.Parameters["@LOAI_HANG"].Value = Lh.Tenlh;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void XoaLoaiHang(int maLh)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("XOA_LOAI_HANG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_LOAI_HANG", SqlDbType.Int);
            cmd.Parameters["@MA_LOAI_HANG"].Value = maLh;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
