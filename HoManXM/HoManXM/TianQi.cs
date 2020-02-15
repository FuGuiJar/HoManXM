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
    public partial class TianQi : Form
    {
        public TianQi()
        {
            InitializeComponent();
        }

        private void btnCha_Click(object sender, EventArgs e)
        {
            if (txtChengShi.Text.Trim() == string.Empty)
            {
                MessageBox.Show("不能为空");
                return;
            }
            string[] aa = WeatherHelper.Weather(txtChengShi.Text.Trim());
            for (int i = 0; i < aa.Length; i++)
            {
                //txtShow.Text = aa[5];
                //txtShow.Text = aa[6];
                txtShow.Text = aa[1] + "\r\n" + aa[5] + "\r\n" + aa[6] + "\r\n" + aa[7] + "\r\n" + aa[13] + "\r\n";
                if (aa[i] == "13")
                {
                    return;
                }
            }

        }
    }
}
