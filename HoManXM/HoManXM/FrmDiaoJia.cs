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
    public partial class FrmDiaoJia : Form
    {
        public FrmDiaoJia()
        {
            InitializeComponent();
        }

        private void FrmDiaoJia_Load(object sender, EventArgs e)
        {
            //写SQL
            dataGridView1.AutoGenerateColumns = false;
            string sql = $@"select roomLei.roomLei_id,roomLei.roomLei_LeiBie,roomLei.roomLei_jiaGe,YaJin.YaJin,roomnum.roomnum_num from 
        roomLei inner join YaJin
        on(roomLei.roomLei_id = YaJin.YaJin_id)
        inner join roomnum
        on(roomLei.roomLei_id = roomnum.roomnum_id)";
            //调DB
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;  
        }

        private void 修改价格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmDiaoJiaGai jiaGai = new FrmDiaoJiaGai();
            //jiaGai.Fang =Convert.ToString( dataGridView1.SelectedRows[0].Cells[0].Value);
            //jiaGai.Show();
        }
        public void Shua()
        {
            //写SQL
            string sql = $"select roomLei_LeiBie,roomLei_jiaGe from roomLei ";
            //调DB
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Shua();
        }
    }
}