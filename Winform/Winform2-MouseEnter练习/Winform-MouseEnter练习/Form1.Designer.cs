namespace Winform_MouseEnter练习
{
    partial class Form1
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
            this.ShowLove = new System.Windows.Forms.Button();
            this.Move = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowLove
            // 
            this.ShowLove.Location = new System.Drawing.Point(55, 128);
            this.ShowLove.Name = "ShowLove";
            this.ShowLove.Size = new System.Drawing.Size(75, 23);
            this.ShowLove.TabIndex = 0;
            this.ShowLove.Text = "爱你";
            this.ShowLove.UseVisualStyleBackColor = true;
            this.ShowLove.Click += new System.EventHandler(this.ShowLove_Click);
            // 
            // Move
            // 
            this.Move.Location = new System.Drawing.Point(207, 128);
            this.Move.Name = "Move";
            this.Move.Size = new System.Drawing.Size(75, 23);
            this.Move.TabIndex = 1;
            this.Move.Text = "不爱你";
            this.Move.UseVisualStyleBackColor = true;
            this.Move.MouseEnter += new System.EventHandler(this.Move_MouseEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 287);
            this.Controls.Add(this.Move);
            this.Controls.Add(this.ShowLove);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowLove;
        private System.Windows.Forms.Button Move;
    }
}

