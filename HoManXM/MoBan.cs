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
    public partial class MoBan : Form
    {
        public MoBan()
        {
            InitializeComponent();
        }
        private void MoBan_Load(object sender, EventArgs e)
        {
            Default();



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
                pt2.Y = 1;
                this.flpCha.Location = pt2;
                flag = false;
                return;
            }
            if (!flag)
            {
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
                pt2.Y = 1;
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
                return;
            }
        }




        #endregion


    }
}
