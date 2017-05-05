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
    public class KhachHang_DAO
    {
        public static DataTable loadKhachHang()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("XEM_KHACH_HANG", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static void ThemKhachHang(KhachHang kh)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("THEM_KH", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_KH", SqlDbType.Int);
            cmd.Parameters.Add("@TEN_KH", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DIA_CHI", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DIEN_THOAI", SqlDbType.NVarChar, 50);
   
            cmd.Parameters["@MA_KH"].Value = kh.Makh;
            cmd.Parameters["@TEN_KH"].Value = kh.Tenkh;
            cmd.Parameters["@DIA_CHI"].Value = kh.Diachi;
            cmd.Parameters["@DIEN_THOAI"].Value = kh.Dienthoai;
        
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void SuaKhachHang(KhachHang kh)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("SUA_KH", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_KH", SqlDbType.Int);
            cmd.Parameters.Add("@TEN_KH", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DIA_CHI", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DIEN_THOAI", SqlDbType.NVarChar, 50);

            cmd.Parameters["@MA_KH"].Value = kh.Makh;
            cmd.Parameters["@TEN_KH"].Value = kh.Tenkh;
            cmd.Parameters["@DIA_CHI"].Value = kh.Diachi;
            cmd.Parameters["@DIEN_THOAI"].Value = kh.Dienthoai;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void XoaHangHoa(int makh)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("XOA_KH", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_KH", SqlDbType.Int);
            cmd.Parameters["@MA_KH"].Value = makh;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
