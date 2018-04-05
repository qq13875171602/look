using MvcAppVue.DAL.titly;
using MvcAppVue.DAL.Uintity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcAppVue.DAL.DAO
{
    public class QiandengluDAO
    {
        public const string Select = @"select * from Tbuser where uname=@p0 and password=@p1";

        public static IDictionary<string,object> Query(Tbuser m)
        {
            SqlConnection conn = DBConn.conn();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                IDictionary<string, object> i = DBHelper.QueryOneDicRow(tran,Select, m.Uname, m.Password);
                if (i==null || i.Count == 0)
                {
                    throw new Exception("登录失败");
                }
                tran.Commit();
                return i;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}