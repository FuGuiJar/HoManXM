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
using System.Text.RegularExpressions;

namespace HoManXM
{
    public partial class FrmAddYuDing : Form
    {
        public string fangjianhao;
        public FrmAddYuDing()
        {
            InitializeComponent();
        }

        private void FrmAddYuDing_Load(object sender, EventArgs e)
        {
            data();
            xiala();
            // TextBox.ImeMode = ImeMode.On;    //打开输入法
            // TextBox.ImeMode = ImeMode.Off;    //关闭输入法
            //  bindshijian();

        }

        //public void bindshijian()
        //{
        //    //得到当前时间
        //    DateTime xianzai = DateTime.Now;
        //    //根据当前时间得到预抵时间
        //    DateTime yuDi = xianzai.AddHours(2);
        //    dateTimePicker2.Value = yuDi;
        //  //  MessageBox.Show(dateTimePicker2.Value.ToString());
        //    DateTime baoliu = yuDi.AddHours(1);
        //    dateTimePicker3.Value = baoliu;
        //}

        public void data()
        {
            string sql = $@"select m.room_id, r.roomLei_LeiBie,r.roomLei_jiaGe,tai.roomTai_zhuangTai from roomLei as r
                                        inner join room as m on(r.roomLei_id=m.room_LeiBie) inner join roomTai as tai
                                        on(tai.roomTai_id=m.room_zhuangTai) 
                                        where tai.roomTai_id=1";// and reserve.reserve_fanghao!={readera[0]}    inner join reserve on(reserve.reserve_fanghao=m.room_id)
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;
            //string fangh = $@"select room_id from room";
            //SqlDataReader readera = DBHelper.ExecutReader(fangh);
            //while (readera.Read())
            //{
            //    string yudingbiao = $@"select reserve_fanghao from reserve where reserve_fanghao={readera[0]}";
            //    SqlDataReader reader = DBHelper.ExecutReader(yudingbiao);
            //    while (reader.Read())
            //    {
                    //if (reader[0] == readera[0])
                    //{
                    //    sql += $@"m.room_id!={reader[0]}";
                    //}

                //}
            //}
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
            string fangjianhao = textBox6.Text;
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
            if (fangjianhao == string.Empty)
            {
                MessageBox.Show("选择房间");
                return;
            }
            DateTime w = dateTimePicker2.Value;
            DateTime ee = dateTimePicker3.Value;
            if (w > ee)
            {
                MessageBox.Show("保留时间要大于预抵时间");
                return;
            }
            DateTime dangqian = DateTime.Now;
            DateTime tiqian = dateTimePicker2.Value.AddHours(-0.5);
        //    if (dangqian==tiqian)
          //  {
                string aaa = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string kanyier = $@"select tai.roomTai_id from roomLei as r inner join room as m on(r.roomLei_id=m.room_LeiBie)
                            inner join roomTai as tai on(tai.roomTai_id = m.room_zhuangTai)";
                SqlDataReader reader = DBHelper.ExecutReader(kanyier);
                if (reader.Read())
                {
                    // MessageBox.Show(reader[0].ToString());
                    //
                    //
                    //if (ii > 0)
                    //{
                        string sql1 = $"update room set room_zhuangTai=8 where room_id={fangjianhao}";
                        string sql = $"insert into reserve values('{name}','{dianhua}','{leixing}','{jiaqian}',{fangjianhao},'{w}','{ee}',7)";
                        int i = DBHelper.ExecuteNonQuery(sql);
                        int ii = DBHelper.ExecuteNonQuery(sql1);
                        if (i+ii > 0)
                        {
                            MessageBox.Show("提交成功");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("提交失败");
                        }


                    //}
                    //else
                    //{
                    //    MessageBox.Show("没成功");
                    //}
                }
            //}


        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            string sql = $"select * from room as r inner join roomLei as l on(r.room_LeiBie=l.roomLei_id) inner join roomTai as t on(r.room_zhuangTai=t.roomTai_id) where t.roomTai_id=1";
            if (comboBox1.Text != "全部")
            {
                sql += $" and l.roomLei_id={comboBox1.SelectedValue}";

            }
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //预抵时间
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
                   dateTimePicker3.Value= dateTimePicker2.Value.AddHours(2);
            }
            
           

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            //保留时间
            DateTime Time = DateTime.Now;
            for (int i = 0; i <= 6; i++)
            {
                if (dateTimePicker2.Value > dateTimePicker3.Value)
                {
                    dateTimePicker3.Value = Time;
                    //MessageBox.Show("保留时间要大于预抵时间");
                    return;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dangqian = DateTime.Now;
            DateTime tiqian = dateTimePicker2.Value.AddHours(-0.5);
            if (dangqian == tiqian)
            {
                MessageBox.Show("12");
                string aaa = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string kanyier = $@"select tai.roomTai_id from roomLei as r inner join room as m on(r.roomLei_id=m.room_LeiBie)
                            inner join roomTai as tai on(tai.roomTai_id = m.room_zhuangTai)";
                SqlDataReader reader = DBHelper.ExecutReader(kanyier);
                if (reader.Read())
                {
                    // MessageBox.Show(reader[0].ToString());
                    string sql1 = $"update room set room_zhuangTai=4 where room_id={fangjianhao}";
                    int ii = DBHelper.ExecuteNonQuery(sql1);
                    if (ii > 0)
                    {
                        
                            MessageBox.Show("提交成功");
                            this.Close();

                    }
                    else
                    {
                        MessageBox.Show("没成功时间");
                    }
                }
            }
        }
    }
}
