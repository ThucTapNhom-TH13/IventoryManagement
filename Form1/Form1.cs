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
using Entity;
namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void showCTVT()
        {
            dgvChiTietVatTu.DataSource = CTVT_BUS.loadCTVT();
        }
        public void clearData()
        {
            txtMaHnag_CTVT.Text = "";
            txtMaPhieu_CTVT.Text = "";
            txtLuongXuat_CTVT.Text = "";
            txtLuongNhap_CTVT.Text = "";
            txtTonDK_CTVT.Text = "";
        }
        public void Enabal()
        {
            txtMaHnag_CTVT.Enabled = false;
            txtMaPhieu_CTVT.Enabled = false;
            txtLuongNhap_CTVT.Enabled = false;
            txtLuongXuat_CTVT.Enabled = false;
            txtTonDK_CTVT.Enabled = false;
            dtpNgay_CTVT.Enabled = false;
        }
        public void unEnable()
        {
            txtMaHnag_CTVT.Enabled = true;
            txtMaPhieu_CTVT.Enabled = true;
            txtLuongNhap_CTVT.Enabled = true;
            txtLuongXuat_CTVT.Enabled = true;
            txtTonDK_CTVT.Enabled = true;
            dtpNgay_CTVT.Enabled = true;
        }
        public void buildingCTVT()
        {
            txtMaHnag_CTVT.DataBindings.Clear();
            txtMaHnag_CTVT.DataBindings.Add("Text", dgvChiTietVatTu.DataSource, "MA_HANG");
            txtMaPhieu_CTVT.DataBindings.Clear();
            txtMaPhieu_CTVT.DataBindings.Add("Text", dgvChiTietVatTu.DataSource, "MA_PHIEU");
            txtLuongNhap_CTVT.DataBindings.Clear();
            txtLuongNhap_CTVT.DataBindings.Add("Text", dgvChiTietVatTu.DataSource, "LUONG_NHAP");
            txtLuongXuat_CTVT.DataBindings.Clear();
            txtLuongXuat_CTVT.DataBindings.Add("Text", dgvChiTietVatTu.DataSource, "LUONG_XUAT");
            txtTonDK_CTVT.DataBindings.Clear();
            txtTonDK_CTVT.DataBindings.Add("Text", dgvChiTietVatTu.DataSource, "TON_DK");
            dtpNgay_CTVT.DataBindings.Clear();
            dtpNgay_CTVT.DataBindings.Add("Text", dgvChiTietVatTu.DataSource, "NGAY");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_CTVT_Click(object sender, EventArgs e)
        {
            if (btnSua_CTVT.Text == "Thêm")
            {
                unEnable();
                clearData();
                btnThem_CTVT.Text = "Lưu Thêm";
                btnSua_CTVT.Text = "Cannel";
                btnXoa_CTVT.Enabled = false;
            }
            else if (btnThem_CTVT.Text == "Lưu Thêm")
            {
                btnThem_CTVT.Text = "Thêm";
                btnSua_CTVT.Text = "Sửa";
                btnXoa_CTVT.Enabled = true;
                if (!Catch.cNullTB(txtMaHnag_CTVT.Text) & !Catch.cNullTB(txtMaPhieu_CTVT.Text) & !Catch.cNullTB(txtLuongXuat_CTVT.Text) & !Catch.cNullTB(txtLuongNhap_CTVT.Text) & !Catch.cNullTB(txtTonDK_CTVT.Text))
                {
                    try
                    {
                        int mahang = Convert.ToInt32(txtMaHnag_CTVT.Text.Trim());
                        string maphieu = txtMaPhieu_CTVT.Text.Trim();
                        int luongxuat = Convert.ToInt32(txtLuongXuat_CTVT.Text.Trim());
                        DateTime ngay = Convert.ToDateTime(dtpNgay_CTVT.Text.Trim());
                        int luongnhap = Convert.ToInt32(txtLuongNhap_CTVT.Text.Trim());
                        int tondk = Convert.ToInt32(txtTonDK_CTVT.Text.Trim());

                        tblChiTietVatTu ctvt = new tblChiTietVatTu(mahang, maphieu, ngay, luongnhap, luongxuat, tondk);
                        CTVT_BUS.addCTVT(ctvt);
                        showCTVT();
                        buildingCTVT();
                        Enabal();
                    }
                    catch
                    {
                        MessageBox.Show("Loi");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập dữ liệu");
                }
            }
            else if (btnThem_CTVT.Text == "Lưu Sửa")
            {
                btnThem_CTVT.Text = "Thêm";
                btnSua_CTVT.Text = "Sửa";
                btnXoa_CTVT.Enabled = true;
                if (!Catch.cNullTB(txtMaHnag_CTVT.Text) & !Catch.cNullTB(txtMaPhieu_CTVT.Text) & !Catch.cNullTB(txtLuongXuat_CTVT.Text) & !Catch.cNullTB(txtLuongNhap_CTVT.Text) & !Catch.cNullTB(txtTonDK_CTVT.Text))
                {
                    try
                    {
                        int mahang = Convert.ToInt32(txtMaHnag_CTVT.Text.Trim());
                        string maphieu = txtMaPhieu_CTVT.Text.Trim();
                        int luongxuat = Convert.ToInt32(txtLuongXuat_CTVT.Text.Trim());
                        DateTime ngay = Convert.ToDateTime(dtpNgay_CTVT.Text.Trim());
                        int luongnhap = Convert.ToInt32(txtLuongNhap_CTVT.Text.Trim());
                        int tondk = Convert.ToInt32(txtTonDK_CTVT.Text.Trim());

                        tblChiTietVatTu ctvt = new tblChiTietVatTu(mahang, maphieu, ngay, luongnhap, luongxuat, tondk);
                        CTVT_BUS.updateCTVT(ctvt);
                        showCTVT();
                        buildingCTVT();
                        Enabal();
                    }
                    catch
                    {
                        MessageBox.Show("Loi");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập dữ liệu");
                }
            }
        }

        private void btnSua_CTVT_Click(object sender, EventArgs e)
        {
            if (btnSua_CTVT.Text == "Sửa")
            {
                unEnable();
                txtMaHnag_CTVT.Enabled = false;
                txtMaPhieu_CTVT.Enabled = false;
                btnThem_CTVT.Text = "Lưu Sửa";
                btnSua_CTVT.Text = "Cannel";
                btnXoa_CTVT.Enabled = false;

            }
            else
            {
                btnThem_CTVT.Text = "Thêm";
                btnSua_CTVT.Text = "Sửa";
                btnXoa_CTVT.Enabled = true;
                Enabal();
            }
        }

        private void btnXoa_CTVT_Click(object sender, EventArgs e)
        {
            if (!Catch.cNullTB(txtMaHnag_CTVT.Text)& !Catch.cNullTB(txtMaPhieu_CTVT.Text))
            {
                int mahang = Convert.ToInt32(txtMaHnag_CTVT.Text);
                string maphieu = txtMaPhieu_CTVT.Text;
                CTVT_BUS.deleteCTVT(mahang,maphieu);
                showCTVT();
                buildingCTVT();
                Enabal();

            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu");
            }
        }
    }
}
