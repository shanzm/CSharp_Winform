
namespace Dev14_BackstageView
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewTabItem1 = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewClientControl2 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewTabItem2 = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            this.backstageViewControl1.SuspendLayout();
            this.backstageViewClientControl1.SuspendLayout();
            this.backstageViewClientControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl2);
            this.backstageViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backstageViewControl1.Items.Add(this.backstageViewTabItem1);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItem2);
            this.backstageViewControl1.Location = new System.Drawing.Point(0, 0);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.SelectedTab = this.backstageViewTabItem2;
            this.backstageViewControl1.SelectedTabIndex = 1;
            this.backstageViewControl1.Size = new System.Drawing.Size(800, 450);
            this.backstageViewControl1.Style = DevExpress.XtraBars.Ribbon.BackstageViewStyle.Office2010;
            this.backstageViewControl1.TabIndex = 0;
            this.backstageViewControl1.Text = "backstageViewControl1";
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Controls.Add(this.label2);
            this.backstageViewClientControl1.Location = new System.Drawing.Point(192, 63);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(607, 386);
            this.backstageViewClientControl1.TabIndex = 1;
            // 
            // backstageViewTabItem1
            // 
            this.backstageViewTabItem1.Caption = "backstageViewTabItem1";
            this.backstageViewTabItem1.ContentControl = this.backstageViewClientControl1;
            this.backstageViewTabItem1.Name = "backstageViewTabItem1";
            // 
            // backstageViewClientControl2
            // 
            this.backstageViewClientControl2.Controls.Add(this.label1);
            this.backstageViewClientControl2.Location = new System.Drawing.Point(192, 0);
            this.backstageViewClientControl2.Name = "backstageViewClientControl2";
            this.backstageViewClientControl2.Size = new System.Drawing.Size(608, 450);
            this.backstageViewClientControl2.TabIndex = 2;
            // 
            // backstageViewTabItem2
            // 
            this.backstageViewTabItem2.Caption = "backstageViewTabItem2";
            this.backstageViewTabItem2.ContentControl = this.backstageViewClientControl2;
            this.backstageViewTabItem2.Name = "backstageViewTabItem2";
            this.backstageViewTabItem2.Selected = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "第二页";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "第一页";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backstageViewControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).EndInit();
            this.backstageViewControl1.ResumeLayout(false);
            this.backstageViewClientControl1.ResumeLayout(false);
            this.backstageViewClientControl1.PerformLayout();
            this.backstageViewClientControl2.ResumeLayout(false);
            this.backstageViewClientControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem2;
    }
}

