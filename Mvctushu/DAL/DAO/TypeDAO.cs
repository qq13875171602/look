using Mvctushu.DAL.Entitly;
using Mvctushu.DAL.Uilty;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mvctushu.DAL.DAO
{
    public class TypeDAO
    {
        public const string ADD = @"insert into Booktype(type)values(@p0)";
        public const string QUERY = @"select *  from Booktype";

        public static int Add(Booktype m)
        {
            SqlConnection conn = DBConn.DBcon();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                if (string.IsNullOrWhiteSpace(m.Type))
                {
                    throw new Exception("请填入内容");
                }
                int i = DBHelper.Update(tran, ADD, m.Type);
                tran.Commit();
                return i;
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

        public static List<Booktype> Query(Booktype m)
        {
            SqlConnection conn = DBConn.DBcon();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                List<Booktype> ol = DBHelper.QueryList(new Booktype(), tran, QUERY, m.Type);
                tran.Commit();
                return ol;
            }
            catch (Exception)
            {
                tran.Rollback();
                throw;
            }
            //finally
            //{
            //    conn.Close();
            //}
        }
    }
}