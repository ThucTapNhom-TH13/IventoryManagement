using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class KhachHang
    {
        private int makh;
        private string tenkh;
        private string diachi;
        private string dienthoai;

        public int Makh
        {
            get
            {
                return makh;
            }

            set
            {
                makh = value;
            }
        }

        public string Tenkh
        {
            get
            {
                return tenkh;
            }

            set
            {
                tenkh = value;
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
        public KhachHang(int makh, string tenkh, string diachi, string dt)
        {
            this.makh = makh;
            this.tenkh = tenkh;
            this.diachi = diachi;
            this.dienthoai = dt;
        }
    }
}
