namespace zcgl
{
    partial class fmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtmima = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btndenglu = new System.Windows.Forms.Button();
            this.btnchongzhi = new System.Windows.Forms.Button();
            this.btnzhuce = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtzhanghao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtmima
            // 
            this.txtmima.Location = new System.Drawing.Point(69, 85);
            this.txtmima.Name = "txtmima";
            this.txtmima.PasswordChar = '*';
            this.txtmima.Size = new System.Drawing.Size(135, 21);
            this.txtmima.TabIndex = 1;
            this.txtmima.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "帐号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "密码：";
            // 
            // btndenglu
            // 
            this.btndenglu.Location = new System.Drawing.Point(66, 163);
            this.btndenglu.Name = "btndenglu";
            this.btndenglu.Size = new System.Drawing.Size(75, 23);
            this.btndenglu.TabIndex = 6;
            this.btndenglu.Text = "登录";
            this.btndenglu.UseVisualStyleBackColor = true;
            this.btndenglu.Click += new System.EventHandler(this.btndenglu_Click);
            // 
            // btnchongzhi
            // 
            this.btnchongzhi.Location = new System.Drawing.Point(168, 163);
            this.btnchongzhi.Name = "btnchongzhi";
            this.btnchongzhi.Size = new System.Drawing.Size(75, 23);
            this.btnchongzhi.TabIndex = 7;
            this.btnchongzhi.Text = "重置";
            this.btnchongzhi.UseVisualStyleBackColor = true;
            this.btnchongzhi.Click += new System.EventHandler(this.btnchongzhi_Click);
            // 
            // btnzhuce
            // 
            this.btnzhuce.Location = new System.Drawing.Point(221, 42);
            this.btnzhuce.Name = "btnzhuce";
            this.btnzhuce.Size = new System.Drawing.Size(55, 21);
            this.btnzhuce.TabIndex = 8;
            this.btnzhuce.Text = "注册";
            this.btnzhuce.UseVisualStyleBackColor = true;
            this.btnzhuce.Click += new System.EventHandler(this.btnzhuce_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(69, 128);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "记住密码";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtzhanghao
            // 
            this.txtzhanghao.FormattingEnabled = true;
            this.txtzhanghao.Items.AddRange(new object[] {
            "1"});
            this.txtzhanghao.Location = new System.Drawing.Point(69, 42);
            this.txtzhanghao.Name = "txtzhanghao";
            this.txtzhanghao.Size = new System.Drawing.Size(135, 20);
            this.txtzhanghao.TabIndex = 0;
            this.txtzhanghao.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(69, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 10;
            // 
            // fmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 221);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtzhanghao);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnzhuce);
            this.Controls.Add(this.btnchongzhi);
            this.Controls.Add(this.btndenglu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtmima);
            this.Name = "fmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.fmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtmima;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btndenglu;
        private System.Windows.Forms.Button btnchongzhi;
        private System.Windows.Forms.Button btnzhuce;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox txtzhanghao;
        private System.Windows.Forms.Label label3;
    }
}

