using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace HoManXM
{
    public partial class Ji : Form
    {
        public Ji()
        {
            InitializeComponent();
        }

        private void Ji_Load(object sender, EventArgs e)
        {
            FangJianLei();
            XingBie();

        }
        public void FangJianLei()
        {
            string[] Tong = null;
            string[] Lei = null;
            string sqlnum = $"	select count(*) from roomLei";
            SqlDataReader readernum = DBHelper.ExecutReader(sqlnum);
            if (readernum.Read())
            {
                Tong = new string[Convert.ToInt32(readernum[0])];
                Lei = new string[Convert.ToInt32(readernum[0])];
            }
            readernum.Close();
            string sqlTong = $@"	select
	count( * ) AS num from
	 room inner join roomLei
	on(room.room_LeiBie = roomLei.roomLei_id) 
	inner join roomTai
	on(room.room_zhuangTai = roomTai.roomTai_id)
	group by room_LeiBie";
            SqlDataReader readerTong = DBHelper.ExecutReader(sqlTong);
            int j = 0;
            while (readerTong.Read())
            {
                    Tong[j] = readerTong[0].ToString();
                    j++;
            }
            readerTong.Close();
            string sqlLei = "select roomLei_LeiBie from roomLei";
            SqlDataReader readerLei = DBHelper.ExecutReader(sqlLei);
            int k = 0;
            while (readerLei.Read())
            {
                Lei[k] = readerLei[0].ToString();
                k++;
            }
            readerLei.Close();

            chart1.Series.Clear();  //清除默认的Series
            Series Strength = new Series("房间类别");  //new 一个叫做【Strength】的系列
            Strength.ChartType = SeriesChartType.Pie;  //设置chart的类型 pie饼状图
                                                       //Strength.IsValueShownAsLabel = true; //把值当做标签展示（默认false）
                                                       //chart1.Series["series1"].LegendText = "#VALX";
            Strength.Label = "#VALX:#PERCENT{P0}";//#VALX显示X轴信息，#PERCENT{P0}以百分比显示Y轴信息，{P0}保留0位小数点
            int[] arr = new int[] { 1, 1, 1 };
            //给系列上的点进行赋值，分别对应横坐标和纵坐标的值
            for (int i = 0; i < Tong.Length; i++)
            {
                Strength.Points.AddXY(Lei[i], Tong[i]);
            }
            Strength.Points[0].Color = Color.Yellow; //实现控制饼状图的颜色,改变对应下标的扇形的颜色
                                                     //把series添加到chart上
            chart1.Series.Add(Strength);

        }

        public void XingBie()
        {

            string[] Tong = new string[2];
            string[] Lei = new string[] {"男","女"};
            string sqlnum = $"select count(*) from checkin";
            //SqlDataReader readernum = DBHelper.ExecutReader(sqlnum);
            //if (readernum.Read())
            //{
            //    Tong = new string[Convert.ToInt32(readernum[0])];
            //    //Lei = new string[Convert.ToInt32(readernum[0])];
            //}
            //readernum.Close();
            string sqlTong = $@"select checkin_sex as 性别,COUNT(*) as 数量 from checkin group by checkin_sex";
            SqlDataReader readerTong = DBHelper.ExecutReader(sqlTong);
            int j = 0;
            while (readerTong.Read())
            {
                Tong[j] = readerTong[1].ToString();
                j++;
            }


            chart2.Series.Clear();  //清除默认的Series
            Series Strength = new Series("房间类别");  //new 一个叫做【Strength】的系列
            Strength.ChartType = SeriesChartType.Pie;  //设置chart的类型 pie饼状图
                                                       //Strength.IsValueShownAsLabel = true; //把值当做标签展示（默认false）
                                                       //chart1.Series["series1"].LegendText = "#VALX";
            Strength.Label = "#VALX:#PERCENT{P0}";//#VALX显示X轴信息，#PERCENT{P0}以百分比显示Y轴信息，{P0}保留0位小数点
            int[] arr = new int[] { 1, 1, 1 };
            //给系列上的点进行赋值，分别对应横坐标和纵坐标的值
            for (int i = 0; i < Tong.Length; i++)
            {
                Strength.Points.AddXY(Lei[i], Tong[i]);
            }
            Strength.Points[0].Color = Color.Yellow; //实现控制饼状图的颜色,改变对应下标的扇形的颜色
                                                     //把series添加到chart上
            chart2.Series.Add(Strength);


        }
        //月订单占比
        public void YueDingDan()
        {




        }



    }
}
