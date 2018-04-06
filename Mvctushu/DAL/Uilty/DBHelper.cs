using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mvctushu.DAL.Uilty
{
    public class DBHelper
    {
        public static void Message(SqlCommand cmd, params object[] age){
            if (age == null || age.Length == 0)
            {
                return;
            }
            for (int i = 0; i < age.Length; i++)
            {
                cmd.Parameters.AddWithValue("@p" + i, age[i]);
            }
        }

        //将查询出来的结果装换成小写
        public static Dictionary<string, string> DicRowtoley(SqlDataReader raeder)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            int ic = raeder.FieldCount;
            for (int i = 0; i < ic; i++)
            {
                dic.Add(raeder.GetName(i).ToLower(), raeder.GetName(i));
            }
            return dic;
        }

        //将查询出来的结果做比较dic有没有包含info如果有将重新赋值
        public static void SqlData(SqlDataReader reader,object o, Dictionary<string, string> dic, Dictionary<string, PropertyInfo> info)
        {
            foreach (string ic in dic.Keys)
            {
                if (info.ContainsKey(ic))
                {
                    PropertyInfo infos = info[ic];
                    string name = dic[ic];
                    infos.SetValue(o, reader[name]);
                }
            }
        }

        public static Dictionary<string, PropertyInfo> GetPropertyInfos(object o)
        {
            Dictionary<string, PropertyInfo> infos = new Dictionary<string, PropertyInfo>();
            Type t = o.GetType();
            PropertyInfo[] info = t.GetProperties();
            foreach (PropertyInfo y in info)
            {
                infos.Add(y.Name.ToLower(), y);
            }
            return infos;
        }

        //查重名的单值
        public static T Queryone<T>(T t,SqlTransaction tran, string sql, params object[] age)
        {
            Type ty = t.GetType();
            T ta=default(T);
            SqlCommand cmd = new SqlCommand(sql, tran.Connection);
            cmd.Transaction = tran;
            Message(cmd, age);
            SqlDataReader reader = cmd.ExecuteReader();
            Dictionary<string, string> dicc = DicRowtoley(reader);
            Dictionary<string, PropertyInfo> infos = GetPropertyInfos(t);
           if(reader.Read())
            {
                ta = (T)Activator.CreateInstance(ty);
                SqlData(reader, ta, dicc, infos);
            }
           reader.Close();
           return ta;
        }

        //查重名的数组
        public static List<T> QueryList<T>(T t, SqlTransaction tran, string sql, params object[] age)
        {
            Type ty = t.GetType();
            List<T> list = new List<T>();
            SqlCommand cmd = new SqlCommand(sql, tran.Connection);
            cmd.Transaction = tran;
            Message(cmd, age);
            SqlDataReader reader = cmd.ExecuteReader();
            Dictionary<string, string> dic = DicRowtoley(reader);
            Dictionary<string, PropertyInfo> infos = GetPropertyInfos(t);
            while (reader.Read())
            {
                T data = (T)Activator.CreateInstance(ty);
                SqlData(reader, data, dic, infos);
                list.Add(data);
            }
            reader.Close();
            return list;
        }

        public static IList<IDictionary<string, object>> DicQueryList(SqlTransaction tran, string sql, params object[] age)
        {
            IList<IDictionary<string, object>> list = new List<IDictionary<string, object>>();
            SqlCommand cmd = new SqlCommand(sql, tran.Connection);
            cmd.Transaction = tran;
            Message(cmd, age);
            SqlDataReader reder = cmd.ExecuteReader();
            Dictionary<string, string> dic = DicRowtoley(reder);
            while (reder.Read())
            {
                IDictionary<string, object> dicz = new Dictionary<string, object>();
                foreach (string z in dic.Keys)
                {
                    if (!dicz.ContainsKey(z))
                    {
                        dicz.Add(z, reder[dic[z]]);
                    }
                }
                list.Add(dicz);
            }
            reder.Close();
            return list;
        }

        public static IDictionary<string, object> DicQueryOne(SqlTransaction tran, string sql, params object[] age)
        {
            IList<IDictionary<string, object>> llst = DicQueryList(tran, sql, age);
            if (llst.Count == 1)
            {
                return llst[0];
            }
            else {
                return new Dictionary<string, object>();
            }
        }

        public static int Update(SqlTransaction tran, string sql, params object[] age) 
        {
            SqlCommand cmd = new SqlCommand(sql,tran.Connection);
            cmd.Transaction = tran;
            Message(cmd, age);
            int i = cmd.ExecuteNonQuery();
            return i;
        }

        public static object Count(SqlTransaction tran, string sql, params object[] age)
        {
            SqlCommand cmd = new SqlCommand(sql, tran.Connection);
            cmd.Transaction = tran;
            Message(cmd, age);
            object o = cmd.ExecuteScalar();
            return o;
        }
    }
}