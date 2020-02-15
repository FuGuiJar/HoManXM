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
    public partial class Hua : Form
    {
        public Hua()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VoiceHelper.SpeakAsync(textBox1.Text.Trim());


        }

        private void Hua_Load(object sender, EventArgs e)
        {
             
        }
    }
}
