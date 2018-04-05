using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MvcAppVue.DAL.titly
{
    public class DBHelper
    {
        private static void ProgressArgs(SqlCommand comm, object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return;
            }
            for (int i = 0; i < args.Length; i++)
            {
                comm.Parameters.AddWithValue("@p" + i, args[i]);
            }
        }
        //将查询出来的列名称转换成小写
        public static Dictionary<string, string> GetReaderRowNames(SqlDataReader reader)
        {
            Dictionary<string, string> rows = new Dictionary<string, string>();
            int count = reader.FieldCount;
            for (int i = 0; i < count; i++)
            {
                rows.Add(reader.GetName(i).ToLower(), reader.GetName(i));
            }
            return rows;
        }
        //将相同的类型通过PropertyInfo来实现小写转换
        public static Dictionary<string, PropertyInfo> GetObjectPropertyInfos(object o)
        {
            Dictionary<string, PropertyInfo> infos = new Dictionary<string, PropertyInfo>();
            Type t = o.GetType();//获取它的内容且它是一个泛型也就是任意类型
            PropertyInfo[] pis = t.GetProperties();//返回一个公共的内容，理解为大家都有的内容,
            foreach (PropertyInfo info in pis)
            {
                infos.Add(info.Name.ToLower(), info);
            }
            return infos;
        }

        public static void SetSqlData(SqlDataReader reader, Object o, Dictionary<string, string> rows, Dictionary<string, PropertyInfo> pis)
        {
            foreach (string row in rows.Keys)//通过循环来获得键值
            {
                if (pis.ContainsKey(row))//判断是否有包含有相同的类型，如果有
                {
                    PropertyInfo pi = pis[row];//则两个相同的类型都交由PropertyInfo来统一
                    string name = rows[row];
                    pi.SetValue(o, reader[name]);//则将PropertyInfo中的值付给rows
                }
            }
        }

        public static T QueryOneRow<T>(T t, SqlTransaction conn, string sql, params object[] args)
        {
            Type type = t.GetType();//获取它的内容且它是一个泛型也就是任意类型
            T data = default(T);

            SqlCommand comm = new SqlCommand(sql, conn.Connection);
            comm.Transaction = conn;
            ProgressArgs(comm, args);
            SqlDataReader reader = comm.ExecuteReader();
            Dictionary<string, string> rows = GetReaderRowNames(reader);
            Dictionary<string, PropertyInfo> pis = GetObjectPropertyInfos(t);

            if (reader.Read())
            {
                data = (T)Activator.CreateInstance(type);
                SetSqlData(reader, data, rows, pis);
            }
            reader.Close();
            return data;
        }

        public static List<T> QueryRows<T>(T t, SqlTransaction conn, string sql, params object[] args)
        {
            Type type = t.GetType();
            List<T> list = new List<T>();

            SqlCommand comm = new SqlCommand(
                sql, conn.Connection);
            comm.Transaction = conn;
            ProgressArgs(comm, args);
            SqlDataReader reader = comm.ExecuteReader();
            Dictionary<string, string> rows = GetReaderRowNames(reader);
            Dictionary<string, PropertyInfo> pis = GetObjectPropertyInfos(t);
            while (reader.Read())
            {
                T data = (T)Activator.CreateInstance(type);
                SetSqlData(reader, data, rows, pis);
                list.Add(data);
            }
            reader.Close();
            return list;
        }

        public static object QueryOne(SqlTransaction conn, string sql, params object[] args)
        {

            SqlCommand comm = new SqlCommand(sql, conn.Connection);
            comm.Transaction = conn;
            ProgressArgs(comm, args);
            object r = comm.ExecuteScalar();
            return r;
        }

        public static int Update(SqlTransaction conn, string sql, params object[] args)
        {

            SqlCommand comm = new SqlCommand(sql, conn.Connection);
            comm.Transaction = conn;
            ProgressArgs(comm, args);
            int r = comm.ExecuteNonQuery();
            return r;

        }

        public static IList<IDictionary<string, object>> QueryDicRows(
            SqlTransaction conn, string sql, params object[] args)
        {
            IList<IDictionary<string, object>> list = new List<IDictionary<string, object>>();

            SqlCommand comm = new SqlCommand(
                sql, conn.Connection);
            comm.Transaction = conn;
            ProgressArgs(comm, args);
            SqlDataReader reader = comm.ExecuteReader();
            Dictionary<string, string> rows = GetReaderRowNames(reader);

            while (reader.Read())
            {
                IDictionary<string, object> dic = new Dictionary<string, object>();
                foreach (string key in rows.Keys)
                {
                    //预防查询的字段重名问题
                    if (!dic.ContainsKey(key))
                    {
                        //不存在才加
                        dic.Add(key, reader[rows[key]]);
                    }
                }
                list.Add(dic);
            }
            reader.Close();
            return list;
        }

        public static IDictionary<string, object>
             QueryOneDicRow(SqlTransaction conn,
            string sql, params object[] args)
        {
            //查询单行记录，委托方法
            IList<IDictionary<string, object>> rows
                = QueryDicRows(conn, sql, args);
            //查询到一行记录到情况，正确期待值
            if (rows.Count == 1)
            {
                return rows[0]; //返回第一行（唯一行）
            }
            else
            {
                //只要不是一行，都认为是错误的结果
                //返回一个空集合
                return new Dictionary<string, object>();
            }
        }
    }
}