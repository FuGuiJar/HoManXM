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
using System.Diagnostics;

namespace HoManXM
{
    public partial class TianFangLeiBie : Form
    {
        public TianFangLeiBie()
        {
            InitializeComponent();
            ReadLog("窗口初始化成功");  //调用ReadLog向richTextBox1内写入日志
        }
        //日志
        public void ReadLog(string log)
        {
            string Time = Convert.ToString(DateTime.Now);
            richTextBox1.AppendText(Time + "  " + log + "\n");
        }
        public string BianHao { get; set; }
        private void MoBan_Load(object sender, EventArgs e)
        {
            Default();
            Bing();
            richTextBox1.Visible = false;
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
        //查
        bool flag = true;
        private void picCha_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                FuNull();
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
                FuNull();
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
                FuNull();
                picCha.Visible = false;
                picZeng.Visible = false;
                picShan.Visible = false;
                Point pt1 = new Point();
                pt1.X = 19;
                pt1.Y = 29;
                this.picGai.Location = pt1;
                flpGai.Visible = true;
                Point pt2 = new Point();
                pt2.X = 77;
                pt2.Y = 10;
                this.flpGai.Location = pt2;
                flag2 = false;
                return;
            }
            if (!flag2)
            {
                FuNull();
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
                FuNull();
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
                FuNull();
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
                FuNull();
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
                pt2.Y = 10;
                this.flpZeng.Location = pt2;
                flag4 = false;
                return;
            }
            if (!flag4)
            {
                FuNull();
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

        private void Bing()
        {
            string sql = $@"	 select roomLei.roomLei_id,roomLei.roomLei_LeiBie,roomLei.roomLei_jiaGe,YaJin.YaJin,roomnum.roomnum_num from 
		roomLei inner join YaJin
		on(roomLei.roomLei_id = YaJin.YaJin_id)
		inner join roomnum
		on(roomLei.roomLei_id = roomnum.roomnum_id)
";
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;

        }

        private void btnCha_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Trace.WriteLine("ccc");

            string sql = $@"select roomLei.roomLei_id,roomLei.roomLei_LeiBie,roomLei.roomLei_jiaGe,YaJin.YaJin,roomnum.roomnum_num from 
		roomLei inner join YaJin
		on(roomLei.roomLei_id = YaJin.YaJin_id)
		inner join roomnum
		on(roomLei.roomLei_id = roomnum.roomnum_id)
";
            DataTable dt = DBHelper.GetTable(sql);
            if (txtChaZhao.Text.Trim() == string.Empty)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = $" roomLei_LeiBie like '%{txtChaZhao.Text.Trim()}%'";
                dataGridView1.DataSource = dv;
            }

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BianHao = dataGridView1.SelectedCells[0].Value.ToString();
            txtBianHao.Text = BianHao;
            txtShanChu.Text = BianHao;
            txtLeiXing.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtJiaGe.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtYaJin.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtkezhu.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void txtXiuGai_Click(object sender, EventArgs e)
        {
            //Gai();
            if (txtBianHao.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空！！");
                return;
            }
            string sqlGai1 = $" update roomLei set roomLei_LeiBie = '{txtLeiXing.Text.Trim()}', roomLei_jiaGe = {Convert.ToDouble(txtJiaGe.Text.Trim())} where roomLei_id = {Convert.ToInt32(txtBianHao.Text.Trim())}";
            string sqlGai2 = $"update YaJin  set YaJin = {Convert.ToInt32(txtYaJin.Text.Trim())} where YaJin_id = {Convert.ToInt32(txtBianHao.Text.Trim())}";
            string sqlGai3 = $"update roomnum set roomnum_num = {Convert.ToInt32(txtkezhu.Text.Trim())} where roomnum_id = {Convert.ToInt32(txtBianHao.Text.Trim())}";
          
            int i1 = DBHelper.ExecuteNonQuery(sqlGai1);
            int i2 = DBHelper.ExecuteNonQuery(sqlGai2);
            int i3 = DBHelper.ExecuteNonQuery(sqlGai3);

            if ((i1+i2+i3)>2)
            {
                MessageBox.Show("修改成功！！");
                Application.Restart();
            }
            else
            {
                MessageBox.Show("修改失败！！");
            }
            Bing();
        }

        private void txtBianHao_MouseLeave(object sender, EventArgs e)
        {
            Gai();
        }
        private void Gai()
        {
            if (txtBianHao.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空！！");
                return;
            }
            string sql = $@"select roomLei.roomLei_id,roomLei.roomLei_LeiBie,roomLei.roomLei_jiaGe,YaJin.YaJin from 
		roomLei inner join YaJin
		on(roomLei.roomLei_id = YaJin.YaJin_id)
        where roomLei_id = {Convert.ToInt32(txtBianHao.Text.Trim())}
";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                txtLeiXing.Text = reader[1].ToString();
                txtJiaGe.Text = reader[2].ToString();
                txtYaJin.Text = reader[3].ToString();
            }
            else
            {
                MessageBox.Show("没有该编号！！");
                txtBianHao.Text = string.Empty;
                return;
            }
            reader.Close();
        }

