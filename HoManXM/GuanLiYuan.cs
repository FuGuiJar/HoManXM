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

 //this.button1.Click += new System.EventHandler(this.button1_Click);
namespace HoManXM
{
    public partial class GuanLiYuan : Form
    {
        public GuanLiYuan()
        {
            InitializeComponent();
        }
        public string  BianHao { get; set; }
        int Index = 1;
        public string  ChongFu { get; set; }
        private void MoBan_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(PublicClass.GuanLiYuan);
            BianHao = string.Empty;
            Default();
            Bing();
            string sqlXiu = $"select * from State";
            DataTable dtXiu = DBHelper.GetTable(sqlXiu);
            cboXiuTai.DataSource = dtXiu;
            cboXiuTai.DisplayMember = "State_nameState";
            cboXiuTai.ValueMember = "State_id";


        }
        private void Bing()
        {

            if (PublicClass.Level == "0")
            {
            string sql = $@"select Login.login_id,Login.login_name,Login.login_zhanghao,Login.login_Pwd,Level.level_nameLevel,State.State_nameState from 
	        Login inner join Level
	        on(Login.login_Level = Level.level_id)
	        inner join State
	        on(Login.login_State = State.State_id)";
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;
            }
            else
            {
                string sql2 = $@"select Login.login_id,Login.login_name,Login.login_zhanghao,Login.login_Pwd,Level.level_nameLevel,State.State_nameState from 
	        Login inner join Level
	        on(Login.login_Level = Level.level_id)
	        inner join State
	        on(Login.login_State = State.State_id)
            where login_zhanghao = '{PublicClass.GuanLiYuan}'
";
                DataTable dt = DBHelper.GetTable(sql2);
                dataGridView1.DataSource = dt;
            }
         
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
            if (PublicClass.Level != "0")
            {
                MessageBox.Show("改项只有超管可用！");
                return;
            }

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
            if (PublicClass.Level != "0")
            {
                MessageBox.Show("改项只有超管可用！");
                return;
            }
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
            if (PublicClass.Level != "0")
            {
                MessageBox.Show("改项只有超管可用！");
                return;
            }
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
                pt2.Y = 1;
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

        private void btnChaZhao_Click(object sender, EventArgs e)
        {

            if (PublicClass.Level == "0")
            {
                string sql2 = $@"select Login.login_id,Login.login_name,Login.login_zhanghao,Login.login_Pwd,Level.level_nameLevel,State.State_nameState from 
	        Login inner join Level
	        on(Login.login_Level = Level.level_id)
	        inner join State
	        on(Login.login_State = State.State_id)
";
                DataTable dt = DBHelper.GetTable(sql2);
                if (txtZhuangHao.Text.Trim() == string.Empty)
                {
                dataGridView1.DataSource = dt;
                }
                else
                {
                    DataView dv = new DataView(dt);
                    dv.RowFilter = $"login_zhanghao ='{txtZhuangHao.Text.Trim()}'";
                    dataGridView1.DataSource = dv;
                }

            }


        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BianHao = dataGridView1.SelectedCells[0].Value.ToString();
            txtShan.Text = dataGridView1.SelectedCells[0].Value.ToString();
            FuZhi();
        }
        private void FuZhi()
        {
         
            string sql = $@"select Login.login_id,Login.login_name,Login.login_zhanghao,Login.login_Pwd,Level.level_nameLevel,State.State_nameState from 
	Login inner join Level
	on(Login.login_Level = Level.level_id)
	inner join State
	on(Login.login_State = State.State_id)
    where Login.login_id = {Convert.ToInt32(BianHao)}
";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                txtXiuName.Text = reader[1].ToString();
                txtXiuHao.Text = reader[2].ToString();
                txtXiuPwd.Text = reader[3].ToString();
                txtBianHao.Text = reader[0].ToString();
                ChongFu = reader[2].ToString();
                if (reader[5].ToString() == "可用")
                {
                    cboXiuTai.SelectedIndex = 0; 
                }
                else
                {
                    cboXiuTai.SelectedIndex = 2;
                }
                JinYong();
            }
            else
            {
                MessageBox.Show("值无效！！");
                return;
            }
            reader.Close();

        }
        private void btnXiuGai_Click(object sender, EventArgs e)
        {
            if (txtBianHao.Text == string.Empty)
            {
                MessageBox.Show("不能为空");
                return;
            }
            if (txtXiuHao.Text.Trim() ==string.Empty)
            {
                MessageBox.Show("不能为空");
                return;
            }
            if (txtXiuName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空");
                return;
            }
            if (txtXiuPwd.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空");
                return;
            }
            string sql = $@"select * from Login
    where login_id = {Convert.ToInt32(txtBianHao.Text)}
";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                if (reader[5].ToString() == "0")
                {
                    Index = 1;
                }
                else
                {
                    Index = int.Parse(cboXiuTai.SelectedValue.ToString());
                }
            }
            else
            {
                MessageBox.Show("值无效！！");
                return;
            }
            reader.Close();
            if ( ZhangHao(txtXiuHao.Text))
            {
                return;
            }

