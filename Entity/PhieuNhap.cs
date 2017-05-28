using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PhieuNhap
    {
        private int maPhieuNhap;
        private int maNCC;
        private int maKho;
        private DateTime ngayNhap;

        public int MaPhieuNhap
        {
            get
            {
                return maPhieuNhap;
            }

            set
            {
                maPhieuNhap = value;
            }
        }

        public int MaNCC
        {
            get
            {
                return maNCC;
            }

            set
            {
                maNCC = value;
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

        public DateTime NgayNhap
        {
            get
            {
                return ngayNhap;
            }

            set
            {
                ngayNhap = value;
            }
        }

        public PhieuNhap(int mapn, int mancc, int makho, DateTime ngaynhap)
        {
            this.MaPhieuNhap = mapn;
            this.MaNCC = mancc;
            this.MaKho = makho;
            this.NgayNhap = ngaynhap;
        }

        public PhieuNhap(int mancc, int makho, DateTime ngaynhap)
        {
            this.MaNCC = mancc;
            this.MaKho = makho;
            this.NgayNhap = ngaynhap;
        }

    }
}
