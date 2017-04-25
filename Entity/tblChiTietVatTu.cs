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
        private int Mapx;
        private int Mapn;
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

        public int Mapx1
        {
            get
            {
                return Mapx;
            }

            set
            {
                Mapx = value;
            }
        }

        public int Mapn1
        {
            get
            {
                return Mapn;
            }

            set
            {
                Mapn = value;
            }
        }

        public tblChiTietVatTu(int mahang, int mapn, int mapx, DateTime ngay, int luongnhap, int luongxuat, int tondk)
        {
            this.Mahang = mahang;
            this.Mapn = mapn;
            this.Mapx = mapx;
            this.Ngay = ngay;
            this.Luongnhap = luongnhap;
            this.Luongxuat = luongxuat;
            this.Tondauky = tondk;
        }
    }
}
