
namespace Dev6_等待窗口
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnShowWait = new System.Windows.Forms.Button();
            this.btnShowMyWait = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowWait
            // 
            this.btnShowWait.Location = new System.Drawing.Point(17, 68);
            this.btnShowWait.Name = "btnShowWait";
            this.btnShowWait.Size = new System.Drawing.Size(175, 29);
            this.btnShowWait.TabIndex = 0;
            this.btnShowWait.Text = "弹出等待窗口（原生DEV）";
            this.btnShowWait.UseVisualStyleBackColor = true;
            this.btnShowWait.Click += new System.EventHandler(this.BtnShowWait_Click);
            // 
            // btnShowMyWait
            // 
            this.btnShowMyWait.Location = new System.Drawing.Point(17, 141);
            this.btnShowMyWait.Name = "btnShowMyWait";
            this.btnShowMyWait.Size = new System.Drawing.Size(175, 29);
            this.btnShowMyWait.TabIndex = 0;
            this.btnShowMyWait.Text = "弹出等待窗口（带进度条）";
            this.btnShowMyWait.UseVisualStyleBackColor = true;
            this.btnShowMyWait.Click += new System.EventHandler(this.BtnShowMyWait_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 255);
            this.Controls.Add(this.btnShowMyWait);
            this.Controls.Add(this.btnShowWait);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowWait;
        private System.Windows.Forms.Button btnShowMyWait;
    }
}

