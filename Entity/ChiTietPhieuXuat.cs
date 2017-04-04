using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ChiTietPhieuXuat
    {
        private int maPhieuXuat;
        private int maHang;
        private int soLuong;
        private int donGia;


        public ChiTietPhieuXuat(int mapx, int mahang, int sl, int dongia) {
            this.maPhieuXuat = mapx;
            this.maHang = mahang;
            this.soLuong = sl;
            this.donGia = dongia;
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

        public int MaHang
        {
            get
            {
                return maHang;
            }

            set
            {
                maHang = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        public int DonGia
        {
            get
            {
                return donGia;
            }

            set
            {
                donGia = value;
            }
        }
    }
}
