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
    public partial class FrmAdd : Form
    {
        public FrmAdd()
        {
            InitializeComponent();
        }

        private void FrmAdd_Load(object sender, EventArgs e)
        {


        }

        private void btn1_Click(object sender, EventArgs e)
        {
            
            string name = txtMingCheng.Text;
            double pirce = Convert.ToDouble(txtPrice.Text);
            int shu = Convert.ToInt32(txtShuLiang.Text);
            //写SQL
            string sql=string.Format($" select * from goods where  goods_name='{name}'");
            //调DB
            SqlDataReader reader= DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                MessageBox.Show("商品名称重复");
            }
            else
            {
                string sql1 =$"insert into goods values('{name}',{pirce},{shu})";
                int i= DBHelper.ExecuteNonQuery(sql1);
                if (i > 0)
                {
                    MessageBox.Show("添加成功");
                    //FrmShangPincomplie fff = new FrmShangPincomplie(); 
                    //这是什么对象
                    //fff.ChushiDGV();
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
            
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtShuLiang_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}

