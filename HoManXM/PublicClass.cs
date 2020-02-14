using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoManXM
{
    class PublicClass
    {

        public static string MiM{ get; set; }

        public static Double Money { get; set; }
        public static string YaJin { get; set; }
        public static string ShenF { get; set; }
        public static int Tian { get; set; }
        public static string FangH { get; set; }
        public static string JiFen { get; set; }
        public static Double SUM { get; set; }
        public static string SEX { get; set; }
        public static string NAME { get; set; }
        public static string SHEN { get; set; }
        public static int FangLei { get; set; }
        public static string RiQi { get; set; }
        public static bool Fa { get; set; }
        public static string FaLei { get; set; }
        public static string FangTai { get; set; }

        //同行
        public static bool To { get; set; }
        public static bool Check { get; set; }
        public static string KeZhu { get; set; }

        public static string[] CFH { get; set; }


        //管理员
        public static string GuanLiYuan { get; set; }
        public static string Level { get; set; }

        //同行人员
        public static string[] ShenFu { get; set; }
        public static string[] NmaeFu { get; set; }
        //
        public static string Name { get; set; }
        public static string Fjian { get; set; }
        //会员级别

        public bool JIn { get; set; }

        public static void HuiYuan(string shen,string f)
        {
            string bb = $@"
	 select member.*,kuanJi.kuanJi_level from 
	member inner join kuanJi
	on(member.member_id = kuanJi.kuanJi_id)
";
          
            string aa = $"select * from userscore where userscore_shenfenid  = '{shen}'";
            SqlDataReader reader = DBHelper.ExecutReader(aa);
            SqlDataReader reader2 = DBHelper.ExecutReader(bb);
            while (reader.Read())
            {
                while (reader2.Read())
                {
                    double fen = Convert.ToInt32(reader[2].ToString()) + Convert.ToDouble(f);
                    string hao2 = $"update userscore set userscore_jifen= {fen} where userscore_shenfenid = '{shen}'";
                    DBHelper.ExecuteNonQuery(hao2);
                    if (Convert.ToInt32(reader[2]) >= Convert.ToInt32(reader2[3]))
                    {
                    string hao = $"update userscore set userscore_dengji = {Convert.ToInt32(reader2[0].ToString())} where userscore_shenfenid = '{shen}'";
                    DBHelper.ExecuteNonQuery(hao);
                    string hao3 = $"update memberuser set memberuser_dengji = {Convert.ToInt32(reader2[0].ToString())} where memberuser_shenfen = '{shen}'";
                    DBHelper.ExecuteNonQuery(hao3);
                    }
                }
            }
            reader.Close();
            reader2.Close();
        }



    }
}
