using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
    //DrawBorder


namespace HoManXM
{
    public partial class XiuGaiFangTai : Form
    {
        public XiuGaiFangTai()
        {
            InitializeComponent();
        }

        private void XiuGaiFangTai_Load(object sender, EventArgs e)
        {
          


            txtFangH.Text = PublicClass.FangH;
            if (PublicClass.FangTai == "未入住")
            {
                pictureBox1.Image = imgDa.Images[0];
            }
            else if (PublicClass.FangTai == "已入住")
            {
                pictureBox1.Image = imgDa.Images[1];
            }
            else if (PublicClass.FangTai == "脏房")
            {
                pictureBox1.Image = imgDa.Images[2];
            }
            else if (PublicClass.FangTai == "预定")
            {
                pictureBox1.Image = imgDa.Images[3];
            }
            else if (PublicClass.FangTai == "停用")
            {
                pictureBox1.Image = imgDa.Images[4];
            }

        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            string sqlf = $@"update room set room_zhuangTai = 1 where room_id = '{PublicClass.FangH}' ";
            DBHelper.ExecuteNonQuery(sqlf);
            this.Close();
        }

        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {
            string sqlf = $@"update room set room_zhuangTai = 2 where room_id = '{PublicClass.FangH}' ";
            DBHelper.ExecuteNonQuery(sqlf);
            this.Close();
        }

        private void pictureBox5_DoubleClick(object sender, EventArgs e)
        {
            string sqlf = $@"update room set room_zhuangTai = 3 where room_id = '{PublicClass.FangH}' ";
            DBHelper.ExecuteNonQuery(sqlf);
            this.Close();
        }

        private void pictureBox7_DoubleClick(object sender, EventArgs e)
        {
            string sqlf = $@"update room set room_zhuangTai = 4 where room_id = '{PublicClass.FangH}' ";
            DBHelper.ExecuteNonQuery(sqlf);
            this.Close();
        }

        private void pictureBox6_DoubleClick(object sender, EventArgs e)
        {
            string sqlf = $@"update room set room_zhuangTai = 5 where room_id = '{PublicClass.FangH}' ";
            DBHelper.ExecuteNonQuery(sqlf);
            this.Close();
        }

  
    }
}
