using Mvctushu.DAL.Entitly;
using Mvctushu.DAL.Uilty;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvctushu.DAL.DAO
{
    public class UserDAO
    {
        public const string sql = @"select * from Tbuser where  uname=@p0 and password=@p1 ";
        public static IDictionary<string, object> Index(Tbuser m)
        {
            SqlConnection conn = DBConn.DBcon();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                if (string.IsNullOrWhiteSpace(m.Uname))
                {
                    throw new Exception("用户名不能为空");
                }
                if (string.IsNullOrWhiteSpace(m.Password))
                {
                    throw new Exception("密码不能为空");
                }
                IDictionary<string, object> dic = DBHelper.DicQueryOne(tran, sql, m.Uname, m.Password);
                if (dic.Count == 0)
                {
                   throw new Exception("用户或密码错误");
                }
                tran.Commit();
                return dic;
            }
            catch (Exception)
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}