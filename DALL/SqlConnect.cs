﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;
namespace DALL
{
    public class SqlConnect
    {
        public static SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP - 6ABMGHP\SQLEXPRESS; Initial Catalog = InventoryManagerment; Integrated Security = True");
            return conn;
        }
    }
}
