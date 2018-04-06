using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mvctushu.DAL.Uilty
{
    public class DBConn
    {
        public const string conn = @"Data Source=LIUWEI-PC\WOAINI;Initial Catalog=MVCshop;User ID=sa;password=123456";

        public static SqlConnection DBcon() {
            SqlConnection connz = new SqlConnection(conn);
            connz.Open();
            return connz;
        }
    }
}