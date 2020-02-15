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
    public partial class DengLu : Form
    {
        public DengLu()
        {
            InitializeComponent();
        }

        private void DengLu_Load(object sender, EventArgs e)
        {
  

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string XH = zhanghao.Text;
            string MM = mima.Text;
          
            if (zhanghao.Text.Trim() == string.Empty || mima.Text.Trim() == string.Empty)
            {
                if (zhanghao.Text.Trim() == string.Empty)
                {
                    redzi1.Text = "请输入账号！！";
                    redzi1.ForeColor = Color.FromArgb(255, 255, 0, 0);
                }
                if (mima.Text.Trim() == string.Empty)
                {
                    redzi2.Text = "请输入密码！！";
                    redzi2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
                }
            }
            else
            {
                SqlDataReader reader = DBHelper.Parameter("Login", "login_zhanghao","login_Pwd", XH,MM);
                if (reader.Read())
                {
                    string name = string.Empty;
                    int level = 0;
                    string sql = $"select login_name,login_Level,login_State from [Login] where login_zhanghao = '{XH}'";
                    SqlDataReader re = DBHelper.ExecutReader(sql);
                    if (re.Read())
                    {
                        name = re[0].ToString();
                        level = int.Parse(re[1].ToString());
                        if (re[2].ToString() == "2")
                        {
                            MessageBox.Show("该账户已停用");
                            return;
                        }

                    }
                    re.Close();
                    redzi2.Text = " ";
                    redzi1.Text = " ";
                    Hosthoman zhu = new Hosthoman();
                    zhu.mingzi = name;
                    zhu.dengji = level;
                    zhu.Name = zhanghao.Text;
                    this.Hide();
                    PublicClass.GuanLiYuan = zhanghao.Text;
                    string sq1 = $"select login_Level from Login where login_zhanghao = '{zhanghao.Text.Trim()}'";
                    SqlDataReader reader2 = DBHelper.ExecutReader(sq1);
                    if (reader2.Read())
                    {
                        PublicClass.Level = reader2[0].ToString();
                    }
                    PublicClass.MiM = mima.Text;
                    reader2.Close();
                    zhu.Show();
                }
                else
                {
                    if (!(zhanghao.Text.Trim() == string.Empty) && !(mima.Text.Trim() == string.Empty))
                    {
                        redzi1.Text = "账号或密码错误！！";
                        redzi1.ForeColor = Color.FromArgb(255, 255, 0, 0);
                        redzi2.Text = "账号或密码错误！！";
                        redzi2.ForeColor = Color.FromArgb(255, 255, 0, 0);

                    }
                    else
                    {
                         MessageBox.Show("未找到你  ！！","消息提示！");
                    }
                  
            }
                reader.Close();
        }

        }
           
        //退出
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("确定要退出吗？","退出提示",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result==DialogResult.Yes)
            {
                this.Close();
            }
        }


        //账号警示
        private void mima_Enter(object sender, EventArgs e)
        {
            redzi2.Text = " ";
        }
        //密码警示
        private void zhanghao_Enter(object sender, EventArgs e)
        {
            redzi1.Text = " ";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
