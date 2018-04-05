using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcAppVue.DAL.titly
{
    public class DBConn
    {
        public const string connz = @"Data Source=LIUWEI-PC\WOAINI;Initial Catalog=MVCshop;User ID=sa;password=123456";

        public static SqlConnection conn()
        {
            SqlConnection conn = new SqlConnection(connz);
            conn.Open();
            return conn;
        }
    }
}