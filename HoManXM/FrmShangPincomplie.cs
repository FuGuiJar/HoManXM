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
    public partial class FrmShangPincomplie : Form
    {
        public FrmShangPincomplie()
        {
            InitializeComponent();
        }
        private void FrmShangPincomplie_Load(object sender, EventArgs e)
        {

            
            //初始化DGV
            ChushiDGV();

        }
        //初始化DGV
        public void ChushiDGV()
        {
            //写SQL
            string sql = "select * from goods";
            //调DB
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;

        }
        

        private void pictureAdd_Click(object sender, EventArgs e)
        {
            FrmAdd fa = new FrmAdd();
            fa.Show();
        }

        private void pictureBianJi_Click(object sender, EventArgs e)
        {
           
            FrmBianJi fbj = new FrmBianJi();
            fbj.hao = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            fbj.Show();
        }
        DataTable dt = null;
        private void pictureDelete_Click(object sender, EventArgs e)
        {
            int xu =Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[0].Value);
            string ming = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //写SQL
            string sqcl = $@"select * from goods  as g inner join XiaoFei as x on  (x.MingCheng=g.goods_name) where x.MingCheng='{ming}'";
            SqlDataReader reader= DBHelper.ExecutReader(sqcl);
            if (reader.Read())
            {
                MessageBox.Show("商品已被购买,不可删除");
                return;
            }
            else
            {
                string sql = $"delete goods where goods_id = {xu}";
                  //调DB
                int i= DBHelper.ExecuteNonQuery(sql);
                if (i > 0)
                {
                 //初始化DGV
                 ChushiDGV();
                 }
                else
                {
                        MessageBox.Show("删除失败");
                }
            }
            
        }
        

        private void pictureShuaXin_Click(object sender, EventArgs e)
        {
            //初始化DGV
            ChushiDGV();

        }

       

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string yu = textBox1.Text;
            //写SQl
            string sql = $"select * from goods where goods_name like '%{yu}%'";
            //调DB
            DataTable dt = DBHelper.GetTable(sql);
            dataGridView1.DataSource = dt;
            
        }

    
    }
}
