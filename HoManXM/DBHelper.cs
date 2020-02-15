using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace HoManXM
{
    class DBHelper
    {
        private static string connStr = "Data Source=.;Initial Catalog=HoManDB;Integrated Security=True";
        //链接数据库
        public static SqlConnection GetConn()
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }
        //增删改
        public static int ExecuteNonQuery(string sql)
        {  
            int i = 0;
            SqlCommand com =null;
            try
            {
                com = new SqlCommand(sql, GetConn());
                i = com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                com.Connection.Close();
            }
            return i;
        }
        //返回单个值
        public static Object ExecuteScalar(string sql)
        {
            Object obj = null;
            SqlCommand com = null;
            try
            {
                com = new SqlCommand(sql, GetConn());
                obj = com.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                com.Connection.Close();
            }
            return obj;
        }
        // 查询
        public static SqlDataReader ExecutReader(string sql)
        {
            SqlDataReader reader = null;
            SqlCommand com = null;
            try
            {
                com = new SqlCommand(sql, GetConn());
                reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return reader;
        }
        //DataTable
        public static DataTable GetTable(string sql)
        {
            DataTable dt = null;
            SqlDataAdapter adapter = null;
            try
            {
                dt = new DataTable();
                adapter = new SqlDataAdapter(sql, GetConn());
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
            //防注入
            /// <summary>
            /// 参数名称       --参数作用
            /// biao             --数据库的表名
            /// zhanghao    --数据库要比对的账号的Name
            /// mima           --数据库要必将对的密码的Name
            /// a                  --用户输入的账号
            /// b                  --用户输入的密码
            /// </summary>
            /// <param name="zhanghao"></param>
            /// <param name="mima"></param>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static SqlDataReader Parameter(string biao,string zhanghao,string mima,string a,string b)
        {
            SqlDataReader reader = null;
            SqlCommand com = null;
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@a",a),
                     new SqlParameter("@b",b)
                };
                string sql = string.Format("select * from {0} where {1} = @a and {2} =@b",biao,zhanghao,mima);
                com = new SqlCommand(sql,GetConn());
                com.Parameters.AddRange(param);
                reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return reader;
        }


    }
}
