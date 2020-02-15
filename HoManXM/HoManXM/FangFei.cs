using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoManXM
{
    public partial class FangFei : Form
    {
        public FangFei()
        {
            InitializeComponent();
        }
        //PublicClass PublicClass = new PublicClass();
        //总价
        private void FangFei_Load(object sender, EventArgs e)
        {

            txtFangFei.Text = PublicClass.Money.ToString();
            txtYaJin.Text = PublicClass.YaJin;
            txtTian.Text = PublicClass.Tian.ToString();

            string sql = $@"   select memberuser.memberuser_shenfen,member.member_level,member.member_zhekou,userscore.userscore_jifen,phone.phone_id,memberuser.memberuser_name,phone.phone_tai from 
     memberuser inner join member
     on(memberuser.memberuser_dengji = member.member_id)
	 inner join userscore
	 on(memberuser.memberuser_shenfen = userscore.userscore_shenfenid)
	 inner join phone
	 on(memberuser.memberuser_shenfen = phone_shenfen)
    where memberuser.memberuser_shenfen = '{PublicClass.ShenF}'
    and  phone.phone_tai ='{"可用"}'
";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {

                txtHuiYuan.Text = reader[1].ToString();
                txtZhekou.Text = reader[2].ToString();

            double fang = Convert.ToDouble(txtFangFei.Text);
            double tianshu = Convert.ToDouble(txtTian.Text);
            double zhe = Convert.ToDouble(txtZhekou.Text);
            double ya = Convert.ToDouble(txtYaJin.Text);
            PublicClass.SUM = (fang * tianshu) * zhe + ya;
            txtSum.Text = PublicClass.SUM.ToString();
            VoiceHelper.SpeakAsync(txtSum1.Text + txtSum.Text + txtSum3.Text);
            }
            else
            {
                double fang = 0.0;
                double tianshu = 0.0;
                double ya = 0.0;
                string sql2 = $@"   select memberuser.memberuser_shenfen,member.member_level,member.member_zhekou,userscore.userscore_jifen,phone.phone_id,memberuser.memberuser_name,phone.phone_tai from 
     memberuser inner join member
     on(memberuser.memberuser_dengji = member.member_id)
	 inner join userscore
	 on(memberuser.memberuser_shenfen = userscore.userscore_shenfenid)
	 inner join phone
	 on(memberuser.memberuser_shenfen = phone_shenfen)
    where memberuser.memberuser_shenfen = '{ PublicClass.ShenF}'
    and  phone.phone_tai ='{"禁用"}'
";
                SqlDataReader reader2 = DBHelper.ExecutReader(sql2);
                if (reader2.Read())
                {
                    txtHuiYuan.Text = reader2[6].ToString();
                    fang = Convert.ToDouble(txtFangFei.Text);
                     tianshu = Convert.ToDouble(txtTian.Text);
                    ya = Convert.ToDouble(txtYaJin.Text);
                    PublicClass.SUM = (fang * tianshu) + ya;
                    txtSum.Text = PublicClass.SUM.ToString();
                    VoiceHelper.SpeakAsync(txtSum1.Text + txtSum.Text + txtSum3.Text);
                    reader2.Close();
                    return;
                }
                 fang = Convert.ToDouble(txtFangFei.Text);
                 tianshu = Convert.ToDouble(txtTian.Text);
                 ya = Convert.ToDouble(txtYaJin.Text);
                PublicClass.SUM = (fang * tianshu) + ya;
                txtSum.Text = PublicClass.SUM.ToString();
                VoiceHelper.SpeakAsync(txtSum1.Text + txtSum.Text + txtSum3.Text);
            }
            reader.Close();
           
        }

        private void btnFuKuang_Click(object sender, EventArgs e)
        {
         
      
            string sql = $@"update room set room_zhuangTai = 2 where room_id = '{PublicClass.FangH}' ";
            int a = DBHelper.ExecuteNonQuery(sql);
            if (a > 0)
            {
    
                RuZhu zhu =new RuZhu();
                int i = zhu.TiJiaoDingDan();

                string sqlhao = $@"select top 1 checkin.checkin_id from
    checkin left join checkedout
    on(checkedout.checkedout_id = checkin.checkin_id)
     where checkedout.checkedout_yingshou is null and checkin_jianhao = '{PublicClass.FangH}'
     order by checkin.checkin_rushi desc";
                SqlDataReader readerh = DBHelper.ExecutReader(sqlhao);
                if (readerh.Read())
                {
                string sql2 = $"insert into XiaoFei values({Convert.ToInt32(PublicClass.FangH)},{Convert.ToInt32(readerh[0])},'0',0,0,0,'已付款','{DateTime.Now}')";
                DBHelper.ExecuteNonQuery(sql2);
                }
                readerh.Close();
                SqlDataReader readertai = DBHelper.ExecutReader(sqlhao);
                if (readertai.Read())
                {
                    string sqltai = $"insert into Tai values ('{readertai[0].ToString()}','在住')";
                    DBHelper.ExecuteNonQuery(sqltai);
                }
                readertai.Close();
                //录入同行信息
                if (PublicClass.To)
                {
                    SqlDataReader reader1 = DBHelper.ExecutReader(sqlhao);
                    if (reader1.Read())
                    {
                        for (int k = 0; k < PublicClass.ShenFu.Length; k++)
                        {
                            string cun = PublicClass.ShenFu[k];
                            string cun2 = PublicClass.NmaeFu[k];
                            string sql3 = $"insert into duoren values ('{reader1[0].ToString()}','{cun}','{cun2}','是')";
                            DBHelper.ExecuteNonQuery(sql3);
                        }
                    }
                    reader1.Close();
                }

                this.Close();
                zhu.Close();
            }
            else
            {
                MessageBox.Show("错误");
            }

            }

        private void btnQu_Click(object sender, EventArgs e)
        {
            //if (PublicClass.Fa)
            //{
            // string sqljifen = $"delete  from userscore where userscore_shenfenid = '{PublicClass.ShenF}'";
            //string sqlhuiyuang = $"delete  from memberuser where memberuser_shenfen = '{PublicClass.ShenF}'";
            //    DBHelper.ExecuteNonQuery(sqljifen);
            //     DBHelper.ExecuteNonQuery(sqlhuiyuang);
            //    this.Close();
            //    return;
            //}

            this.Close();
        }

        private void FangFei_FormClosing(object sender, FormClosingEventArgs e)
        {
            //hosthoman ho = new hosthoman();
            //hosthoman.lei = "全部类型";
            //ho.BindListView();
        }

        private void FangFei_FormClosed(object sender, FormClosedEventArgs e)
        {
            //hosthoman ho = new hosthoman();
            //hosthoman.lei = "全部类型";
            //ho.BindListView();

        }
    }
}
