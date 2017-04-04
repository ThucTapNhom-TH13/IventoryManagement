using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PhieuXuat
    {
        private int maPhieuXuat;
        private DateTime ngayXuat;
        private String lyDo;
        private int maKho;
        private int maKhachHang;

        public PhieuXuat(int maPhieuXuat, DateTime ngayXuat, String lyDo, int maKho, int maKhachHang)
        {
            this.maPhieuXuat = maPhieuXuat;
            this.ngayXuat = ngayXuat;
            this.lyDo = lyDo;
            this.maKho = maKho;
            this.maKhachHang = maKhachHang;
        }

        public PhieuXuat(DateTime ngayXuat, String lyDo, int maKho, int maKhachHang)
        {
            this.ngayXuat = ngayXuat;
            this.lyDo = lyDo;
            this.maKho = maKho;
            this.maKhachHang = maKhachHang;
        }

        public int MaPhieuXuat
        {
            get
            {
                return maPhieuXuat;
            }

            set
            {
                maPhieuXuat = value;
            }
        }

        public DateTime NgayXuat
        {
            get
            {
                return ngayXuat;
            }

            set
            {
                ngayXuat = value;
            }
        }

        public string LyDo
        {
            get
            {
                return lyDo;
            }

            set
            {
                lyDo = value;
            }
        }

        public int MaKho
        {
            get
            {
                return maKho;
            }

            set
            {
                maKho = value;
            }
        }

        public int MaKhachHang
        {
            get
            {
                return maKhachHang;
            }

            set
            {
                maKhachHang = value;
            }
        }
    }
}
