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
    
    public partial class FrmYuDing : Form
    {
      //  public string fangjianhao;
        public FrmYuDing()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmAddYuDing addYuDing = new FrmAddYuDing();
            addYuDing.ShowDialog();
            xian();

        }

        private void FrmYuDing_Load(object sender, EventArgs e)
        {
            xian();
            huodefangjian();
        }
        public void huodefangjian()
        {
            //FrmAddYuDing addYuDing = new FrmAddYuDing();
            //int count = dataGridView1.Rows.Count;
            //int i = 0;
            //for (; i < count; i++)
            //{
            // addYuDing.fangjianhao = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            //   MessageBox.Show(addYuDing.fangjianhao);
            //}
           
        }
        public void xian()
        {
            //
            string sql = $@"	select r.reserve_bianhao,r.reserve_name,r.reserve_phone,
                r.reserve_fanglei,r.reserve_Jiaqian,r.reserve_fanghao,r.reserve_shijian,r.reserve_baoliu,tai.roomTai_zhuangTai
                from reserve as r inner join roomTai as tai on(r.reserve_ZhuangTai=tai.roomTai_id) 
				inner join room on(r.reserve_fanghao = room.room_id)
				where reserve_ZhuangTai !=6 and reserve_ZhuangTai !=2";//
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmXiuGaiYuDing frmXiuGaiYu = new FrmXiuGaiYuDing();
            int count = dataGridView1.Rows.Count;
            if (count == 0)
            {
                MessageBox.Show("无可修改");
                return;
            }
            
                    DateTime dangqian = DateTime.Now;
                    DateTime yudi = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[6].Value);//.AddHours(-0.5)
                    if (!(dangqian > yudi))
                    {
                        frmXiuGaiYu.bianhao = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        frmXiuGaiYu.fangjianhao = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                        frmXiuGaiYu.ShowDialog();
                        xian();
                        
                    }
                    else
                    {
                        MessageBox.Show("已过预抵时间");
                        return;
                    }         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime zhao1 = dateTimePicker2.Value;
            //MessageBox.Show(Convert.ToString( yudi));
            DateTime zhao2 = dateTimePicker1.Value;
            string shouji = textBox1.Text;
            //if (shouji == string.Empty)
            //{
            //    return;
            //}
            //if (shouji.Length != 11)
            //{
            //    MessageBox.Show("手机号长度错误");
            //    return;
            //}
            //写SQL reserve_shijian='{yudi}' and reserve_baoliu='{baoliu}' and reserve_phone='{shouji}
            dataGridView1.AutoGenerateColumns = false;
            string sql = $"select * from reserve where reserve_shijian between '{zhao1}' and '{zhao2}' and reserve_phone like '%{shouji}%'";
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            if (count == 0)
            {
                MessageBox.Show("无可删除的");
                return;
            }
            string yu = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string fang = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();            
            //写SQL
            string sqll = $" update room set room_zhuangTai=1 where room_id={fang}";
            string sql = $" delete reserve where reserve_bianhao={yu}";
            //调DB
            int i = DBHelper.ExecuteNonQuery(sql);
            int ii = DBHelper.ExecuteNonQuery(sqll);
            if (i+ ii>1)
            {
                MessageBox.Show("删除成功");
                xian();
            }
            else
            {
                MessageBox.Show("错误");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string shouj = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            if (shouj == "预定")
            {
                Frmshouji shouji = new Frmshouji();
                shouji.shouji = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                shouji .FangHao = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                shouji.Fang = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                RuZhuYu ruZhvu = new RuZhuYu();
                ruZhvu.Yn = true;
                shouji.ShowDialog();
            }
            else
            {
                MessageBox.Show("不可入住");
            }
           
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmXiuGaiYuDing frmXiuGaiYu = new FrmXiuGaiYuDing();
            DateTime yudi = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[6].Value);//.AddHours(-0.5)
            frmXiuGaiYu.bianhao = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            frmXiuGaiYu.fangjianhao = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            frmXiuGaiYu.ShowDialog();
            xian();

        }
    }
}
