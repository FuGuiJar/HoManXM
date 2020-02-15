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
    public partial class Frmshouji : Form
    {
        public Frmshouji()
        {
            InitializeComponent();
        }
        public string FangHao;
         public string Fang ;
        public string shouji;
        private void Frmshouji_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == shouji)
            {
                RuZhuYu ruZhvu = new RuZhuYu();
                ruZhvu.Yn = true;
                ruZhvu.Fang = Fang;
                ruZhvu.FangHao = FangHao;
                ruZhvu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("手机号不对,重新输入");
            }
            
        }
    }
}
