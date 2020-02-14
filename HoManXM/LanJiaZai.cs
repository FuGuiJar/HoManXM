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
    public partial class LanJiaZai : Form
    {
        public LanJiaZai()
        {
            InitializeComponent();
        }
        public string Zhi { get; set; }
        private void LanJiaZai_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(progressBar1.Value) ==100)
            {
                switch (Zhi)
                {
                    case "入住":
                        timer1.Stop();
                        timer1.Enabled = false;
                        Hide();
                        FangFei fei = new FangFei();
                        fei.ShowDialog();
                        break;
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    default:
                        MessageBox.Show("错误！");
                        break;
                }
                return;
            }
        }
    }
}
