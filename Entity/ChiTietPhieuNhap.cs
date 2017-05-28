using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ChiTietPhieuNhap
    {
        private int maPhieuNhap;
        private int maHang;
        private int slTheoChungTu;
        private int slThuc;
        private int donGia;

        public ChiTietPhieuNhap(int mapn, int mahang, int sltheochungtu, int slthuc, int dongia)
        {
            this.maPhieuNhap = mapn;
            this.maHang = mahang;
            this.slTheoChungTu = sltheochungtu;
            this.slThuc = slthuc;
            this.donGia = dongia;
        }

        public ChiTietPhieuNhap(int mahang, int sltheochungtu, int slthuc, int dongia)
        {
            this.maHang = mahang;
            this.slTheoChungTu = sltheochungtu;
            this.slThuc = slthuc;
            this.donGia = dongia;
        }

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

        public int SlTheoChungTu
        {
            get
            {
                return slTheoChungTu;
            }

            set
            {
                slTheoChungTu = value;
            }
        }

        public int SlThuc
        {
            get
            {
                return slThuc;
            }

            set
            {
                slThuc = value;
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
