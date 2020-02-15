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
    public partial class JieZhang : Form
    {
        public JieZhang()
        {
            InitializeComponent();
        }
        public string  Zong { get; set; }
        public string FangHao { get; set; }
        public double Sum { get; set; }
        public double zheKou { get; set; }
        private void JieZhang_Load(object sender, EventArgs e)
        {
            Bing();

        }
        private void Bing()
        {
            string sql = $@" select  top 1 checkin.*,checkedout.checkedout_yingshou from
    checkin left join checkedout
    on(checkedout.checkedout_id = checkin.checkin_id)
    where checkin.checkin_jianhao = {FangHao}
    and checkedout.checkedout_yingshou is null
      order by checkin.checkin_rushi desc";
            

            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                string sqlXiaoFei = $"select   sum(XiaoJi) from XiaoFei  where DanHao = '{reader[0].ToString()}'";
                txtBianHao.Text = reader[0].ToString();
                SqlDataReader readerXiaoFei = DBHelper.ExecutReader(sqlXiaoFei);
                if (readerXiaoFei.Read())
                {
                    txtXiaoFei.Text = readerXiaoFei[0].ToString();
                }
                readerXiaoFei.Close();

                txtFangJian.Text = reader[7].ToString();
                txtRiQi.Text = reader[5].ToString();
                txtXingMing.Text = reader[1].ToString();
                txtYaJin.Text = reader[4].ToString();
                txtYiJiao.Text = (Convert.ToDouble(reader[9].ToString()) - Convert.ToDouble(reader[4].ToString())).ToString();

                DateTime oldDate = new DateTime(Convert.ToDateTime(reader[5].ToString()).Ticks);
                DateTime newDate = DateTime.Now;
                TimeSpan tsw = newDate - oldDate;
                int differenceInDays = tsw.Days;
                domainUpDown1.Text = (Convert.ToInt32(reader[6].ToString()) + differenceInDays).ToString();

                double zhe = 1;
                string sqlShen = $"select * from checkin where checkin_id = {Convert.ToInt32(txtBianHao.Text)}";
                SqlDataReader readerShen = DBHelper.ExecutReader(sqlShen);
                if (readerShen.Read())
                {
                    string sqlHui = $"select * from memberuser where memberuser_shenfen = '{readerShen[2].ToString()}'";
                    SqlDataReader readerHui = DBHelper.ExecutReader(sqlHui);
                    if (readerHui.Read())
                    {
                        string sqlJin = $"select * from phone where phone_shenfen  ='{readerHui[0].ToString()}'";
                        SqlDataReader readerJin = DBHelper.ExecutReader(sqlJin);
                        if (readerJin.Read())
                        {
                            if (readerJin[2].ToString() == "可用")
                            {
                                string sqlJi = $"select * from member where member_id = {Convert.ToInt32(readerHui[2])}";
                                SqlDataReader readerJi = DBHelper.ExecutReader(sqlJi);
                                if (readerJi.Read())
                                {
                                    zhe = Convert.ToDouble(readerJi[2]);
                                }
                                readerJi.Close();
                            }
                        }
                        readerJin.Close();
                    }
                    readerHui.Close();
                }
                readerShen.Close();

                string jai = string.Empty;
                //MessageBox.Show(ToString()+"---"+reader[4].ToString());
                double i = Convert.ToDouble(reader[9]) - Convert.ToDouble(reader[4]);
                string sqlqq = $@"select roomLei.roomLei_jiaGe from 
	room inner join roomLei
	on(room.room_LeiBie = roomLei.roomLei_id)
	where room_id = {txtFangJian.Text}";
                SqlDataReader readerqq = DBHelper.ExecutReader(sqlqq);
                if (readerqq.Read())
                {
                    jai = readerqq[0].ToString();
                }
                readerqq.Close();
                double c = 0.0;
                if (domainUpDown1.Text == "1")
                {
                    c =(i + Convert.ToDouble(txtXiaoFei.Text)) *zhe;
                }
                else
                {
                     c = (Convert.ToDouble(jai) * (Convert.ToDouble(domainUpDown1.Text) -1) + i + Convert.ToDouble(txtXiaoFei.Text)) *zhe;
                }
                //MessageBox.Show(i.ToString());
                //MessageBox.Show(c.ToString());  
                //txtJiFen.Text = i.ToString("0.0");
                txtJiFen.Text = c.ToString();
                 //= reader[10].ToString();
               
                //(Convert.ToDouble(txtYiJiao.Text) + Convert.ToDouble(txtXiaoFei.Text)).ToString();
                string sqlHuiYuan = $@"select memberuser.memberuser_shenfen,member.member_level,member.member_zhekou from 
        memberuser inner join member
        on(memberuser.memberuser_dengji = member.member_id)
where memberuser.memberuser_shenfen = '{reader[2].ToString()}'
       ";
                SqlDataReader readerHuiYUan = DBHelper.ExecutReader(sqlHuiYuan);
                if (readerHuiYUan.Read())
                {
                    txtHuiYuan.Text = readerHuiYUan[1].ToString();
                    zheKou = Convert.ToDouble(readerHuiYUan[2]);
                }
                else
                {
                    txtHuiYuan.Text = "无";
                    zheKou = 0.0;
                }
                readerHuiYUan.Close();

                if (Convert.ToInt32(domainUpDown1.Text) > 1)
                {
                    string sqlFangJia = $@"	select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai,YaJin.YaJin
                      from room as r
                      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
                      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)
                      inner join YaJin on(l.roomLei_id = YaJin.YaJin_id)
                       where  r.room_id = '{FangHao}'
                ";
                    SqlDataReader readerFangJia = DBHelper.ExecutReader(sqlFangJia);
                    if (readerFangJia.Read())
                    {
                        SqlDataReader readerHuiYUan2 = DBHelper.ExecutReader(sqlHuiYuan);
                        if (readerHuiYUan2.Read())
                        {
                            //Application.Restart
                            //MessageBox.Show(readerFangJia[2].ToString()+"--"+ domainUpDown1.Text);
                            //MessageBox.Show("押金："+txtYaJin.Text+"--"+ "消费：" + txtXiaoFei.Text + "--" + "会员：" + readerHuiYUan2[2].ToString() + "--");
                            double num = Convert.ToDouble(readerFangJia[2].ToString()) * Convert.ToDouble(domainUpDown1.Text);
                            Sum = Convert.ToDouble(txtYaJin.Text) - (((Convert.ToDouble(txtXiaoFei.Text) + num) * Convert.ToDouble(readerHuiYUan2[2].ToString())) - Convert.ToDouble(readerFangJia[2].ToString()) * Convert.ToDouble(reader[6].ToString()));
                        }
                        else
                        {
                            double num = Convert.ToDouble(readerFangJia[2].ToString()) * Convert.ToDouble(domainUpDown1.Text);
                            Sum = Convert.ToDouble(txtYaJin.Text) - ((Convert.ToDouble(txtXiaoFei.Text) + num)- Convert.ToDouble(readerFangJia[2].ToString()) * Convert.ToDouble(reader[6].ToString()));
                        }
                        readerHuiYUan2.Close();
                    }
                    readerFangJia.Close();
                }
                else
                {
                    SqlDataReader readerHuiYUan3 = DBHelper.ExecutReader(sqlHuiYuan);
                    if (readerHuiYUan3.Read())
                    {
                        Sum = Convert.ToDouble(txtYaJin.Text) - Convert.ToDouble(txtXiaoFei.Text) * Convert.ToDouble(readerHuiYUan3[2].ToString());
                    }
                    else
                    {
                        Sum = Convert.ToDouble(txtYaJin.Text) - Convert.ToDouble(txtXiaoFei.Text);
                    }
                    readerHuiYUan3.Close();
                }
                txtShiShou.Text = Sum.ToString();
            }
            reader.Close();
            //MessageBox.Show(Zong);
        }

        private void domainUpDown1_TextChanged(object sender, EventArgs e)
        {
            Bing();
        }
        //添加到退房数据表
        private void btnZhiFu_Click(object sender, EventArgs e)
        {
            string sqlcaozuo = $"insert into caoZuo values ({Convert.ToInt32(txtBianHao.Text)},'{PublicClass.GuanLiYuan}')";
            DBHelper.ExecuteNonQuery(sqlcaozuo);

            string sqltai = $"update Tai set Tai_tai = '已退房' where Tai_id = '{Convert.ToInt32(txtBianHao.Text)}'";
            DBHelper.ExecuteNonQuery(sqltai);

            string sqljian = $"insert into timec values('{Convert.ToInt32(txtBianHao.Text)}','{DateTime.Now}')";
            DBHelper.ExecuteNonQuery(sqljian);
            //计算消费累加
            Lei();

    


            string hui = "1";
            string sqlHuiYuan = $@"select member_id from member where member_level = '{txtHuiYuan.Text}'";
            SqlDataReader reader = DBHelper.ExecutReader(sqlHuiYuan);
            if (reader.Read())
            {
                hui = reader[0].ToString();
            }
            else
            {
                hui = "1";
            }
            reader.Close();
            //MessageBox.Show(txtBianHao.Text +"-"+ txtXiaoFei.Text+ txtYaJin.Text+ "-" + txtYiJiao.Text+ "-" + txtJiFen.Text+ "-" + domainUpDown1.Text+ "-" + hui.ToString()+ "-" + txtShiShou.Text.ToString());
            string sql = $@"insert into checkedout values ('{txtBianHao.Text}',{Convert.ToDouble(txtXiaoFei.Text)},{Convert.ToDouble(txtYaJin.Text)},{Convert.ToDouble(txtYiJiao.Text)},{Convert.ToDouble(txtJiFen.Text)},{Convert.ToInt32(domainUpDown1.Text)},{Convert.ToInt32(hui.ToString())},{Convert.ToDouble(txtShiShou.Text.ToString())})";
            int i = DBHelper.ExecuteNonQuery(sql);
            if (i > 0)
            {
                MessageBox.Show("结账成功");
                string sqlXiaoFei = $"update XiaoFei set ZhuangTai = '已付款' where DanHao = '{txtBianHao.Text}';";
                DBHelper.ExecuteNonQuery(sqlXiaoFei);
                string sqlf = $@"update room set room_zhuangTai = 3 where room_id = '{FangHao}' ";
                DBHelper.ExecuteNonQuery(sqlf);


                string sqlfangqian = $@"
	select top 1 checkin.*,checkedout.* from
    checkin left join checkedout
    on(checkedout.checkedout_id = checkin.checkin_id)
	    where checkin.checkin_id ={Convert.ToInt32(txtBianHao.Text)}
      order by checkin.checkin_rushi desc";

                SqlDataReader reade = DBHelper.ExecutReader(sqlfangqian);
                if (reade.Read())
                {
     

                    Zong = (Convert.ToDouble(reade[9].ToString()) +(Convert.ToDouble(txtXiaoFei.Text) * zheKou)- Convert.ToDouble(reade[18].ToString())).ToString("0.00");
                    //MessageBox.Show(Zong + "--" + reade[9].ToString() +"--"+reade[18].ToString());
                    string sqlMingXi = $"insert into consume values ({Convert.ToInt32(reade[0].ToString())}, {Convert.ToInt32(reade[7].ToString())},'{DateTime.Now}',{Convert.ToDouble(Zong)})";
                    DBHelper.ExecuteNonQuery(sqlMingXi);
                }
                reade.Close();




                this.Close();
            }
            else
            {
                MessageBox.Show("结账失败！！");
            }

        }

        private void btnQuXiao_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuXiao_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Lei()
        {
            string sqlShen = $"select * from checkin where checkin_id = {Convert.ToInt32(txtBianHao.Text)}";
            SqlDataReader readerShen = DBHelper.ExecutReader(sqlShen);
            if (readerShen.Read())
            {
                string sqlHui = $"select * from memberuser where memberuser_shenfen = '{readerShen[2].ToString()}'";
                SqlDataReader readerHui = DBHelper.ExecutReader(sqlHui);
                if (readerHui.Read())
                {
                    string sqlJin = $"select * from phone where phone_shenfen  ='{readerHui[0].ToString()}'";
                    SqlDataReader readerJin = DBHelper.ExecutReader(sqlJin);
                    if (readerJin.Read())
                    {
                        if (readerJin[2].ToString() == "可用")
                        {
                            PublicClass.HuiYuan(readerShen[2].ToString(), txtJiFen.Text);
                        }
                    }
                    readerJin.Close();
                }
                readerHui.Close();
            }
            readerShen.Close();
        }


    }
}
