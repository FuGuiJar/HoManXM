using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HoManXM
{
    public partial class Ce : Form
    {
        public Ce()
        {
            InitializeComponent();
        }

        private void Ce_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            //this.BackColor = Color.White;
            //this.TransparencyKey = Color.White;
            //this.Opacity = 1;
            //panel1.ForeColor = Color.Purple;
            //panel1.BackColor = Color.White;

            //ExtendedPanel pa = new ExtendedPanel();
            //pa.BackColor = Color.Red;
            //Point pt1 = PointToScreen(panel1.Location);
            //pa.Location = pt1;
            //pa.Anchor = AnchorStyles.None;
            //this.Controls.Add(pa);
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string aa = string.Empty;
            string sql = $"select login_Pwd from Login where login_Level =0";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                aa = reader[0].ToString();
            }
            reader.Close();
            if (txtMiMa.Text.Trim() == PublicClass.MiM || txtMiMa.Text.Trim() ==aa)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("密码错误！！");
                txtMiMa.Text = string.Empty;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //123
        }
    }
}
