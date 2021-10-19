namespace PM.WinPM
{
    partial class FrmMain
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
            this.tvMenus = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvMenus
            // 
            this.tvMenus.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvMenus.Location = new System.Drawing.Point(0, 0);
            this.tvMenus.Name = "tvMenus";
            this.tvMenus.Size = new System.Drawing.Size(165, 450);
            this.tvMenus.TabIndex = 0;
            this.tvMenus.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMenus_AfterSelect);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tvMenus);
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.Text = "权限管理系统主页面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvMenus;
    }
}