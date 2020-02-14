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
    public partial class TianFang : Form
    {
        public TianFang()
        {
            InitializeComponent();
        }
        public string FangHao { get; set; }
        private void MoBan_Load(object sender, EventArgs e)
        {
            Default();
            Bing();
            //dataGridView1.AutoGenerateColumns
            string sql1 = $"select* from roomLei";
            DataTable dt1 = DBHelper.GetTable(sql1);
            cboLei.DataSource = dt1;
            cboLei.DisplayMember = "roomLei_LeiBie";
            cboLei.ValueMember = "roomLei_id";
            //cboLei.ValueMember = "roomLei_jiaGe";

            string sql2 = $"select * from roomTai";
            DataTable dt2 = DBHelper.GetTable(sql2);
            cboTai.DataSource = dt2;
            cboTai.DisplayMember = "roomTai_zhuangTai";
            cboTai.ValueMember = "roomTai_id";

            string sql3 = $"select * from roomLei";
            DataTable dt3 = DBHelper.GetTable(sql3);
            cboTian.DataSource = dt3;
            cboTian.DisplayMember = "roomLei_LeiBie";
            cboTian.ValueMember = "roomLei_id";
            //cboTian.ValueMember = "roomLei_jiaGe";
        }


        #region 定位与显示
        //查控件在父容器的位置
        //int q = this.picShan.Location.X;
        //int y = this.picGai.Location.Y;
        //  picGai.Location = new Point(x, y)
        //默认隐藏
        private void Default()
        {
            flpZeng.Visible = false;
            flpCha.Visible = false;
            flpGai.Visible = false;
            flpShan.Visible = false;
        }
        public void zeng()
        {
            cboTai.SelectedIndex =1;
            numericUpDown1.Value = 1;
        }
        public void gai()
        {
            cboLei.SelectedIndex = 1;
            cboTai.SelectedIndex = 1;
            textBox1.Text=string.Empty;
        }
        public void shan()
        {
            txtShan.Text = string.Empty;
        }
        
        public void zhao()
        {
            txtChaZhao.Text = string.Empty;
        }
        //查
        bool flag = true;
        private void picCha_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                zhao();
                picZeng.Visible = false;
                picShan.Visible = false;
                picGai.Visible = false;
                Point pt1 = new Point();
                pt1.X = 19;
                pt1.Y = 29;
                this.picCha.Location = pt1;
                flpCha.Visible = true;
                Point pt2 = new Point();
                pt2.X = 77;
                pt2.Y = 60;
                this.flpCha.Location = pt2;
                flag = false;
                return;
            }
            if (!flag)
            {
                zhao();
                picZeng.Visible = true;
                picShan.Visible = true;
                picGai.Visible = true;
                Point pt1 = new Point();
                pt1.X = 249;
                pt1.Y = 19;
                this.picCha.Location = pt1;
                flpCha.Visible = false;
                flag = true;
                return;
            }
        }
        //改
        bool flag2 = true;
        private void picGai_Click_1(object sender, EventArgs e)
        {
            if (flag2)
            {
                gai();
                picCha.Visible = false;
                picZeng.Visible = false;
                picShan.Visible = false;
                Point pt1 = new Point();
                pt1.X = 19;
                pt1.Y = 29;
                this.picGai.Location = pt1;
                flpGai.Visible = true;
                Point pt2 = new Point();
                pt2.X = 97;
                pt2.Y = 10;
                this.flpGai.Location = pt2;
                flag2 = false;
                return;
            }
            if (!flag2)
            {
                gai();
                picCha.Visible = true;
                picZeng.Visible = true;
                picShan.Visible = true;
                Point pt1 = new Point();
                pt1.X = 170;
                pt1.Y = 19;
                this.picGai.Location = pt1;
                flpGai.Visible = false;
                flag2 = true;
                return;
            }
        }
        //删
        bool flag3 = true;
        private void picShan_Click_1(object sender, EventArgs e)
        {
            if (flag3)
            {
                shan();
                picGai.Visible = false;
                picCha.Visible = false;
                picZeng.Visible = false;
                Point pt1 = new Point();
                pt1.X = 19;
                pt1.Y = 29;
                this.picShan.Location = pt1;
                flpShan.Visible = true;
                Point pt2 = new Point();
                pt2.X = 77;
                pt2.Y = 60;
                this.flpShan.Location = pt2;
                flag3 = false;
                return;
            }
            if (!flag3)
            {
                shan();
                picGai.Visible = true;
                picCha.Visible = true;
                picZeng.Visible = true;
                Point pt1 = new Point();
                pt1.X = 91;
                pt1.Y = 19;
                this.picShan.Location = pt1;
                flpShan.Visible = false;
                flag3 = true;
                return;
            }
        }
        //增
        bool flag4 = true;
        private void picZeng_Click_1(object sender, EventArgs e)
        {
            if (flag4)
            {
                zeng();
                picShan.Visible = false;
                picGai.Visible = false;
                picCha.Visible = false;
                Point pt1 = new Point();
                pt1.X = 19;
                pt1.Y = 29;
                this.picZeng.Location = pt1;
                flpZeng.Visible = true;
                Point pt2 = new Point();
                pt2.X = 77;
                pt2.Y = 15;
                this.flpZeng.Location = pt2;
                flag4 = false;
                return;
            }
            if (!flag4)
            {
                zeng();
                picShan.Visible = true;
                picGai.Visible = true;
                picCha.Visible = true;
                Point pt1 = new Point();
                pt1.X = 12;
                pt1.Y = 19;
                this.picZeng.Location = pt1;
                flpZeng.Visible = false;
                flag4 = true;
                return;
            }
        }




        #endregion
        public string sql = $@"	select  r.room_id,l.roomLei_LeiBie,t.roomTai_zhuangTai,YaJin.YaJin
      from room as r
      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id) 
	  inner join YaJin on(l.roomLei_id =YaJin.YaJin_id )";
        private void Bing()
        {

            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;

//            select* from roomLei
//select* from roomTai

        }

      
        private void btnChaZhao_Click(object sender, EventArgs e)
        {
            DataTable dt = DBHelper.GetTable(sql);
            if (txtChaZhao.Text.Trim() == string.Empty)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = $" room_id = '{Convert.ToInt32(txtChaZhao.Text.Trim())}'";
                dataGridView1.DataSource = dv;
            }

            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FangHao = dataGridView1.SelectedCells[0].Value.ToString();
            txtShan.Text = FangHao;
        }

        private void btnXiu_Click(object sender, EventArgs e)
        {
            if (FangHao == string.Empty)
            {
                MessageBox.Show("请双击要修改的房间！");
                return;
            }

            string sql = $@"	select  r.room_id,l.roomLei_LeiBie,t.roomTai_zhuangTai,YaJin.YaJin
      from room as r
      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id) 
	  inner join YaJin on(l.roomLei_id =YaJin.YaJin_id )
      where room_id = {Convert.ToInt32(FangHao)}
