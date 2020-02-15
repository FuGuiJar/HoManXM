namespace HoManXM
{
    partial class RuZhu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuZhu));
            this.btnTiJiao = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDingJIn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.dtpRiQi = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtJiaGe = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnChongZhi = new System.Windows.Forms.Button();
            this.Days = new System.Windows.Forms.NumericUpDown();
            this.txtLeiXing = new System.Windows.Forms.ComboBox();
            this.cboFanghao = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labKeZhu = new System.Windows.Forms.Label();
            this.cbTongXing = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Days)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTiJiao
            // 
            this.btnTiJiao.Location = new System.Drawing.Point(580, 245);
            this.btnTiJiao.Name = "btnTiJiao";
            this.btnTiJiao.Size = new System.Drawing.Size(92, 41);
            this.btnTiJiao.TabIndex = 7;
            this.btnTiJiao.Text = "提交";
            this.btnTiJiao.UseVisualStyleBackColor = true;
            this.btnTiJiao.Click += new System.EventHandler(this.btnTiJiao_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(118, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 28);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "姓名";
            // 
            // txtShen
            // 
            this.txtShen.Location = new System.Drawing.Point(118, 101);
            this.txtShen.Name = "txtShen";
            this.txtShen.Size = new System.Drawing.Size(200, 28);
            this.txtShen.TabIndex = 2;
            this.txtShen.MouseLeave += new System.EventHandler(this.txtShen_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "身份证";
            // 
            // txtDingJIn
            // 
            this.txtDingJIn.Location = new System.Drawing.Point(118, 220);
            this.txtDingJIn.Name = "txtDingJIn";
            this.txtDingJIn.ReadOnly = true;
            this.txtDingJIn.Size = new System.Drawing.Size(200, 28);
            this.txtDingJIn.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "入住日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "性别";
            // 
            // cboSex
            // 
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.Enabled = false;
            this.cboSex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cboSex.Location = new System.Drawing.Point(118, 168);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(66, 26);
            this.cboSex.TabIndex = 3;
            // 
            // dtpRiQi
            // 
            this.dtpRiQi.Enabled = false;
            this.dtpRiQi.Location = new System.Drawing.Point(118, 285);
            this.dtpRiQi.Name = "dtpRiQi";
            this.dtpRiQi.Size = new System.Drawing.Size(200, 28);
            this.dtpRiQi.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "押金";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "入住天数";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(403, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "房间号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(385, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "房间类型";
            // 
            // txtJiaGe
            // 
            this.txtJiaGe.Location = new System.Drawing.Point(472, 154);
            this.txtJiaGe.Name = "txtJiaGe";
            this.txtJiaGe.ReadOnly = true;
            this.txtJiaGe.Size = new System.Drawing.Size(200, 28);
            this.txtJiaGe.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(421, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "价格";
            // 
            // btnChongZhi
            // 
            this.btnChongZhi.Location = new System.Drawing.Point(472, 245);
            this.btnChongZhi.Name = "btnChongZhi";
            this.btnChongZhi.Size = new System.Drawing.Size(92, 41);
            this.btnChongZhi.TabIndex = 8;
            this.btnChongZhi.Text = "重置";
            this.btnChongZhi.UseVisualStyleBackColor = true;
            this.btnChongZhi.Click += new System.EventHandler(this.btnChongZhi_Click);
            // 
            // Days
            // 
            this.Days.Location = new System.Drawing.Point(118, 350);
            this.Days.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Days.Name = "Days";
            this.Days.Size = new System.Drawing.Size(200, 28);
            this.Days.TabIndex = 12;
            this.Days.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Days.ValueChanged += new System.EventHandler(this.Days_ValueChanged);
            this.Days.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Days_KeyPress);
            // 
            // txtLeiXing
            // 
            this.txtLeiXing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtLeiXing.FormattingEnabled = true;
            this.txtLeiXing.Location = new System.Drawing.Point(472, 36);
            this.txtLeiXing.Name = "txtLeiXing";
            this.txtLeiXing.Size = new System.Drawing.Size(200, 26);
            this.txtLeiXing.TabIndex = 13;
            this.txtLeiXing.SelectedIndexChanged += new System.EventHandler(this.txtLeiXing_SelectedIndexChanged);
            // 
            // cboFanghao
            // 
            this.cboFanghao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFanghao.FormattingEnabled = true;
            this.cboFanghao.Location = new System.Drawing.Point(472, 95);
            this.cboFanghao.Name = "cboFanghao";
            this.cboFanghao.Size = new System.Drawing.Size(200, 26);
            this.cboFanghao.TabIndex = 13;
            this.cboFanghao.SelectedIndexChanged += new System.EventHandler(this.cboFanghao_SelectedIndexChanged);
            this.cboFanghao.SelectionChangeCommitted += new System.EventHandler(this.cboFanghao_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(202, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 16;
            this.label10.Text = "可住人数";
            // 
            // labKeZhu
            // 
            this.labKeZhu.AutoSize = true;
            this.labKeZhu.Location = new System.Drawing.Point(294, 172);
            this.labKeZhu.Name = "labKeZhu";
            this.labKeZhu.Size = new System.Drawing.Size(17, 18);
            this.labKeZhu.TabIndex = 16;
            this.labKeZhu.Text = "0";
            // 
            // cbTongXing
            // 
            this.cbTongXing.AutoSize = true;
            this.cbTongXing.Location = new System.Drawing.Point(472, 203);
            this.cbTongXing.Name = "cbTongXing";
            this.cbTongXing.Size = new System.Drawing.Size(124, 22);
            this.cbTongXing.TabIndex = 17;
            this.cbTongXing.Text = "同住人信息";
            this.cbTongXing.UseVisualStyleBackColor = true;
            this.cbTongXing.CheckedChanged += new System.EventHandler(this.cbTongXing_CheckedChanged);
            this.cbTongXing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbTongXing_MouseClick);
            // 
            // RuZhu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(720, 409);
            this.Controls.Add(this.cbTongXing);
            this.Controls.Add(this.labKeZhu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnChongZhi);
            this.Controls.Add(this.btnTiJiao);
            this.Controls.Add(this.cboFanghao);
            this.Controls.Add(this.txtLeiXing);
            this.Controls.Add(this.Days);
            this.Controls.Add(this.dtpRiQi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSex);
            this.Controls.Add(this.txtJiaGe);
            this.Controls.Add(this.txtDingJIn);
            this.Controls.Add(this.txtShen);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RuZhu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登记入住";
            this.Load += new System.EventHandler(this.RuZhu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Days)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTiJiao;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDingJIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.DateTimePicker dtpRiQi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtJiaGe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnChongZhi;
        private System.Windows.Forms.NumericUpDown Days;
        private System.Windows.Forms.ComboBox txtLeiXing;
        private System.Windows.Forms.ComboBox cboFanghao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labKeZhu;
        private System.Windows.Forms.CheckBox cbTongXing;
    }
}