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
    public partial class RuZhuChaXun : Form
    {
        public RuZhuChaXun()
        {
            InitializeComponent();
        }

        private void RuZhuChaXun_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            string sql = $@"select *from 
	checkin left join checkedout
	on(checkedout.checkedout_id = checkin.checkin_id)
	inner join roomLei
	on(checkin.checkin_leixing = roomLei.roomLei_id)
	left join duoren
	on(checkin.checkin_id = duoren.duoren_id)
	inner join Tai
	on(checkin.checkin_id = Tai.Tai_id)
	left join timec 
	on(checkin.checkin_id = timec.time_h)";
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;



            //where consume_time  between '{dtpKai.Value}' and '{dtpTing.Value}'
        }

        private void btnCha_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            string sql = $@"select *from 
	checkin left join checkedout
	on(checkedout.checkedout_id = checkin.checkin_id)
	inner join roomLei
	on(checkin.checkin_leixing = roomLei.roomLei_id)
	left join duoren
	on(checkin.checkin_id = duoren.duoren_id)
	inner join Tai
	on(checkin.checkin_id = Tai.Tai_id)
	left join timec 
	on(checkin.checkin_id = timec.time_h)
    where checkin_rushi  between '{dtpKai.Value}' and '{dtpTing.Value}'
";

            //string sql = $@"select *from checkin ";
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.AutoGenerateColumns = false;
            string sql = $@"select *from 
	checkin left join checkedout
	on(checkedout.checkedout_id = checkin.checkin_id)
	inner join roomLei
	on(checkin.checkin_leixing = roomLei.roomLei_id)
	left join duoren
	on(checkin.checkin_id = duoren.duoren_id)
	inner join Tai
	on(checkin.checkin_id = Tai.Tai_id)
	left join timec 
	on(checkin.checkin_id = timec.time_h)";
            DataTable dt = DBHelper.GetTable(sql);

            if (txtShen.Text.Trim() == string.Empty)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataView dv = new DataView(dt);
                dv.RowFilter =$"checkin_shenfen ={ txtShen.Text.Trim()}";
                dataGridView1.DataSource = dv;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.AutoGenerateColumns = false;
            string hao = string.Empty;
            if (e.RowIndex > -1)
            {
                hao = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
                string sql = $"select * from duoren where duoren_id = '{hao}'";
                DataTable dt = DBHelper.GetTable(sql);
                dataGridView2.DataSource = dt;

        }
    }
}
