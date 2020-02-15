using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoManXM
{
    public partial class RuZhuYu : Form
    {
        public RuZhuYu()
        {
            InitializeComponent();
        }
        public bool Yn { get; set; }
        //public string [] ShenFu { get; set; }
        public string Fang { get; set; }
        public string FangHao { get; set; }
        public string Fen { get; set; }
        private void RuZhu_Load(object sender, EventArgs e)
        {
             //Fang = "1";
            Bind();
            if (Yn)
            {
                ChuShiHua();
            }
           

            cboSex.SelectedIndex = 0;
            //cboFanghao.SelectedIndex = 0;
            kezhu();
            //MessageBox.Show(Yn.ToString());
            
        }



        private void Bind()
        {
            string sql = $"select roomLei_id,roomLei_LeiBie from roomLei";
            DataTable dt = DBHelper.GetTable(sql);
            txtLeiXing.ValueMember = "roomLei_id";
            txtLeiXing.DisplayMember = "roomLei_LeiBie";
            txtLeiXing.DataSource = dt;

            string sql2 = $"select room_id, room_LeiBie from room";
            DataTable dt2 = DBHelper.GetTable(sql2);
            cboFanghao.DataSource = dt2;
            cboFanghao.ValueMember = "room_LeiBie";
            cboFanghao.DisplayMember = "room_id";

        }
        private void ChuShiHua()
        {
            #region 问题
 //           select r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai,YaJin.YaJin
 //from  room as r

 //     inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)

 //     inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)

 //     inner join YaJin on(l.roomLei_id = YaJin.YaJin_id)
 //     where r.room_id = { Convert.ToInt32(FangHao)}
            #endregion
            //MessageBox.Show(FangHao);
            string sql = $@"select * from reserve inner join room on(room.room_id=reserve.reserve_fanghao)
                            where  reserve.reserve_fanghao={FangHao}";

            cboFanghao.SelectedItem = FangHao;
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                txtName.Text = reader[1].ToString();
                //cboFanghao.Text = reader[5].ToString();
                //MessageBox.Show(Fang);
                //MessageBox.Show(FangHao);

                txtLeiXing.SelectedIndex =Convert.ToInt32( reader[11])-1;
                cboFanghao.Text =reader[5].ToString();

                txtJiaGe.Text = reader[4].ToString();
                txtDingJIn.Text = 200.ToString();
                //更改
                int i = (int)Convert.ToDouble(reader[2].ToString());
                int tian = Convert.ToInt32(Days.Value.ToString());
                Fen = (i * tian).ToString();
            }
            else
            {

                //txtFangHao1.Text = 
                //string sql = $"";

                //cboFanghao.SelectedValue = PublicClass.Fjian;
                cboFanghao.Text = PublicClass.Fjian;
                txtName.Text = PublicClass.Name;
                string sqll = $@"	select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai,YaJin.YaJin
	  from  room as r 
	  inner join roomLei as l on (r.room_LeiBie=l.roomLei_id)
	  inner join roomTai as t on (r.room_zhuangTai=t.roomTai_id)
	  inner join YaJin on(l.roomLei_id = YaJin.YaJin_id)
      where r.room_id = '{cboFanghao.Text}'
";
                //txtFangHao.Text = FangHao;
                SqlDataReader readerq = DBHelper.ExecutReader(sqll);
                if (readerq.Read())
                {
                    txtLeiXing.Text = readerq[1].ToString();
                    txtJiaGe.Text = readerq[2].ToString();
                    txtDingJIn.Text = readerq[4].ToString();
                    int i = (int)Convert.ToDouble(readerq[2].ToString()) ;
                    int tian = Convert.ToInt32(Days.Value.ToString());
                    Fen = (i * tian).ToString();
                }
                readerq.Close();
            }
            reader.Close();
        }
        private void btnTiJiao_Click(object sender, EventArgs e)
        {
           
            //ChaFangJian();
            if (PublicClass.To)
            {
                //for (int i = 0; i < flpTongZhu.Controls.Count; i++)
                //{
                //    if (flpTongZhu.Controls[i].Text.Trim() == string.Empty)
                //    {
                //        MessageBox.Show("同行信息不能为空！！");
                //        return;
                //    }
                //}
                //cun();
            }


            if (txtShen.Text.Trim() == string.Empty)
            {
                return;
            }
            if (txtShen.Text.Trim().Length != 18)
            {
                txtShen.Text = string.Empty;
                MessageBox.Show("请输入18位身份证");
                return;
            }

            int sex = Convert.ToInt32(txtShen.Text.Trim().Substring(16, 1));
            if (sex % 2 == 0)
            {
                cboSex.SelectedIndex = 1;
            }
            else
            {
                cboSex.SelectedIndex = 0;
            }


            string sql = $@"	select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai
      from room as r
      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)
      where r.room_id = {Convert.ToInt32(cboFanghao.Text)}";
            SqlDataReader readerf = DBHelper.ExecutReader(sql);
            while (readerf.Read())
            {
                if (!Yn)
                {
                    if (readerf[3].ToString() != "未入住" && readerf[3].ToString() != "有人预定但未入住")
                    {
                        //预定
                        MessageBox.Show("请选择未入住的房间！！");
                        return;
                    }
                }

            }
            readerf.Close();
            if (Convert.ToInt32(Days.Value.ToString()) < 1)
            {
                MessageBox.Show("天数最小为1");
                return;
            }
            if (txtName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("任何值不能为空！！");
                return;
            }
            if (txtShen.Text.Trim() == string.Empty)
            {
                MessageBox.Show("任何值不能为空！！");
                return;
            }


            //string shen = txtShen.Text;
            //string sqlHuiYuan = $"select * from userscore where userscore_shenfenid = '{shen}' ";
            //SqlDataReader readerHuiYuan = DBHelper.ExecutReader(sqlHuiYuan);
            //if (!readerHuiYuan.Read())
            //{
            //    PublicClass.Fa = true;
            //    string ff = $@"select * from userscore where userscore_shenfenid = '{shen}'";
            //    SqlDataReader reader4 = DBHelper.ExecutReader(ff);
            //    if (!reader4.Read())
            //    {
            //        string sqlJiFen = $"insert  into userscore values ('{shen}',1,0)";
            //        DBHelper.ExecuteNonQuery(sqlJiFen);
            //    }
            //    reader4.Close();
            //    PublicClass.HuiYuan(shen, Fen);
            //}
            //else
            //{
            //    PublicClass.Fa = false;
            //    PublicClass.HuiYuan(shen, Fen);
            //}
            //readerHuiYuan.Close();

            if (Days.Value.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("任何值不能为空！！");
                return;
            }
            string y = txtDingJIn.Text;
            PublicClass.YaJin = y;
            PublicClass.ShenF = txtShen.Text;
            PublicClass.Tian = int.Parse(Days.Value.ToString());
            PublicClass.FangH = cboFanghao.Text;
            PublicClass.Money = Convert.ToDouble(txtJiaGe.Text);
            PublicClass.JiFen = Fen;
            PublicClass.SEX = cboSex.Text;
            PublicClass.NAME = txtName.Text;
            PublicClass.SHEN = txtShen.Text;
            PublicClass.RiQi = DateTime.Now.ToString();


            string sqlleixing = $"select roomLei_id from roomLei where roomLei_LeiBie = '{txtLeiXing.Text}'";
            SqlDataReader readerlei = DBHelper.ExecutReader(sqlleixing);
            PublicClass.FangLei = 1;
            if (readerlei.Read())
            {
                string sw = $@"update reserve set reserve_ZhuangTai=2 where reserve_fanghao={FangHao}";
                if (DBHelper.ExecuteNonQuery(sw) > 0)
                {

                }
                PublicClass.FangLei = Convert.ToInt32(readerlei[0].ToString());
            }
            readerlei.Close();
            LanJiaZai jiaZai = new LanJiaZai();
            jiaZai.Zhi = "入住";
            this.Close();
            jiaZai.ShowDialog();
        }
        //添加订单
        public int TiJiaoDingDan()
        {
  
            ///
           // MessageBox.Show(fanglei.ToString());
         //   MessageBox.Show($"{name}-{shen}-{PublicClass.SEX}-{dingjin}-{riqi}-{tian}-{FangHao}-{fanglei}-{PublicClass.SUM}-{jifen}");
            ///
            string sql = $"	insert into checkin values('{PublicClass.NAME}','{PublicClass.SHEN}','{PublicClass.SEX}','{PublicClass.YaJin}','{ PublicClass.RiQi}',{PublicClass.Tian},{PublicClass.FangH},{PublicClass.FangLei},{PublicClass.SUM},{PublicClass.JiFen})";
            int i = DBHelper.ExecuteNonQuery(sql);
            return i;
        }
        //增加积分
        //增加会员
