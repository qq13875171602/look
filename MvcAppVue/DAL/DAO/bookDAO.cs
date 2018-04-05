using MvcAppVue.DAL.titly;
using MvcAppVue.DAL.Uintity;
using MvcAppVue.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcAppVue.DAL.DAO
{
    public class bookDAO
    {
        public const string ADD = @"insert into Book(tid,bname,author,press)values(@p0,@p1,@p2,@p3)";
        public const string COUNT = @"select count(*) from Book where ifbname='y'";
        public const string QUERY = @"select top {0} k.bid,k.bname,k.author,k.press,k.ifbname,t.type,t.tid ,convert(varchar(50),k.datatime,120) 'datatime' from Book k 
  inner join Booktype t on k.tid=t.tid
  where k.ifbname='y'  and k.bid not in(select top {1} bid from book where ifbname='y' )";
        public const string DELETE = @"delete from Book where bid=@p0";
        public const string UPDATE = @"update Book set tid=@p0,bname=@p1,author=@p2,press=@p3,ifbname=@p4 where bid=@p5";
        public const string SELECT = @"select * from Book where ifbname='y' {0}";

        public static int Add(Book m)
        {
            SqlConnection conn = DBConn.conn();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                if (string.IsNullOrWhiteSpace(m.Bname))
                {
                    throw new Exception("请输入用户名");
                }
                if (string.IsNullOrWhiteSpace(m.Author))
                {
                    throw new Exception("请输入作者");
                }
                if (string.IsNullOrWhiteSpace(m.Press))
                {
                    throw new Exception("请输入出版社");
                }
                int i = DBHelper.Update(tran, ADD, m.Tid, m.Bname, m.Author, m.Press);
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

        public static IList<IDictionary<string, object>> Query(Page g)
        {
            SqlConnection conn = DBConn.conn();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                g.Count = (int)DBHelper.QueryOne(tran, COUNT);
                IList<IDictionary<string, object>> dic = DBHelper.QueryDicRows(tran,string.Format(QUERY,g.PageSize, g.Skip));
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

        public static int DEteup(Book m)
        {
            SqlConnection conn = DBConn.conn();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                int i = DBHelper.Update(tran, DELETE, m.Bid);
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

        public static int Update(Book m)
        {
            SqlConnection conn = DBConn.conn();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                int i = DBHelper.Update(tran, UPDATE, m.Tid, m.Bname, m.Author, m.Press, m.Ifbname, m.Bid);
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

        public static IList<IDictionary<string, object>> list(Book b)
        {
            SqlConnection conn = DBConn.conn();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string where = "";
                List<object> user = new List<object>();
                if (!string.IsNullOrWhiteSpace(b.Bname))
                {
                    where += " and bname like @p" + user.Count;
                    user.Add("%" + b.Bname + "%");
                }
                string sql = string.Format(SELECT, where);
                IList<IDictionary<string, object>> op = DBHelper.QueryDicRows(tran, sql, user.ToArray<object>());
                tran.Commit();
                return op;
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