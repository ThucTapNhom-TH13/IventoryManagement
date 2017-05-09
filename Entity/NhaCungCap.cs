using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NhaCungCap
    {
        public int maNhaCC;
        public string tenNhaCC;
        public string dienthoai;
        public string diachi;
        public int maNuoc;

        public NhaCungCap(string ten, string diachi, string dt, int manuoc)
        {
            this.tenNhaCC = ten;
            this.dienthoai = dt;
            this.diachi = diachi;
            this.maNuoc = manuoc;
        }

        public NhaCungCap(int ma, string ten, string diachi, string dt, int manuoc)
        {
            this.maNhaCC = ma;
            this.tenNhaCC = ten;
            this.dienthoai = dt;
            this.diachi = diachi;
            this.maNuoc = manuoc;
        }
    }
}
