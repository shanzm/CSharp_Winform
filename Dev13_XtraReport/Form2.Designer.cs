
namespace Dev13_XtraReport
{
    partial class Form2
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnForChiChu = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(53, 51);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(146, 34);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "预览报表";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnForChiChu
            // 
            this.btnForChiChu.Location = new System.Drawing.Point(53, 138);
            this.btnForChiChu.Name = "btnForChiChu";
            this.btnForChiChu.Size = new System.Drawing.Size(146, 34);
            this.btnForChiChu.TabIndex = 0;
            this.btnForChiChu.Text = "预览报表2ForChiChu";
            this.btnForChiChu.Click += new System.EventHandler(this.btnForChiChu_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(53, 233);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(146, 34);
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "预览报表3ForBeiJing";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 406);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btnForChiChu);
            this.Controls.Add(this.simpleButton1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnForChiChu;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}