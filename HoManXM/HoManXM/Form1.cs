using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HoManXM;
namespace HoManXM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(0, 122, 204, 0);

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(217, 217, 217, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void yi_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "1";
        }

        private void er_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "2";
        }

        private void san_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "3";
        }

        private void si_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "4";
        }

        private void wu_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "5";
        }

        private void liu_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "6";
        }

        private void qi_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "7";
        }

        private void ba_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "8";
        }

        private void jiu_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text+"9";
        }

        //归零
        private void shanchu_Click(object sender, EventArgs e)
        {
            xianshi.Text = string.Empty;
        }

        private void yu_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "%";
        }

        private void ling_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "0";
        }

        private void dian_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + ".";
        }

        private void jian_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "－";
        }

        private void jia_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "＋";
        }

        private void cheng_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "×";
        }

        private void chu_Click(object sender, EventArgs e)
        {
            xianshi.Text = xianshi.Text + "÷";
        }

        private void dengyu_Click(object sender, EventArgs e)
        {
            string[] getAry = xianshi.Text.Split(new char[] { '＋', '－', '×', '÷','%' });
            string result = System.Text.RegularExpressions.Regex.Replace(xianshi.Text, @"[0-9]+", "");
            xianshi.Text = xianshi.Text + "=" + JiSuan1(getAry[0],result, getAry[1]);
        }
        //计算
        public double JiSuan1(string a,string b,string c)
        {
            double sum = 0;
            double aa = Convert.ToDouble(a);
            double cc = Convert.ToDouble(c);
            switch (b)
            {
                case "÷":
                    sum = aa / cc;
                break;
                case "×":
                    sum = aa * cc;
                    break;
                case "＋":
                    sum = aa + cc;
                    break;
                case "－":
                    sum = aa - cc;
                    break;
                case "%":
                    sum = aa % cc;
                    break;
                default:
                    MessageBox.Show("错误！！");
                    break;
            }
            return sum;
        }


    }
}
