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
    public class Hanghoa_DAO
    {
        public static DataTable loadHanghoa()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("XEM_HANG_HOA", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static void ThemHangHoa(Hanghoa hh)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("THEM_HANG_HOA", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@TEN_HANG", SqlDbType.NVarChar,50);
            cmd.Parameters.Add("@MA_NUOC_SX", SqlDbType.Int);
            cmd.Parameters.Add("@KICH_THUOC", SqlDbType.NVarChar,50);
            cmd.Parameters.Add("@MA_LOAI_HANG", SqlDbType.Int);
            cmd.Parameters.Add("@DON_VI_TINH", SqlDbType.NVarChar,50);
            cmd.Parameters.Add("@LUONG_TON", SqlDbType.Int);
            cmd.Parameters.Add("@MA_KHO", SqlDbType.Int);

            cmd.Parameters["@TEN_HANG"].Value = hh.Tenhang;
            cmd.Parameters["@MA_NUOC_SX"].Value = hh.Manuocsx;
            cmd.Parameters["@KICH_THUOC"].Value = hh.Kichthuoc;
            cmd.Parameters["@MA_LOAI_HANG"].Value = hh.Maloaihang;
            cmd.Parameters["@DON_VI_TINH"].Value = hh.Donvitinh;
            cmd.Parameters["@LUONG_TON"].Value = hh.Luongton;
            cmd.Parameters["@MA_KHO"].Value = hh.Makho;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void SuaHangJoa(Hanghoa hh)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("SUA_HANG_HOA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_HANG", SqlDbType.Int);
            cmd.Parameters.Add("@TEN_HANG", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MA_NUOC_SX", SqlDbType.Int);
            cmd.Parameters.Add("@KICH_THUOC", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MA_LOAI_HANG", SqlDbType.Int);
            cmd.Parameters.Add("@DON_VI_TINH", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@LUONG_TON", SqlDbType.Int);
            cmd.Parameters.Add("@MA_KHO", SqlDbType.Int);
            cmd.Parameters["@MA_HANG"].Value = hh.Mahang;
            cmd.Parameters["@TEN_HANG"].Value = hh.Tenhang;
            cmd.Parameters["@MA_NUOC_SX"].Value = hh.Manuocsx;
            cmd.Parameters["@KICH_THUOC"].Value = hh.Kichthuoc;
            cmd.Parameters["@MA_LOAI_HANG"].Value = hh.Maloaihang;
            cmd.Parameters["@DON_VI_TINH"].Value = hh.Donvitinh;
            cmd.Parameters["@LUONG_TON"].Value = hh.Luongton;
            cmd.Parameters["@MA_KHO"].Value = hh.Makho;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void XoaHangHoa(int mahang)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("XOA_HANG_HOA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_HANG", SqlDbType.Int);
            cmd.Parameters["@MA_HANG"].Value = mahang;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
