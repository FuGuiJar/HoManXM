namespace HoManXM
{
    partial class FrmShangPincomplie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShangPincomplie));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBianJi = new System.Windows.Forms.PictureBox();
            this.pictureDelete = new System.Windows.Forms.PictureBox();
            this.pictureAdd = new System.Windows.Forms.PictureBox();
            this.pictureShuaXin = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBianJi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShuaXin)).BeginInit();
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
            this.Column4});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 157);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1033, 474);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "goods_id";
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "goods_name";
            this.Column2.HeaderText = "商品名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "goods_money";
            this.Column3.HeaderText = "单价";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "goods_shuliang";
            this.Column4.HeaderText = "数量";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // pictureBianJi
            // 
            this.pictureBianJi.Image = ((System.Drawing.Image)(resources.GetObject("pictureBianJi.Image")));
            this.pictureBianJi.Location = new System.Drawing.Point(265, 59);
            this.pictureBianJi.Name = "pictureBianJi";
            this.pictureBianJi.Size = new System.Drawing.Size(51, 51);
            this.pictureBianJi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBianJi.TabIndex = 6;
            this.pictureBianJi.TabStop = false;
            this.pictureBianJi.Click += new System.EventHandler(this.pictureBianJi_Click);
            // 
            // pictureDelete
            // 
            this.pictureDelete.Image = ((System.Drawing.Image)(resources.GetObject("pictureDelete.Image")));
            this.pictureDelete.Location = new System.Drawing.Point(465, 59);
            this.pictureDelete.Name = "pictureDelete";
            this.pictureDelete.Size = new System.Drawing.Size(51, 51);
            this.pictureDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureDelete.TabIndex = 8;
            this.pictureDelete.TabStop = false;
            this.pictureDelete.Click += new System.EventHandler(this.pictureDelete_Click);
            // 
            // pictureAdd
            // 
            this.pictureAdd.Image = ((System.Drawing.Image)(resources.GetObject("pictureAdd.Image")));
            this.pictureAdd.InitialImage = null;
            this.pictureAdd.Location = new System.Drawing.Point(65, 59);
            this.pictureAdd.Name = "pictureAdd";
            this.pictureAdd.Size = new System.Drawing.Size(51, 51);
            this.pictureAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureAdd.TabIndex = 9;
            this.pictureAdd.TabStop = false;
            this.pictureAdd.Click += new System.EventHandler(this.pictureAdd_Click);
            // 
            // pictureShuaXin
            // 
            this.pictureShuaXin.Image = ((System.Drawing.Image)(resources.GetObject("pictureShuaXin.Image")));
            this.pictureShuaXin.Location = new System.Drawing.Point(665, 59);
            this.pictureShuaXin.Name = "pictureShuaXin";
            this.pictureShuaXin.Size = new System.Drawing.Size(51, 51);
            this.pictureShuaXin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureShuaXin.TabIndex = 10;
            this.pictureShuaXin.TabStop = false;
            this.pictureShuaXin.Click += new System.EventHandler(this.pictureShuaXin_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(798, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 25);
            this.textBox1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(937, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 25);
            this.button1.TabIndex = 12;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmShangPincomplie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 631);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureShuaXin);
            this.Controls.Add(this.pictureAdd);
            this.Controls.Add(this.pictureDelete);
            this.Controls.Add(this.pictureBianJi);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShangPincomplie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品管理";
            this.Load += new System.EventHandler(this.FrmShangPincomplie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBianJi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShuaXin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.PictureBox pictureBianJi;
        private System.Windows.Forms.PictureBox pictureDelete;
        private System.Windows.Forms.PictureBox pictureAdd;
        private System.Windows.Forms.PictureBox pictureShuaXin;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}