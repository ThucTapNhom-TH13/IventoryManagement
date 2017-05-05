using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Hanghoa
    {
        private int mahang;
        private string tenhang;
        private int manuocsx;
        private string kichthuoc;
        private int maloaihang;
        private string donvitinh;
        private int luongton;
        private int makho;

        public int Mahang
        {
            get
            {
                return mahang;
            }

            set
            {
                mahang = value;
            }
        }

        public string Tenhang
        {
            get
            {
                return tenhang;
            }

            set
            {
                tenhang = value;
            }
        }

        public int Manuocsx
        {
            get
            {
                return manuocsx;
            }

            set
            {
                manuocsx = value;
            }
        }

        public string Kichthuoc
        {
            get
            {
                return kichthuoc;
            }

            set
            {
                kichthuoc = value;
            }
        }

        public int Maloaihang
        {
            get
            {
                return maloaihang;
            }

            set
            {
                maloaihang = value;
            }
        }

        public string Donvitinh
        {
            get
            {
                return donvitinh;
            }

            set
            {
                donvitinh = value;
            }
        }

        public int Luongton
        {
            get
            {
                return luongton;
            }

            set
            {
                luongton = value;
            }
        }

        public int Makho
        {
            get
            {
                return makho;
            }

            set
            {
                makho = value;
            }
        }
        public Hanghoa(int mahang, string tenhang, int manuoc, string kichthuoc, int maloai, string donvi,int luongton,int makho)
        {
            this.mahang = mahang;
            this.tenhang = tenhang;
            this.manuocsx = manuoc;
            this.kichthuoc = kichthuoc;
            this.maloaihang = maloai;
            this.donvitinh = donvi;
            this.luongton = luongton;
            this.makho = makho;
        }
    }
}
