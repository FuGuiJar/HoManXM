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
    public partial class HuiYuan : Form
    {
        public HuiYuan()
        {
            InitializeComponent();
        }

        private void HuiYuan_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            flpZeng.Visible = false;
            flpCha.Visible = false;
            flpGai.Visible = false;
            flpShan.Visible = false;
            Bing();
        }
        private void Bing()
        {
            string aa = $@"select memberuser.memberuser_shenfen,member.member_level,member.member_zhekou,userscore.userscore_jifen,phone.phone_id,memberuser.memberuser_name,phone.phone_tai from 
     memberuser inner join member
     on(memberuser.memberuser_dengji = member.member_id)
	 inner join userscore
	 on(memberuser.memberuser_shenfen = userscore.userscore_shenfenid)
	 inner join phone
	 on(memberuser.memberuser_shenfen = phone_shenfen)
    where 1=1
";
            DataTable dt = DBHelper.GetTable(aa);
            dataGridView1.DataSource = dt;
        }

        bool flag = true;
        private void picCha_Click_1(object sender, EventArgs e)
        {
            int x = this.picGai.Location.X;
            //int q = this.picShan.Location.X;
            int y = this.picGai.Location.Y;
            //  picGai.Location = new Point(x, y)
            //MessageBox.Show(x+"---"+y);

            if (flag)
            {
            picZeng.Visible = false;
            picShan.Visible = false;
            picGai.Visible = false;
            Point pt1 = new Point();
            pt1.X = 19;
            pt1.Y = 29;
            this.picCha.Location = pt1;
            flpCha.Visible = true;
            Point pt2 = new Point();
            pt2.X = 70;
            pt2.Y = 55;
            this.flpCha.Location = pt2;
                flag = false;
                return;
            }
            if(!flag){
                picZeng.Visible = true;
                picShan.Visible = true;
                picGai.Visible = true;
                Point pt1 = new Point();
                pt1.X = 249;
                pt1.Y = 19;
                this.picCha.Location = pt1;
                flpCha.Visible = false;
                flag = true;
                FuNull();
                return;                                      

            }


        }

        private void btnCha_Click(object sender, EventArgs e)
        {
            string aa = $@"select memberuser.memberuser_shenfen,member.member_level,member.member_zhekou,userscore.userscore_jifen,phone.phone_id,memberuser.memberuser_name,phone.phone_tai from 
     memberuser inner join member
     on(memberuser.memberuser_dengji = member.member_id)
	 inner join userscore
	 on(memberuser.memberuser_shenfen = userscore.userscore_shenfenid)
	 inner join phone
	 on(memberuser.memberuser_shenfen = phone_shenfen)
";
            DataTable dt = DBHelper.GetTable(aa);
            if (txtCha.Text.Trim() == string.Empty)
            {
                   dataGridView1.DataSource = dt;
            }
            if (txtCha.Text.Trim() != string.Empty)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = $"memberuser_shenfen like '%{txtCha.Text.Trim()}%'";
                dataGridView1.DataSource = dv;
            }
         



        }
        bool flag2 = true;
        private void picGai_Click(object sender, EventArgs e)
        {
            int x = this.picGai.Location.X;
            //int q = this.picShan.Location.X;
            int y = this.picGai.Location.Y;
            //  picGai.Location = new Point(x, y)
            //MessageBox.Show(x+"---"+y);

            if (flag2)
            {
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
                flag2= false;
                return;
            }
            if (!flag2)
            {
                picCha.Visible = true;
                picZeng.Visible = true;
                picShan.Visible = true;
                Point pt1 = new Point();
                pt1.X = 170;
                pt1.Y = 19;
                this.picGai.Location = pt1;
                flpGai.Visible = false;
                flag2 = true;
                FuNull();
                return;

            }
        }
        string shen = string.Empty;
        private void btnGai_Click(object sender, EventArgs e)
        {
            shen = dataGridView1.SelectedCells[0].Value.ToString();
            if (txtGai.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }
            if (txtnameXingMing.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }
            if (txtShouJ.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }
            string jifen = $" update userscore set userscore_shenfenid = '{txtGai.Text}' where userscore_shenfenid = '{shen}'";
            string huiyuan = $" update memberuser set memberuser_shenfen = '{txtGai.Text}',memberuser_name = '{txtnameXingMing.Text}' where memberuser_shenfen = '{shen}'";
            string shiu = $"update phone set phone_shenfen = '{txtGai.Text}',phone_id = '{txtShouJ.Text}',phone.phone_tai = '{comboBox1.Text}' where phone_shenfen = '{shen}'";


            string sqlRead = $"   select memberuser_shenfen from memberuser where memberuser_shenfen = '{txtGai.Text.Trim()}'";
            SqlDataReader readers = DBHelper.ExecutReader(sqlRead);
            if (readers.Read())
            {
              int i = DBHelper.ExecuteNonQuery(jifen);
            int a = DBHelper.ExecuteNonQuery(huiyuan);
            int o = DBHelper.ExecuteNonQuery(shiu);

            if ((i+a+o)>2)
            {
                MessageBox.Show("修改成功！！");
            }
            else
            {
                MessageBox.Show("修改失败！！");
            }
            }
            else
            {
                MessageBox.Show("没查到");
            }
            readers.Close();
            Bing();
        }
        bool flag3 = true;
        private void picShan_Click(object sender, EventArgs e)
        {
            if (flag3)
            {
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
                pt2.Y = 55;
                this.flpShan.Location = pt2;
                flag3 = false;
                return;
            }
            if (!flag3)
            {
                picGai.Visible = true;
                picCha.Visible = true;
                picZeng.Visible = true;
                Point pt1 = new Point();
                pt1.X = 91;
                pt1.Y = 19;
                this.picShan.Location = pt1;
                flpShan.Visible = false;
                flag3 = true;
                FuNull();
                return;

            }
        }

        private void btnShan_Click(object sender, EventArgs e)
        {
           
            if (txtShan.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }
            string hahha = $@"select * from checkin where checkin_shenfen='{txtShan.Text}'";
            SqlDataReader reader= DBHelper.ExecutReader(hahha);
            if (reader.Read())
            {
                MessageBox.Show("用户开过单,不可删除");
            }
            else
            {
                string a = $"delete from memberuser where memberuser_shenfen = '{txtShan.Text}'";
                string s = $"delete from userscore  where  userscore_shenfenid = '{txtShan.Text}' ";
                string r = $"delete from phone  where  phone_shenfen = '{txtShan.Text}' ";
                string sqlRead = $"   select memberuser_shenfen from memberuser where memberuser_shenfen = '{txtShan.Text.Trim()}'";
                SqlDataReader readers = DBHelper.ExecutReader(sqlRead);
                if (readers.Read())
                {
                    int i = DBHelper.ExecuteNonQuery(a);
                    int k = DBHelper.ExecuteNonQuery(s);
                    int tr = DBHelper.ExecuteNonQuery(r);
                    if ((i + k + tr) > 2)
                    {
                        MessageBox.Show("删除成功！！");
                    }
                    else
                    {
                        MessageBox.Show("删除失败！！");
                    }
                }
                else
                {
                    MessageBox.Show("没查到");
                }
                readers.Close();
                Bing();
            }

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtGai.Text = dataGridView1.SelectedCells[0].Value.ToString();
            txtShan.Text = dataGridView1.SelectedCells[0].Value.ToString();
            txtZeng.Text = dataGridView1.SelectedCells[0].Value.ToString();
        }

        bool flag4 = true;
        private void picZeng_Click(object sender, EventArgs e)
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

        private void btnZeng_Click(object sender, EventArgs e)
        {

            if (txtZeng.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }
            if (txtname.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }
            if (txtShouji.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不可为空！！");
                return;
            }

            //string dianhua = txtShouji.Text;
            //if (dianhua.Length != 11)
            //{
            //    MessageBox.Show("手机号长度错误");
            //    return;
            //}
            string sqlRead = $"   select memberuser_shenfen from memberuser where memberuser_shenfen = '{txtZeng.Text.Trim()}'";
            SqlDataReader readers = DBHelper.ExecutReader(sqlRead);
            if (!readers.Read())
            {
                int t = 0;
                string fen = $"   select * from userscore where userscore_shenfenid = '{txtZeng.Text}'";
                SqlDataReader fenn = DBHelper.ExecutReader(fen);
                if (!fenn.Read())
                {
                    string sqlJiFen = $"insert  into userscore values ('{txtZeng.Text}',1,0)";
                    t =  DBHelper.ExecuteNonQuery(sqlJiFen);
                }
                fenn.Close();
                    string sqlHui = $"insert into memberuser values ('{txtZeng.Text}','{txtname.Text}',1)";
                    int i = DBHelper.ExecuteNonQuery(sqlHui);
                    string sqshouJI = $"insert into phone values('{txtZeng.Text}','{txtShouji.Text}','{"可用"}')";
                    int u = DBHelper.ExecuteNonQuery(sqshouJI);
            PublicClass.HuiYuan(shen, "0");
            if ((t+i+u)>2)
            {
                MessageBox.Show("添加成功！！");
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
            }
            else
            {
                MessageBox.Show("不可添加重复！！");
            }
            readers.Close();
            Bing();
        }
        private void FuNull()
        {
            txtCha.Text = string.Empty;
            txtGai.Text = string.Empty;
            txtname.Text = string.Empty;
            txtnameXingMing.Text = string.Empty;
            txtShan.Text = string.Empty;
            txtShouJ.Text = string.Empty;
            txtShouji.Text = string.Empty;
            txtZeng.Text = string.Empty;
            comboBox1.SelectedIndex = 0;


        }

        private void txtZeng_MouseLeave(object sender, EventArgs e)
        {
            if (txtZeng.Text.Trim() == string.Empty)
            {
                return;
            }
            if (txtZeng.Text.Trim().Length  != 18)
            {
                MessageBox.Show("身份证为18位");
                txtZeng.Text = string.Empty;
                return;
            }
        }

        private void txtShouji_MouseLeave(object sender, EventArgs e)
        {
            if (txtShouji.Text.Trim() == string.Empty)
            {
                return;
            }
            if (txtShouji.Text.Trim().Length != 11)
            {
                MessageBox.Show("手机号为11位");
                txtShouji.Text = string.Empty;
                return;
            }
        }

        private void txtGai_MouseLeave(object sender, EventArgs e)
        {
            if (txtGai.Text.Trim() == string.Empty)
            {
                return;
            }
            if (txtGai.Text.Trim().Length != 18)
            {
                MessageBox.Show("身份证为18位");
                txtGai.Text = string.Empty;
                return;
            }


        }

        private void txtShouJ_MouseLeave(object sender, EventArgs e)
        {
            if (txtShouJ.Text.Trim() == string.Empty)
            {
                return;
            }
            if (txtShouJ.Text.Trim().Length != 11)
            {
                MessageBox.Show("手机号为11位");
                txtShouJ.Text = string.Empty;
                return;
            }
        }


    }
}
