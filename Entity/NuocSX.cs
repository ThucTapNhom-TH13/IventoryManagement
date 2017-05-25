using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NuocSX
    {
        private int manuoc;
        private string tennuoc;

        public int Manuoc
        {
            get
            {
                return manuoc;
            }

            set
            {
                manuoc = value;
            }
        }

        public string Tennuoc
        {
            get
            {
                return tennuoc;
            }

            set
            {
                tennuoc = value;
            }
        }
        public NuocSX(int ma, string ten)
        {
            this.manuoc = ma;
            this.tennuoc = ten;
        }
    }
}
