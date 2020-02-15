using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HoManXM
{
    public partial class YuDingBiDui : Form
    {
        public YuDingBiDui()
        {
            InitializeComponent();
        }
        private void YuDingBiDui_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Hao);
        }
        private void btnQuXiao_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string  Hao { get; set; }
        private void btnQueDing_Click(object sender, EventArgs e)
        {
            string sqls = $"select * from reserve where reserve_phone = '{txtShouJiHao.Text.Trim()}'";
            SqlDataReader readers = DBHelper.ExecutReader(sqls);
            if (readers.Read())
            {
                KaiFang(Hao);
                this.Close();
            }
            else
            {
                MessageBox.Show("手机号错误！！");
                return;
            }
            readers.Close();
           
        }

        public void KaiFang( string Hao)
        {
            //MessageBox.Show("Test");
            string sql = $"select * from reserve where reserve_bianhao = '{Hao}'";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                RuZhuYu zhu = new RuZhuYu();
                zhu.Yn = true;
                zhu.FangHao = reader[5].ToString();
                PublicClass.Name = reader[1].ToString();
                PublicClass.Fjian = reader[5].ToString();
                //MessageBox.Show(PublicClass.Name +"--"+PublicClass.Fjian);
                zhu.ShowDialog();
                string sqlGai = $"update reserve set reserve_ZhuangTai = 2 where reserve_bianhao = {Hao}";
                DBHelper.ExecuteNonQuery(sqlGai);
                this.Close();
            }
            reader.Close();
        }

    }
}
