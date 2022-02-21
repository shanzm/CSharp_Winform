namespace zcgl.xtwh
{
    partial class fmDefault
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtqz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnbc = new System.Windows.Forms.Button();
            this.btnqx = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtqz);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtqz
            // 
            this.txtqz.Location = new System.Drawing.Point(74, 43);
            this.txtqz.Name = "txtqz";
            this.txtqz.Size = new System.Drawing.Size(141, 21);
            this.txtqz.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "前缀：";
            // 
            // btnbc
            // 
            this.btnbc.Location = new System.Drawing.Point(53, 155);
            this.btnbc.Name = "btnbc";
            this.btnbc.Size = new System.Drawing.Size(75, 23);
            this.btnbc.TabIndex = 1;
            this.btnbc.Text = "保存";
            this.btnbc.UseVisualStyleBackColor = true;
            this.btnbc.Click += new System.EventHandler(this.btnbc_Click);
            // 
            // btnqx
            // 
            this.btnqx.Location = new System.Drawing.Point(154, 155);
            this.btnqx.Name = "btnqx";
            this.btnqx.Size = new System.Drawing.Size(75, 23);
            this.btnqx.TabIndex = 2;
            this.btnqx.Text = "关闭";
            this.btnqx.UseVisualStyleBackColor = true;
            this.btnqx.Click += new System.EventHandler(this.btnqx_Click);
            // 
            // fmDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 204);
            this.Controls.Add(this.btnqx);
            this.Controls.Add(this.btnbc);
            this.Controls.Add(this.groupBox1);
            this.Name = "fmDefault";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "资产编号";
            this.Load += new System.EventHandler(this.fmDefault_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtqz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnbc;
        private System.Windows.Forms.Button btnqx;
    }
}