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
using System.Data;

namespace HoManXM
{
    public partial class ZenegJiaXiaoFei : Form
    {
        public ZenegJiaXiaoFei()
        {
            InitializeComponent();
        }
        public string FangHao { get; set; }
        string Fang = PublicClass.FangH;
        string Dan = "101";
        private void Form1_Load(object sender, EventArgs e)
        {
            ShangPingPrices();
            ZhongJie();
            dataGridView2.ClearSelection();
            Fang = PublicClass.FangH;
            string sql = $@" select  top 1 checkin.*,checkedout.checkedout_yingshou from
    checkin left join checkedout
    on(checkedout.checkedout_id = checkin.checkin_id)
    where checkin.checkin_jianhao = '{Fang}'
    and checkedout.checkedout_yingshou is null
      order by checkin.checkin_rushi desc";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                Dan = reader[0].ToString(); 
            }
            reader.Close();
            lblFangHao.Text = Fang;
            labDanHao.Text = Dan;

        }
        //public void 商品价格表
        public  void ShangPingPrices()
        {
            //写SQL
            string sql = "select * from goods";
            //调DB
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;
        }
        //产生DataTable
        DataTable dt2 = null;
        #region 把要在dataGridView2里显示的先放在dt2
        private void ZhongJie()
        {
            dt2 = new DataTable();
            //产生列
            for(int i = 0; i < 5; i++)
            {
                DataColumn dc = new DataColumn((i + 1).ToString());
                dt2.Columns.Add(dc);
            }
            //把要在dataGridView2里显示的先放在dt2
            dataGridView2.DataSource = dt2;
           
        }
        #endregion


        private void SuanQian()
        {
            //查看有东西没
            int count = dt2.Rows.Count;
            double sum = 0.0;
            for(int i = 0; i < count; i++)
            {
                sum += Convert.ToInt32(dt2.Rows[i][4]);
            }
            lblSum.Text = sum.ToString();
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 哎
            dataGridView2.DataSource = dt2;
            //得到序号
            int xu = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);

            int a = dataGridView1.Rows.Count;
            for (int j = 0; j < a; j++)
            {
                if(Convert.ToInt32(dataGridView1.Rows[j].Cells[0].Value) == xu)
                {
                    dataGridView1.Rows[j].Cells[3].Value = Convert.ToInt32(dataGridView1.Rows[j].Cells[3].Value) + 1;
                }
            }
           
