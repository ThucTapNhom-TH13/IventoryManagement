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
    public class PhieuXuat_DAO
    {
        public static DataView PhieuXuat_getAll()
        {
            SqlConnection connection = SqlConnect.Connect();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("PhieuXuat_getAll", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            return dv;
        }

        public static bool edit(PhieuXuat phieuxuat)
        {
            SqlConnection connection = SqlConnect.Connect();

            SqlCommand cmd = new SqlCommand("PhieuXuat_edit", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@maPX", phieuxuat.MaPhieuXuat));
            cmd.Parameters.Add(new SqlParameter("@ngayXuat", new SqlDateTime(phieuxuat.NgayXuat)));
            cmd.Parameters.Add(new SqlParameter("@lyDo", phieuxuat.LyDo));
            cmd.Parameters.Add(new SqlParameter("@maKho", phieuxuat.MaKho));
            cmd.Parameters.Add(new SqlParameter("@maKH", phieuxuat.MaKhachHang));
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

        public static bool insert(PhieuXuat phieuxuat)
        {
            SqlConnection connection = SqlConnect.Connect();

            SqlCommand cmd = new SqlCommand("PhieuXuat_insert", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ngayXuat", new SqlDateTime(phieuxuat.NgayXuat)));
            cmd.Parameters.Add(new SqlParameter("@lyDo", phieuxuat.LyDo));
            cmd.Parameters.Add(new SqlParameter("@maKho", phieuxuat.MaKho));
            cmd.Parameters.Add(new SqlParameter("@maKH", phieuxuat.MaKhachHang));
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
