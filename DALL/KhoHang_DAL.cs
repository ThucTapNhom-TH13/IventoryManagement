using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class KhoHang_DAL
    {
        public static DataTable loadHanghoa()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("XEM_KHO", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static DataSet getMakho()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("SELECT MA_KHO, TEN_KHO FROM Danh_Muc_Kho", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataSet dt = new DataSet();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static void ThemKho(KhoHang kh)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("THEM_KHO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@TEN_KHO", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DIA_CHI", SqlDbType.NVarChar,50);
            cmd.Parameters.Add("@SDT", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TEN_THU_KHO", SqlDbType.NVarChar,50);

            cmd.Parameters["@TEN_KHO"].Value = kh.Tenkho;
            cmd.Parameters["@DIA_CHI"].Value = kh.Diachi;
            cmd.Parameters["@SDT"].Value = kh.Dienthoai;
            cmd.Parameters["@TEN_THU_KHO"].Value = kh.Tenthukho;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void SuaKho(KhoHang kh)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("SUA_KHO", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MA_KHO", SqlDbType.Int);
            cmd.Parameters.Add("@TEN_KHO", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DIA_CHI", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SDT", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TEN_THU_KHO", SqlDbType.NVarChar, 50);

            cmd.Parameters["@MA_KHO"].Value = kh.Makho;
            cmd.Parameters["@TEN_KHO"].Value = kh.Tenkho;
            cmd.Parameters["@DIA_CHI"].Value = kh.Diachi;
            cmd.Parameters["@SDT"].Value = kh.Dienthoai;
            cmd.Parameters["@TEN_THU_KHO"].Value = kh.Tenthukho;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void XoaKho(int makho)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("XOA_KHO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_KHO", SqlDbType.Int);
            cmd.Parameters["@MA_KHO"].Value = makho;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
