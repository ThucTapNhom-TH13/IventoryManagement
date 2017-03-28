using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Load_BangPhieuXuat();
        }

        private void Load_BangPhieuXuat()
        {
            DataView table = PhieuXuat_BUS.PhieuXuat_getAll();
            bangPhieuXuat.DataSource = table;
        }

        private void bangPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String mapx = "", lydo = "", makho = "", makh = "";
            int CurrentIndex = bangPhieuXuat.CurrentCell.RowIndex;

            if (bangPhieuXuat.Rows[CurrentIndex].Cells[0].Value != null)
            {
                mapx = bangPhieuXuat.Rows[CurrentIndex].Cells[0].Value.ToString();
                maPhieuXuat_txt.Text = mapx;
            }
            if (bangPhieuXuat.Rows[CurrentIndex].Cells[3].Value != null)
            {
                lydo = bangPhieuXuat.Rows[CurrentIndex].Cells[3].Value.ToString();
                lyDo_txt.Text = lydo;
            }
            if (bangPhieuXuat.Rows[CurrentIndex].Cells[2].Value != null)
            {
                makho = bangPhieuXuat.Rows[CurrentIndex].Cells[2].Value.ToString();
                maKho_txt.Text = makho;
            }
            if (bangPhieuXuat.Rows[CurrentIndex].Cells[4].Value != null)
            {
                makh = bangPhieuXuat.Rows[CurrentIndex].Cells[4].Value.ToString();
                maKH_txt.Text = makh;
            }
            if (bangPhieuXuat.Rows[CurrentIndex].Cells[1].Value != null)
            {
                String[] datetime = bangPhieuXuat.Rows[CurrentIndex].Cells[1].Value.ToString().Split('/',' ');
                DateTime date = new DateTime(Int32.Parse(datetime[2]), Int32.Parse(datetime[0]), Int32.Parse(datetime[1]));
                ngayXuat_datepicker.Value = date;
            }

            DataView table = ChiTietPhieuXuat_BUS.chiTietPhieuXuat_findOne(mapx);
            bangChiTietPhieuNhap.DataSource = table;
        }

        private void load_chiTietPhieuXuat(int mapx)
        {
            DataView table = PhieuXuat_BUS.PhieuXuat_getAll();
            bangPhieuXuat.DataSource = table;
        }

        private void bangChiTietPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String mahang = "", soluong = "", dongia = "";
            int CurrentIndex = bangPhieuXuat.CurrentCell.RowIndex;

            if (bangChiTietPhieuNhap.Rows[CurrentIndex].Cells[1].Value != null)
            {
                mahang = bangChiTietPhieuNhap.Rows[CurrentIndex].Cells[1].Value.ToString();
                maHang_txt.Text = mahang;
            }
            if (bangChiTietPhieuNhap.Rows[CurrentIndex].Cells[2].Value != null)
            {
                soluong = bangChiTietPhieuNhap.Rows[CurrentIndex].Cells[2].Value.ToString();
                soLuong_txt.Text = soluong;
            }
            if (bangChiTietPhieuNhap.Rows[CurrentIndex].Cells[3].Value != null)
            {
                dongia = bangChiTietPhieuNhap.Rows[CurrentIndex].Cells[3].Value.ToString();
                donGia_txt.Text = dongia;
            }
        }
    }
}
