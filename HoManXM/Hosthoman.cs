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
using HoManXM.cn.com.webxml.www;

namespace HoManXM
{
    public partial class Hosthoman : Form
    {
        public Hosthoman()
        {
            InitializeComponent();
        }
        public string mingzi { get; set; }
        public int dengji { get; set; }
       
        //加载
        private void hosthoman_Load(object sender, EventArgs e)
        {
            //初始化欢迎界面
            HuanYing();
            //初始化竖向面板
            this.splitContainer2.Orientation = Orientation.Horizontal;
            //初始化按钮位置
            Dingwei();
            //初始化两面板距离
            splitContainer2.SplitterDistance = 470;
            //初始化关闭按钮
            btnguan.Visible = false;
            BindButtons();//动态产生按钮
            BindListView();
            //默认绑LV
            splitContainer3.Visible = false;
            flowLayoutPanel3.Visible = true;
            //初始化flowLayoutPanel3位置
            Flp3dingwei();
            //初始化LV选中状态
            //listView1.Items[0].Selected = true;
            //初始化信息栏
            //赋空
            XinXiNull();
            //初始化统计类型
            //LeiTongJi();
            //绑CBO
            Bingcboleixing();
            //禁用
            JinYong();
            //无取消栏
            // this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            TianQi();
            //初始化房间信息
            FuXinXi();
            //BackColor = Color.FromArgb(255, 66, 64);
            PublicClass.CFH = new string[1];
            xi();
        }
        private void TianQi()
        {
            try
            {
                WeatherWebService webc = new WeatherWebService();
                string city = "邯郸";
                string[] s = webc.getWeatherbyCityName(city);
                // 基本 1 5  6  7  
                lab1.Text = s[1];
                lab5.Text = s[5];
                lab6.Text = s[6];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //初始化信息栏
        //赋空
        private void XinXiNull()
        {
            labTime.Text = string.Empty;
            labFangHao.Text = string.Empty;
            labXingMing.Text = string.Empty;
            labLeiXing.Text = string.Empty;
            labRuZhuJia.Text = string.Empty;
            labRushijian.Text = string.Empty;
            labYaJin.Text = string.Empty;
            //cboleixing.SelectedIndex = 0;
            labZhuanTai.Text = string.Empty;


        }

        //  初始化flowLayoutPanel3位置
        private void Flp3dingwei()
        {
            Point pt1 = new Point();
            pt1.X = 0;
            pt1.Y = -3;
            this.flowLayoutPanel3.Location = pt1;
        }
        //在下面板展显示或隐藏
        private void Flp3vis()
        {
            if (btnZhankai.Visible == true)
            {
                flowLayoutPanel3.Visible = true;
            }
            if (btnguan.Visible == true)
            {
                flowLayoutPanel3.Visible = false;
            }

        }
        //splitContainer3显示或隐藏
        private void ScdaXiao()
        {
            if (btnZhankai.Visible == true)
            {
                splitContainer3.Visible = false;
            }
            if (btnguan.Visible == true)
            {
                splitContainer3.Visible = true;
            }

        }
        //  在下面板展显示或隐藏
        private void FLPVis()
        {
            if (btnZhankai.Visible == true)
            {
                flowLayoutPanel2.Visible = false;
            }
            if (btnguan.Visible == true)
            {
                flowLayoutPanel2.Visible = true;
            }

        }
        //初始化按钮位置
        private void Dingwei() {
            Point pt1 = new Point();
            pt1.X = 1100;
            pt1.Y = 0;
            this.btnguan.Location = pt1;
            Point pt2 = new Point();
            pt2.X = 1100;
            pt2.Y = 0;
            this.btnZhankai.Location = pt2;
        }
        //初始化欢迎界面
        private void HuanYing()
        {
            string aa = string.Empty;
            switch (dengji)
            {
                case 0:
                    aa = "超管";
                    break;
                case 1:
                    aa = "普管";
                    break;
                default:
                    MessageBox.Show("错误！！");
                    break;
            }
            this.Text = $"[{aa}] {Name} --\t\t\t欢迎您{mingzi}！！";
        }
        //关闭相关窗口
        private void hosthoman_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #region 下面板展开
        //隐藏显示按钮
        private void btnZhankai_Click(object sender, EventArgs e)
        {
            

            splitContainer2.SplitterDistance = 250;
            btnZhankai.Visible = false;
            btnguan.Visible = true;
            ScdaXiao();
            FLPVis();
            splitContainer3.SplitterDistance = 25;
            Flp3vis();
        }

        private void btnguan_Click(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = 470;
            btnguan.Visible = false;
            btnZhankai.Visible = true;
            ScdaXiao();
            FLPVis();
            Flp3vis();
            //splitContainer3.SplitterDistance = 70;
        }
        #endregion

         public  string lei = "全部类型"; //类型全局变量
        //int danHao = 1000;

        //动态产生按钮方法
        private void BindButtons()
        {
            string sql = "select roomLei_id,roomLei_LeiBie from roomLei";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            while (reader.Read())
            {
                //产生按钮对象
                Button btn = new Button();
                btn.Tag = reader[0].ToString();
                btn.Text = reader[1].ToString();
                btn.Click += btnquanbu_Click_1;
                flowLayoutPanel1.Controls.Add(btn);

            }
            reader.Close();

        }
        //绑定ListView控件方法
        public void BindListView()
        {
            //MessageBox.Show("进了初始化");
            //公用的SQL
            string sql = $@"	select  r.room_id,l.roomLei_LeiBie,t.roomTai_zhuangTai
            from room as r
            inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
            inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id) 
            where 1=1";

            listView1.Items.Clear();
            //string sqlTai = $"select * from roomLei";
            //SqlDataReader readerTai = DBHelper.ExecutReader(sqlTai);
            //while (readerTai.Read())
            //{
            //    Button btn = new Button();
            //    btn.Text = readerTai[1].ToString();
            //    btn.Click += btnquanbu_Click_1;
            //    flowLayoutPanel1.Controls.Add(btn);
            //}
            //readerTai.Close();
            //if (lei == "标间")
            //{
            //    sql += String.Format(" and l.roomLei_LeiBie = '{0}'", lei);
            //}
            //if (lei == "单人间")
            //{
            //    sql += String.Format(" and l.roomLei_LeiBie = '{0}'", lei);
            //}
            //if (lei == "大床房")
            //{
            //    sql += String.Format(" and l.roomLei_LeiBie = '{0}'", lei);
            //}
            //if (lei == "总统套")
            //{
            //    sql += String.Format(" and l.roomLei_LeiBie = '{0}'", lei);
            //}
            if (lei != "全部类型")
            {
                sql += String.Format(" and l.roomLei_LeiBie = '{0}'", lei);
            }

            SqlDataReader reader = DBHelper.ExecutReader(sql);
            while (reader.Read())
            {
                //台号绑定到项上
                ListViewItem item = new ListViewItem(reader[0].ToString());
                string yong = reader[2].ToString().Trim();
                if (yong == "未入住")
                {
                    item.ImageIndex = 0;
                }
                if (yong == "已入住")
                {
                    item.ImageIndex = 1;
                }
                if (yong == "脏房")
                {
                    item.ImageIndex = 2;
                }
                if (yong == "预定")
                {
                    item.ImageIndex = 3;
                }
                if (yong == "停用")
                {
                    item.ImageIndex = 4;
                }
                if (yong == "有人预定但未入住")
                {
                    item.ImageIndex = 0;
                }
                listView1.Items.Add(item);
            }
            reader.Close();

        }
        //切换
        private void btnquanbu_Click_1(object sender, EventArgs e)
        {
            // 得到类型
            lei = (sender as Button).Text;
                                    //  PublicClass.FaLei = (sender as Button).Text;
            BindListView();
        }
        //增加房间类别
        private void piczenglei_Click(object sender, EventArgs e)
        {
            if (dengji == 0)
            {
                Tianfanglei lei = new Tianfanglei();
                lei.ShowDialog();
                BindListView();
                //BindButtons();
            }
            else
            {
                MessageBox.Show("该项只可超管使用--------抱歉！！您不是超级管理员！");
                return;
            }

        }

        #region 增加房间类别失去获得焦点
        private void piczenglei_MouseEnter(object sender, EventArgs e)
        {
            piczenglei.BackColor = Color.FromArgb(255, 66, 64);
        }

        private void piczenglei_MouseLeave(object sender, EventArgs e)
        {
            piczenglei.BackColor = Color.FromArgb(255, 255, 255);
        }
        #endregion

        //小图标显示
        private void btnTuXiao_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;

        }
        //大图标显示
        private void btnTuDa_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;

        }