        private void btnShanChu_Click(object sender, EventArgs e)
        {
            if (txtShanChu.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空！！");
                return;
            }

            string sql = $@" select roomLei.roomLei_id,roomLei.roomLei_LeiBie,roomLei.roomLei_jiaGe,YaJin.YaJin,roomnum.roomnum_num from 
		roomLei inner join YaJin
		on(roomLei.roomLei_id = YaJin.YaJin_id)
		inner join roomnum
		on(roomLei.roomLei_id = roomnum.roomnum_id)
        where roomLei_id = {Convert.ToInt32(txtShanChu.Text.Trim())}
";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (!reader.Read())
            {
                MessageBox.Show("没有该编号！！");
                txtShanChu.Text = string.Empty;
                return;
            }
            else
            {
                string sqlYong = $@"select  r.room_id,l.roomLei_LeiBie,t.roomTai_zhuangTai
            from room as r
            inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
            inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id) 
            where roomLei_LeiBie = '{reader[1].ToString()}'
";
                SqlDataReader reader2 = DBHelper.ExecutReader(sqlYong);
                if (reader2.Read())
                {
                    MessageBox.Show("正在使用无法删除！！");
                    return;
                }
                reader2.Close();
            }
            reader.Close();
          


            string sql1 = $"delete from roomLei where roomLei_id = {Convert.ToInt32(txtShanChu.Text.Trim())}";
            string sql2 = $"delete from YaJin where YaJin_id = {Convert.ToInt32(txtShanChu.Text.Trim())}";
            string sql3 = $"delete from roomnum where roomnum_id = {Convert.ToInt32(txtShanChu.Text.Trim())}";

            int i3 = DBHelper.ExecuteNonQuery(sql3);
            int i1 = DBHelper.ExecuteNonQuery(sql1);
            int i2 = DBHelper.ExecuteNonQuery(sql2);
   
            if ((i1+i2+i3)>2)
            {
                MessageBox.Show("删除成功！！");
                Application.Restart();

            }
            else
            {
                MessageBox.Show("刪除失敗！！");
            }
            Bing();
        }

        private void btnTian_Click(object sender, EventArgs e)
        {
            //价格 txtTianJia
            if (txtTianJia.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }
            //价格 txttianlei
            if (txtTianLei.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }
            if (txtzhu.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }
            //价格 txtTianya
            if (txtTianYa.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }
            string ss = txtTianLei.Text;
            string aa = txtTianJia.Text;
            string sql = $@"select roomLei.roomLei_id,roomLei.roomLei_LeiBie,roomLei.roomLei_jiaGe,YaJin.YaJin,kuanJi.kuanJi_level from 
		roomLei inner join YaJin
		on(roomLei.roomLei_id = YaJin.YaJin_id)
        inner join kuanJi
		on(kuanJi.kuanJi_id = YaJin_id)where roomLei.roomLei_LeiBie='{ss}' or roomLei.roomLei_jiaGe={aa}";
            //where roomLei_id = {Convert.ToInt32(txtBianHao.Text.Trim())}
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
              
                    MessageBox.Show("已有该类型或价钱一样！！");
                  //  MessageBox.Show("价钱不可一样！！");
                    return;
               

            }
            reader.Close();

            string sq1 = $"insert into roomLei values ('{txtTianLei.Text.Trim()}',{Convert.ToInt32(txtTianJia.Text.Trim())})";
            string sq2 = $"insert into YaJin values({Convert.ToInt32(txtTianYa.Text.Trim())})";
            string sq3 = string.Empty;
            int s1 = DBHelper.ExecuteNonQuery(sq1);
            int s2 = DBHelper.ExecuteNonQuery(sq2);

            string sqlfu = "select Top 1 roomLei_id from roomLei order by roomLei_id desc";
            SqlDataReader re = DBHelper.ExecutReader(sqlfu);
            if (re.Read())
            {
                sq3 = $"insert into roomnum values ({Convert.ToInt32(re[0].ToString())},{Convert.ToInt32(txtzhu.Text.Trim())})";
            }
            re.Close();
           
            int s3 = DBHelper.ExecuteNonQuery(sq3);
            if ((s1+s2+s3)>2)
            {
                MessageBox.Show("添加成功！！");
                Application.Restart();
            }
            else
            {
                MessageBox.Show("添加失败！！");
            }
            Bing();
        }
        private void FuNull()
        {
            txtBianHao.Text = string.Empty;
            txtCha.Text = string.Empty;
            txtChaZhao.Text = string.Empty;
            txtJiaGe.Text = string.Empty;
            txtLeiXing.Text = string.Empty;
            txtShanChu.Text = string.Empty;
            txtTianJia.Text = string.Empty;
            txtTianLei.Text = string.Empty;
            txtTianYa.Text = string.Empty;
            txtYaJin.Text = string.Empty;
            BianHao = string.Empty;
        }

        private void txtJiaGe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtYaJin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtTianYa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtTianJia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
