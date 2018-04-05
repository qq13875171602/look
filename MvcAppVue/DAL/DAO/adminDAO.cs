using MvcAppVue.DAL.titly;
using MvcAppVue.DAL.Uintity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcAppVue.DAL.DAO
{
    public class adminDAO
    {
        public const string QUERY = @"select * from Tbuser where uname=@p0 and password=@p1 and ifuname='n'";

        public static IDictionary<string, object> dic(Tbuser m)
        {
            SqlConnection conn = DBConn.conn();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                IDictionary<string, object> dicz = DBHelper.QueryOneDicRow(tran, QUERY,m.Uname,m.Password);
                if (dicz.Count == 0)
                {
                    throw new Exception("账号密码错误");
                }
                tran.Commit();
                return dicz;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}