          //  MessageBox.Show(xu+"");
            // MessageBox.Show(xu + "");
            //得到dt2中的总数量
             int count = dt2.Rows.Count;
          //  MessageBox.Show(count + "");
            //判断
             int i = 0;
            bool flag = false;
            for (; i < count; i++)
            {
                if (Convert.ToInt32(dt2.Rows[i][0]) == xu)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
               //MessageBox.Show(Convert.ToInt32(dt2.Rows[i][3]) + "-----------------" + i + "*************");
                if (Convert.ToInt32(dt2.Rows[i][3]) > 1)
                {
                    int h = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    dt2.Rows[i][3] = Convert.ToInt32(dt2.Rows[i][3]) - 1;
                    dt2.Rows[i][4] = Convert.ToInt32(dt2.Rows[i][3]) * Convert.ToSingle(dt2.Rows[i][2]);
                    if(xu==h)
                    {
                        dataGridView1.Rows[i].Cells[3].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) + 1;
                    }
                   
                }
                else
                {
                    dt2.Rows.RemoveAt(i);
                    int h = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    if (xu == h)
                    {
                        dataGridView1.Rows[i].Cells[3].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) + 1;
                    }
                }
            }
         
            SuanQian();

            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Rows[0].Selected = true;
            }
            #endregion
           
           
              //  dataGridView1.Rows[i].Cells[3].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) + 1;
            
         //   dataGridView1.Rows[i].Cells[3].Value = Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value)+ 1;
         //   dataGridView2.SelectedRows[0].Cells[3].Value = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[3].Value) - 1;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string yu = textBox1.Text;
            //写SQL
            string sql = $" select * from goods where goods_name like '%{yu}%'";
            //调DB
            DataTable data = DBHelper.GetTable(sql);
            dataGridView1.DataSource = data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int row = 0;//默认增加的行数
            //得到dataGirdView的行数
            int Hang = dataGridView2.Rows.Count;
            //  MessageBox.Show(Convert.ToString( Hang));

            //判断dt2中是否存在行
            int iii = 0;
            for (; iii < Hang; iii++)
            {
                
              
                    string sj = dataGridView2.Rows[iii].Cells[0].Value.ToString();
                    string ej = dataGridView2.Rows[iii].Cells[3].Value.ToString();
                    //写SQL
                    string sql = $" update goods set goods_shuliang=goods_shuliang-{ej} where goods_id={sj}";
                    //调DB
                    int i1 = DBHelper.ExecuteNonQuery(sql);
                    if (i1 > 0)
                    {
                        ShangPingPrices();
                    }
                
                
            }
         

            string zhuang = "未付款";
            for (int i = 0; i < Hang; i++)
            {
                DateTime shi = DateTime.Now;
                string Ke = Convert.ToString(dataGridView2.Rows[i].Cells[1].Value);
                double DanJia = Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
                string shu = Convert.ToString(dataGridView2.Rows[i].Cells[3].Value);
                string XiaoJi = Convert.ToString(dataGridView2.Rows[i].Cells[4].Value);
            
                //写SQL
                string sss = $@"insert into XiaoFei values({Fang},{Dan},'{Ke}',{DanJia},{shu},{XiaoJi},'{zhuang}','{shi}')";
                //string sql = $"insert into XiaoFei values({Fang},{Dan},'{Ke}',{DanJia},{shu},{XiaoJi},'{zhuang}')";
                //调DB
                int i2 = DBHelper.ExecuteNonQuery(sss);
                if (i2 > 0)
                {
                    row++;
                }
            }
          
           
            if (row > 0)
            {
              //    MessageBox.Show("成功,共录入"+row+"行数据");
                MessageBox.Show("购买成功！！");
                this.Close();
            }
            else
            {
                MessageBox.Show("没成功");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //判断dt2中是否存在行
            int row = dt2.Rows.Count;
            if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString()) != 0)
            {
                int iii = 0;
                
                    if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString()) <= 0)
                    {
                        MessageBox.Show("不够");
                        return;
                    }
                    else
                    {
                        //判断是否有行
                        if (row == 0)
                        {
                            //产生新行
                            DataRow row1 = dt2.NewRow();//给dt2产生差不多就相当于给dataGridView2
                                                        //例如序号   控件名        选中行     要填充的位置  值
                            row1[0] = dataGridView1.SelectedRows[0].Cells[0].Value;
                            row1[1] = dataGridView1.SelectedRows[0].Cells[1].Value;
                            row1[2] = dataGridView1.SelectedRows[0].Cells[2].Value;
                            //上面的都是把信息直接传过去
                            //购买数量  默认1
                            row1[3] = 1;
                            //小计  要先把他们转换为int类型   用row1[2]*row1[3]
                            row1[4] = Convert.ToSingle(row1[2]) * Convert.ToInt32(row1[3]);
                            //把这个放到行上
                            dt2.Rows.InsertAt(row1, 0);
                            string hhhh = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                            // string ss = $@"update goods set goods_shuliang = goods_shuliang - 1 where goods_id = { hhhh}";
                            //  dataGridView1.SelectedRows[0].Cells[3].Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value) - 1;
                        }
                        else
                        {
                            //如果有至少一行，判断增加商品的内容是否一致
                            //得到左边选中的商品序号
                            int xuHao = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                            int i = 0;
                            bool flag = false;//默认没有相同的商品
                            for (; i < row; i++)
                            {
                                if (Convert.ToInt32(dt2.Rows[i][0].ToString()) == xuHao)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            //判断 flag
                            if (flag)
                            {
                                //一致，前面信息单价都不用，数量+1,小计在乘一下
                                dt2.Rows[i][3] = Convert.ToInt32(dt2.Rows[i][3]) + 1;
                                dt2.Rows[i][4] = Convert.ToInt32(dt2.Rows[i][3]) * Convert.ToSingle(dt2.Rows[i][2]);
                            }
                            else
                            {
                                //不一致，再来一行  产生新行的代码
                                DataRow dr = dt2.NewRow();
                                dr[0] = dataGridView1.SelectedRows[0].Cells[0].Value;
                                dr[1] = dataGridView1.SelectedRows[0].Cells[1].Value;
                                dr[2] = dataGridView1.SelectedRows[0].Cells[2].Value;
                                dr[3] = 1;
                                dr[4] = Convert.ToSingle(dr[2]) * Convert.ToInt32(dr[3]);
                                //把这个放到
                                dt2.Rows.InsertAt(dr, 0);
                                // dataGridView1.SelectedRows[0].Cells[3].Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value) - 1;
                            }
                            //dataGridView1.SelectedRows[0].Cells[3].Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value) - 1;
                        }
                        SuanQian();
                        dataGridView1.SelectedRows[0].Cells[3].Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value) - 1;
                    }
            }
            else
            {
                MessageBox.Show("没存货了");
                return;
            }
        }

 

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 1)
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ha = Convert.ToInt32(numericUpDown1.Value.ToString());

            if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString())!= 0)
            { 
             
               
                //判断dt2中是否存在行
                int row = dt2.Rows.Count;

                if (ha >= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString()))
                {
                    MessageBox.Show("购买数量大于存货数量");
                    return;
                }
                else
                {
                    //判断是否有行
                    if (row == 0)
                    {
                        //产生新行
                        DataRow row1 = dt2.NewRow();//给dt2产生差不多就相当于给dataGridView2
                                                    //例如序号   控件名        选中行     要填充的位置  值
                        row1[0] = dataGridView1.SelectedRows[0].Cells[0].Value;
                        row1[1] = dataGridView1.SelectedRows[0].Cells[1].Value;
                        row1[2] = dataGridView1.SelectedRows[0].Cells[2].Value;
                        //上面的都是把信息直接传过去
                        //购买数量  默认1
                        row1[3] = ha;
                        //小计  要先把他们转换为int类型   用row1[2]*row1[3]
                        row1[4] = Convert.ToSingle(row1[2]) * Convert.ToInt32(row1[3]);
                        //把这个放到行上
                        dt2.Rows.InsertAt(row1, 0);
                        string hhhh = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                        // string ss = $@"update goods set goods_shuliang = goods_shuliang - 1 where goods_id = { hhhh}";

                    }
                    else
                    {
                        //如果有至少一行，判断增加商品的内容是否一致
                        //得到左边选中的商品序号
                        int xuHao = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                        int i = 0;
                        bool flag = false;//默认没有相同的商品
                        for (; i < row; i++)
                        {
                            if (Convert.ToInt32(dt2.Rows[i][0].ToString()) == xuHao)
                            {
                                flag = true;
                                break;
                            }
                        }
                        //判断 flag
                        if (flag)
                        {
                            //一致，前面信息单价都不用，数量+1,小计在乘一下
                            dt2.Rows[i][3] = Convert.ToInt32(dt2.Rows[i][3]) + ha;
                            dt2.Rows[i][4] = Convert.ToInt32(dt2.Rows[i][3]) * Convert.ToSingle(dt2.Rows[i][2]);
                        }
                        else
                        {
                            //不一致，再来一行  产生新行的代码
                            DataRow dr = dt2.NewRow();
                            dr[0] = dataGridView1.SelectedRows[0].Cells[0].Value;
                            dr[1] = dataGridView1.SelectedRows[0].Cells[1].Value;
                            dr[2] = dataGridView1.SelectedRows[0].Cells[2].Value;
                            dr[3] = 1;
                            dr[4] = Convert.ToSingle(dr[2]) * Convert.ToInt32(dr[3]);
                            //把这个放到
                            dt2.Rows.InsertAt(dr, 0);
                        }
                    }
                }
              
               
                SuanQian();
                dataGridView1.SelectedRows[0].Cells[3].Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value) - ha;
            }
            if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString()) == 0)
            {
                MessageBox.Show("Test");
            }


        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int a = dataGridView2.Rows.Count;
            if (a <= 0)
            {
                e.Cancel = true;
            }
        }
    }
}
