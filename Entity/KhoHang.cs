using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class KhoHang
    {
        private int makho;
        private string tenkho;
        private string diachi;
        private string dienthoai;
        private string tenthukho;

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

        public string Tenkho
        {
            get
            {
                return tenkho;
            }

            set
            {
                tenkho = value;
            }
        }

        public string Diachi
        {
            get
            {
                return diachi;
            }

            set
            {
                diachi = value;
            }
        }

        public string Dienthoai
        {
            get
            {
                return dienthoai;
            }

            set
            {
                dienthoai = value;
            }
        }

        public string Tenthukho
        {
            get
            {
                return tenthukho;
            }

            set
            {
                tenthukho = value;
            }
        }
        public KhoHang(int makho, string tenkho, string diachi, string sdt, string tenthukho)
        {
            this.makho = makho;
            this.tenkho = tenkho;
            this.diachi = diachi;
            this.dienthoai = sdt;
            this.tenthukho = tenthukho;
        }
        public KhoHang(string tenkho, string diachi, string sdt, string tenthukho)
        {
            this.tenkho = tenkho;
            this.diachi = diachi;
            this.dienthoai = sdt;
            this.tenthukho = tenthukho;
        }
    }
}