//        private void txtFangHao_MouseLeave(object sender, EventArgs e)
//        {
//            ChaFangJian();
//            string sql = $@"	select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai
//      from room as r
//      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
//      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)
//      where r.room_id = '{FangHao}'
//";
//            SqlDataReader reader = DBHelper.ExecutReader(sql);
//            while (reader.Read())
//            {
//                if (!(reader[3].ToString() == "未入住" || reader[3].ToString() == "预定"))
//                {
//                    MessageBox.Show("请选择未入住的房间！！");
//                    return;
//                }
//            }
//            reader.Close();
//        }
        private void ChaFangJian()
        {
            string sql = $@"	select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai
                  from room as r
                  inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
                  inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)
                  where r.room_id = {cboFanghao.Text}
            ";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            while (reader.Read())
            {
                if (!(reader[3].ToString() == "未入住"))
                {
                    MessageBox.Show("请选择未入住的房间！！");
                    txtLeiXing.SelectedIndex = 0;
                    return;
                }
            }
            reader.Close();
        }
        private void btnChongZhi_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtShen.Text = string.Empty;
            cboSex.SelectedIndex = 0;
            txtLeiXing.SelectedIndex = 0;


        }

        private void txtFangHao_TextChanged(object sender, EventArgs e)
        {
        }

        private void Days_ValueChanged(object sender, EventArgs e)
        {
            ChuShiHua();
        }



        private void Days_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void txtShen_MouseLeave(object sender, EventArgs e)
        {
            if (txtShen.Text.Trim() == string.Empty)
            {
                return;
            }
                if (txtShen.Text.Trim().Length != 18)
                {
                    txtShen.Text = string.Empty;
                    MessageBox.Show("请输入18位身份证");
                    return;
                }

            int sex = Convert.ToInt32(txtShen.Text.Trim().Substring(16,1));
            if (sex % 2 == 0)
            {
                cboSex.SelectedIndex = 1;
            }
            else
            {
                cboSex.SelectedIndex = 0;
            }

        }
        public int defa = 3;
        private void txtLeiXing_SelectedIndexChanged(object sender, EventArgs e)
        {


            string sql2 = $"select room_id, room_LeiBie from room";
            DataTable dt2 = DBHelper.GetTable(sql2);
            cboFanghao.DataSource = dt2;
            cboFanghao.ValueMember = "room_LeiBie";
            cboFanghao.DisplayMember = "room_id";
            DataView dv = new DataView(dt2);
            //MessageBox.Show(txtLeiXing.SelectedValue.ToString());
            dv.RowFilter = $"room_LeiBie = {Convert.ToInt32(txtLeiXing.SelectedValue)}";
            cboFanghao.DataSource = dv;
            kezhu();
            PublicClass.Check = false;
            cbTongXing.Checked = false;
        }

        private void cboFanghao_SelectedIndexChanged(object sender, EventArgs e)
        {


            //FangHao = cboFanghao.Text;
            //kezhu();
            //ChaFangJian();


            //           string sql = $@"select * from 
            //roomLei inner join room 
            //on(roomLei.roomLei_id = room.room_LeiBie)
            //where room.room_id = {Convert.ToInt32(FangHao)}";
            //           SqlDataReader reader = DBHelper.ExecutReader(sql);
            //           if (reader.Read())
            //           {
            //               txtLeiXing.SelectedIndex = Convert.ToInt32(reader[0].ToString())-1; 
            //           }
            //           reader.Close();
        }

        private void kezhu()
        {
  
            string sql = $@"select room.room_id,roomLei.roomLei_LeiBie,roomnum.roomnum_num from
	room inner join roomLei
	on(room.room_LeiBie = roomLei.roomLei_id)
	inner join roomnum
	on(roomLei.roomLei_id = roomnum.roomnum_id)
	where room.room_id = '{FangHao}'"; // Convert.ToInt32(cboFanghao.Text)
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                labKeZhu.Text = reader[2].ToString();
            }
            reader.Close();


        }

        string name = "txtfu";
        bool flag = true;
        //private void btnTongZhu_Click(object sender, EventArgs e)
        //{
        //    //显示隐藏flp
        //    if (flag)
        //    {
        //        PublicClass.To = flag;
        //        flpTongZhu.Visible = true;
        //        flag = false;

        //        //打开删除TextBox
        //        //foreach (Control c in this.flpTongZhu.Controls)
        //        //{
        //        //}
        //        //for (int i = 0; i < flpTongZhu.Controls.Count; i++)
        //        //{
        //        //    flpTongZhu.Controls.Remove(flpTongZhu.Controls[i]);
        //        //}
        //        flpTongZhu.Controls.Clear();
        //        //监测可住人数
        //        if (Convert.ToInt32(labKeZhu.Text) == 1)
        //        {
        //            MessageBox.Show("抱歉该房间只可住一人");
        //            return;
        //        }
        //        //打开产生TextBox
        //        //string name = "txtfu";
        //        // Convert.ToInt32(labKeZhu.Text) -1
        //        for (int i = 0; i < Convert.ToInt32(labKeZhu.Text) - 1; i++)
        //        {
        //            TextBox txt = new TextBox();
        //            txt.Name = name + i;
        //            txt.Width = 125;
        //            flpTongZhu.Controls.Add(txt);
        //        }
        //        //初始化数组长度
        //        PublicClass.ShenFu = new string[Convert.ToInt32(labKeZhu.Text) - 1];

        //        //循环加事件
        //        TextBox txt1 = new TextBox();
        //        //MessageBox.Show(flpTongZhu.Controls.Count.ToString());
        //        for (int i = 0; i < flpTongZhu.Controls.Count; i++)
        //        {
        //            //MessageBox.Show(i.ToString());
        //            NullEvent(txt1);
        //            //字符串转TextBox
        //            txt1 = (TextBox)this.Controls.Find(flpTongZhu.Controls[i].Name, true)[0];
        //            AddEvent(txt1);
        //        }

        //    }
        //    else
        //    {
        //        PublicClass.To = flag;
        //        //关闭时事件赋NULL
        //        for (int i = 0; i < flpTongZhu.Controls.Count; i++)
        //        {
        //            TextBox txt = (TextBox)this.Controls.Find(flpTongZhu.Controls[i].Name, true)[0];
        //            NullEvent(txt);
        //        }
        //        //数组赋NULL
        //        PublicClass.ShenFu = null;
        //        flpTongZhu.Visible = false;
        //        flag = true;
        //    }
           

         

        //    }


        private void cboFanghao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            kezhu();
            ChaFangJian();
        }

        private void cbTongXing_CheckedChanged(object sender, EventArgs e)
        {
            if (labKeZhu.Text == "1")
            {
                return;
            }
            if (cbTongXing.Checked)
            {
                    PublicClass.To = true;
            }
            else
            {
                PublicClass.To = false;
            }
            if (cbTongXing.Checked)
            {
                TongZhu tongZhu = new TongZhu();
                PublicClass.KeZhu = labKeZhu.Text;
                tongZhu.ShowDialog();
                if (PublicClass.Check)
                {
                    cbTongXing.Checked = true;
                }
                else
                {
                    cbTongXing.Checked = false;
                }
            }
        }

        private void cbTongXing_MouseClick(object sender, MouseEventArgs e)
        {
            if (labKeZhu.Text == "1")
            {
                MessageBox.Show("该房间只可住一人！！");
                cbTongXing.Checked = false;
            }
        }

        private void txtLeiXing_Click(object sender, EventArgs e)
        {
            if (Yn)
            {
                MessageBox.Show("预定不可更改房间");
                return;
            }
        }

        private void cboFanghao_Click(object sender, EventArgs e)
        {
            if (Yn)
            {
                MessageBox.Show("预定不可更改房间");
                return;
            }
        }
        //注册事件
        //public void AddEvent(TextBox text)
        //{
        //    text.MouseLeave += new EventHandler(CunText);
        //}
        //public void NullEvent(TextBox text)
        //{
        //    text.MouseLeave += null;
        //}
        //事件判断输入是否合法并给字符串数组赋值
        //public void CunText(object sender, EventArgs e)
        //{
        //    cun();
        //}
        //事件方法
        //public void cun()
        //{
        //    //flpTongZhu.Controls.Count
        //    for (int i = 0; i < Convert.ToInt32(labKeZhu.Text)-1; i++)
        //    {
        //        //flpTongZhu.Controls[i].Text = "qwe";
        //        //MessageBox.Show(flpTongZhu.Controls[i].Name + "+++" + flpTongZhu.Controls[i].Text);
        //        if (flpTongZhu.Controls[i].Text.Trim() == string.Empty)
        //        {
        //            return;
        //        }
        //        if (flpTongZhu.Controls[i].Text.Trim().Length != 18)
        //        {
        //            flpTongZhu.Controls[i].Text = string.Empty;
        //            MessageBox.Show("请输入18位身份证");
        //            return;
        //        }
        //        PublicClass.ShenFu[i] = flpTongZhu.Controls[i].Text;
        //    }

        //}


    }
}
