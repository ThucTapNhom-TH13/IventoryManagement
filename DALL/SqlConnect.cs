using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DALL
{
    public class SqlConnect
    {
        public static SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-MTOCE95;Initial Catalog=InventoryManagerment;Persist Security Info=True;User ID=sa;Password=linh1996");
            return conn;
        }
    }

}