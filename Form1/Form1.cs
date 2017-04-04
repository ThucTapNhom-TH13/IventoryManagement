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
        
        private void Form1_Load(object sender, EventArgs e)
        {
            PhieuXuat_initTextboxStatus(false, false);


            Load_BangPhieuXuat();
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

        /// H.Linh - added

        public void PhieuXuat_initTextboxStatus(bool status1, bool status2)
        {
            maPhieuXuat_txt.Enabled = false;
            ngayXuat_datepicker.Enabled = status1;
            lyDo_txt.Enabled = status1;
            maKho_txt.Enabled = status1;
            maKH_txt.Enabled = status1;
            maHang_txt.Enabled = status2;
            soLuong_txt.Enabled = status2;
            donGia_txt.Enabled = status2;
        }

        public void PhieuXuat_clearTextBoxValues(bool status1, bool status2)
        {
            if (status1)
            {
                maPhieuXuat_txt.Clear();
                lyDo_txt.Clear();
                maKho_txt.Clear();
                maKH_txt.Clear();
            }
            if (status2)
            {
                maHang_txt.Clear();
                soLuong_txt.Clear();
                donGia_txt.Clear();
            }
            
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
                String[] datetime = bangPhieuXuat.Rows[CurrentIndex].Cells[1].Value.ToString().Split('/', ' ');
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

        private void PX_button1_Click(object sender, EventArgs e)
        {
            if (PX_button1.Text.Equals("Thêm"))
            {
                PX_button1.Text = "Lưu";
                PX_button2.Text = "Hủy";
                PhieuXuat_initTextboxStatus(true, false);
            }
            else if (PX_button1.Text.Equals("Hủy"))
            {
                PX_button1.Text = "Thêm";
                PX_button2.Text = "Sửa";
                PhieuXuat_initTextboxStatus(false, false);
                PhieuXuat_clearTextBoxValues(true, true);
            }
            else if (PX_button1.Text.Equals("Lưu"))
            {
                bool result = false;
                DateTime ngayxuat = ngayXuat_datepicker.Value;
                String lydo = lyDo_txt.Text;
                try
                {
                    int maKho = Convert.ToInt32(maKho_txt.Text);
                    int maKH = Convert.ToInt32(maKH_txt.Text);
                    PhieuXuat phieuxuat = new PhieuXuat(ngayxuat, lydo, maKho, maKH);
                    result = BUS.PhieuXuat_BUS.insert(phieuxuat);
                    if (result)
                    {
                        System.Windows.Forms.MessageBox.Show("Thêm thành công!");
                    }
                    PX_button1.Text = "Thêm";
                    PX_button2.Text = "Sửa";
                    PhieuXuat_initTextboxStatus(false, false);
                    PhieuXuat_clearTextBoxValues(true, true);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Mã kho hoặc mã khách màng không hợp lệ");
                }
                
            }
        }

        private void PX_button2_Click(object sender, EventArgs e)
        {
            if (PX_button2.Text.Equals("Sửa"))
            {
                String mapx = maPhieuXuat_txt.Text.ToString();
                if (!"".Equals(mapx.Trim()))
                {
                    PX_button1.Text = "Hủy";
                    PX_button2.Text = "Lưu";
                    PhieuXuat_initTextboxStatus(true, false);
                }
            }
            else if (PX_button2.Text.Equals("Hủy"))
            {
                PX_button1.Text = "Thêm";
                PX_button2.Text = "Sửa";
                PhieuXuat_initTextboxStatus(false, false);
                PhieuXuat_clearTextBoxValues(true, true);
            }
            else if (PX_button2.Text.Equals("Lưu"))
            {
                bool result = false;
                int mapx = Convert.ToInt32(maPhieuXuat_txt.Text);
                DateTime ngayxuat = ngayXuat_datepicker.Value;
                String lydo = lyDo_txt.Text;
                try
                {
                    int maKho = Convert.ToInt32(maKho_txt.Text);
                    int maKH = Convert.ToInt32(maKH_txt.Text);
                    PhieuXuat phieuxuat = new PhieuXuat(mapx, ngayxuat, lydo, maKho, maKH);
                    result = BUS.PhieuXuat_BUS.edit(phieuxuat);
                    if (result)
                    {
                        System.Windows.Forms.MessageBox.Show("Sửa thành công!");
                    }
                    PX_button1.Text = "Thêm";
                    PX_button2.Text = "Sửa";
                    PhieuXuat_initTextboxStatus(false, false);
                    PhieuXuat_clearTextBoxValues(true, true);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Mã kho hoặc mã khách màng không hợp lệ");
                }
            }
        }

        private void CTPX_button1_Click(object sender, EventArgs e)
        {
            if (CTPX_button1.Text.Equals("Thêm"))
            {
                CTPX_button1.Text = "Lưu";
                CTPX_button2.Text = "Hủy";
                PhieuXuat_initTextboxStatus(false, true);
            }
            else if (CTPX_button1.Text.Equals("Hủy"))
            {
                CTPX_button1.Text = "Thêm";
                CTPX_button2.Text = "Sửa";
                PhieuXuat_initTextboxStatus(false, false);
                PhieuXuat_clearTextBoxValues(false, true);
            }
            else if (CTPX_button1.Text.Equals("Lưu"))
            {
                Boolean result = false;
                try
                {
                    int mapx = Convert.ToInt32(maPhieuXuat_txt.Text);
                    int maHang = Convert.ToInt32(maHang_txt.Text);
                    int soLuong = Convert.ToInt32(soLuong_txt.Text);
                    int donGia = Convert.ToInt32(donGia_txt.Text);
                    ChiTietPhieuXuat chiTiet = new ChiTietPhieuXuat(mapx, maHang, soLuong, donGia);
                    result = BUS.ChiTietPhieuXuat_BUS.add(chiTiet);
                    if (result)
                    {
                        System.Windows.Forms.MessageBox.Show("Thêm thành công!");
                    }
                    CTPX_button1.Text = "Thêm";
                    CTPX_button2.Text = "Sửa";
                    PhieuXuat_initTextboxStatus(false, false);
                    PhieuXuat_clearTextBoxValues(false, true);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Số liệu không hợp lệ");
                }
            }
        }

        private void CTPX_button2_Click(object sender, EventArgs e)
        {
            if (CTPX_button2.Text.Equals("Sửa"))
            {
                String mapx = maPhieuXuat_txt.Text.ToString();
                if (!"".Equals(mapx.Trim()))
                {
                    CTPX_button1.Text = "Hủy";
                    CTPX_button2.Text = "Lưu";
                    PhieuXuat_initTextboxStatus(false, true);
                }
            }
            else if (CTPX_button2.Text.Equals("Hủy"))
            {
                CTPX_button1.Text = "Thêm";
                CTPX_button2.Text = "Sửa";
                PhieuXuat_initTextboxStatus(false, false);
                PhieuXuat_clearTextBoxValues(false, true);
            }
            else if (CTPX_button2.Text.Equals("Lưu"))
            {
                Boolean result = false;
                try
                {
                    int mapx = Convert.ToInt32(maPhieuXuat_txt.Text);
                    if (maHang_txt.Text != "")
                    {
                        int maHang = Convert.ToInt32(maHang_txt.Text);
                        int soLuong = Convert.ToInt32(soLuong_txt.Text);
                        int donGia = Convert.ToInt32(donGia_txt.Text);
                        ChiTietPhieuXuat chiTiet = new ChiTietPhieuXuat(mapx, maHang, soLuong, donGia);
                        result = BUS.ChiTietPhieuXuat_BUS.edit(chiTiet);
                        if (result)
                        {
                            System.Windows.Forms.MessageBox.Show("Sửa thành công!");
                        }
                        CTPX_button1.Text = "Thêm";
                        CTPX_button2.Text = "Sửa";
                        PhieuXuat_initTextboxStatus(false, false);
                        PhieuXuat_clearTextBoxValues(false, true);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Xin chọn 1 bản ghi hợp lệ");
                    }
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Số liệu không hợp lệ");
                }
            }
        }
    }
}
