using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;
using System.Data;
namespace DALL
{
    public class ChiTietVatTu_DALL
    {
        public static DataTable loadChiTietVatTu()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("XEM_CTVT", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static void ThemCTVT(tblChiTietVatTu ctvt)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("THEM_CTVT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_HANG", SqlDbType.Int);
            cmd.Parameters.Add("@MA_PN", SqlDbType.Int);
            cmd.Parameters.Add("@MA_PX", SqlDbType.Int);
            cmd.Parameters.Add("@NGAY", SqlDbType.DateTime);
            cmd.Parameters.Add("@LUONG_NHAP", SqlDbType.Int);
            cmd.Parameters.Add("@LUONG_XUAT", SqlDbType.Int);
            cmd.Parameters.Add("@TON_DK", SqlDbType.Int);
            cmd.Parameters["@MA_HANG"].Value = ctvt.Mahang1;
            cmd.Parameters["@MA_PX"].Value = ctvt.Mapx1;
            cmd.Parameters["@MA_PN"].Value = ctvt.Mapn1;
            cmd.Parameters["@NGAY"].Value = ctvt.Ngay1;
            cmd.Parameters["@LUONG_NHAP"].Value = ctvt.Luongnhap1;
            cmd.Parameters["@LUONG_XUAT"].Value = ctvt.Luongxuat1;
            cmd.Parameters["@TON_DK"].Value = ctvt.Tondauky1;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void SuaCTVT(tblChiTietVatTu ctvt)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("SUA_CTVT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_HANG", SqlDbType.Int);
            cmd.Parameters.Add("@MA_PN", SqlDbType.Int);
            cmd.Parameters.Add("@MA_PX", SqlDbType.Int);
            cmd.Parameters.Add("@NGAY", SqlDbType.DateTime);
            cmd.Parameters.Add("@LUONG_NHAP", SqlDbType.Int);
            cmd.Parameters.Add("@LUONG_XUAT", SqlDbType.Int);
            cmd.Parameters.Add("@TON_DK", SqlDbType.Int);
            cmd.Parameters["@MA_HANG"].Value = ctvt.Mahang1;
            cmd.Parameters["@MA_PX"].Value = ctvt.Mapx1;
            cmd.Parameters["@MA_PN"].Value = ctvt.Mapn1;
            cmd.Parameters["@NGAY"].Value = ctvt.Ngay1;
            cmd.Parameters["@LUONG_NHAP"].Value = ctvt.Luongnhap1;
            cmd.Parameters["@LUONG_XUAT"].Value = ctvt.Luongxuat1;
            cmd.Parameters["@TON_DK"].Value = ctvt.Tondauky1;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void XoaCTVT(int mahang, int mapx, int mapn)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("XOA_CTVT", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_HANG", SqlDbType.Int);
            cmd.Parameters["@MA_HANG"].Value = mahang;
            cmd.Parameters.Add("@MA_PX", SqlDbType.Int);
            cmd.Parameters["@MA_HANG"].Value =  mapx;
            cmd.Parameters.Add("@MA_PN", SqlDbType.Int);
            cmd.Parameters["@MA_HANG"].Value = mapn;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
