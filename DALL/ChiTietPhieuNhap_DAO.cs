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
    public class ChiTietPhieuNhap_DAO
    {
        public static DataView chiTietPhieuNhap_find(int mapn)
        {
            SqlConnection connection = SqlConnect.Connect();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("chiTietPhieuNhap_find", connection);
            da.SelectCommand.Parameters.Add("@mapn", SqlDbType.Int);
            da.SelectCommand.Parameters["@mapn"].Value = mapn;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            return dv;
        }
        public static DataSet getsoluong(int mapn)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("SELECT SO_LUONG_THUC FROM Chi_Tiet_Phieu_Nhap where MA_PX=@MA_PX ", conn);
            conn.Open();
            command.Parameters.Add("@LOAI_HANG", SqlDbType.Int);
            command.Parameters["@LOAI_HANG"].Value = mapn;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.SelectCommand = command;
            DataSet dt = new DataSet();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static bool delete(int mapn)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("ChiTietPhieuNhap_delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mapn", mapn));
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

        public static bool update(ChiTietPhieuNhap ctpn)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("ChiTietPhieuNhap_update", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mahang", ctpn.MaHang));
            cmd.Parameters.Add(new SqlParameter("@slgia", ctpn.SlTheoChungTu));
            cmd.Parameters.Add(new SqlParameter("@slthuc", ctpn.SlThuc));
            cmd.Parameters.Add(new SqlParameter("@dongia", ctpn.DonGia));
            cmd.Parameters.Add(new SqlParameter("@mapn", ctpn.MaPhieuNhap));
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

        public static bool insert(ChiTietPhieuNhap ctpn)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("ChiTietPhieuNhap_insert", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mapn", ctpn.MaPhieuNhap));
            cmd.Parameters.Add(new SqlParameter("@mahang", ctpn.MaHang));
            cmd.Parameters.Add(new SqlParameter("@slgia", ctpn.SlTheoChungTu));
            cmd.Parameters.Add(new SqlParameter("@slthuc", ctpn.SlThuc));
            cmd.Parameters.Add(new SqlParameter("@dongia", ctpn.DonGia));
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
