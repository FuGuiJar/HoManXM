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
    public partial class FrmXiuGaiYuDing : Form
    {
        public string bianhao;
        public string fangjianhao;
        public FrmXiuGaiYuDing()
        {
            InitializeComponent();
        }

        private void FrmXiuGaiYuDing_Load(object sender, EventArgs e)
        {
            data();
            xian();
            xiala();
        }
        public void xian()
        {
            textBox7.Text = bianhao;
            //写SQL
            string sql = $"select * from reserve where reserve_bianhao={bianhao}";
            //调DB
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                textBox1.Text = reader["reserve_name"].ToString();
                textBox2.Text = reader["reserve_phone"].ToString();
                
                textBox4.Text = reader["reserve_fanglei"].ToString();
                textBox5.Text = reader["reserve_Jiaqian"].ToString();
                textBox6.Text = reader["reserve_fanghao"].ToString();
                dateTimePicker2.Value =Convert.ToDateTime( reader["reserve_shijian"]);
                dateTimePicker3.Value = Convert.ToDateTime(reader["reserve_baoliu"]);
            }
            reader.Close();
        }
        public void data()
        {
            string sql = @"select m.room_id, r.roomLei_LeiBie,r.roomLei_jiaGe,tai.roomTai_zhuangTai from roomLei as r inner join room as m on(r.roomLei_id=m.room_LeiBie)
                        inner join roomTai as tai on(tai.roomTai_id=m.room_zhuangTai) where tai.roomTai_id=1";
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string hao = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string lei = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string Money = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string yajin = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox6.Text = hao;
            textBox4.Text = lei;
            textBox5.Text = Money;

        }
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string hao = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string lei = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string Money = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string yajin = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox6.Text = hao;
            textBox4.Text = lei;
            textBox5.Text = Money;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (name == string.Empty)
            {
                MessageBox.Show("姓名？");
                return;
            }

            string dianhua = textBox2.Text;
            if (dianhua == string.Empty)
            {
                MessageBox.Show("电话？");
                return;
            }
            if (dianhua.Length != 11)
            {
                MessageBox.Show("手机号长度错误");
                return;
            }

          
            string leixing = textBox4.Text;
            string jiaqian = textBox5.Text;
            string fangjianhaoa = textBox6.Text;
            #region 日期
            //string yudishijian = dateTimePicker2.Value.Date.ToLongDateString();
            //string shifenmiao = dateTimePicker1.Value.TimeOfDay.Hours.ToString();
            //string [] word = new string[2];
            //word[0] = yudishijian;
            //word[1] = shifenmiao;
            //string a = String.Join("-",word);
            //string baoliushijian = dateTimePicker3.Value.Date.ToLongDateString();
            //string baoliushifenmiao = dateTimePicker4.Value.TimeOfDay.Hours.ToString();
            //string[] wordd = new string[2];
            //wordd[0] = baoliushijian;
            //wordd[1] = baoliushifenmiao;
            //string b = string.Join("-" , wordd);
            #endregion
            if (leixing == string.Empty)
            {
                MessageBox.Show("选择房间");
                return;
            }
            if (jiaqian == string.Empty)
            {
                MessageBox.Show("选择房间");
                return;
            }
            if (fangjianhaoa == string.Empty)
            {
                MessageBox.Show("选择房间");
                return;
            }

            DateTime w = dateTimePicker2.Value;
            DateTime ee = dateTimePicker3.Value;
            DateTime date = DateTime.Now;
            if (w > ee)
            {
                MessageBox.Show("保留时间要大于预抵时间");
                return;
            }
            string bianhao = textBox7.Text;
            //写SQL 

            string sql1 = $@"update room set room_zhuangTai=1 where room_id={fangjianhao}";
            string sql = $@" update reserve set reserve_name='{name}',
                reserve_phone={dianhua},reserve_fanglei='{leixing}', reserve_Jiaqian='{jiaqian}',
                reserve_fanghao={fangjianhaoa},reserve_shijian='{w}',reserve_baoliu='{ee}',reserve_ZhuangTai=1 where reserve_bianhao='{bianhao}'";

            //调DB
            int i = DBHelper.ExecuteNonQuery(sql);
            int ii = DBHelper.ExecuteNonQuery(sql1);
            if (i+ii > 1)
            {
                MessageBox.Show(" 修改成功");
                FrmYuDing yuDing = new FrmYuDing();
                yuDing.xian();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }



        public void xiala()
        {
            string sql = "select *from roomLei";
            DataTable dt = DBHelper.GetTable(sql);
            DataRow row = dt.NewRow();
            row[0] = -1;
            row[1] = "全部";
            dt.Rows.InsertAt(row, 0);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "roomLei_LeiBie";
            comboBox1.ValueMember = "roomLei_id";

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            string sql = $@"select * from room as r inner join roomLei as l on(r.room_LeiBie=l.roomLei_id) inner 
                        join roomTai as t on(r.room_zhuangTai=t.roomTai_id) where t.roomTai_id=1";
            if (comboBox1.Text != "全部")
            {
                sql += $" and l.roomLei_id={comboBox1.SelectedValue}";

            }
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime Time = DateTime.Now;
            for (int i = 0; i <= 6; i++)
            {
                if (dateTimePicker2.Value < Time)
                {
                    dateTimePicker2.Value = Time;
                    break;
                }
            }
            DateTime shj = dateTimePicker2.Value;
            if (shj > Time)
            {
                dateTimePicker3.Value = dateTimePicker2.Value.AddHours(2);
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            DateTime Time = DateTime.Now;
            for (int i = 0; i <= 6; i++)
            {
                if (dateTimePicker2.Value > dateTimePicker3.Value)
                {
                    dateTimePicker3.Value = Time;
                    return;
                }
            }
        }
    }
}
