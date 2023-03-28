namespace DemoMessageBox
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnYesNo = new System.Windows.Forms.Button();
            this.btnYesNoCancel = new System.Windows.Forms.Button();
            this.btnOkCancel = new System.Windows.Forms.Button();
            this.btnRetryCancel = new System.Windows.Forms.Button();
            this.btnAbortRetryCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(18, 68);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnYesNo
            // 
            this.btnYesNo.Location = new System.Drawing.Point(130, 68);
            this.btnYesNo.Name = "btnYesNo";
            this.btnYesNo.Size = new System.Drawing.Size(75, 23);
            this.btnYesNo.TabIndex = 1;
            this.btnYesNo.Text = "YesNo";
            this.btnYesNo.UseVisualStyleBackColor = true;
            this.btnYesNo.Click += new System.EventHandler(this.btnYesNo_Click);
            // 
            // btnYesNoCancel
            // 
            this.btnYesNoCancel.Location = new System.Drawing.Point(242, 68);
            this.btnYesNoCancel.Name = "btnYesNoCancel";
            this.btnYesNoCancel.Size = new System.Drawing.Size(75, 23);
            this.btnYesNoCancel.TabIndex = 2;
            this.btnYesNoCancel.Text = "YesNoCacle";
            this.btnYesNoCancel.UseVisualStyleBackColor = true;
            this.btnYesNoCancel.Click += new System.EventHandler(this.btnYesNoCancel_Click);
            // 
            // btnOkCancel
            // 
            this.btnOkCancel.Location = new System.Drawing.Point(18, 125);
            this.btnOkCancel.Name = "btnOkCancel";
            this.btnOkCancel.Size = new System.Drawing.Size(75, 23);
            this.btnOkCancel.TabIndex = 3;
            this.btnOkCancel.Text = "OkCancel";
            this.btnOkCancel.UseVisualStyleBackColor = true;
            this.btnOkCancel.Click += new System.EventHandler(this.btnOkCancel_Click);
            // 
            // btnRetryCancel
            // 
            this.btnRetryCancel.Location = new System.Drawing.Point(130, 125);
            this.btnRetryCancel.Name = "btnRetryCancel";
            this.btnRetryCancel.Size = new System.Drawing.Size(75, 23);
            this.btnRetryCancel.TabIndex = 4;
            this.btnRetryCancel.Text = "RetryCancel";
            this.btnRetryCancel.UseVisualStyleBackColor = true;
            this.btnRetryCancel.Click += new System.EventHandler(this.btnRetryCancel_Click);
            // 
            // btnAbortRetryCancel
            // 
            this.btnAbortRetryCancel.Location = new System.Drawing.Point(242, 125);
            this.btnAbortRetryCancel.Name = "btnAbortRetryCancel";
            this.btnAbortRetryCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAbortRetryCancel.TabIndex = 5;
            this.btnAbortRetryCancel.Text = "AbortRetryCancel";
            this.btnAbortRetryCancel.UseVisualStyleBackColor = true;
            this.btnAbortRetryCancel.Click += new System.EventHandler(this.btnAbortRetryCancel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 188);
            this.Controls.Add(this.btnAbortRetryCancel);
            this.Controls.Add(this.btnRetryCancel);
            this.Controls.Add(this.btnOkCancel);
            this.Controls.Add(this.btnYesNoCancel);
            this.Controls.Add(this.btnYesNo);
            this.Controls.Add(this.btnOK);
            this.Name = "MainForm";
            this.Text = "对话框示例";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnYesNo;
        private System.Windows.Forms.Button btnYesNoCancel;
        private System.Windows.Forms.Button btnOkCancel;
        private System.Windows.Forms.Button btnRetryCancel;
        private System.Windows.Forms.Button btnAbortRetryCancel;
    }
}

