namespace HoManXM
{
    partial class FrmBianJi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBianJi));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtXuHao = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtMingCheng = new System.Windows.Forms.TextBox();
            this.txtShuLiang = new System.Windows.Forms.TextBox();
            this.btn1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "序号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "商品名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "单价";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 406);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "数量";
            // 
            // txtXuHao
            // 
            this.txtXuHao.Enabled = false;
            this.txtXuHao.Location = new System.Drawing.Point(166, 48);
            this.txtXuHao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtXuHao.Name = "txtXuHao";
            this.txtXuHao.ReadOnly = true;
            this.txtXuHao.Size = new System.Drawing.Size(210, 28);
            this.txtXuHao.TabIndex = 4;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(166, 288);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(210, 28);
            this.txtPrice.TabIndex = 5;
            // 
            // txtMingCheng
            // 
            this.txtMingCheng.Location = new System.Drawing.Point(166, 164);
            this.txtMingCheng.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMingCheng.Name = "txtMingCheng";
            this.txtMingCheng.Size = new System.Drawing.Size(210, 28);
            this.txtMingCheng.TabIndex = 6;
            // 
            // txtShuLiang
            // 
            this.txtShuLiang.Location = new System.Drawing.Point(166, 403);
            this.txtShuLiang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtShuLiang.Name = "txtShuLiang";
            this.txtShuLiang.Size = new System.Drawing.Size(210, 28);
            this.txtShuLiang.TabIndex = 7;
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(204, 504);
            this.btn1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(84, 28);
            this.btn1.TabIndex = 8;
            this.btn1.Text = "提交";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // FrmBianJi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(472, 586);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.txtShuLiang);
            this.Controls.Add(this.txtMingCheng);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtXuHao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBianJi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改商品";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBianJi_FormClosed);
            this.Load += new System.EventHandler(this.编辑商品_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtXuHao;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtMingCheng;
        private System.Windows.Forms.TextBox txtShuLiang;
        private System.Windows.Forms.Button btn1;
    }
}