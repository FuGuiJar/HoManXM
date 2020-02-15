namespace HoManXM
{
    partial class TianQi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TianQi));
            this.txtChengShi = new System.Windows.Forms.TextBox();
            this.btnCha = new System.Windows.Forms.Button();
            this.txtShow = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtChengShi
            // 
            this.txtChengShi.Location = new System.Drawing.Point(94, 29);
            this.txtChengShi.Name = "txtChengShi";
            this.txtChengShi.Size = new System.Drawing.Size(215, 28);
            this.txtChengShi.TabIndex = 0;
            // 
            // btnCha
            // 
            this.btnCha.Location = new System.Drawing.Point(363, 22);
            this.btnCha.Name = "btnCha";
            this.btnCha.Size = new System.Drawing.Size(98, 38);
            this.btnCha.TabIndex = 1;
            this.btnCha.Text = "查找";
            this.btnCha.UseVisualStyleBackColor = true;
            this.btnCha.Click += new System.EventHandler(this.btnCha_Click);
            // 
            // txtShow
            // 
            this.txtShow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtShow.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtShow.Location = new System.Drawing.Point(0, 82);
            this.txtShow.Name = "txtShow";
            this.txtShow.Size = new System.Drawing.Size(800, 368);
            this.txtShow.TabIndex = 2;
            this.txtShow.Text = "";
            // 
            // TianQi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtShow);
            this.Controls.Add(this.btnCha);
            this.Controls.Add(this.txtChengShi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TianQi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "天气";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChengShi;
        private System.Windows.Forms.Button btnCha;
        private System.Windows.Forms.RichTextBox txtShow;
    }
}