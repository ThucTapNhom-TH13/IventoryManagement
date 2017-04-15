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
using System.Data.SqlClient;

namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string strConnection = @"Data Source=LINH\SQLEXPRESS;Initial Catalog=InventoryManagerment;Integrated Security=True";
        public SqlConnection conn = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strConnection);
            conn.Open();
            loadData();
            PhieuXuat_initTextboxStatus(false, false);
            Load_BangPhieuXuat();
            NhaCungCapTab_enableTextbox(false, false);
            loadBangNhaCungCap();
            loadBangNuocSanXuat();
            Load_BangPhieuNhap();
            enablePhieuNhap(false, false, false, false);
            enableCTPN(false, false, false, false, false);

            Enabal_Kho();
            showKhoHang();
            buildingKho();
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
        /// 
        public void enablePhieuNhap(bool mapn, bool ngaynhap, bool maNCC, bool maKho)
        {
            textBox30.Enabled = mapn;
            dateTimePicker1.Enabled = ngaynhap;
            textBox28.Enabled = maNCC;
            textBox25.Enabled = maKho;
        }

        public void enableCTPN(bool mapn, bool mahang, bool soluongtheoct, bool soluongthuc, bool dongia)
        {
            textBox34.Enabled = mapn;
            textBox33.Enabled = mahang;
            textBox32.Enabled = soluongtheoct;
            textBox31.Enabled = soluongthuc;
            textBox29.Enabled = dongia;

        }

        
        
        private void btnThem_CTVT_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_chitietvattu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MAPHIEUNHAP", cmbMa_PN.Text);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MAPHIEUXUAT", cmbMa_PX.Text);
                cmd.Parameters.Add(p);

                p = new SqlParameter("@NGAY", dtpNgay_CTVT.Text);
                cmd.Parameters.Add(p);


                p = new SqlParameter("@LUONGNHAP", txtLuongNhap_CTVT.Text);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@LUONGXUAT", txtLuongXuat_CTVT.Text);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@TONDK", txtTonDK_CTVT.Text);
                cmd.Parameters.Add(p);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Thêm mới thành công");
                    loadData();
                }

                else MessageBox.Show("Không thể thêm mới");
            }
            catch
            {

            }
        }

        private void btnSua_CTVT_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_SuaPhong", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p = new SqlParameter("@MAHANG", cmbMaHang.Text);
            cmd.Parameters.Add(p);

            p = new SqlParameter("@NGAY", dtpNgay_CTVT.Text);
            cmd.Parameters.Add(p);
            p = new SqlParameter("@MAPHIEUNHAP", cmbMa_PN.Text);
            cmd.Parameters.Add(p);
            p = new SqlParameter("@MAPHIEUXUAT", cmbMa_PX.Text);
            cmd.Parameters.Add(p);

            p = new SqlParameter("@LUONGNHAP",txtLuongXuat_CTVT.Text);
            cmd.Parameters.Add(p);
            p = new SqlParameter("@LUONGXUAT", txtLuongXuat_CTVT.Text);
            cmd.Parameters.Add(p);
            p = new SqlParameter("@TONDK", txtTonDK_CTVT.Text);
            cmd.Parameters.Add(p);


            int count = cmd.ExecuteNonQuery();

            if (count > 0)
            {
                MessageBox.Show("Sửa thành công!");
                loadData();
            }
            else MessageBox.Show("Không sửa được!");
        }

        private void btnXoa_CTVT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muôn xóa bản ghi đang chọn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("sp_XoaPhong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@Ma", cmbMaHang.Text);
                cmd.Parameters.Add(p);

                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    loadData();
                   

                }
                else MessageBox.Show("Không thể xóa bản ghi hiện thời!");
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

        private void Load_BangPhieuNhap()
        {
            DataView table = PhieuNhap_BUS.PhieuNhap_getAll();
            dataGridView7.DataSource = table;
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
            cmbNuoc_sx.Text = "";
            txtKichThuoc.Text = "";
            txtDonvi.Text = "";
            txtLuongTon.Text = "";
            cmbMa_kho.Text = "";
        }
        public void Enabal_hh()
        {
            txtMaHang.Enabled = false;
            txtTenHang.Enabled = false;
            cmbNuoc_sx.Enabled = false;
            txtKichThuoc.Enabled = false;
            cmbMaloai.Enabled = false;
            txtDonvi.Enabled = false;
            txtLuongTon.Enabled = false;
            cmbMa_kho.Enabled = false;
        }
        public void unEnable_hh()
        {
            txtMaHang.Enabled = true;
            txtTenHang.Enabled = true;
            cmbNuoc_sx.Enabled = true;
            txtKichThuoc.Enabled = true;
            cmbMaloai.Enabled = true;
            txtDonvi.Enabled = true;
            txtLuongTon.Enabled = true;
            cmbMa_kho.Enabled = true;
        }
        public void buildingHangHoa()
        {
            txtMaHang.DataBindings.Clear();
            txtMaHang.DataBindings.Add("Text", dgvHangHoa.DataSource, "MA_HANG");
            txtTenHang.DataBindings.Clear();
            txtTenHang.DataBindings.Add("Text", dgvHangHoa.DataSource, "TEN_HANG");
            cmbNuoc_sx.DataBindings.Clear();
            cmbNuoc_sx.DataBindings.Add("Text", dgvHangHoa.DataSource, "MA_NUOC_SX");
            txtKichThuoc.DataBindings.Clear();
            txtKichThuoc.DataBindings.Add("Text", dgvHangHoa.DataSource, "KICH_THUOC");
            cmbMaloai.DataBindings.Clear();
            cmbMaloai.DataBindings.Add("Text", dgvHangHoa.DataSource, "MA_LOAI_HANG");
            
            txtDonvi.DataBindings.Clear();
            txtDonvi.DataBindings.Add("Text", dgvHangHoa.DataSource, "DON_VI_TINH");
            txtLuongTon.DataBindings.Clear();
            txtLuongTon.DataBindings.Add("Text", dgvHangHoa.DataSource, "LUONG_TON");
            cmbMa_kho.DataBindings.Clear();
            cmbMa_kho.DataBindings.Add("Text", dgvHangHoa.DataSource, "MA_KHO");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                errorHH.Clear();
                cmbNuoc_sx.DataBindings.Clear();
                cmbMaloai.DataBindings.Clear();
                cmbMa_kho.DataBindings.Clear();
                txtLuongTon.DataBindings.Clear();
                unEnable_hh();
                clearData_hh();
                cmbNuoc_sx.DataSource = NuocSX_BUS.NuocSX_getma().Tables[0];
                cmbNuoc_sx.DisplayMember = "MA_NUOC_SX";
                cmbNuoc_sx.ValueMember = "MA_NUOC_SX";
                cmbMa_kho.DataSource = KhoHang_BUS.getMakho().Tables[0];
                cmbMa_kho.DisplayMember = "MA_KHO";
                cmbMa_kho.ValueMember = "MA_KHO";
                cmbMaloai.DataSource = LoaiHang_BUS.getLoaiHang().Tables[0];
                cmbMaloai.DisplayMember = "MA_LOAI_HANG";
                cmbMaloai.ValueMember = "MA_LOAI_HANG";
                txtMaHang.Enabled = false;
                btnThem.Text = "Lưu";
                btnSua.Text = "Cannel";
                btnXoa.Visible = false;
            }
            else if (btnThem.Text == "Lưu")
            {
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                btnXoa.Visible = true;
                if (!Catch.cNullTB(txtTenHang.Text) & !Catch.cNullTB(cmbNuoc_sx.Text) & !Catch.cNullTB(cmbMaloai.Text) & !Catch.cNullTB(cmbMa_kho.Text))
                {
                        try
                        {

                            string tenhang = txtTenHang.Text.Trim();
                            
                            int manuoc = Convert.ToInt32(cmbNuoc_sx.Text.Trim());
                            string kichthuoc = txtKichThuoc.Text.Trim();
                            int maloai = Convert.ToInt32(cmbMaloai.Text.Trim());
                            string donvi = txtDonvi.Text.Trim();
                            int luongton = Convert.ToInt32(txtLuongTon.Text.Trim());
                            int makho = Convert.ToInt32(cmbMa_kho.Text.Trim());
                            Hanghoa hh = new Hanghoa(tenhang, manuoc, kichthuoc, maloai, donvi, luongton, makho);
                            Hanghoa_BUS.addHangHoa(hh);
                            showHangHoa();
                            buildingHangHoa();
                            Enabal_hh();
                        }
                        catch
                        {
                            int n = 0;
                            if (int.TryParse(txtKichThuoc.Text.Trim(), out n) == false)
                            {
                                errorHH.SetError(txtKichThuoc, "không được nhập chữ");
                            }
                            if (int.TryParse(txtKichThuoc.Text.Trim(), out n) == false)
                            {
                                errorHH.SetError(txtKichThuoc, "không được nhập chữ");
                            }
                            if (int.TryParse(txtLuongTon.Text.Trim(), out n) == false)
                            {
                                errorHH.SetError(txtLuongTon, "không được nhập chữ");
                            }
                        }

                }
                else
                {
                    
                    if (txtTenHang.Text.Trim().Length == 0)
                    {
                        errorHH.SetError(txtTenHang, "không được bỏ trống");
                    }
                    if (txtKichThuoc.Text.Trim().Length == 0)
                    {
                        errorHH.SetError(txtKichThuoc, "không được bỏ trống");
                    }
                    if (txtDonvi.Text.Trim().Length == 0)
                    {
                        errorHH.SetError(txtDonvi, "không được bỏ trống");
                    }
                    if (txtLuongTon.Text.Trim().Length == 0)
                    {
                        errorHH.SetError(txtLuongTon, "không được bỏ trống");
                    }
                   
                }
                Enabal_hh();
            }
            else if (btnThem.Text == "Lưu ")
            {
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                btnXoa.Visible = true;
                if (!Catch.cNullTB(txtTenHang.Text) & !Catch.cNullTB(cmbNuoc_sx.Text) & !Catch.cNullTB(cmbMaloai.Text) & !Catch.cNullTB(cmbMa_kho.Text))
                {
                    try
                    {
                        int mahang = Convert.ToInt32(txtMaHang.Text.Trim());
                        string tenhang = txtTenHang.Text.Trim();
                        int manuoc = Convert.ToInt32(cmbNuoc_sx.Text.Trim());
                        string kichthuoc = txtKichThuoc.Text.Trim();
                        int maloai = Convert.ToInt32(cmbMaloai.Text.Trim());
                        string donvi = txtDonvi.Text.Trim();
                        int luongton = Convert.ToInt32(txtLuongTon.Text.Trim());
                        int makho = Convert.ToInt32(cmbMa_kho.Text.Trim());

                        Hanghoa hh = new Hanghoa(mahang,tenhang, manuoc, kichthuoc, maloai, donvi, luongton, makho);
                        Hanghoa_BUS.updateHangHoa(hh);
                        showHangHoa();
                        buildingHangHoa();
                        Enabal_hh();
                    }
                    catch
                    {
                        int n = 0;
                        if (int.TryParse(txtKichThuoc.Text.Trim(), out n) == false)
                        {
                            errorHH.SetError(txtKichThuoc, "không được nhập chữ");
                        }
                        if (int.TryParse(txtKichThuoc.Text.Trim(), out n) == false)
                        {
                            errorHH.SetError(txtKichThuoc, "không được nhập chữ");
                        }
                        if (int.TryParse(txtLuongTon.Text.Trim(), out n) == false)
                        {
                            errorHH.SetError(txtLuongTon, "không được nhập chữ");
                        }
                    }
                }
                else
                {

                    if (txtTenHang.Text.Trim().Length == 0)
                    {
                        errorHH.SetError(txtTenHang, "không được bỏ trống");
                    }
                    if (txtKichThuoc.Text.Trim().Length == 0)
                    {
                        errorHH.SetError(txtKichThuoc, "không được bỏ trống");
                    }
                    if (txtDonvi.Text.Trim().Length == 0)
                    {
                        errorHH.SetError(txtDonvi, "không được bỏ trống");
                    }
                    if (txtLuongTon.Text.Trim().Length == 0)
                    {
                        errorHH.SetError(txtLuongTon, "không được bỏ trống");
                    }
                    
                }
                Enabal_hh();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                unEnable_hh();
                errorHH.Clear();
                cmbNuoc_sx.DataBindings.Clear();
                cmbMaloai.DataBindings.Clear();
                cmbMa_kho.DataBindings.Clear();
                txtLuongTon.DataBindings.Clear();
                cmbNuoc_sx.DataSource = NuocSX_BUS.NuocSX_getma().Tables[0];
                cmbNuoc_sx.DisplayMember = "MA_NUOC_SX";
                cmbNuoc_sx.ValueMember = "MA_NUOC_SX";
                cmbMa_kho.DataSource = KhoHang_BUS.getMakho().Tables[0];
                cmbMa_kho.DisplayMember = "MA_KHO";
                cmbMa_kho.ValueMember = "MA_KHO";
                cmbMaloai.DataSource = LoaiHang_BUS.getLoaiHang().Tables[0];
                cmbMaloai.DisplayMember = "MA_LOAI_HANG";
                cmbMaloai.ValueMember = "MA_LOAI_HANG";
                txtMaHang.Enabled = false;
                btnThem.Text = "Lưu Sửa";
                btnSua.Text = "Cannel";
                btnXoa.Visible = false;

            }
            else
            {
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                btnXoa.Visible = true;
                Enabal_hh();
                showHangHoa();
                buildingHangHoa();
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
                errorKH.Clear();
                txtMaKh.Enabled = false;
                btnThem_KH.Text = "Lưu Thêm";
                btnSua_KH.Text = "Cannel";
                btnXoa_KH.Visible = false;
            }
            else if (btnThem_KH.Text == "Lưu")
            {
                btnThem_KH.Text = "Thêm";
                btnSua_KH.Text = "Sửa";
                btnXoa_KH.Visible = true;
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
                    if (txtTenKH.Text.Trim().Length == 0)
                    {
                        errorKH.SetError(txtTenKH, "không được bỏ trống");
                    }
                  
                    if (txtSDT.Text.Trim().Length == 0)
                    {
                        errorKH.SetError(txtSDT, "không được bỏ trống");
                    }

                    if (txtDiaChi.Text.Trim().Length == 0)
                    {
                        errorKH.SetError(txtDiaChi, "không được bỏ trống");
                    }

                }
                Enabal_KH();
            }
            else if (btnThem_KH.Text == "Lưu ")
            {
                btnThem_KH.Text = "Thêm";
                btnSua_KH.Text = "Sửa";
                btnXoa_KH.Visible = true;
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

                    if (txtTenKH.Text.Trim().Length == 0)
                    {
                        errorKH.SetError(txtTenKH, "không được bỏ trống");
                    }

                    if (txtSDT.Text.Trim().Length == 0)
                    {
                        errorKH.SetError(txtSDT, "không được bỏ trống");
                    }

                    if (txtDiaChi.Text.Trim().Length == 0)
                    {
                        errorKH.SetError(txtDiaChi, "không được bỏ trống");
                    }
                }
                Enabal_KH();
            }
        }

        private void btnSua_KH_Click(object sender, EventArgs e)
        {
            if (btnSua_KH.Text == "Sửa")
            {
                unEnable_KH();
                errorKH.Clear();
                txtMaKh.Enabled = false;
                btnThem_KH.Text = "Lưu Sửa";
                btnSua_KH.Text = "Cannel";
                btnXoa_KH.Visible = false;

            }
            else
            {
                btnThem_KH.Text = "Thêm";
                btnSua_KH.Text = "Sửa";
                btnXoa_KH.Visible = true;
                Enabal_KH();
                showKhachHang();
                buildingKhachHang();
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
                clearData_LH();
                errorLH.Clear();
                txtMaLoaiHang.Enabled = false;
                btnThem_LH.Text = "Lưu Thêm";
                btnSua_LH.Text = "Cannel";
                btnXoa_LH.Visible = false;
            }
            else if (btnThem_LH.Text == "Lưu Thêm")
            {
                btnThem_LH.Text = "Thêm";
                btnSua_LH.Text = "Sửa";
                btnXoa_LH.Visible = true;
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
                    if (txtTenLoaiHang.Text.Trim().Length == 0)
                    {
                        errorLH.SetError(txtTenLoaiHang, "không được bỏ trống");
                    }
                   
                }
                Enabal_LH();
            }
            else if (btnThem_LH.Text == "Lưu Sửa")
            {
                btnThem_LH.Text = "Thêm";
                btnSua_LH.Text = "Sửa";
                btnXoa_LH.Visible = true;
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
                    if (txtTenLoaiHang.Text.Trim().Length == 0)
                    {
                        errorLH.SetError(txtTenLoaiHang, "không được bỏ trống");
                    }
                }
                Enabal_LH();
            }
        }

        private void btnSua_LH_Click(object sender, EventArgs e)
        {
            if (btnSua_LH.Text == "Sửa")
            {
                unEnable_LH();
                errorLH.Clear();
                txtMaLoaiHang.Enabled = false;
                btnThem_LH.Text = "Lưu Sửa";
                btnSua_LH.Text = "Cannel";
                btnXoa_LH.Visible = false;

            }
            else
            {
                btnThem_LH.Text = "Thêm";
                btnSua_LH.Text = "Sửa";
                btnXoa_LH.Visible = true;
                Enabal_LH();
                showLoaiHang();
                buildingLoaiHang();
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

        /// <summary>
        /// NHA CUNG CAP
        /// </summary>
        /// <param name="nhacc"></param>
        /// <param name="nuocsx"></param>
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

        ////////////////////////////////////////////
        ///              KHO HANG               ////
        ///                                     ////
        ////////////////////////////////////////////
        public void showKhoHang()
        {
            dgvKhoHang.DataSource = KhoHang_BUS.loadKhoHang();
        }
        public void clearData_Kho()
        {
            txtMaKho.Text = "";
            txtTenKho.Text = "";
            txtDienThoai.Text = "";
            txtDia_Chi.Text = "";
            txtThuKho.Text = "";

        }
        public void Enabal_Kho()
        {
            txtMaKho.Enabled = false;
            txtTenKho.Enabled = false;
            txtDienThoai.Enabled = false;
            txtDia_Chi.Enabled = false;
            txtThuKho.Enabled = false;

        }
        public void unEnable_Kho()
        {
            txtMaKho.Enabled = true;
            txtTenKho.Enabled = true;
            txtDienThoai.Enabled = true;
            txtDia_Chi.Enabled = true;
            txtThuKho.Enabled = true;
        }
        public void buildingKho()
        {
            txtMaKho.DataBindings.Clear();
            txtMaKho.DataBindings.Add("Text", dgvKhoHang.DataSource, "MA_KHO");
            txtTenKho.DataBindings.Clear();
            txtTenKho.DataBindings.Add("Text", dgvKhoHang.DataSource, "TEN_KHO");
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", dgvKhoHang.DataSource, "DIEN_THOAI");
            txtDia_Chi.DataBindings.Clear();
            txtDia_Chi.DataBindings.Add("Text", dgvKhoHang.DataSource, "DIA_CHI");
            txtThuKho.DataBindings.Clear();
            txtThuKho.DataBindings.Add("Text", dgvKhoHang.DataSource, "TEN_THU_KHO");
        }

        private void btnThemKho_Click(object sender, EventArgs e)
        {
            if (btnThemKho.Text == "Thêm")
            {
                unEnable_Kho();
                clearData_Kho();
                errorKho.Clear();
                txtMaKho.Enabled = false;
                btnThemKho.Text = "Lưu";
                btnSuaKho.Text = "Cannel";
                btnXoaKho.Visible = false;
            }
            else if (btnThemKho.Text == "Lưu")
            {
                btnThemKho.Text = "Thêm";
                btnSuaKho.Text = "Sửa";
                btnXoaKho.Visible = true;
                if (!Catch.cNullTB(txtTenKho.Text) & !Catch.cNullTB(txtDia_Chi.Text) & !Catch.cNullTB(txtDienThoai.Text) & !Catch.cNullTB(txtThuKho.Text))
                {
                    try
                    {
                        string tenkho = txtTenKho.Text.Trim();
                        string sdt = txtDienThoai.Text.Trim();
                        string diachi = txtDia_Chi.Text.Trim();
                        string thukho = txtThuKho.Text.Trim();

                        KhoHang kh = new KhoHang(tenkho, diachi, sdt, thukho);
                        KhoHang_BUS.addKhoHang(kh);
                        showKhoHang();
                        buildingKho();
                        Enabal_Kho();
                    }
                    catch
                    {
                        MessageBox.Show("Loi");
                    }
                }
                else
                {

                    if (txtTenKho.Text.Trim().Length == 0)
                    {
                        errorKho.SetError(txtTenKho, "không được bỏ trống");
                    }
                    if (txtDienThoai.Text.Trim().Length == 0)
                    {
                        errorKho.SetError(txtDienThoai, "không được bỏ trống");
                    }
                    if (txtDia_Chi.Text.Trim().Length == 0)
                    {
                        errorKho.SetError(txtDia_Chi, "không được bỏ trống");
                    }
                    if (txtThuKho.Text.Trim().Length == 0)
                    {
                        errorKho.SetError(txtThuKho, "không được bỏ trống");
                    }
                   
                }
                Enabal_Kho();
            }
            else if (btnThemKho.Text == "Lưu ")
            {
                btnThemKho.Text = "Thêm";
                btnSuaKho.Text = "Sửa";
                btnXoaKho.Visible = true;
                if (!Catch.cNullTB(txtTenKho.Text) & !Catch.cNullTB(txtDia_Chi.Text) & !Catch.cNullTB(txtDienThoai.Text) & !Catch.cNullTB(txtThuKho.Text))
                {
                    try
                    {
                        int makho = Convert.ToInt32(txtMaKho.Text.Trim());
                        string tenkho = txtTenKho.Text.Trim();
                        string sdt = txtDienThoai.Text.Trim();
                        string diachi = txtDia_Chi.Text.Trim();
                        string thukho = txtThuKho.Text.Trim();

                        KhoHang kh = new KhoHang(makho,tenkho, diachi, sdt, thukho);
                        KhoHang_BUS.updateKho(kh);
                        showKhoHang();
                        buildingKho();
                        Enabal_Kho();
                    }
                    catch
                    {
                        MessageBox.Show("Loi");
                    }
                }
                else
                {

                    if (txtTenKho.Text.Trim().Length == 0)
                    {
                        errorKho.SetError(txtTenKho, "không được bỏ trống");
                    }
                    if (txtDienThoai.Text.Trim().Length == 0)
                    {
                        errorKho.SetError(txtDienThoai, "không được bỏ trống");
                    }
                    if (txtDia_Chi.Text.Trim().Length == 0)
                    {
                        errorKho.SetError(txtDia_Chi, "không được bỏ trống");
                    }
                    if (txtThuKho.Text.Trim().Length == 0)
                    {
                        errorKho.SetError(txtThuKho, "không được bỏ trống");
                    }
                   
                }
                Enabal_Kho();
            }
        }

        private void btnSuaKho_Click(object sender, EventArgs e)
        {
            if (btnSuaKho.Text == "Sửa")
            {
                unEnable_Kho();
                txtMaKho.Enabled = false;
                btnThemKho.Text = "Lưu ";
                btnSuaKho.Text = "Cannel";
                btnXoaKho.Visible = false;

            }
            else
            {
                btnThemKho.Text = "Thêm";
                btnSuaKho.Text = "Sửa";
                btnXoaKho.Visible = true;
                Enabal_Kho();
                showKhoHang();
                buildingKho();
            }
        }

        private void btnXoaKho_Click(object sender, EventArgs e)
        {
            if (!Catch.cNullTB(txtMaKho.Text))
            {
                int makh = Convert.ToInt32(txtMaKho.Text);

                KhoHang_BUS.deleteKho(makh);
                showKhoHang();
                buildingKho();
                Enabal_Kho();

            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu");
            }
        }

        private void clearPhieuNhapData()
        {
            textBox30.Text = "";
            textBox28.Text = "";
            textBox25.Text = "";
        }

        private void button21_Click(object sender, EventArgs e) //them
        {
            if (button21.Text.Equals("Thêm"))
            {
                button21.Text = "Lưu";
                button20.Text = "Hủy";
                enablePhieuNhap(false, true, true, true);
                clearPhieuNhapData();
            }
            else if (button21.Text.Equals("Hủy"))
            {
                button21.Text = "Thêm";
                button20.Text = "Sửa";
                enablePhieuNhap(false, false, false, false);
                clearPhieuNhapData();
            }
            else if (button21.Text.Equals("Lưu"))
            {
                try
                {
                    if (textBox28.Text.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("Vui lòng nhập mã nhà cung cấp");
                        return;
                    }
                    if (textBox25.Text.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("Vui lòng nhập mã nhà kho");
                        return;
                    }
                    int mancc = Int32.Parse(textBox28.Text);
                    int makho = Int32.Parse(textBox25.Text);
                    PhieuNhap phieuNhap = new PhieuNhap(mancc, makho, dateTimePicker1.Value);
                    bool result = PhieuNhap_BUS.addPhieuNhap(phieuNhap);
                    if (result)
                    {
                        System.Windows.Forms.MessageBox.Show("Thêm phiếu nhập thành công");
                    }
                    enablePhieuNhap(false, false, false, false);
                    clearPhieuNhapData();
                    Load_BangPhieuNhap();
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("dữ liệu không hợp lệ");
                }

            }
        }

        private void button20_Click(object sender, EventArgs e) // sua
        {
            if (button20.Text.Equals("Sửa"))
            {
                button20.Text = "Lưu";
                button21.Text = "Hủy";
                enablePhieuNhap(false, true, true, true);
            }
            else if (button20.Text.Equals("Hủy"))
            {
                button21.Text = "Thêm";
                button20.Text = "Sửa";
                enablePhieuNhap(false, true, true, true);
                clearPhieuNhapData();
            }
            else if (button20.Text.Equals("Lưu"))
            {
                try
                {
                    if (textBox30.Text.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("Vui lòng một phiếu nhập để sửa");
                        return;
                    }
                    if (textBox28.Text.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("Vui lòng nhập mã nhà cung cấp");
                        return;
                    }
                    if (textBox25.Text.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("Vui lòng nhập mã nhà kho");
                        return;
                    }
                    int mapn = Int32.Parse(textBox30.Text);
                    int mancc = Int32.Parse(textBox28.Text);
                    int makho = Int32.Parse(textBox25.Text);
                    PhieuNhap phieuNhap = new PhieuNhap(mapn, mancc, makho, dateTimePicker1.Value);
                    bool result = PhieuNhap_BUS.editPhieuNhap(phieuNhap);
                    if (result)
                    {
                        System.Windows.Forms.MessageBox.Show("Sửa phiếu nhập thành công");
                    }
                    enablePhieuNhap(false, false, false, false);
                    Load_BangPhieuNhap();
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("dữ liệu không hợp lệ");
                }

            }
        }

        private void button19_Click(object sender, EventArgs e) //xoa
        {
            if (textBox30.Text.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show("Vui lòng một phiếu nhập để xóa");
                return;
            }
            int mapn = Int32.Parse(textBox30.Text);
            bool result = PhieuNhap_BUS.deletePhieuNhap(mapn);
            if (result)
            {
                System.Windows.Forms.MessageBox.Show("Xóa phiếu nhập thành công");
            }
            Load_BangPhieuNhap();
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CurrentIndex = dataGridView7.CurrentCell.RowIndex;
            int maPhieuNhap = 0;
            if (dataGridView7.Rows[CurrentIndex].Cells[0].Value != null)
            {
                String maPN = dataGridView7.Rows[CurrentIndex].Cells[0].Value.ToString();
                maPhieuNhap = Int32.Parse(maPN);
                textBox30.Text = maPN;
            }
            if (dataGridView7.Rows[CurrentIndex].Cells[2].Value != null)
            {
                String maNCC = dataGridView7.Rows[CurrentIndex].Cells[2].Value.ToString();
                textBox28.Text = maNCC;
            }
            if (dataGridView7.Rows[CurrentIndex].Cells[3].Value != null)
            {
                String maKho = dataGridView7.Rows[CurrentIndex].Cells[3].Value.ToString();
                textBox25.Text = maKho;
            }
            if (dataGridView7.Rows[CurrentIndex].Cells[1].Value != null)
            {
                String value = dataGridView7.Rows[CurrentIndex].Cells[1].Value.ToString();
                String[] datetime = value.Split('/', ' ');
                DateTime date = new DateTime(Int32.Parse(datetime[2]), Int32.Parse(datetime[0]), Int32.Parse(datetime[1]));
                dateTimePicker1.Value = date;
            }

            DataView table = PhieuNhap_detail(maPhieuNhap);
            dataGridView8.DataSource = table;
        }

        private DataView PhieuNhap_detail(int mapn)
        {
            return ChiTietPhieuNhap_BUS.chiTietPhieuNhap_find(mapn);
        }

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CurrentIndex = dataGridView8.CurrentCell.RowIndex;
            
            if (dataGridView8.Rows[CurrentIndex].Cells[0].Value != null)
            {
                String maPN = dataGridView8.Rows[CurrentIndex].Cells[0].Value.ToString();
                textBox34.Text = maPN;
            }
            if (dataGridView8.Rows[CurrentIndex].Cells[1].Value != null)
            {
                String mahang = dataGridView8.Rows[CurrentIndex].Cells[1].Value.ToString();
                textBox33.Text = mahang;
            }
            if (dataGridView8.Rows[CurrentIndex].Cells[2].Value != null)
            {
                String soluong = dataGridView8.Rows[CurrentIndex].Cells[2].Value.ToString();
                textBox32.Text = soluong;
            }
            if (dataGridView8.Rows[CurrentIndex].Cells[3].Value != null)
            {
                String soluong = dataGridView8.Rows[CurrentIndex].Cells[3].Value.ToString();
                textBox31.Text = soluong;
            }
            if (dataGridView8.Rows[CurrentIndex].Cells[4].Value != null)
            {
                String gia = dataGridView8.Rows[CurrentIndex].Cells[4].Value.ToString();
                textBox29.Text = gia;
            }
        }

        private void clearCTPNText()
        {
            textBox34.Text = "";
            textBox33.Text = "";
            textBox32.Text = "";
            textBox31.Text = "";
            textBox29.Text = "";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (button24.Text.Equals("Thêm"))
            {
                button24.Text = "Lưu";
                button23.Text = "Hủy";
                enableCTPN(false, true, true, true, true);
                clearCTPNText();
            }
            else if (button24.Text.Equals("Hủy"))
            {
                button24.Text = "Thêm";
                button23.Text = "Sửa";
                enableCTPN(false, false, false, false, false);
                clearCTPNText();
            }
            else if (button24.Text.Equals("Lưu"))
            {
                try
                {
                    if (textBox33.Text.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("vui lòng nhập mã hàng");
                        return;
                    }
                    if (textBox32.Text.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("vui lòng nhập số lượng");
                        return;
                    }
                    if (textBox31.Text.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("vui lòng nhập số lượng thực");
                        return;
                    }
                    if (textBox29.Text.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("vui lòng nhập đơn giá");
                        return;
                    }
                    int mapn = Int32.Parse(textBox30.Text);
                    int mahang = Int32.Parse(textBox33.Text);
                    int slgia = Int32.Parse(textBox32.Text);
                    int slthuc = Int32.Parse(textBox31.Text);
                    int dongia = Int32.Parse(textBox29.Text);
                    ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap(mapn, mahang, slgia, slthuc, dongia);
                    bool result = ChiTietPhieuNhap_BUS.insert(ctpn);
                    if (result)
                    {
                        System.Windows.Forms.MessageBox.Show("Thêm thành công");
                    }
                    enableCTPN(false, false, false, false, false);
                    clearCTPNText();
                    DataView table = PhieuNhap_detail(Int32.Parse(textBox30.Text));
                    dataGridView8.DataSource = table;
                    button24.Text = "Thêm";
                    button23.Text = "Sửa";
            }
                catch
            {
                System.Windows.Forms.MessageBox.Show("mã hàng không tồn tại hoặc phiếu nhập đã tồn tại, vui lòng kiểm tra lại");
                enableCTPN(false, false, false, false, false);
                clearCTPNText();
                button24.Text = "Thêm";
                button23.Text = "Sửa";
            }

        }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (button23.Text.Equals("Sửa"))
            {
                if (textBox34.Text.Trim() == "")
                {
                    System.Windows.Forms.MessageBox.Show("Chọn 1 bản ghi để sửa");
                    return;
                }
                button23.Text = "Lưu";
                button24.Text = "Hủy";
                enableCTPN(false, true, true, true, true);
            }
            else if (button23.Text.Equals("Hủy"))
            {
                button24.Text = "Thêm";
                button23.Text = "Sửa";
                enableCTPN(false, false, false, false, false);
                clearCTPNText();
            }
            else if (button23.Text.Equals("Lưu"))
            {
                try
                {
                    if (textBox33.Text.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("vui lòng nhập mã hàng");
                        return;
                    }
                    if (textBox32.Text.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("vui lòng nhập số lượng");
                        return;
                    }
                    if (textBox31.Text.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("vui lòng nhập số lượng thực");
                        return;
                    }
                    if (textBox29.Text.Trim() == "")
                    {
                        System.Windows.Forms.MessageBox.Show("vui lòng nhập đơn giá");
                        return;
                    }
                    int mapn = Int32.Parse(textBox34.Text);
                    int mahang = Int32.Parse(textBox33.Text);
                    int slgia = Int32.Parse(textBox32.Text);
                    int slthuc = Int32.Parse(textBox31.Text);
                    int dongia = Int32.Parse(textBox29.Text);
                    ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap(mapn, mahang, slgia, slthuc, dongia);
                    bool result = ChiTietPhieuNhap_BUS.update(ctpn);
                    if (result)
                    {
                        System.Windows.Forms.MessageBox.Show("Sửa thành công");
                    }
                    enableCTPN(false, false, false, false, false);
                    clearCTPNText();
                    DataView table = PhieuNhap_detail(Int32.Parse(textBox30.Text));
                    dataGridView8.DataSource = table;
                    button24.Text = "Thêm";
                    button23.Text = "Sửa";
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi không xác định");
                    enableCTPN(false, false, false, false, false);
                    clearCTPNText();
                    button24.Text = "Thêm";
                    button23.Text = "Sửa";
                }

            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox34.Text.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show("Vui lòng một phiếu nhập để xóa");
                return;
            }
            int mapn = Int32.Parse(textBox34.Text);
            bool result = ChiTietPhieuNhap_BUS.delete(mapn);
            if (result)
            {
                System.Windows.Forms.MessageBox.Show("Xóa phiếu nhập thành công");
            }
            DataView table = PhieuNhap_detail(Int32.Parse(textBox34.Text));
            dataGridView8.DataSource = table;
            clearCTPNText();
        }
        private void loadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT* FROM Chi_Tiet_Vat_Tu", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvChiTietVatTu.DataSource = dt;
        }
        private void tabPage8_Click(object sender, EventArgs e)
        {

        }
        // hien thi chi tiet vat tu len data gripview
        private void dgvChiTietVatTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbMaHang.Text = Convert.ToString(dgvChiTietVatTu.CurrentRow.Cells["MA_HANG"].Value);
            cmbMa_PN.Text = Convert.ToString(dgvChiTietVatTu.CurrentRow.Cells["MA_PN"].Value);
            cmbMa_PX.Text = Convert.ToString(dgvChiTietVatTu.CurrentRow.Cells["MA_PX"].Value);

            txtLuongNhap_CTVT.Text = Convert.ToString(dgvChiTietVatTu.CurrentRow.Cells["LUONG_NHAP"].Value);
            txtLuongXuat_CTVT.Text = Convert.ToString(dgvChiTietVatTu.CurrentRow.Cells["LUONG_XUAT"].Value);
            txtTonDK_CTVT.Text = Convert.ToString(dgvChiTietVatTu.CurrentRow.Cells["TON_DK"].Value);
        }

        private void dgvChiTietVatTu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
