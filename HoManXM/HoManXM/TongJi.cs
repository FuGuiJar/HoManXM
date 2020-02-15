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
    public partial class TongJi : Form
    {
        public TongJi()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //folderBrowserDialog1.ShowDialog();
            //colorDialog1.ShowDialog();
            //string aa = Convert.ToString(colorDialog1.Color);
            //MessageBox.Show(aa);
            //Color color = new Color();
            //color = colorDialog1.Color;
            //MessageBox.Show(color.ToString());

        }

        private void TongJi_Load(object sender, EventArgs e)
        {
            //string sql = $@"	select SUM(consume_jine) as '总收入',avg(consume_jine) as '平均收入', count(*) as '订单数量' from consume where consume_time  between '2019-12-16' and '2020-1-15' ";
            //DataTable dt = DBHelper.GetTable(sql);
            //chart1.DataSource = dt;
            //chart1.Series[0].XValueMember = "consume_jine";
            //chart1.Series[0].YValueMembers = "consume_jine";
            panJin.BringToFront();
            Bind();



        }
        private void Bind()
        {
            string sqlJin = $@"select SUM(consume_jine) as '总收入',avg(consume_jine) as '平均收入', count(*) as '订单数量'  from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	 where DateDiff(dd,consume.consume_time,getdate())=0";
            SqlDataReader readerJin = DBHelper.ExecutReader(sqlJin);
            if (readerJin.Read())
            {
                labJinZong.Text = readerJin[0].ToString();
                labJinPing.Text = readerJin[1].ToString();
                labJinNum.Text = readerJin[2].ToString();
            }
            readerJin.Close();
            string sqlJinDGV = $@" select consume.*,checkin.checkin_name,checkin.checkin_sex from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	 where DateDiff(dd,consume.consume_time,getdate())=0";
            DataTable dt = DBHelper.GetTable(sqlJinDGV);
            dgvJin.DataSource = dt;
        }

        private void btnJin_Click(object sender, EventArgs e)
        {
            panJin.BringToFront();
            Bind();
        }

        private void labJinZong_Click(object sender, EventArgs e)
        {

        }

        private void labJinPing_Click(object sender, EventArgs e)
        {

        }

        private void labJinNum_Click(object sender, EventArgs e)
        {

        }

        private void btnZuo_Click(object sender, EventArgs e)
        {
            panZuo.BringToFront();

            string sqlJin = $@"select SUM(consume_jine) as '总收入',avg(consume_jine) as '平均收入', count(*) as '订单数量'  from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	 where DateDiff(dd,consume.consume_time,getdate())=1";
            SqlDataReader readerJin = DBHelper.ExecutReader(sqlJin);
            if (readerJin.Read())
            {
                labZuoZong.Text = readerJin[0].ToString();
                labZuoPing.Text = readerJin[1].ToString();
                labZuoNum.Text = readerJin[2].ToString();
            }
            readerJin.Close();
            string sqlJinDGV = $@" select consume.*,checkin.checkin_name,checkin.checkin_sex from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	 where DateDiff(dd,consume.consume_time,getdate())=1";
            DataTable dt = DBHelper.GetTable(sqlJinDGV);
            dgvZuo.DataSource = dt;

        }

        private void btnQi_Click(object sender, EventArgs e)
        {
            panQi.BringToFront();

            string sqlJin = $@"select SUM(consume_jine) as '总收入',avg(consume_jine) as '平均收入', count(*) as '订单数量'  from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	 where DateDiff(dd,consume.consume_time,getdate())<=7";
            SqlDataReader readerJin = DBHelper.ExecutReader(sqlJin);
            if (readerJin.Read())
            {
                labQIZong.Text = readerJin[0].ToString();
                labQiPing.Text = readerJin[1].ToString();
                labQiNum.Text = readerJin[2].ToString();
            }
            readerJin.Close();
            string sqlJinDGV = $@" select consume.*,checkin.checkin_name,checkin.checkin_sex from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	 where DateDiff(dd,consume.consume_time,getdate())<=7";
            DataTable dt = DBHelper.GetTable(sqlJinDGV);
            dvgQi.DataSource = dt;
        }

        private void btnSanShi_Click(object sender, EventArgs e)
        {
            panSanShi.BringToFront();

            string sqlJin = $@"select SUM(consume_jine) as '总收入',avg(consume_jine) as '平均收入', count(*) as '订单数量'  from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	 where DateDiff(dd,consume.consume_time,getdate())<=30";
            SqlDataReader readerJin = DBHelper.ExecutReader(sqlJin);
            if (readerJin.Read())
            {
                labZongSanShi.Text = readerJin[0].ToString();
                labPingSanShi.Text = readerJin[1].ToString();
                labNumSanShi.Text = readerJin[2].ToString();
            }
            readerJin.Close();
            string sqlJinDGV = $@" select consume.*,checkin.checkin_name,checkin.checkin_sex from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	 where DateDiff(dd,consume.consume_time,getdate())<=30";
            DataTable dt = DBHelper.GetTable(sqlJinDGV);
            dgvSanShi.DataSource = dt;
        }

        private void btnYue_Click(object sender, EventArgs e)
        {
            panYue.BringToFront();

            string sqlJin = $@"select SUM(consume_jine) as '总收入',avg(consume_jine) as '平均收入', count(*) as '订单数量'  from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	 where DateDiff(mm,consume.consume_time,getdate())=0";
            SqlDataReader readerJin = DBHelper.ExecutReader(sqlJin);
            if (readerJin.Read())
            {
                labYueZong.Text = readerJin[0].ToString();
                labYuePing.Text = readerJin[1].ToString();
                labYueNum.Text = readerJin[2].ToString();
            }
            readerJin.Close();
            string sqlJinDGV = $@" select consume.*,checkin.checkin_name,checkin.checkin_sex from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	 where DateDiff(mm,consume.consume_time,getdate())=0";
            DataTable dt = DBHelper.GetTable(sqlJinDGV);
            dgvYue.DataSource = dt;


        }

        private void btnNian_Click(object sender, EventArgs e)
        {
            panNian.BringToFront();
            string sqlJin = $@"select SUM(consume_jine) as '总收入',avg(consume_jine) as '平均收入', count(*) as '订单数量'  from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	 where DateDiff(yy,consume.consume_time,getdate())=0";
            SqlDataReader readerJin = DBHelper.ExecutReader(sqlJin);
            if (readerJin.Read())
            {
                labNianZong.Text = readerJin[0].ToString();
                labNianPing.Text = readerJin[1].ToString();
                labNianNum.Text = readerJin[2].ToString();
            }
            readerJin.Close();
            string sqlJinDGV = $@" select consume.*,checkin.checkin_name,checkin.checkin_sex from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	 where DateDiff(yy,consume.consume_time,getdate())=0";
            DataTable dt = DBHelper.GetTable(sqlJinDGV);
            dvgNian.DataSource = dt;

        }

        private void btnZi_Click(object sender, EventArgs e)
        {
            panZi.BringToFront();

        }

        private void btnCha_Click(object sender, EventArgs e)
        {
            string sqlJin = $@"select SUM(consume_jine) as '总收入',avg(consume_jine) as '平均收入', count(*) as '订单数量' from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	  where consume_time  between '{dtpKai.Value}' and '{dtpTing.Value}'";
            SqlDataReader readerJin = DBHelper.ExecutReader(sqlJin);
            if (readerJin.Read())
            {
                labZiZong.Text = readerJin[0].ToString();
                labPing.Text = readerJin[1].ToString();
                labNum.Text = readerJin[2].ToString();
            }
            readerJin.Close();
            string sqlJinDGV = $@" select consume.*,checkin.checkin_name,checkin.checkin_sex from 
	  consume  inner join checkin
	  on(consume.consume_danhao = checkin.checkin_id)
	  inner join checkedout
	  on(checkedout.checkedout_id = consume.consume_danhao)
	  where consume_time  between '{dtpKai.Value}' and '{dtpTing.Value}'";
            DataTable dt = DBHelper.GetTable(sqlJinDGV);
            dvgZi.DataSource = dt;
        }
    }
}
