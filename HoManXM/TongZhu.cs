using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoManXM
{
    public partial class TongZhu : Form
    {
        public TongZhu()
        {
            InitializeComponent();
        }

        private void TongZhu_Load(object sender, EventArgs e)
        {
            //隐藏flp下的所有子控件
            Hide();
            //初始化同行个数
            Show();
            //注册事件
            //null
            //ShiJian();
            //初始化数组长度
            PublicClass.ShenFu = new string[Convert.ToInt32(PublicClass.KeZhu)-1];
            PublicClass.NmaeFu = new string[Convert.ToInt32(PublicClass.KeZhu)-1];

        }
        //隐藏flp下的所有子控件方法
        public void Hide()
        {
            for (int i = 0; i < flp.Controls.Count; i++)
            {
                flp.Controls[i].Visible = false;
            }
        }
        //初始化同行个数方法
        public void Show()
        {
            for (int i = 0; i < Convert.ToInt32(PublicClass.KeZhu)-1; i++)
            {
                flp.Controls[i].Visible = true;
            }
            ShiJian();
        }

        //注册事件方法
        public void ShiJian()
        {
            for (int i = 0; i < flp.Controls.Count; i++)
            {
                //MessageBox.Show(flp.Controls[i].Controls[3].Name+ flp.Controls[i].Controls[1].Name);
                flp.Controls[i].Controls[2].MouseLeave += new EventHandler(Shen_MouseLeave);
                flp.Controls[i].Controls[1].MouseLeave += new EventHandler(Name_MouseLeave);
            }

        }
        //鼠标经过事件
        private void Shen_MouseLeave(object sender, EventArgs e)
        {

            TextBox text = (TextBox)sender;
            if (text.Text.Trim() == string.Empty)
            {
                return;
            }
            if (text.Text.Trim().Length != 18)
            {
                MessageBox.Show("身份证为18位");
                text.Text = string.Empty;
            }

        }
        private void Name_MouseLeave(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Text.Trim() == string.Empty)
            {
                MessageBox.Show("姓名不能为空！！");
            }

        }

        private void btnQuXiao_Click(object sender, EventArgs e)
        {
            PublicClass.Check = false;
            PublicClass.To = false;
            PublicClass.NmaeFu = null;
            PublicClass.ShenFu = null;
            this.Close();
        }

        private void TongZhu_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btnQueDing_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(PublicClass.KeZhu)-1; i++)
            {
                //MessageBox.Show(flp.Controls[i].Controls[2].Text.Trim() + flp.Controls[i].Controls[1].Text.Trim());
                PublicClass.ShenFu[i] = flp.Controls[i].Controls[2].Text.Trim();
                PublicClass.NmaeFu[i] = flp.Controls[i].Controls[1].Text.Trim();
            }
            //MessageBox.Show("Test");
            //foreach (var item in PublicClass.ShenFu)
            //{
            //    MessageBox.Show(item);
            //}
            //foreach (var item in PublicClass.NmaeFu)
            //{
            //    MessageBox.Show(item);
            //}
            PublicClass.Check = true;
            this.Close();
        }
    }
}
