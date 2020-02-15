using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HoManXM.Weather;
using System.ServiceModel;
using System.Runtime.InteropServices;
using HoManXM.cn.com.webxml.www;

namespace HoManXM
{
    public partial class Tianfanglei : Form
    {
        public Tianfanglei()
        {
            InitializeComponent();
        }

        private void Tianfanglei_Load(object sender, EventArgs e)
        {



        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(61, 212, 255);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
           pictureBox1.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(61, 212, 255);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TianFangLeiBie fangLei = new TianFangLeiBie();
            fangLei.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TianFang fang = new TianFang();
            fang.ShowDialog();
            this.Close();
        }
    }
}
