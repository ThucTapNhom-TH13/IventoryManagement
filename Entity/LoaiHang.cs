using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LoaiHang
    {
        private int malh;
        private string tenlh;

        public int Malh
        {
            get
            {
                return malh;
            }

            set
            {
                malh = value;
            }
        }

        public string Tenlh
        {
            get
            {
                return tenlh;
            }

            set
            {
                tenlh = value;
            }
        }
        public LoaiHang(int malh, string tenlh)
        {
            this.malh = malh;
            this.tenlh = tenlh;
        }
        public LoaiHang( string tenlh)
        {
            
            this.tenlh = tenlh;
        }
    }
}
