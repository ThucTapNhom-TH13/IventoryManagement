using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlTypes;

namespace DALL
{
    public class PhieuNhap_DAL
    {
        public static DataSet getPhieuNhap()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("SELECT MA_PN FROM Phieu_Nhap", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.SelectCommand = command;
            DataSet dt = new DataSet();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public static bool PhieuNhap_edit(PhieuNhap phieuNhap)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("PhieuNhap_edit", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ngayNhap", new SqlDateTime(phieuNhap.NgayNhap)));
            cmd.Parameters.Add(new SqlParameter("@maNCC", phieuNhap.MaNCC));
            cmd.Parameters.Add(new SqlParameter("@maKho", phieuNhap.MaKho));
            cmd.Parameters.Add(new SqlParameter("@maPN", phieuNhap.MaPhieuNhap));
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

        public static bool PhieuNhap_delete(int mapn)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("PhieuNhap_delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maPN", mapn));
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

        public static bool PhieuNhap_add(PhieuNhap phieuNhap)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("PhieuNhap_insert", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ngayNhap", new SqlDateTime(phieuNhap.NgayNhap)));
            cmd.Parameters.Add(new SqlParameter("@maNCC", phieuNhap.MaNCC));
            cmd.Parameters.Add(new SqlParameter("@maKho", phieuNhap.MaKho));
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

        public static DataView PhieuNhap_getAll()
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("PhieuNhap_getAll", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            return dv;
        }
    }
}
