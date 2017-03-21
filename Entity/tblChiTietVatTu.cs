using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class tblChiTietVatTu
    {
        private int Mahang;
        private string Maphieu;
        private DateTime Ngay;
        private int Luongnhap;
        private int Luongxuat;
        private int Tondauky;

        public int Mahang1
        {
            get
            {
                return Mahang;
            }

            set
            {
                Mahang = value;
            }
        }

        public string Maphieu1
        {
            get
            {
                return Maphieu;
            }

            set
            {
                Maphieu = value;
            }
        }

        public DateTime Ngay1
        {
            get
            {
                return Ngay;
            }

            set
            {
                Ngay = value;
            }
        }

        public int Luongnhap1
        {
            get
            {
                return Luongnhap;
            }

            set
            {
                Luongnhap = value;
            }
        }

        public int Luongxuat1
        {
            get
            {
                return Luongxuat;
            }

            set
            {
                Luongxuat = value;
            }
        }

        public int Tondauky1
        {
            get
            {
                return Tondauky;
            }

            set
            {
                Tondauky = value;
            }
        }
        public tblChiTietVatTu(int mahang, string maphieu, DateTime ngay, int luongnhap, int luongxuat, int tondk)
        {
            this.Mahang = mahang;
            this.Maphieu = maphieu;
            this.Ngay = ngay;
            this.Luongnhap = luongnhap;
            this.Luongxuat = luongxuat;
            this.Tondauky = tondk;
        }
    }
}
