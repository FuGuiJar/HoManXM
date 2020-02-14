namespace HoManXM
{
    partial class HuiYuan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HuiYuan));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picShan = new System.Windows.Forms.PictureBox();
            this.picZeng = new System.Windows.Forms.PictureBox();
            this.picCha = new System.Windows.Forms.PictureBox();
            this.picGai = new System.Windows.Forms.PictureBox();
            this.txtCha = new System.Windows.Forms.TextBox();
            this.btnCha = new System.Windows.Forms.Button();
            this.flpCha = new System.Windows.Forms.FlowLayoutPanel();
            this.flpGai = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGai = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnameXingMing = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShouJ = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnGai = new System.Windows.Forms.Button();
            this.flpShan = new System.Windows.Forms.FlowLayoutPanel();
            this.txtShan = new System.Windows.Forms.TextBox();
            this.btnShan = new System.Windows.Forms.Button();
            this.flpZeng = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZeng = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShouji = new System.Windows.Forms.TextBox();
            this.btnZeng = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZeng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGai)).BeginInit();
            this.flpCha.SuspendLayout();
            this.flpGai.SuspendLayout();
            this.flpShan.SuspendLayout();
            this.flpZeng.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(866, 403);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "memberuser_shenfen";
            this.Column1.HeaderText = "卡号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "member_level";
            this.Column2.HeaderText = "等级";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "member_zhekou";
            this.Column3.HeaderText = "折扣";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "userscore_jifen";
            this.Column4.HeaderText = "共消费";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "phone_id";
            this.Column5.HeaderText = "手机号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "memberuser_name";
            this.Column6.HeaderText = "姓名";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "phone_tai";
            this.Column7.HeaderText = "状态";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // picShan
            // 
            this.picShan.Image = ((System.Drawing.Image)(resources.GetObject("picShan.Image")));
            this.picShan.Location = new System.Drawing.Point(137, 29);
            this.picShan.Name = "picShan";
            this.picShan.Size = new System.Drawing.Size(70, 70);
            this.picShan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picShan.TabIndex = 1;
            this.picShan.TabStop = false;
            this.picShan.Click += new System.EventHandler(this.picShan_Click);
            // 
            // picZeng
            // 
            this.picZeng.Image = ((System.Drawing.Image)(resources.GetObject("picZeng.Image")));
            this.picZeng.Location = new System.Drawing.Point(19, 29);
            this.picZeng.Name = "picZeng";
            this.picZeng.Size = new System.Drawing.Size(70, 70);
            this.picZeng.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picZeng.TabIndex = 2;
            this.picZeng.TabStop = false;
            this.picZeng.Click += new System.EventHandler(this.picZeng_Click);
            // 
            // picCha
            // 
            this.picCha.Image = ((System.Drawing.Image)(resources.GetObject("picCha.Image")));
            this.picCha.Location = new System.Drawing.Point(399, 29);
            this.picCha.Name = "picCha";
            this.picCha.Size = new System.Drawing.Size(70, 70);
            this.picCha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCha.TabIndex = 1;
            this.picCha.TabStop = false;
            this.picCha.Click += new System.EventHandler(this.picCha_Click_1);
            // 
            // picGai
            // 
            this.picGai.Image = ((System.Drawing.Image)(resources.GetObject("picGai.Image")));
            this.picGai.Location = new System.Drawing.Point(255, 29);
            this.picGai.Name = "picGai";
            this.picGai.Size = new System.Drawing.Size(96, 70);
            this.picGai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGai.TabIndex = 2;
            this.picGai.TabStop = false;
            this.picGai.Click += new System.EventHandler(this.picGai_Click);
            // 
            // txtCha
            // 
            this.txtCha.Location = new System.Drawing.Point(3, 3);
            this.txtCha.Name = "txtCha";
            this.txtCha.Size = new System.Drawing.Size(201, 28);
            this.txtCha.TabIndex = 3;
            // 
            // btnCha
            // 
            this.btnCha.Location = new System.Drawing.Point(210, 3);
            this.btnCha.Name = "btnCha";
            this.btnCha.Size = new System.Drawing.Size(75, 31);
            this.btnCha.TabIndex = 4;
            this.btnCha.Text = "确定";
            this.btnCha.UseVisualStyleBackColor = true;
            this.btnCha.Click += new System.EventHandler(this.btnCha_Click);
            // 
            // flpCha
            // 
            this.flpCha.Controls.Add(this.txtCha);
            this.flpCha.Controls.Add(this.btnCha);
            this.flpCha.Location = new System.Drawing.Point(124, 118);
            this.flpCha.Name = "flpCha";
            this.flpCha.Size = new System.Drawing.Size(291, 34);
            this.flpCha.TabIndex = 5;
            // 
            // flpGai
            // 
            this.flpGai.Controls.Add(this.label4);
            this.flpGai.Controls.Add(this.txtGai);
            this.flpGai.Controls.Add(this.label5);
            this.flpGai.Controls.Add(this.txtnameXingMing);
            this.flpGai.Controls.Add(this.label6);
            this.flpGai.Controls.Add(this.txtShouJ);
            this.flpGai.Controls.Add(this.label7);
            this.flpGai.Controls.Add(this.comboBox1);
            this.flpGai.Controls.Add(this.btnGai);
            this.flpGai.Location = new System.Drawing.Point(478, 245);
            this.flpGai.Name = "flpGai";
            this.flpGai.Size = new System.Drawing.Size(333, 150);
            this.flpGai.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "身份证";
            // 
            // txtGai
            // 
            this.txtGai.Location = new System.Drawing.Point(71, 3);
            this.txtGai.Name = "txtGai";
            this.txtGai.Size = new System.Drawing.Size(256, 28);
            this.txtGai.TabIndex = 0;
            this.txtGai.MouseLeave += new System.EventHandler(this.txtGai_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "姓名  ";
            // 
            // txtnameXingMing
            // 
            this.txtnameXingMing.Location = new System.Drawing.Point(71, 37);
            this.txtnameXingMing.Name = "txtnameXingMing";
            this.txtnameXingMing.Size = new System.Drawing.Size(256, 28);
            this.txtnameXingMing.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "手机号";
            // 
            // txtShouJ
            // 
            this.txtShouJ.Location = new System.Drawing.Point(71, 71);
            this.txtShouJ.Name = "txtShouJ";
            this.txtShouJ.Size = new System.Drawing.Size(256, 28);
            this.txtShouJ.TabIndex = 0;
            this.txtShouJ.MouseLeave += new System.EventHandler(this.txtShouJ_MouseLeave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "状态  ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "可用",
            "禁用"});
            this.comboBox1.Location = new System.Drawing.Point(71, 105);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 8;
            // 
            // btnGai
            // 
            this.btnGai.Location = new System.Drawing.Point(198, 105);
            this.btnGai.Name = "btnGai";
            this.btnGai.Size = new System.Drawing.Size(75, 31);
            this.btnGai.TabIndex = 7;
            this.btnGai.Text = "修改";
            this.btnGai.UseVisualStyleBackColor = true;
            this.btnGai.Click += new System.EventHandler(this.btnGai_Click);
            // 
            // flpShan
            // 
            this.flpShan.Controls.Add(this.txtShan);
            this.flpShan.Controls.Add(this.btnShan);
            this.flpShan.Location = new System.Drawing.Point(490, 44);
            this.flpShan.Name = "flpShan";
            this.flpShan.Size = new System.Drawing.Size(354, 35);
            this.flpShan.TabIndex = 6;
            // 
            // txtShan
            // 
            this.txtShan.Location = new System.Drawing.Point(3, 3);
            this.txtShan.Name = "txtShan";
            this.txtShan.Size = new System.Drawing.Size(256, 28);
            this.txtShan.TabIndex = 0;
            // 
            // btnShan
            // 
            this.btnShan.Location = new System.Drawing.Point(265, 3);
            this.btnShan.Name = "btnShan";
            this.btnShan.Size = new System.Drawing.Size(75, 31);
            this.btnShan.TabIndex = 1;
            this.btnShan.Text = "删除";
            this.btnShan.UseVisualStyleBackColor = true;
            this.btnShan.Click += new System.EventHandler(this.btnShan_Click);
            // 
            // flpZeng
            // 
            this.flpZeng.Controls.Add(this.label1);
            this.flpZeng.Controls.Add(this.txtZeng);
            this.flpZeng.Controls.Add(this.label2);
            this.flpZeng.Controls.Add(this.txtname);
            this.flpZeng.Controls.Add(this.label3);
            this.flpZeng.Controls.Add(this.txtShouji);
            this.flpZeng.Controls.Add(this.btnZeng);
            this.flpZeng.Location = new System.Drawing.Point(51, 225);
            this.flpZeng.Name = "flpZeng";
            this.flpZeng.Size = new System.Drawing.Size(381, 151);
            this.flpZeng.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "身份证";
            // 
            // txtZeng
            // 
            this.txtZeng.Location = new System.Drawing.Point(71, 3);
            this.txtZeng.Name = "txtZeng";
            this.txtZeng.Size = new System.Drawing.Size(256, 28);
            this.txtZeng.TabIndex = 0;
            this.txtZeng.MouseLeave += new System.EventHandler(this.txtZeng_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "姓名  ";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(71, 37);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(256, 28);
            this.txtname.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "手机号";
            // 
            // txtShouji
            // 
            this.txtShouji.Location = new System.Drawing.Point(71, 71);
            this.txtShouji.Name = "txtShouji";
            this.txtShouji.Size = new System.Drawing.Size(256, 28);
            this.txtShouji.TabIndex = 0;
            this.txtShouji.MouseLeave += new System.EventHandler(this.txtShouji_MouseLeave);
            // 
            // btnZeng
            // 
            this.btnZeng.Location = new System.Drawing.Point(3, 105);
            this.btnZeng.Name = "btnZeng";
            this.btnZeng.Size = new System.Drawing.Size(75, 31);
            this.btnZeng.TabIndex = 1;
            this.btnZeng.Text = "添加";
            this.btnZeng.UseVisualStyleBackColor = true;
            this.btnZeng.Click += new System.EventHandler(this.btnZeng_Click);
            // 
            // HuiYuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(866, 561);
            this.Controls.Add(this.flpShan);
            this.Controls.Add(this.flpCha);
            this.Controls.Add(this.flpGai);
            this.Controls.Add(this.flpZeng);
            this.Controls.Add(this.picGai);
            this.Controls.Add(this.picCha);
            this.Controls.Add(this.picZeng);
            this.Controls.Add(this.picShan);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HuiYuan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员设置";
            this.Load += new System.EventHandler(this.HuiYuan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZeng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGai)).EndInit();
            this.flpCha.ResumeLayout(false);
            this.flpCha.PerformLayout();
            this.flpGai.ResumeLayout(false);
            this.flpGai.PerformLayout();
            this.flpShan.ResumeLayout(false);
            this.flpShan.PerformLayout();
            this.flpZeng.ResumeLayout(false);
            this.flpZeng.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox picShan;
        private System.Windows.Forms.PictureBox picZeng;
        private System.Windows.Forms.PictureBox picCha;
        private System.Windows.Forms.PictureBox picGai;
        private System.Windows.Forms.TextBox txtCha;
        private System.Windows.Forms.Button btnCha;
        private System.Windows.Forms.FlowLayoutPanel flpCha;
        private System.Windows.Forms.FlowLayoutPanel flpGai;
        private System.Windows.Forms.TextBox txtGai;
        private System.Windows.Forms.Button btnGai;
        private System.Windows.Forms.FlowLayoutPanel flpShan;
        private System.Windows.Forms.TextBox txtShan;
        private System.Windows.Forms.Button btnShan;
        private System.Windows.Forms.FlowLayoutPanel flpZeng;
        private System.Windows.Forms.TextBox txtZeng;
        private System.Windows.Forms.Button btnZeng;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShouji;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtnameXingMing;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtShouJ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}