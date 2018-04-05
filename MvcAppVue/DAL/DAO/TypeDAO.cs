using MvcAppVue.DAL.titly;
using MvcAppVue.DAL.Uintity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcAppVue.DAL.DAO
{
    public class TypeDAO
    {
        public const string ADD = @"insert into Booktype(type)values(@p0)";
        public const string QUERY = @"select * from Booktype";

        public static int Add(Booktype m)
        {
            SqlConnection conn = DBConn.conn();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                int i= DBHelper.Update(tran, ADD, m.Type);
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

        public static IList<IDictionary<string, object>> list()
        {
            SqlConnection conn = DBConn.conn();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                IList<IDictionary<string, object>> dic = DBHelper.QueryDicRows(tran, QUERY);
                if (dic.Count == 0)
                {
                    throw new Exception("查询失败");
                }
                tran.Commit();
                return dic;
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