";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            while (reader.Read())
            {
                if (reader[2].ToString()=="已入住")
                {
                    MessageBox.Show("已入住不可修改！！");
                    return;
                }
            }
            reader.Close();
            string ss = cboLei.SelectedValue.ToString();
            string aaa = cboTai.SelectedValue.ToString();
            string hahah = textBox1.Text;
            string sql1 = $@"update room set  room_zhuangTai 
            = {aaa},room_LeiBie =
            {ss} where room_id ={hahah} ";
            int t = DBHelper.ExecuteNonQuery(sql1);
            if (t > 0)
            {
                MessageBox.Show("修改成功！");
            }
            else
            {
                MessageBox.Show("修改成功");
            }
            Bing();
        }

        private void btnSahnChu_Click(object sender, EventArgs e)
        {
            string sqlZhu = $"select * from checkin where checkin_jianhao = {Convert.ToInt32(txtShan.Text.Trim())}";
            SqlDataReader reader2 = DBHelper.ExecutReader(sqlZhu);
            if (reader2.Read())
            {
                MessageBox.Show("该房间已产生订单，不可删除！！");
                return;
            }
            reader2.Close();
            string sql = $@"	select  r.room_id,l.roomLei_LeiBie,t.roomTai_zhuangTai,YaJin.YaJin
      from room as r
      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id) 
	  inner join YaJin on(l.roomLei_id =YaJin.YaJin_id )
      where room_id = {Convert.ToInt32(txtShan.Text.Trim())}
";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                if (reader[2].ToString() == "已入住")
                {
                    MessageBox.Show("已入住不可删除！！");
                    return;
                }


            }
            else
            {
                MessageBox.Show("未找到该房号！！");
                return;
            }
            reader.Close();
            if (txtShan.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空！！");
                return;
            }
            string sqlShan = $"delete from room where room_id ={Convert.ToInt32(txtShan.Text.Trim())}";
             DBHelper.ExecuteNonQuery(sqlShan);
            Bing();
        }

        private void txtTian_Click(object sender, EventArgs e)
        {
            int shu =Convert.ToInt32( numericUpDown1.Value);
            for(int i = 0; i < shu; i++)
            {
                string sqlTian = $"insert into room values (1,{int.Parse(cboTian.SelectedValue.ToString())})";
                DBHelper.ExecuteNonQuery(sqlTian);
                
            }
            MessageBox.Show("成功");
            Bing();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 1)
            {
                return;
            }
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
         
                e.Handled = true;
                return;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            cboLei.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            cboTai.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
