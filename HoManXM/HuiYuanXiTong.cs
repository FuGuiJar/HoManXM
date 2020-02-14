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
    public partial class HuiYuanXiTong : Form
    {
        public HuiYuanXiTong()
        {
            InitializeComponent();
        }
        public string XuHao { get; set; }
        private void MoBan_Load(object sender, EventArgs e)
        {
            Default();
            Bing();


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
                pt2.Y = 1;
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
            //if (true)
            //{
            //    MessageBox.Show("功能暂未开放！！");
            //    return;
            //}
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
                pt2.Y = 1;
                this.flpZeng.Location = pt2;
                flag4 = false;
                FuNull();
                return;
            }
            if (!flag4)
            {
                picShan.Visible = true;
                picGai.Visible = true;
                picCha.Visible = true;
                Point pt1 = new Point();
                pt1.X = 12;
                pt1.Y = 19;
                this.picZeng.Location = pt1;
                flpZeng.Visible = false;
                flag4 = true;
                FuNull();
                return;
            }
        }




        #endregion
        //默认绑定DGV
        private void Bing()
        {
            string sql = @"select member.member_id,member.member_level,member.member_zhekou,kuanJi.kuanJi_level from 
	member inner join kuanji
	on(member.member_id = kuanJi.kuanJi_id)";
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;

        }

        private void btnCha_Click(object sender, EventArgs e)
        {
            string sql = @"select member.member_id,member.member_level,member.member_zhekou,kuanJi.kuanJi_level from 
	member inner join kuanji
	on(member.member_id = kuanJi.kuanJi_id)";
            DataTable dt = DBHelper.GetTable(sql);
  
            if (txtChaZhao.Text.Trim() == string.Empty)
            {
             dataGridView1.DataSource = dt;
            }
            else
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = $"member_level like '%{txtChaZhao.Text.Trim()}%'";
                dataGridView1.DataSource = dv;
            }

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            XuHao = dataGridView1.SelectedCells[0].Value.ToString();
            txtShan.Text = XuHao;
        }

        private void btnXiuGai_Click(object sender, EventArgs e)
        {
            if (txtFen.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空！！");
                return;
            }
            if (txtXing.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空！！");
                return;
            }
            if (txtZhe.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空！！");
                return;
            }
            if (XuHao == string.Empty)
            {
                MessageBox.Show("不能为空！！");
                return;
            }
            string sql1 = $"update member set member_level = '{txtXing.Text.Trim()}',member_zhekou = {Convert.ToDouble(txtZhe.Text.Trim())} where member_id = {Convert.ToInt32(XuHao)}";
            string sql2 = $"update kuanJi set kuanJi_level = {txtFen.Text.Trim()} where kuanJi_id = {Convert.ToInt32(XuHao)}";
            int z = DBHelper.ExecuteNonQuery(sql1);
            int x =DBHelper.ExecuteNonQuery(sql2);
            if ((z+x)>1)
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
            Bing();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (XuHao == string.Empty)
            {
                MessageBox.Show("不可为空");
                return;
            }
            if (txtShan.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空");
                return;
            }
            //select* from userscore
            string sssss = $@"select mb.member_id,mbs.memberuser_shenfen,mbs.memberuser_name,
                        mb.member_level from memberuser as mbs inner join member as mb on(mbs.memberuser_dengji = mb.member_id)
						";
            SqlDataReader re = DBHelper.ExecutReader(sssss);
            while (re.Read())
            {
                if (re[0].ToString() == txtShan.Text.Trim())
                {
                    MessageBox.Show("有用户再用,不可删除");
                    return;
                }
            }
            re.Close();


                string sql2 = $"delete from kuanJi where kuanJi_id = {Convert.ToInt32(txtShan.Text.Trim())}";
                int i = DBHelper.ExecuteNonQuery(sql2);
                if (i > 0)
                {
                    string sql1 = $" delete from member where member_id = {Convert.ToInt32(txtShan.Text.Trim())}";
                    int o = DBHelper.ExecuteNonQuery(sql1);
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
                Bing();
            
           

        }

        private void btnJia_Click(object sender, EventArgs e)
        {
            if (txtJiaFen.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空！！");
                return;
            }
            if (txtJiaLei.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空！！");
                return;
            }
            if (txtJiaZhe.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空！！");
                return;
            }
            //if (XuHao == string.Empty)
            //{
            //    MessageBox.Show("不能为空！！");
            //    return;
            //}
            int i = 0;
            string sql1 = $"insert into member values ('{txtJiaLei.Text.Trim()}',{Convert.ToDouble(txtJiaZhe.Text.Trim())})";
             i+=  DBHelper.ExecuteNonQuery(sql1);
            string sqq = $@"select kuanJi_level from kuanJi where kuanJi_level={txtJiaFen.Text}";
            SqlDataReader rrr = DBHelper.ExecutReader(sqq);
            if (rrr.Read())
            {
                MessageBox.Show("积分不可重复");
                return;
            }
            else
            {
                string sq3 = $"select top 1 * from member order by member_id desc";
                SqlDataReader reader = DBHelper.ExecutReader(sq3);
                if (reader.Read())
                {
                    string sql2 = $"insert into kuanJi values({Convert.ToInt32(reader[0].ToString())},{Convert.ToInt32(txtJiaFen.Text.Trim())})";
                    i += DBHelper.ExecuteNonQuery(sql2);
                }
                reader.Close();
                if (i > 1)
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
                Bing();
            }
          
        }

        private void FuNull()
        {
            txtCha.Text = string.Empty;
            txtChaZhao.Text = string.Empty;
            txtFen.Text = string.Empty;
            txtJiaFen.Text = string.Empty;
            txtJiaLei.Text = string.Empty;
            txtJiaZhe.Text = string.Empty;
            txtShan.Text = string.Empty;
            txtXing.Text = string.Empty;
            txtZhe.Text = string.Empty;
            XuHao = string.Empty;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtXing.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtZhe.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtFen.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