                string sqlXiu = $"update Login set login_name = '{txtXiuName.Text.Trim()}',login_zhanghao = '{txtXiuHao.Text.Trim()}',login_Pwd = '{txtXiuPwd.Text.Trim()}',login_State ={Index} where login_id = {Convert.ToInt32(txtBianHao.Text.Trim())}";
            int i = DBHelper.ExecuteNonQuery(sqlXiu);
            if (i>0)
            {
                MessageBox.Show("修改成功！!");
                if (txtXiuHao.Text.Trim() == PublicClass.GuanLiYuan)
                {
                    Application.Restart();
                }
            }
            else
            {
                MessageBox.Show("修改失败！！");
            }
            Bing();
        }
        private void JinYong()
        {

            string sql = $@"select * from Login
    where login_id = {Convert.ToInt32(txtBianHao.Text)}
";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                if (reader[5].ToString() == "0")
                {
                    cboXiuTai.Enabled = false;
                }
                else
                {
                    cboXiuTai.Enabled = true;
                }
            }
            reader.Close();
           

        }
        private bool ZhangHao(string aa)
        {
            bool fg = true;
            string sqlZhao = $"select * from Login where login_zhanghao = '{aa}'";
            SqlDataReader reader = DBHelper.ExecutReader(sqlZhao);
            while (reader.Read())
            {
                if (ChongFu == aa)
                {
                    fg = false;
                    continue;
                }
                if (aa == reader[2].ToString())
                {
                   MessageBox.Show("不可插入重复账号！！");
                    fg = true;
                }
               else
            {
                fg = false;
            }
            }
            reader.Close();
            return fg;
         }
            private void btnShanChu_Click(object sender, EventArgs e)
            {
            if (txtShan.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空！！");
                return;
            }
            string sqlZhao = $"select * from Login where login_id = '{Convert.ToInt32(txtShan.Text.Trim())}'";
            SqlDataReader reader = DBHelper.ExecutReader(sqlZhao);
            if (reader.Read())
            {
                if (reader[5].ToString().Trim() == "0")
                {
                    MessageBox.Show("超管不可删除！！");
                    return;
                }
                if (reader[4].ToString().Trim() != "1")
                {
                    MessageBox.Show("未禁用不可删除不可删除！！");
                    return;
                }
            }
            reader.Close();
            string sqlCha = $"select * from caoZuo where caoZuo_ren = '{txtShan.Text.Trim()}'";
            SqlDataReader readerCha = DBHelper.ExecutReader(sqlCha);
            if (readerCha.Read())
            {
                MessageBox.Show("该管理员已操作数据，不可删除！！");
                return;
            }
            readerCha.Close();
            string sqlShan = $"delete from Login where login_id = {Convert.ToInt32(txtShan.Text.Trim())}";
            int i = DBHelper.ExecuteNonQuery(sqlShan);
            if (i>0)
            {
                MessageBox.Show("删除成功！！");
            }
            else
            {
                MessageBox.Show("删除失败！！");
            }
            Bing();
        }

        private void btnTianJia_Click(object sender, EventArgs e)
        {
            if (txtTianMima.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }
            if (txtTianNmame.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }
            if (txtTianZhang.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }
            //if (ZhangHao(txtTianZhang.Text))
            //{
            //    return;
            //}
            string sqlZhao = $"select * from Login where login_zhanghao = '{txtTianZhang}'";
            SqlDataReader reader = DBHelper.ExecutReader(sqlZhao);
            if (reader.Read())
            {
                MessageBox.Show("不可添加重复！！");

            }
            else
            {
                string sql = $"insert into Login values ('{txtTianNmame.Text.Trim()}','{txtTianZhang.Text.Trim()}','{txtTianMima.Text.Trim()}',1,1)";
                int i = DBHelper.ExecuteNonQuery(sql);
                if (i > 0)
                {
                    MessageBox.Show("添加成功！");
                }
                else
                {
                    MessageBox.Show("添加失败！！");
                }

            }
            reader.Close();
            Bing();
        }

        private void FuNull()
        {
            txtCha.Text = string.Empty;
            txtShan.Text = string.Empty;
            txtTianMima.Text = string.Empty;
            txtTianNmame.Text = string.Empty;
            txtTianZhang.Text = string.Empty;
            txtXiuHao.Text = string.Empty;
            txtXiuName.Text = string.Empty;
            txtXiuPwd.Text = string.Empty;
            txtZhuangHao.Text = string.Empty;
           BianHao = string.Empty;
            txtBianHao.Text = string.Empty;
        }

        private void txtBianHao_MouseLeave(object sender, EventArgs e)
        {
            if (txtBianHao.Text == string.Empty)
            {
                MessageBox.Show("不能为空");
                return;
            }
            //FuZhi();

            string sql = $@"select Login.login_id,Login.login_name,Login.login_zhanghao,Login.login_Pwd,Level.level_nameLevel,State.State_nameState from 
	Login inner join Level
	on(Login.login_Level = Level.level_id)
	inner join State
	on(Login.login_State = State.State_id)
    where Login.login_id = {Convert.ToInt32(txtBianHao.Text.Trim())}
";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                txtXiuName.Text = reader[1].ToString();
                txtXiuHao.Text = reader[2].ToString();
                txtXiuPwd.Text = reader[3].ToString();
                txtBianHao.Text = reader[0].ToString();
                if (reader[5].ToString() == "可用")
                {
                    cboXiuTai.SelectedIndex = 0;
                }
                else
                {
                    cboXiuTai.SelectedIndex = 2;
                }
                JinYong();
            }
            else
            {
                MessageBox.Show("值无效！！");
                return;
            }
            reader.Close();


        }





    }
}