        private void 登记入住HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RuZhu();
        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            int count = listView1.SelectedItems.Count;
            if (count < 1)
            {
                e.Cancel = true;
            }
           

        }

      
        private void btnFangTai_Click(object sender, EventArgs e)
        {
        }

        private void btnShuaXin_Click(object sender, EventArgs e)
        {
            //btnShuaXin.Click += hosthoman_Load;
            //LeiTongJi();
            shua();

        }

        private void 登记入住ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RuZhu();
        }
        //禁用
        private void JinYong()
        {
            toolStripButton1.Enabled = false;
            登记入住ToolStripMenuItem1.Enabled = false;
            toolStripButton2.Enabled = false;
            toolStripMenuItem2.Enabled = false;
            增加消费ZToolStripMenuItem.Enabled = false;
            结账离店LToolStripMenuItem.Enabled = false;
            结账离店NToolStripMenuItem.Enabled = false;
            toolStripButton3.Enabled = false;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //禁用
            int count2 = listView1.SelectedItems.Count;
            if (count2 == 1)
            {
                登记入住HToolStripMenuItem.Enabled = true;
                toolStripButton1.Enabled = true;
                登记入住ToolStripMenuItem1.Enabled = true;
 string fangHaoq = listView1.SelectedItems[0].Text;
            string sqlq= $@"	select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai
      from room as r
      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)
      where r.room_id = '{fangHaoq}'
";
            SqlDataReader readerq = DBHelper.ExecutReader(sqlq);
            while (readerq.Read())
            {
                if (readerq[3].ToString() == "已入住")
                {
                        增加消费ZToolStripMenuItem.Enabled = true;
                        toolStripButton2.Enabled = true;
                    toolStripMenuItem2.Enabled = true;
                        结账离店LToolStripMenuItem.Enabled = true;
                        结账离店NToolStripMenuItem.Enabled = true;
                        toolStripButton3.Enabled = true;
                        登记入住HToolStripMenuItem.Enabled = false;
                        toolStripButton1.Enabled = false;
                        登记入住ToolStripMenuItem1.Enabled = false;
                    }
                else
                {
                        增加消费ZToolStripMenuItem.Enabled = false;
                        toolStripButton2.Enabled = false;
                    toolStripMenuItem2.Enabled = false;
                }
                    if (readerq[3].ToString() == "未入住")
                    {
                        登记入住HToolStripMenuItem.Enabled = true;
                        toolStripButton1.Enabled = true;
                        登记入住ToolStripMenuItem1.Enabled = true;

                        结账离店LToolStripMenuItem.Enabled = false;
                        结账离店NToolStripMenuItem.Enabled = false;
                        toolStripButton3.Enabled = false;
                    }

                }

            }
            else
            {
                登记入住HToolStripMenuItem.Enabled = false;
                toolStripButton1.Enabled = false;
                登记入住ToolStripMenuItem1.Enabled = false;
                  toolStripButton2.Enabled = false;
                toolStripMenuItem2.Enabled = false;
                结账离店LToolStripMenuItem.Enabled = false;
                结账离店NToolStripMenuItem.Enabled = false;
                toolStripButton3.Enabled = false;
                增加消费ZToolStripMenuItem.Enabled = false;

            }



            int count = listView1.SelectedItems.Count;
            if (count>0)
            {
                //  _fangJian = listView1.SelectedItems[0].Text;
                string fangHao = listView1.SelectedItems[0].Text;
                //按照房号查询状态
                string sql = $@"	select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai
      from room as r
      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id) where r.room_id = {fangHao}";

                SqlDataReader reader = DBHelper.ExecutReader(sql);
                if (reader.Read())
                {
                    string zhuangTai = reader[3].ToString();
                    if (zhuangTai == "未入住")
                    {
                        XinXiNull();
                        labFangHao.Text = reader[0].ToString();
                        labLeiXing.Text = reader[1].ToString();
                        labRuZhuJia.Text = reader[2].ToString();
                        labZhuanTai.Text = reader[3].ToString();
                    }
                    else if (zhuangTai == "已入住")
                    {
                        string sqll = $@"select checkin.*,checkedout.checkedout_yingshou from
    checkin left join checkedout
    on(checkedout.checkedout_id = checkin.checkin_id)
     where checkedout.checkedout_yingshou is null and checkin_jianhao = {fangHao} 
     order by checkin.checkin_rushi desc
";
                        SqlDataReader reader1 = DBHelper.ExecutReader(sqll);
                        if (reader1.Read())
                        {
                            XinXiNull();
                            labXingMing.Text = reader1[1].ToString();
                            labFangHao.Text = reader1[7].ToString();
                            labLeiXing.Text = reader[1].ToString();
                            labRuZhuJia.Text = reader[2].ToString();
                            labRushijian.Text = reader1[5].ToString();
                            labYaJin.Text = reader1[4].ToString();
                            labZhuanTai.Text = reader[3].ToString();
                        }
                    }
                    else
                    {
                        SqlDataReader reader2 = DBHelper.ExecutReader(sql);
                        if (reader2.Read())
                        {
                            string zhuangTai2 = reader2[3].ToString();
                            if (zhuangTai2 == reader2[3].ToString())
                            {
                                XinXiNull();
                                labFangHao.Text = reader2[0].ToString();
                                labLeiXing.Text = reader2[1].ToString();
                                labRuZhuJia.Text = reader2[2].ToString();
                                labZhuanTai.Text = reader2[3].ToString();



                            }
                        }
                    }
                }
            }
        }
        //初始化统计类型
       
        //未入住
     
        //private void LeiTongJi() 
        //{
        //    SqlDataReader reader = DBHelper.ExecutReader(PublicClass.sqlWei);
        //    if (reader.Read())
        //    {
        //        labKongFang.Text = reader[0].ToString();
        //    }
        //    reader.Close();

        //    SqlDataReader reader1 = DBHelper.ExecutReader(PublicClass.sqlZang);
        //    if (reader1.Read())
        //    {
        //        labZangFang.Text = reader1[0].ToString();
        //    }
        //    reader1.Close();

        //    SqlDataReader reader2 = DBHelper.ExecutReader(PublicClass.sqlTing);
        //    if (reader2.Read())
        //    {
        //        labTiangYong.Text = reader2[0].ToString();
        //    }
        //    reader2.Close();

        //    SqlDataReader reader3 = DBHelper.ExecutReader(PublicClass.sqlYi);
        //    if (reader3.Read())
        //    {
        //        labZaiZhu.Text = reader3[0].ToString();
        //    }
        //    reader3.Close();

        //    SqlDataReader reader4 = DBHelper.ExecutReader(PublicClass.sqlYu);
        //    if (reader4.Read())
        //    {
        //        labYuDing.Text = reader4[0].ToString();
        //    }
        //    reader4.Close();
        //}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FuXinXi();
        }
        private void FuXinXi()
        {
            labKongFang.Text = "0";
            labZangFang.Text = "0";
            labTiangYong.Text = "0";
            labZaiZhu.Text = "0";
            labYuDing.Text = "0";
            string[] Tong = new string[5];
            string qq = cboleixing.Text.ToString();
            string sql = $@"select
	count( * ) AS num from
	 room inner join roomLei
	on(room.room_LeiBie = roomLei.roomLei_id) 
	inner join roomTai
	on(room.room_zhuangTai = roomTai.roomTai_id)
	where 1=1
	";
            if (qq != "全部")
            {
                sql += $" and  roomLei.roomLei_LeiBie = '{qq}'";
                sql += $"  group by room_zhuangTai";
            }
            else
            {
                sql += $"  group by room_zhuangTai";
            }
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            int i = 0;
            while (reader.Read())
            {
                Tong[i] = reader[0].ToString();
                i++;
            }
            reader.Close();
            for (int c = 0; c < Tong.Length; c++)
            {
                if (c == 0 && Tong[c] != null)
                {
                    labKongFang.Text = Tong[c].ToString();
                }
                if (c == 1 && Tong[c] != null)
                {
                    labZangFang.Text = Tong[c].ToString();
                }
                if (c == 2 && Tong[c] != null)
                {
                    labTiangYong.Text = Tong[c].ToString();
                }
                if (c == 3 && Tong[c] != null)
                {
                    labZaiZhu.Text = Tong[c].ToString();
                }
                if (c == 4 && Tong[c] != null)
                {
                    labYuDing.Text = Tong[c].ToString();
                }
            }


        }

        private void Bingcboleixing()
        {
            string sql = "select roomLei_id,roomLei_LeiBie from roomLei";
            DataTable dt = DBHelper.GetTable(sql);
            cboleixing.DataSource = dt;
            DataRow row = dt.NewRow();
            row[0] = -1;
            row[1] = "全部";
            dt.Rows.InsertAt(row, 0);
            cboleixing.ValueMember = "roomLei_id";
            cboleixing.DisplayMember = "roomLei_LeiBie";
            cboleixing.SelectedIndex = 0;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RuZhu();
        }
        //房间入住
        public  void RuZhu()
        {
            if (listView1.SelectedItems.Count  == 0)
            {
                return;
            }
            string fangHao = listView1.SelectedItems[0].Text;
            string sql = $@"	select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai
      from room as r
      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)
      where r.room_id = '{fangHao}'
