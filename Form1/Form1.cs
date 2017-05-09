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
            NhaCungCapTab_enableTextbox(false, false);
            loadBangNhaCungCap();
            loadBangNuocSanXuat();

            Enabal();
            showCTVT();
            buildingCTVT();
            Enabal_hh();
            showHangHoa();
            buildingHangHoa();
            Enabal_KH();
            showKhachHang();
            buildingKhachHang();
            Enabal_LH();
            showLoaiHang();
            buildingLoaiHang();
        }
        /// <summary>
        /// CTVT
        /// </summary>
        public void showCTVT()
        {
            dgvChiTietVatTu.DataSource = CTVT_BUS.loadCTVT();
        }
        public void clearData()
        {
            txtMaHang_CTVT.Text = "";
            txtMaPN_CTVT.Text = "";
            txtMaPX_CTVT.Text = "";
            txtLuongXuat_CTVT.Text = "";
            txtLuongNhap_CTVT.Text = "";
            txtTonDK_CTVT.Text = "";
        }
        public void Enabal()
        {
            txtMaHang_CTVT.Enabled = false;
            txtMaPN_CTVT.Enabled = false;
            txtMaPX_CTVT.Enabled = false;
            txtLuongNhap_CTVT.Enabled = false;
            txtLuongXuat_CTVT.Enabled = false;
            txtTonDK_CTVT.Enabled = false;
            dtpNgay_CTVT.Enabled = false;
        }
        public void unEnable()
        {
            txtMaHang_CTVT.Enabled = true;
            txtMaPN_CTVT.Enabled = true;
            txtMaPX_CTVT.Enabled = true;
            txtLuongNhap_CTVT.Enabled = true;
            txtLuongXuat_CTVT.Enabled = true;
            txtTonDK_CTVT.Enabled = true;
            dtpNgay_CTVT.Enabled = true;
        }
        public void buildingCTVT()
        {
            txtMaHang_CTVT.DataBindings.Clear();
            txtMaHang_CTVT.DataBindings.Add("Text", dgvChiTietVatTu.DataSource, "MA_HANG");
            txtMaPN_CTVT.DataBindings.Clear();
            txtMaPN_CTVT.DataBindings.Add("Text", dgvChiTietVatTu.DataSource, "MA_PN");
            txtMaPX_CTVT.DataBindings.Clear();
            txtMaPX_CTVT.DataBindings.Add("Text", dgvChiTietVatTu.DataSource, "MA_PX");
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
            if (btnThem_CTVT.Text == "Thêm")
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
                if (!Catch.cNullTB(txtMaHang_CTVT.Text)  & !Catch.cNullTB(txtLuongXuat_CTVT.Text) & !Catch.cNullTB(txtLuongNhap_CTVT.Text) & !Catch.cNullTB(txtTonDK_CTVT.Text))
                {
                    try
                    {
                        int mahang = Convert.ToInt32(txtMaHang_CTVT.Text.Trim());
                        int mapn = Convert.ToInt32(txtMaPN_CTVT.Text.Trim());
                        int mapx = Convert.ToInt32(txtMaPX_CTVT.Text.Trim());
                        int luongxuat = Convert.ToInt32(txtLuongXuat_CTVT.Text.Trim());
                        DateTime ngay = Convert.ToDateTime(dtpNgay_CTVT.Text.Trim());
                        int luongnhap = Convert.ToInt32(txtLuongNhap_CTVT.Text.Trim());
                        int tondk = Convert.ToInt32(txtTonDK_CTVT.Text.Trim());

                        tblChiTietVatTu ctvt = new tblChiTietVatTu(mahang, mapn, mapx, ngay, luongnhap, luongxuat, tondk);
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
                if (!Catch.cNullTB(txtMaHang_CTVT.Text) &  !Catch.cNullTB(txtLuongXuat_CTVT.Text) & !Catch.cNullTB(txtLuongNhap_CTVT.Text) & !Catch.cNullTB(txtTonDK_CTVT.Text))
                {
                    try
                    {
                        int mahang = Convert.ToInt32(txtMaHang_CTVT.Text.Trim());
                        int mapn = Convert.ToInt32(txtMaPN_CTVT.Text.Trim());
                        int mapx = Convert.ToInt32(txtMaPX_CTVT.Text.Trim());
                        int luongxuat = Convert.ToInt32(txtLuongXuat_CTVT.Text.Trim());
                        DateTime ngay = Convert.ToDateTime(dtpNgay_CTVT.Text.Trim());
                        int luongnhap = Convert.ToInt32(txtLuongNhap_CTVT.Text.Trim());
                        int tondk = Convert.ToInt32(txtTonDK_CTVT.Text.Trim());

                        tblChiTietVatTu ctvt = new tblChiTietVatTu(mahang, mapn,mapx, ngay, luongnhap, luongxuat, tondk);
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
                txtMaHang_CTVT.Enabled = false;
                txtMaPN_CTVT.Enabled = false;
                txtMaPX_CTVT.Enabled = false;
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
            if (!Catch.cNullTB(txtMaHang_CTVT.Text) )
            {
                int mahang = Convert.ToInt32(txtMaHang_CTVT.Text);
                int mapn = Convert.ToInt32(txtMaPN_CTVT.Text);
                int mapx= Convert.ToInt32(txtMaPN_CTVT.Text);
                CTVT_BUS.deleteCTVT(mahang,mapx, mapn);
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

        private void PX_button3_Click(object sender, EventArgs e)
        {
            if (maPhieuXuat_txt.Text != "")
            {
                int mapx = Convert.ToInt32(maPhieuXuat_txt.Text);
                bool result = PhieuXuat_BUS.delete(mapx);
                if (result)
                {
                    System.Windows.Forms.MessageBox.Show("Xóa thành công");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Xin chọn 1 bản ghi hợp lệ");
            }
        }

        private void CTPX_button3_Click(object sender, EventArgs e)
        {
            if (maHang_txt.Text != "")
            {
                int mahang = Convert.ToInt32(maHang_txt.Text);
                bool result = ChiTietPhieuXuat_BUS.delete(mahang);
                if (result)
                {
                    System.Windows.Forms.MessageBox.Show("Xóa thành công");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Xin chọn 1 bản ghi hợp lệ");
            }
        }

        /// <summary>
        /// Hang Hoa
        /// </summary>
        public void showHangHoa()
        {
            dgvHangHoa.DataSource = Hanghoa_BUS.loadHangHoa();
        }
        public void clearData_hh()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtNuocSX.Text = "";
            txtKichThuoc.Text = "";
            txtMaLoai.Text = "";
            txtDonvi.Text = "";
            txtLuongTon.Text = "";
            txtMaKho.Text = "";
        }
        public void Enabal_hh()
        {
            txtMaHang.Enabled = false;
            txtTenHang.Enabled = false;
            txtNuocSX.Enabled = false;
            txtKichThuoc.Enabled = false;
            txtMaLoai.Enabled = false;
            txtDonvi.Enabled = false;
            txtLuongTon.Enabled = false;
            txtMaKho.Enabled = false;
        }
        public void unEnable_hh()
        {
            txtMaHang.Enabled = true;
            txtTenHang.Enabled = true;
            txtNuocSX.Enabled = true;
            txtKichThuoc.Enabled = true;
            txtMaLoai.Enabled = true;
            txtDonvi.Enabled = true;
            txtLuongTon.Enabled = true;
            txtMaKho.Enabled = true;
        }
        public void buildingHangHoa()
        {
            txtMaHang.DataBindings.Clear();
            txtMaHang.DataBindings.Add("Text", dgvHangHoa.DataSource, "MA_HANG");
            txtTenHang.DataBindings.Clear();
            txtTenHang.DataBindings.Add("Text", dgvHangHoa.DataSource, "TEN_HANG");
            txtNuocSX.DataBindings.Clear();
            txtNuocSX.DataBindings.Add("Text", dgvHangHoa.DataSource, "MA_NUOC_SX");
            txtKichThuoc.DataBindings.Clear();
            txtKichThuoc.DataBindings.Add("Text", dgvHangHoa.DataSource, "KICH_THUOC");
            txtMaLoai.DataBindings.Clear();
            txtMaLoai.DataBindings.Add("Text", dgvHangHoa.DataSource, "MA_LOAI_HANG");
            txtDonvi.DataBindings.Clear();
            txtDonvi.DataBindings.Add("Text", dgvHangHoa.DataSource, "DON_VI_TINH");
            txtLuongTon.DataBindings.Clear();
            txtLuongTon.DataBindings.Add("Text", dgvHangHoa.DataSource, "LUONG_TON");
            txtMaKho.DataBindings.Clear();
            txtMaKho.DataBindings.Add("Text", dgvHangHoa.DataSource, "MA_KHO");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                unEnable_hh();
                clearData_hh();
                txtMaHang.Enabled = false;
                btnThem.Text = "Lưu Thêm";
                btnSua.Text = "Cannel";
                btnXoa.Enabled = false;
            }
            else if (btnThem.Text == "Lưu Thêm")
            {
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                btnXoa.Enabled = true;
                if (!Catch.cNullTB(txtTenHang.Text) & !Catch.cNullTB(txtNuocSX.Text) & !Catch.cNullTB(txtMaLoai.Text) & !Catch.cNullTB(txtMaKho.Text))
                {
                    try
                    {
                        
                        string tenhang = txtTenHang.Text.Trim();
                        int manuoc = Convert.ToInt32(txtNuocSX.Text.Trim());
                        string kichthuoc = txtKichThuoc.Text.Trim();
                        int maloai = Convert.ToInt32(txtMaLoai.Text.Trim());
                        string donvi = txtDonvi.Text.Trim();
                        int luongton = Convert.ToInt32(txtLuongTon.Text.Trim());
                        int makho = Convert.ToInt32(txtMaKho.Text.Trim());

                        Hanghoa hh = new Hanghoa(tenhang, manuoc, kichthuoc, maloai, donvi, luongton, makho);
                        Hanghoa_BUS.addHangHoa(hh);
                        showHangHoa();
                        buildingHangHoa();
                        Enabal_hh();
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
            else if (btnThem.Text == "Lưu Sửa")
            {
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                btnXoa.Enabled = true;
                if (!Catch.cNullTB(txtTenHang.Text) & !Catch.cNullTB(txtNuocSX.Text) & !Catch.cNullTB(txtMaLoai.Text) & !Catch.cNullTB(txtMaKho.Text))
                {
                    try
                    {
                        int mahang = Convert.ToInt32(txtMaHang.Text.Trim());
                        string tenhang = txtTenHang.Text.Trim();
                        int manuoc = Convert.ToInt32(txtNuocSX.Text.Trim());
                        string kichthuoc = txtKichThuoc.Text.Trim();
                        int maloai = Convert.ToInt32(txtMaLoai.Text.Trim());
                        string donvi = txtDonvi.Text.Trim();
                        int luongton = Convert.ToInt32(txtLuongTon.Text.Trim());
                        int makho = Convert.ToInt32(txtMaKho.Text.Trim());

                        Hanghoa hh = new Hanghoa(mahang,tenhang, manuoc, kichthuoc, maloai, donvi, luongton, makho);
                        Hanghoa_BUS.updateHangHoa(hh);
                        showHangHoa();
                        buildingHangHoa();
                        Enabal_hh();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                unEnable_hh();
                txtMaHang.Enabled = false;
                btnThem.Text = "Lưu Sửa";
                btnSua.Text = "Cannel";
                btnXoa.Enabled = false;

            }
            else
            {
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                btnXoa.Enabled = true;
                Enabal_hh();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!Catch.cNullTB(txtMaHang.Text))
            {
                int mahang = Convert.ToInt32(txtMaHang.Text);
              
                Hanghoa_BUS.deleteHangHoa(mahang);
                showHangHoa();
                buildingHangHoa();
                Enabal_hh();

            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu");
            }
        }
        /// <summary>
        /// KHACH HANG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void showKhachHang()
        {
            dgvKH.DataSource = KhachHang_BUS.loadKhachHang();
        }
        public void clearData_KH()
        {
            txtMaKh.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
           
        }
        public void Enabal_KH()
        {
            txtMaKh.Enabled = false;
            txtTenKH.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
          
        }
        public void unEnable_KH()
        {
            txtMaKh.Enabled = true;
            txtTenKH.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
        }
        public void buildingKhachHang()
        {
            txtMaKh.DataBindings.Clear();
            txtMaKh.DataBindings.Add("Text", dgvKH.DataSource, "MA_KH");
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", dgvKH.DataSource, "TEN_KH");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvKH.DataSource, "DIA_CHI");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dgvKH.DataSource, "DIEN_THOAI");
        }
        private void btnThem_KH_Click(object sender, EventArgs e)
        {
            if (btnThem_KH.Text == "Thêm")
            {
                unEnable_KH();
                clearData_KH();
                txtMaKh.Enabled = false;
                btnThem_KH.Text = "Lưu Thêm";
                btnSua_KH.Text = "Cannel";
                btnXoa_KH.Enabled = false;
            }
            else if (btnThem_KH.Text == "Lưu Thêm")
            {
                btnThem_KH.Text = "Thêm";
                btnSua_KH.Text = "Sửa";
                btnXoa_KH.Enabled = true;
                if (!Catch.cNullTB(txtTenKH.Text) & !Catch.cNullTB(txtDiaChi.Text) & !Catch.cNullTB(txtSDT.Text))
                {
                    try
                    {
                        string tenkh = txtTenKH.Text.Trim();
                        string sdt = txtSDT.Text.Trim();
                        string diachi = txtDiaChi.Text.Trim();

                        KhachHang kh = new KhachHang( tenkh, diachi, sdt);
                        KhachHang_BUS.addKhachHang(kh);
                        showKhachHang();
                        buildingKhachHang();
                        Enabal_KH();
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
            else if (btnThem_KH.Text == "Lưu Sửa")
            {
                btnThem_KH.Text = "Thêm";
                btnSua_KH.Text = "Sửa";
                btnXoa_KH.Enabled = true;
                if ( !Catch.cNullTB(txtTenKH.Text) & !Catch.cNullTB(txtDiaChi.Text) & !Catch.cNullTB(txtSDT.Text))
                {
                    try
                    {
                        int makh = Convert.ToInt32(txtMaKh.Text.Trim());
                        string tenkh = txtTenKH.Text.Trim();
                        string sdt = txtSDT.Text.Trim();
                        string diachi = txtDiaChi.Text.Trim();

                        KhachHang kh = new KhachHang(makh, tenkh, diachi, sdt);
                        KhachHang_BUS.updateKhachHang(kh);
                        showKhachHang();
                        buildingKhachHang();
                        Enabal_KH();
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

        private void btnSua_KH_Click(object sender, EventArgs e)
        {
            if (btnSua_KH.Text == "Sửa")
            {
                unEnable_KH();
                txtMaKh.Enabled = false;
                btnThem_KH.Text = "Lưu Sửa";
                btnSua_KH.Text = "Cannel";
                btnXoa_KH.Enabled = false;

            }
            else
            {
                btnThem_KH.Text = "Thêm";
                btnSua_KH.Text = "Sửa";
                btnXoa_KH.Enabled = true;
                Enabal_KH();
            }
        }

        private void btnXoa_KH_Click(object sender, EventArgs e)
        {
            if (!Catch.cNullTB(txtMaKh.Text))
            {
                int makh = Convert.ToInt32(txtMaKh.Text);

                KhachHang_BUS.deleteKhachHang(makh);
                showKhachHang();
                buildingKhachHang();
                Enabal_KH();

            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu");
            }
        }

        ///
        /// 
        /// LOAI HANG
        ///
        ///

        public void showLoaiHang()
        {
            dgvLoaiHang.DataSource = LoaiHang_BUS.loadLoaiHang();
        }
        public void buildingLoaiHang()
        {
            txtMaLoaiHang.DataBindings.Clear();
            txtMaLoaiHang.DataBindings.Add("Text", dgvLoaiHang.DataSource, "MA_LOAI_HANG");
            txtTenLoaiHang.DataBindings.Clear();
            txtTenLoaiHang.DataBindings.Add("Text", dgvLoaiHang.DataSource, "LOAI_HANG");
        }
        public void clearData_LH()
        {
            txtMaLoaiHang.Text = "";
            txtTenLoaiHang.Text = "";
     
        }
        public void Enabal_LH()
        {
            txtMaLoaiHang.Enabled = false;
            txtTenLoaiHang.Enabled = false;
            
        }
        public void unEnable_LH()
        {
            txtMaLoaiHang.Enabled = true;
            txtTenLoaiHang.Enabled = true;
        }
        private void btnThem_LH_Click(object sender, EventArgs e)
        {
            if (btnThem_LH.Text == "Thêm")
            {
                unEnable_LH();
                clearData_hh();
                txtMaLoaiHang.Enabled = false;
                btnThem_LH.Text = "Lưu Thêm";
                btnSua_LH.Text = "Cannel";
                btnXoa_LH.Enabled = false;
            }
            else if (btnThem_LH.Text == "Lưu Thêm")
            {
                btnThem_LH.Text = "Thêm";
                btnSua_LH.Text = "Sửa";
                btnXoa_LH.Enabled = true;
                if (!Catch.cNullTB(txtTenLoaiHang.Text))
                {
                    try
                    {

                        string tenloaihang = txtTenLoaiHang.Text.Trim();

                        LoaiHang lh = new LoaiHang(tenloaihang);
                        LoaiHang_BUS.addLoaiHang(lh);
                        showLoaiHang();
                        buildingLoaiHang();
                        Enabal_LH();
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
            else if (btnThem_LH.Text == "Lưu Sửa")
            {
                btnThem_LH.Text = "Thêm";
                btnSua_LH.Text = "Sửa";
                btnXoa_LH.Enabled = true;
                if (!Catch.cNullTB(txtTenLoaiHang.Text) )
                {
                    try
                    {
                        int maloaihang = Convert.ToInt32(txtMaLoaiHang.Text.Trim());
                        string tenloaihang = txtTenLoaiHang.Text.Trim();

                        LoaiHang lh = new LoaiHang(maloaihang, tenloaihang);
                        LoaiHang_BUS.updateLoaiHang(lh);
                        showLoaiHang();
                        buildingLoaiHang();
                        Enabal_LH();
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

        private void btnSua_LH_Click(object sender, EventArgs e)
        {
            if (btnSua_LH.Text == "Sửa")
            {
                unEnable_LH();
                txtMaLoaiHang.Enabled = false;
                btnThem_LH.Text = "Lưu Sửa";
                btnSua_LH.Text = "Cannel";
                btnXoa_LH.Enabled = false;

            }
            else
            {
                btnThem_LH.Text = "Thêm";
                btnSua_LH.Text = "Sửa";
                btnXoa_LH.Enabled = true;
                Enabal_LH();
            }
        }

        private void btnXoa_LH_Click(object sender, EventArgs e)
        {
            if (!Catch.cNullTB(txtMaLoaiHang.Text))
            {
                int malh = Convert.ToInt32(txtMaLoaiHang.Text);

                LoaiHang_BUS.deleteLoaiHang(malh);
                showLoaiHang();
                buildingLoaiHang();
                Enabal_LH();

            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu");
            }
        }

        public void NhaCungCapTab_enableTextbox(bool nhacc, bool nuocsx)
        {
            textBox16.Enabled = false;
            textBox17.Enabled = nhacc;
            textBox18.Enabled = nhacc;
            textBox19.Enabled = nhacc;
            textBox20.Enabled = nhacc;
            textBox22.Enabled = false;
            textBox21.Enabled = nuocsx;
        }

        public void NhaCungCapTab_clearTextbox(bool nhacc, bool nuocsx)
        {
            if (nhacc)
            {
                textBox16.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
            }
            if (nuocsx)
            {
                textBox22.Text = "";
                textBox21.Text = "";
            }
        }

        public void loadBangNhaCungCap()
        {
            dataGridView4.DataSource = NhaCungCap_BUS.NhaCungCap_getAll();
        }

        public void loadBangNuocSanXuat()
        {
            dataGridView5.DataSource = NuocSX_BUS.NuocSX_getAll();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CurrentIndex = dataGridView4.CurrentCell.RowIndex;

            if (dataGridView4.Rows[CurrentIndex].Cells[0].Value != null)
            {
                String manhacc = dataGridView4.Rows[CurrentIndex].Cells[0].Value.ToString();
                textBox16.Text = manhacc;
            }
            if (dataGridView4.Rows[CurrentIndex].Cells[1].Value != null)
            {
                String tennhacc = dataGridView4.Rows[CurrentIndex].Cells[1].Value.ToString();
                textBox17.Text = tennhacc;
            }
            if (dataGridView4.Rows[CurrentIndex].Cells[2].Value != null)
            {
                String diachi = dataGridView4.Rows[CurrentIndex].Cells[2].Value.ToString();
                textBox18.Text = diachi;
            }
            if (dataGridView4.Rows[CurrentIndex].Cells[3].Value != null)
            {
                String dienthoai = dataGridView4.Rows[CurrentIndex].Cells[3].Value.ToString();
                textBox19.Text = dienthoai;
            }
            if (dataGridView4.Rows[CurrentIndex].Cells[4].Value != null)
            {
                String manuoc = dataGridView4.Rows[CurrentIndex].Cells[4].Value.ToString();
                textBox20.Text = manuoc;
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CurrentIndex = dataGridView5.CurrentCell.RowIndex;

            if (dataGridView5.Rows[CurrentIndex].Cells[0].Value != null)
            {
                String manuoc = dataGridView5.Rows[CurrentIndex].Cells[0].Value.ToString();
                textBox22.Text = manuoc;
            }
            if (dataGridView5.Rows[CurrentIndex].Cells[1].Value != null)
            {
                String tennuoc = dataGridView5.Rows[CurrentIndex].Cells[1].Value.ToString();
                textBox21.Text = tennuoc;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.Text.Equals("Thêm"))
            {
                button15.Text = "Lưu";
                button14.Text = "Hủy";
                NhaCungCapTab_enableTextbox(false, true);
                NhaCungCapTab_clearTextbox(false, true);
            }
            else if (button15.Text.Equals("Hủy"))
            {
                button15.Text = "Thêm";
                button14.Text = "Sửa";
                NhaCungCapTab_enableTextbox(false, false);
                NhaCungCapTab_clearTextbox(false, true);
            }
            else if (button15.Text.Equals("Lưu"))
            {
                try
                {
                    String tennuoc = textBox21.Text;
                    if (tennuoc.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("vui lòng nhập tên nước");
                        return;
                    }
                    bool result = NuocSX_BUS.insert(tennuoc);
                    if (result)
                    {
                        System.Windows.Forms.MessageBox.Show("Thêm thành công!");
                    }
                    button15.Text = "Thêm";
                    button14.Text = "Sửa";
                    NhaCungCapTab_enableTextbox(false, false);
                    loadBangNuocSanXuat();
                    NhaCungCapTab_clearTextbox(false, true);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("không hợp lệ");
                }

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.Text.Equals("Sửa"))
            {
                String manuoc = textBox21.Text.ToString();
                if (!"".Equals(manuoc.Trim()))
                {
                    button15.Text = "Hủy";
                    button14.Text = "Lưu";
                    NhaCungCapTab_enableTextbox(false, true);
                }
            }
            else if (button14.Text.Equals("Hủy"))
            {
                button15.Text = "Thêm";
                button14.Text = "Sửa";
                NhaCungCapTab_clearTextbox(false, true);
                NhaCungCapTab_enableTextbox(false, false);
            }
            else if (button14.Text.Equals("Lưu"))
            {
                try
                {
                    if (textBox22.Text.Trim() != "")
                    {
                        String tennuoc = textBox21.Text;
                        String manuoc = textBox22.Text;
                        if (tennuoc.Trim() == "")
                        {
                            System.Windows.Forms.MessageBox.Show("vui lòng nhập tên nước");
                            return;
                        }
                        bool result = NuocSX_BUS.edit(manuoc, tennuoc);
                        if (result)
                        {
                            System.Windows.Forms.MessageBox.Show("Sửa thành công!");
                        }
                        button15.Text = "Thêm";
                        button14.Text = "Sửa";
                        PhieuXuat_initTextboxStatus(false, false);
                        PhieuXuat_clearTextBoxValues(false, true);
                        loadBangNuocSanXuat();
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

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox22.Text.Trim() != "")
            {
                String manuoc = textBox22.Text;
                bool result = NuocSX_BUS.delete(manuoc);
                if (result)
                {
                    System.Windows.Forms.MessageBox.Show("Xóa thành công!");
                }
                loadBangNuocSanXuat();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Xin chọn 1 bản ghi hợp lệ");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Text.Equals("Thêm"))
            {
                button12.Text = "Lưu";
                button11.Text = "Hủy";
                NhaCungCapTab_enableTextbox(true, false);
                NhaCungCapTab_clearTextbox(true, false);
            }
            else if (button12.Text.Equals("Hủy"))
            {
                button12.Text = "Thêm";
                button11.Text = "Sửa";
                NhaCungCapTab_enableTextbox(false, false);
                NhaCungCapTab_clearTextbox(true, false);
            }
            else if (button12.Text.Equals("Lưu"))
            {
                try
                {
                    String tennhacc = textBox17.Text;
                    if (tennhacc.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("vui lòng nhập tên nhà cung cấp");
                        return;
                    }
                    String diachi = textBox18.Text;
                    if (diachi.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("vui lòng nhập địa chỉ");
                        return;
                    }
                    String dienthoai = textBox19.Text;
                    if (dienthoai.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("vui lòng nhập số điện thoại");
                        return;
                    }
                    String manuoc = textBox20.Text;
                    if (manuoc.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("vui lòng nhập mã nước");
                        return;
                    }
                    NhaCungCap ncc = new NhaCungCap(tennhacc, diachi, dienthoai, Int32.Parse(manuoc));
                    bool result = NhaCungCap_BUS.insert(ncc);
                    if (result)
                    {
                        System.Windows.Forms.MessageBox.Show("Thêm thành công!");
                    }
                    button12.Text = "Thêm";
                    button11.Text = "Sửa";
                    NhaCungCapTab_enableTextbox(false, false);
                    loadBangNhaCungCap();
                    NhaCungCapTab_clearTextbox(true, false);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Mã nhà cung cấp không hợp lệ");
                }

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text.Equals("Sửa"))
            {
                String manuoc = textBox16.Text;
                if (!"".Equals(manuoc.Trim()))
                {
                    button12.Text = "Hủy";
                    button11.Text = "Lưu";
                    NhaCungCapTab_enableTextbox(true, false);
                }
            }
            else if (button11.Text.Equals("Hủy"))
            {
                button12.Text = "Thêm";
                button11.Text = "Sửa";
                NhaCungCapTab_clearTextbox(false, true);
                NhaCungCapTab_enableTextbox(false, false);
            }
            else if (button11.Text.Equals("Lưu"))
            {
                try
                {
                    if (textBox22.Text.Trim() != "")
                    {
                        String tennhacc = textBox17.Text;
                        if (tennhacc.Trim() == "")
                        {
                            System.Windows.Forms.MessageBox.Show("vui lòng nhập tên nhà cung cấp");
                            return;
                        }
                        String diachi = textBox18.Text;
                        if (diachi.Trim() == "")
                        {
                            System.Windows.Forms.MessageBox.Show("vui lòng nhập địa chỉ");
                            return;
                        }
                        String dienthoai = textBox19.Text;
                        if (dienthoai.Trim() == "")
                        {
                            System.Windows.Forms.MessageBox.Show("vui lòng nhập số điện thoại");
                            return;
                        }
                        String manuoc = textBox20.Text;
                        if (manuoc.Trim() == "")
                        {
                            System.Windows.Forms.MessageBox.Show("vui lòng nhập mã nước");
                            return;
                        }
                        String maNhacc = textBox16.Text;
                        NhaCungCap ncc = new NhaCungCap(Int32.Parse(maNhacc), tennhacc, diachi, dienthoai, Int32.Parse(manuoc));
                        bool result = NhaCungCap_BUS.update(ncc);
                        if (result)
                        {
                            System.Windows.Forms.MessageBox.Show("Sửa thành công!");
                        }

                        button12.Text = "Thêm";
                        button11.Text = "Sửa";
                        NhaCungCapTab_enableTextbox(false, false);
                        loadBangNhaCungCap();
                        NhaCungCapTab_clearTextbox(true, false);
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

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }

}
