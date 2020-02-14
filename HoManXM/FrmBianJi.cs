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
    public partial class FrmBianJi : Form
    {
        public FrmBianJi()
        {
            InitializeComponent();
        }
        public int hao;
        private void 编辑商品_Load(object sender, EventArgs e)
        {
            DongXi();
           

        }
        public void DongXi()
        {
            
            txtXuHao.Text =Convert.ToString( hao);
            //写SQL
            string sql = $"select  goods_name, goods_money,goods_shuliang from goods where goods_id={hao}";
            //调DB
            SqlDataReader reader= DBHelper.ExecutReader(sql);
            //判断
            if (reader.Read())
            {
                txtPrice.Text = reader["goods_money"].ToString();
                txtMingCheng.Text = reader["goods_name"].ToString();
                txtShuLiang.Text = reader["goods_shuliang"].ToString();
              
            }

        }
        //改价
        private void GaiJia()
        {
            string Name = txtMingCheng.Text;
            string prices = txtPrice.Text;
            string shuliang = txtShuLiang.Text;
            string qq = $"select goods_name from goods where  goods_name ='{Name}'";
            SqlDataReader reader = DBHelper.ExecutReader(qq);
            if (reader.Read())
            {
                MessageBox.Show("商品已存在");
                return;
            }
            else
            {
                //写sql
                string qq1 = $"select goods_name from goods where  goods_name ='{Name}'";
                SqlDataReader re = DBHelper.ExecutReader(qq1);
                if (reader.Read())
                {
                    MessageBox.Show("商品已存在");
                    return;
                }
                else
                {
                    string sql = string.Format($"update goods set goods_name='{Name}',goods_money={prices},goods_shuliang={shuliang} where goods_id={hao}");
                    //调DB
                    int i = DBHelper.ExecuteNonQuery(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("成功了");
                    }
                    else
                    {
                        MessageBox.Show("重复");
                    }
                }
            }
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            GaiJia();
          
        }

        private void FrmBianJi_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
