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
using System.Data;
namespace HoManXM
{
    public partial class FrmHuiYuan : Form
    {
        public FrmHuiYuan()
        {
            InitializeComponent();
        }
        public string HuiYuan;
        private void FrmHuiYuan_Load(object sender, EventArgs e)
        {
            //写SQL
            string sql = @"select s.memberuser_shenfen,s.memberuser_name,u.userscore_jifen,m.member_level from member as m inner join memberuser as s on(m.member_id = s.memberuser_dengji)
            inner join userscore as u on(u.userscore_shenfenid = s.memberuser_shenfen)";
            //调DB
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource=dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string hao = textBox1.Text;
            if (hao == string.Empty)
            {
                MessageBox.Show("请输入会员号");
                return;
            }
            //写SQL
            string sql = $@"select s.memberuser_shenfen,s.memberuser_name,u.userscore_jifen,m.member_level from member as m inner join memberuser as s on(m.member_id = s.memberuser_dengji)
            inner join userscore as u on(u.userscore_shenfenid = s.memberuser_shenfen) where s.memberuser_shenfen like '%{hao}%'";
            //调DB
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;
        }


        string yu;
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void FrmHuiYuan_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            
        }
    }
}
