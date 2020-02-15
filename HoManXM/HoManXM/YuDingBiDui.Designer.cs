namespace HoManXM
{
    partial class YuDingBiDui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YuDingBiDui));
            this.txtShouJiHao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQueDing = new System.Windows.Forms.Button();
            this.btnQuXiao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtShouJiHao
            // 
            this.txtShouJiHao.Location = new System.Drawing.Point(116, 48);
            this.txtShouJiHao.Name = "txtShouJiHao";
            this.txtShouJiHao.Size = new System.Drawing.Size(179, 28);
            this.txtShouJiHao.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "手机号";
            // 
            // btnQueDing
            // 
            this.btnQueDing.Location = new System.Drawing.Point(116, 124);
            this.btnQueDing.Name = "btnQueDing";
            this.btnQueDing.Size = new System.Drawing.Size(75, 30);
            this.btnQueDing.TabIndex = 2;
            this.btnQueDing.Text = "确定";
            this.btnQueDing.UseVisualStyleBackColor = true;
            this.btnQueDing.Click += new System.EventHandler(this.btnQueDing_Click);
            // 
            // btnQuXiao
            // 
            this.btnQuXiao.Location = new System.Drawing.Point(220, 124);
            this.btnQuXiao.Name = "btnQuXiao";
            this.btnQuXiao.Size = new System.Drawing.Size(75, 30);
            this.btnQuXiao.TabIndex = 2;
            this.btnQuXiao.Text = "取消";
            this.btnQuXiao.UseVisualStyleBackColor = true;
            this.btnQuXiao.Click += new System.EventHandler(this.btnQuXiao_Click);
            // 
            // YuDingBiDui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(371, 209);
            this.Controls.Add(this.btnQuXiao);
            this.Controls.Add(this.btnQueDing);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtShouJiHao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YuDingBiDui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "开房";
            this.Load += new System.EventHandler(this.YuDingBiDui_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtShouJiHao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQueDing;
        private System.Windows.Forms.Button btnQuXiao;
    }
}