";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            while (reader.Read())
            {
                if (reader[3].ToString() != "未入住" && reader[3].ToString() != "有人预定但未入住")
                {
                    MessageBox.Show("请选择未入住的房间！！");
                    return; 
                }
            }
            reader.Close();
            RuZhu ruZhu = new RuZhu();
            ruZhu.FangHao = fangHao;
            string sql2 = $@"select * from 
	roomLei inner join room 
	on(roomLei.roomLei_id = room.room_LeiBie)
	where room.room_id = {fangHao}";
            SqlDataReader reader2 = DBHelper.ExecutReader(sql2);
            if (reader2.Read())
            {
                ruZhu.Fang = reader2[0].ToString();
            }
            reader2.Close();
            ruZhu.ShowDialog();
            BindListView();
        }
        //增加消费
        public void AddXiaoFei()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            string fangHao = listView1.SelectedItems[0].Text;
           PublicClass.FangH = fangHao;
            string sql = $@"	select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai
      from room as r
      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)
      where r.room_id = '{fangHao}'
";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            while (reader.Read())
            {
                if (reader[3].ToString() != "已入住")
                {
                    MessageBox.Show("请选择已入住的房间！！");
                    return;
                }
            }
            reader.Close();
            ZenegJiaXiaoFei xiaofei = new ZenegJiaXiaoFei();
            xiaofei.FangHao = fangHao;
            xiaofei.ShowDialog();
            BindListView();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddXiaoFei();
            BindListView();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddXiaoFei();
            BindListView();
        }

        private void 退出系统SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 增添商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dengji == 0)
            {
                FrmShangPincomplie frm = new FrmShangPincomplie();
                frm.ShowDialog();
                BindListView();
            }
            else
            {
                MessageBox.Show("该项只可超管使用--------抱歉！！您不是超级管理员！");
                return;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            JieZhang();
            BindListView();
        }
        //结账
        public void JieZhang()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            string fangHao = listView1.SelectedItems[0].Text;
            PublicClass.FangH = fangHao;
            string sql = $@"	select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai
      from room as r
      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)
      where r.room_id = '{fangHao}'

