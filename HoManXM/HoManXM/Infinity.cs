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
    public partial class Infinity : Form
    {
        public Infinity()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            Form1 form = new Form1();
            this.Hide();
            form.ShowDialog();
            this.Hide();
                }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            TianQi form = new TianQi();
            this.Hide();
            form.ShowDialog();
            this.Hide();

        }
    }
}
