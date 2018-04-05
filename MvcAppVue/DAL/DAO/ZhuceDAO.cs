using MvcAppVue.DAL.titly;
using MvcAppVue.DAL.Uintity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcAppVue.DAL.DAO
{
    public class ZhuceDAO
    {
        public const string ADD = @"insert into Tbuser(uname,password,nick)values(@p0,@p1,@p2)";

        public static int Add(Tbuser m)
        {
            SqlConnection conn=DBConn.conn();
            SqlTransaction tran=conn.BeginTransaction();
          try 
	      {
              int i = DBHelper.Update(tran,ADD,m.Uname,m.Password,m.Nick);
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