";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            while (reader.Read())
            {
                if (reader[3].ToString() != "已入住")
                {
                    MessageBox.Show("请选择已入住的房间！！");
                    return;
                }
            }
            reader.Close();
            JieZhang zhang = new JieZhang();
            zhang.FangHao = fangHao;
            zhang.ShowDialog();
            BindListView();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labTime.Text = DateTime.Now.ToString();
         
        }

        private void 结账离店NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JieZhang();
            BindListView();
        }

        private void 结账离店LToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            JieZhang();
            BindListView();

        }

        private void 增加消费ZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddXiaoFei();
            BindListView();
        }
        //成为目标窗体后刷新
        private void hosthoman_Enter(object sender, EventArgs e)
        {
            lei = (sender as Button).Text;
            BindListView();
            //LeiTongJi();
            MessageBox.Show("Test");
        }

        private void 修改房态WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fangHao = listView1.SelectedItems[0].Text;
            PublicClass.FangH = fangHao;
            string sql = $@"	select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai
      from room as r
      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)
      where r.room_id = '{fangHao}'
";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            while (reader.Read())
            {
                PublicClass.FangTai = reader[3].ToString();
            }
            reader.Close();
            XiuGaiFangTai tai = new XiuGaiFangTai();
            tai.ShowDialog();
                BindListView();
        }

        private void 置为脏房YToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fangHao = listView1.SelectedItems[0].Text;
            //只有未入住可用 
            string sqlPan = $@"select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai
      from room as r
      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)
	  where r.room_id = {fangHao}";
            SqlDataReader readerPan = DBHelper.ExecutReader(sqlPan);
            if (readerPan.Read())
            {
                if (readerPan[3].ToString() != "未入住")
                {
                    MessageBox.Show("请选择未入住房");
                    return;
                }
            }
            readerPan.Close();
            string sqlf = $@"update room set room_zhuangTai = 3 where room_id = '{fangHao}' ";
            DBHelper.ExecuteNonQuery(sqlf);
            BindListView();

        }

 

        private void 打扫房间FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fangHao = listView1.SelectedItems[0].Text;
            //只有脏房可打扫
            string sqlPan = $@"select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai
      from room as r
      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)
	  where r.room_id = {fangHao}";
            SqlDataReader readerPan = DBHelper.ExecutReader(sqlPan);
            if (readerPan.Read())
            {
                if (readerPan[3].ToString() != "脏房")
                {
                    MessageBox.Show("请选择脏房");
                    return;
                }
            }
            readerPan.Close();


            string sqlf = $@"update room set room_zhuangTai = 1 where room_id = '{fangHao}' ";
            DBHelper.ExecuteNonQuery(sqlf);
            BindListView();
        }

        private void 会员设置HToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                HuiYuan Hui = new HuiYuan();
                Hui.ShowDialog();
        }

        private void 会员设置HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dengji == 0)
            {
                HuiYuanXiTong HuiXiTong = new HuiYuanXiTong();
                HuiXiTong.ShowDialog();
            }
            else
            {
                MessageBox.Show("该项只可超管使用--------抱歉！！您不是超级管理员！");
                return;
            }
        }

        private void 管理员设置GToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuanLiYuan guanLiYuan = new GuanLiYuan();
            guanLiYuan.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            FrmYuDing yuDing = new FrmYuDing();
            yuDing.ShowDialog();
            BindListView();
        }

        private void 预订入住ZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fangHao = listView1.SelectedItems[0].Text;
            //请选择预订房间
            string sqlPan = $@"select  r.room_id,l.roomLei_LeiBie,l.roomLei_jiaGe,t.roomTai_zhuangTai
      from room as r
      inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
      inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)
	  where r.room_id = {fangHao}";
            SqlDataReader readerPan = DBHelper.ExecutReader(sqlPan);
            if (readerPan.Read())
            {
                if (readerPan[3].ToString() != "预定")
                {
                    MessageBox.Show("请选择预定房");
                    return;
                }
            }
            readerPan.Close();

            string sql = $@"select top 1* from 
	reserve where reserve_fanghao = {fangHao}
	order by reserve_shijian desc";
            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                YuDingBiDui yu = new YuDingBiDui();
                yu.Hao = reader[0].ToString();
                yu.ShowDialog();
            }
            reader.Read();
            BindListView();

        }

        private void 登记入住ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            TongJi ji = new TongJi();
            ji.ShowDialog();

        }

        private void btnXiaoFeiXi_Click(object sender, EventArgs e)
        {
            dgvXiaofeiMingXi.BringToFront();
            XiaoFeiXi();

        }
        private void XiaoFeiXi()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择房间");
                return;
            }
            string fangHao = listView1.SelectedItems[0].Text;
            string sql = $@" select  top 1 checkin.*,checkedout.checkedout_yingshou from
    checkin left join checkedout
    on(checkedout.checkedout_id = checkin.checkin_id)
    where checkin.checkin_jianhao = {Convert.ToInt32(fangHao)}
    and checkedout.checkedout_yingshou is null
      order by checkin.checkin_rushi desc";

            SqlDataReader reader = DBHelper.ExecutReader(sql);
            if (reader.Read())
            {
                string sq3 = $" select* from room where room_id = {Convert.ToInt32(fangHao)}";
                SqlDataReader reader3 = DBHelper.ExecutReader(sq3);
                if (reader3.Read())
                {
                    if (reader3[1].ToString() != "2")
                    {
                        MessageBox.Show("请选择已入住房间");
                        return;
                    }
                }

                string sql2 = $@"select XiaoFei.* from 
	XiaoFei inner join checkin
	on(XiaoFei.DanHao =checkin.checkin_id)
	where ZhuangTai = '未付款'
	and DanHao = {Convert.ToInt32(reader[0])}";
                DataTable dt = DBHelper.GetTable(sql2);
                dgvXiaofeiMingXi.DataSource = dt;
                reader3.Close();
            }
            reader.Close();
        }

        private void btnYaJin_Click(object sender, EventArgs e)
        {
            dgvYaJin.BringToFront();
            YaJin();
        }
        private void YaJin()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择房间");
                return;
            }
            string fangHao = listView1.SelectedItems[0].Text;
            string sq3 = $" select* from room where room_id = {Convert.ToInt32(fangHao)}";
            SqlDataReader reader3 = DBHelper.ExecutReader(sq3);
            if (reader3.Read())
            {
                if (reader3[1].ToString() != "2")
                {
                    MessageBox.Show("请选择已入住房间");
                    return;
                }
            }
            reader3.Close();

            string sql = $@" select  top 1 checkin.checkin_id,checkin.checkin_name,checkin.checkin_yajin,checkin.checkin_jianhao from
    checkin left join checkedout
    on(checkedout.checkedout_id = checkin.checkin_id)
    where checkin.checkin_jianhao = {Convert.ToInt32(fangHao)}
    and checkedout.checkedout_yingshou is null
      order by checkin.checkin_rushi desc";

                DataTable dt = DBHelper.GetTable(sql);
                dgvYaJin.DataSource = dt;
        }

        private void btnFuKuangXiang_Click(object sender, EventArgs e)
        {
            dgvFuKuan.BringToFront();
            FuKuan();
        }
        private void FuKuan()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择房间");
                return;
            }
            string fangHao = listView1.SelectedItems[0].Text;
            string sq3 = $" select* from room where room_id = {Convert.ToInt32(fangHao)}";
            SqlDataReader reader3 = DBHelper.ExecutReader(sq3);
            if (reader3.Read())
            {
                if (reader3[1].ToString() != "2")
                {
                    MessageBox.Show("请选择已入住房间");
                    return;
                }
            }
            reader3.Close();

            string sql = $@" select  top 1  checkin.checkin_id,checkin.checkin_name,checkin.checkin_feiyong,checkin.checkin_jianhao,checkin.checkin_rushi from
    checkin left join checkedout
    on(checkedout.checkedout_id = checkin.checkin_id)
    where checkin.checkin_jianhao = {Convert.ToInt32(fangHao)}
    and checkedout.checkedout_yingshou is null
      order by checkin.checkin_rushi desc";

            DataTable dt = DBHelper.GetTable(sql);
            dgvFuKuan.DataSource = dt;
        }

        private void btnYuDing_Click(object sender, EventArgs e)
        {
            dgvYu.BringToFront();
            Yu();
        }

        private void Yu()
        {

            string sql = $@"select r.reserve_bianhao,r.reserve_name,r.reserve_phone,
                r.reserve_fanglei,r.reserve_Jiaqian,r.reserve_fanghao,r.reserve_shijian,r.reserve_baoliu,tai.roomTai_zhuangTai
                from reserve as r inner join roomTai as tai on(r.reserve_ZhuangTai=tai.roomTai_id) 
				inner join room on(r.reserve_fanghao = room.room_id)
				where reserve_ZhuangTai= 4";
            DataTable dt = DBHelper.GetTable(sql);
            dgvYu.DataSource = dt;
        }

        private void iNFINITEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Infinity infinity = new Infinity();
            infinity.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            FrmDiaoJia jia = new FrmDiaoJia();
            jia.ShowDialog();


        }

        private void 关于软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://fuguijar.top/XM/");
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnTiXing_Click(object sender, EventArgs e)
        {
            if (flpXiaoXi.IsVScrolVisible())
            {
                splitContainer1.SplitterDistance = 153;
            }
            else
            {
                splitContainer1.SplitterDistance = 135;
            }
            tabControl1.SelectedTab = tabPage2;
            shi();
        }

        private void timyuqi_Tick(object sender, EventArgs e)
        {
            qing();
            //MessageBox.Show("Test");
            shi();
            if (tabControl1.SelectedTab == tabPage2)
            {
                if (flpXiaoXi.IsVScrolVisible())
                {
                    splitContainer1.SplitterDistance = 153;
                }
                else
                {
                    splitContainer1.SplitterDistance = 135;
                }
            }
        }
        // piczenglei.BackColor = Color.FromArgb(224, 224, 224);
        string scName= "scname";
        string labText = "房租逾期";
        string puName = "puname";

        int k = 0;
        public void shi()
        {
            string sqlyi = $@"select  r.room_id
            from room as r
            inner join roomLei as l on(r.room_LeiBie = l.roomLei_id)
            inner join roomTai as t on(r.room_zhuangTai = t.roomTai_id)
            where t.roomTai_zhuangTai = '已入住'
            ";
            SqlDataReader readeryi = DBHelper.ExecutReader(sqlyi);
            while (readeryi.Read())
            {

                //MessageBox.Show(readeryi[0].ToString());
                string sqlShi = $@"	  select top 1 checkin.*,checkedout.checkedout_yingshou from
    checkin left join checkedout
    on(checkedout.checkedout_id = checkin.checkin_id)
	where checkin.checkin_jianhao = '{readeryi[0].ToString()}'
	and checkedout.checkedout_yingshou is null
 	 order by checkin.checkin_rushi desc
 	       ";
                    SqlDataReader readerShi = DBHelper.ExecutReader(sqlShi);
                    while (readerShi.Read())
                    {
                    //MessageBox.Show(readerShi[7].ToString());
                    //MessageBox.Show(readeryi[0].ToString());

                    //5  6
                    DateTime time = Convert.ToDateTime(readerShi[5]).AddHours(Convert.ToDouble(readerShi[6]) * 24);
                        if (time <= DateTime.Now)
                        {
                        //逾期了7
                        string sqljishu = $"select * from JiShu";
                        SqlDataReader readerjishu = DBHelper.ExecutReader(sqljishu);
                        if (readerjishu.Read())
                        {
                            k = Convert.ToInt32(readerjishu[0]);
                            //MessageBox.Show(k +"="+ readerjishu[0].ToString());
                        }
                        readerjishu.Close();

                        string sqlxiaoxi = $"select * from XiaoXi where XiaoXi_jian = '{readerShi[7].ToString()}'";
                        SqlDataReader readerxiaoxi = DBHelper.ExecutReader(sqlxiaoxi);
                        while (readerxiaoxi.Read())
                        {
                            return;
                        }
                        readerxiaoxi.Close();

                        SplitContainer sc = new SplitContainer();
                        sc.Name = scName + k;
                        sc.Width = 117;
                        sc.Height = 23;
                        sc.SplitterDistance = 87;
                        sc.BackColor = Color.FromArgb(224, 224, 224);
                        flpXiaoXi.Controls.Add(sc);
                        Label label = new Label();
                        label.Text = readerShi[7].ToString() + labText;
                        //label.Text = k.ToString();
                        //label.Text = readerShi[7].ToString();

                        sc.Panel1.Controls.Add(label);
                        PictureBox box = new PictureBox();
                        box.Name = puName + k;
                        box.Dock = DockStyle.Fill;
                        box.Image = HoManXM.Properties.Resources.Cha;
                        box.SizeMode = PictureBoxSizeMode.CenterImage;
                        sc.Panel2.Controls.Add(box);
                        AddEvent(box);
                        string sqlxiadd = $"insert into XiaoXi values ('{sc.Name}','{ label.Text}','{box.Name}','{readerShi[7].ToString()}')";
                        DBHelper.ExecuteNonQuery(sqlxiadd);

                        string sqljishu1 = $"select * from JiShu";
                        SqlDataReader readerjishu1 = DBHelper.ExecutReader(sqljishu1);
                        if (readerjishu1.Read())
                        {
                            string sqljishuadd = $"update JiShu set JiShu_id = '{Convert.ToInt32(readerjishu1[0]) + 1}'";
                            DBHelper.ExecuteNonQuery(sqljishuadd);
                        }
                        readerjishu1.Close();
                    }
                    }
                    readerShi.Close();
              //  }
              
            }
            readeryi.Close();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                splitContainer1.SplitterDistance = 135;
            }
            if (tabControl1.SelectedTab == tabPage2)
            {
                if (flpXiaoXi.IsVScrolVisible())
                {
                    splitContainer1.SplitterDistance = 153;
                }
                else
                {
                    splitContainer1.SplitterDistance = 135;
                }
            }


        }
        public void AddEvent(PictureBox text)
        {
            text.MouseLeave += new EventHandler(box_MouseLeave);
            text.MouseEnter += new EventHandler(box_MouseEnter);
            text.Click += new EventHandler(box_Click);
            //text.MouseLeave +=box_MouseLeave;
            //text.MouseEnter +=box_MouseEnter;
            //text.Click += box_Click;
        }
        private void box_MouseEnter(object sender, EventArgs e)
        {
            //for (int i = 0; i < flpXiaoXi.Controls.Count; i++)
            //{
            //    flpXiaoXi.Controls[i].Controls[1].Controls[0].BackColor = Color.FromArgb(255, 255, 255);
            //    return;
            //}
            //(sender as PictureBox).BackColor = Color.FromArgb(225, 225, 225);

            PictureBox box = (PictureBox)sender;
            box.BackColor = Color.FromArgb(224, 224, 224,0);

        }

        private void box_MouseLeave(object sender, EventArgs e)
        {
            //for (int i = 0; i < flpXiaoXi.Controls.Count; i++)
            //{
            //    flpXiaoXi.Controls[i].Controls[1].Controls[0].BackColor = Color.FromArgb(224, 224, 224);
            //    return;
            //}
            //(sender as PictureBox).BackColor = Color.FromArgb(224, 224, 224);
            PictureBox box = (PictureBox)sender;
            box.BackColor = Color.FromArgb(0, 100, 100, 45);


        }
        private void box_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < flpXiaoXi.Controls.Count; i++)
            //{
            //    //flpXiaoXi.Controls[i].Controls[1].Controls[0].BackColor = Color.FromArgb(224, 224, 224);
            //    //flpXiaoXi.Controls[i].Visible = false;
            //    flpXiaoXi.Controls.Remove(flpXiaoXi.Controls[i]);
            //    return;
            //}
            PictureBox box = (PictureBox)sender;
            //MessageBox.Show(box.Name+"---"+ box.Parent.Parent.Name);
            SplitContainer txt = (SplitContainer)this.Controls.Find(box.Parent.Parent.Name, true)[0];
            //txt.Visible = false;
            flpXiaoXi.Controls.Remove(txt);
            string sqlxiadd = $"delete from XiaoXi where XiaoXi_sp = '{txt.Name}'";
            DBHelper.ExecuteNonQuery(sqlxiadd);

            if (tabControl1.SelectedTab == tabPage2)
            {
                if (flpXiaoXi.IsVScrolVisible())
                {
                    splitContainer1.SplitterDistance = 153;
                }
                else
                {
                    splitContainer1.SplitterDistance = 135;
                }
            }

        }

        public void qing()
        {
            flpXiaoXi.Controls.Clear();
            string sqlxiadd = $"delete from XiaoXi";
            DBHelper.ExecuteNonQuery(sqlxiadd);

        }
        public void xi()
        {

            string sqlxiaoxi = $"select * from XiaoXi";
            SqlDataReader readerxiaoxi = DBHelper.ExecutReader(sqlxiaoxi);
            while (readerxiaoxi.Read())
            {
                SplitContainer sc = new SplitContainer();
                sc.Name = readerxiaoxi[0].ToString();
                sc.Width = 117;
                sc.Height = 23;
                sc.SplitterDistance = 87;
                sc.BackColor = Color.FromArgb(224, 224, 224);
                flpXiaoXi.Controls.Add(sc);
                Label label = new Label();
                label.Text = readerxiaoxi[1].ToString();
                sc.Panel1.Controls.Add(label);
                PictureBox box = new PictureBox();
                box.Name = readerxiaoxi[2].ToString();
                box.Dock = DockStyle.Fill;
                box.Image = HoManXM.Properties.Resources.Cha;
                box.SizeMode = PictureBoxSizeMode.CenterImage;
                sc.Panel2.Controls.Add(box);
                AddEvent(box);
            }
            readerxiaoxi.Close();
        }

        public void shua()
        {
            qing();
            //MessageBox.Show("Test");
            shi();
            if (tabControl1.SelectedTab == tabPage2)
            {
                if (flpXiaoXi.IsVScrolVisible())
                {
                    splitContainer1.SplitterDistance = 153;
                }
                else
                {
                    splitContainer1.SplitterDistance = 135;
                }
            }
        }

        private void 营业查询CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RuZhuChaXun chaXun = new RuZhuChaXun();
            chaXun.ShowDialog();
        }

        private void 统计JToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ji j = new Ji();
            j.ShowDialog();
        }
        int i = 0;
        int ff = 20;
        private void 测试消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ff += i;
            //MessageBox.Show("11");
            if (tabControl1.SelectedTab == tabPage2)
            {
                if (flpXiaoXi.IsVScrolVisible())
                {
                    splitContainer1.SplitterDistance = 153;
                }
                else
                {
                    splitContainer1.SplitterDistance = 135;
                }
            }
            for (; i < ff; i++)
            {
                string x = "sce-";
                string v = "测试-";
                string sqlce = $"insert into XiaoXi values('{x + i}','{v + i}','pce-1','{i}')";
                DBHelper.ExecuteNonQuery(sqlce);
                
            }

            string sqlxiaoxi = $"select * from XiaoXi";
            SqlDataReader readerxiaoxi = DBHelper.ExecutReader(sqlxiaoxi);
            while (readerxiaoxi.Read())
            {
                SplitContainer sc = new SplitContainer();
                sc.Name = readerxiaoxi[0].ToString();
                sc.Width = 117;
                sc.Height = 23;
                sc.SplitterDistance = 87;
                sc.BackColor = Color.FromArgb(224, 224, 224);
                flpXiaoXi.Controls.Add(sc);
                Label label = new Label();
                label.Text = readerxiaoxi[1].ToString();
                sc.Panel1.Controls.Add(label);
                PictureBox box = new PictureBox();
                box.Name = readerxiaoxi[2].ToString();
                box.Dock = DockStyle.Fill;
                box.Image = HoManXM.Properties.Resources.Cha;
                box.SizeMode = PictureBoxSizeMode.CenterImage;
                sc.Panel2.Controls.Add(box);
                AddEvent(box);

                if (tabControl1.SelectedTab == tabPage2)
                {
                    if (flpXiaoXi.IsVScrolVisible())
                    {
                        splitContainer1.SplitterDistance = 153;
                    }
                    else
                    {
                        splitContainer1.SplitterDistance = 135;
                    }
                }

            }
            readerxiaoxi.Close();



        }

        private void 清空测试消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
            flpXiaoXi.Controls.Clear();
            string sqlxiadd = $"delete from XiaoXi";
            DBHelper.ExecuteNonQuery(sqlxiadd);
            if (tabControl1.SelectedTab == tabPage2)
            {
                if (flpXiaoXi.IsVScrolVisible())
                {
                    splitContainer1.SplitterDistance = 153;
                }
                else
                {
                    splitContainer1.SplitterDistance = 135;
                }
            }

        }

        private void 重启程序CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void 退出登录TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DengLu lu = new DengLu();
            lu.ShowDialog();
            this.Close();

        }

        private void 锁定程序SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ce ce = new Ce();
            ce.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

                #region 预定判断
                //MessageBox.Show("走进预定");
                string sql = $@"select * from room where room_zhuangTai=8";
                SqlDataReader reader = DBHelper.ExecutReader(sql);
                while (reader.Read())
                {
                    //MessageBox.Show("找见状态8 的房间");
                    string biao = $@"select * from reserve";
                    SqlDataReader dataReader = DBHelper.ExecutReader(biao);
                    while (dataReader.Read())
                    {
                        int zhuangt = Convert.ToInt32(dataReader[8]);
                        if (zhuangt == 7)
                        {
                            DateTime dangqian = DateTime.Now;
                            DateTime yudi = Convert.ToDateTime(dataReader[6]);
                            DateTime waaw = yudi.AddHours(-0.5);
                            DateTime wasw = yudi.AddHours(-1);
                            if (!(dangqian >= wasw && dangqian <= yudi))
                            {

                            }
                            else
                            {
                                //MessageBox.Show("又再这是时间断的人");
                                string fang = $@"select reserve_fanghao,reserve_ZhuangTai from reserve where reserve_ZhuangTai=7";
                                SqlDataReader f = DBHelper.ExecutReader(fang);
                                while (f.Read())
                                {
                                    //MessageBox.Show("看他的房间号");
                                    int haoo = Convert.ToInt32(f[0].ToString());
                                    int zhuangtia = Convert.ToInt32(f[1].ToString());
                                    if ((zhuangtia == 7))
                                    {
                                        //MessageBox.Show("又");
                                        //string sql1 = $@"select * from room where room_id='{haoo}' and room_zhuangTai=8 ";// or room_zhuangTai=1
                                        //SqlDataReader zt = DBHelper.ExecutReader(sql1);
                                        //if (zt.Read())
                                        //{
                                        //MessageBox.Show("有的话拉这里" + haoo);
                                        if ((dangqian >= waaw && dangqian <= yudi))
                                        {
                                            string qwe = $@"select reserve_fanghao from reserve";
                                            SqlDataReader re = DBHelper.ExecutReader(qwe);
                                            while (re.Read())
                                            {
                                                int hao = Convert.ToInt32(re[0].ToString());
                                                string you = $@"select *from room where room_id={hao} and room_zhuangTai=8";
                                                SqlDataReader chaba = DBHelper.ExecutReader(you);
                                                if (chaba.Read())
                                                {
                                                    string sql4 = $"update reserve set reserve_ZhuangTai= 4 where reserve_fanghao={hao}";
                                                    string sql3 = $"update room set room_zhuangTai=4 where room_id={hao}";
                                                    int hh = DBHelper.ExecuteNonQuery(sql3);
                                                    int he = DBHelper.ExecuteNonQuery(sql4);
                                                    if (hh + he > 1)
                                                    {
                                                        BindListView();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("没成功时间");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //MessageBox.Show("没有的话来这里" + haoo);
                                        string min = dataReader[1].ToString();
                                        string aaa = dataReader[5].ToString();
                                        MessageBox.Show(min + "预定的" + aaa + "房间正在有人住,点击确定修改");
                                        string sql9 = $@"select * from reserve where reserve_fanghao={haoo}";
                                        SqlDataReader ss = DBHelper.ExecutReader(sql9);
                                        if (ss.Read())
                                        {
                                            FrmXiuGaiYuDing frmXiuGaiYu = new FrmXiuGaiYuDing();
                                            frmXiuGaiYu.bianhao = Convert.ToString(ss[0]);
                                            frmXiuGaiYu.fangjianhao = ss[5].ToString();
                                            frmXiuGaiYu.ShowDialog();
                                            BindListView();
                                        }

                                    }
                                    //}
                                    //else
                                    //{
                                    //    break;
                                    //}

                                }
                            }
                        }
                    }
                }
                #endregion
                #region 超过保留时间就该状态
                string pan = $@"		select reserve_shijian,reserve_baoliu,reserve_fanghao,reserve_ZhuangTai from reserve where reserve_ZhuangTai !=6";//
                SqlDataReader aa = DBHelper.ExecutReader(pan);
                while (aa.Read())
                {
                   // MessageBox.Show(aa[1].ToString());
                    int shuz = Convert.ToInt32(aa[3]);
                    if (shuz == 6)
                    {
                        break;
                    }
                    else
                    {
                        DateTime time = DateTime.Now;
                        DateTime baoliu = Convert.ToDateTime(aa[1].ToString());

                        if (time > baoliu)
                        {
                            string fangjianhao = aa[2].ToString();
                            //MessageBox.Show(fangjianhao);
                            string asd = $"update room set room_zhuangTai= 1 where room_id={fangjianhao}";
                            string asdas = $"update reserve set reserve_ZhuangTai= 6 where reserve_fanghao={fangjianhao}";
                            int ii = DBHelper.ExecuteNonQuery(asd);
                            int tt = DBHelper.ExecuteNonQuery(asdas);
                            if ((ii + tt) > 1)
                            {
                                BindListView();
                                break;
                            }
                            else
                            {
                                //MessageBox.Show("修改失败");
                            }
                        }
                    }
                }
                #endregion

            }
        

        //private void 测试消息ToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{
        //    Ce ce = new Ce();
        //    ce.ShowDialog();

        //}



    }
}
