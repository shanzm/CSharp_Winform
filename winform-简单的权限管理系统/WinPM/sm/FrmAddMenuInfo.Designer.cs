namespace PM.WinPM.sm
{
    partial class FrmAddMenuInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.cboParents = new System.Windows.Forms.ComboBox();
            this.cboForms = new System.Windows.Forms.ComboBox();
            this.txtShortKey = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "菜单名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "父级菜单：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "关联页面：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "快捷键：";
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(107, 50);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(157, 21);
            this.txtMName.TabIndex = 4;
            // 
            // cboParents
            // 
            this.cboParents.FormattingEnabled = true;
            this.cboParents.Location = new System.Drawing.Point(107, 100);
            this.cboParents.Name = "cboParents";
            this.cboParents.Size = new System.Drawing.Size(157, 20);
            this.cboParents.TabIndex = 5;
            // 
            // cboForms
            // 
            this.cboForms.FormattingEnabled = true;
            this.cboForms.Location = new System.Drawing.Point(107, 154);
            this.cboForms.Name = "cboForms";
            this.cboForms.Size = new System.Drawing.Size(157, 20);
            this.cboForms.TabIndex = 6;
            // 
            // txtShortKey
            // 
            this.txtShortKey.Location = new System.Drawing.Point(107, 196);
            this.txtShortKey.Name = "txtShortKey";
            this.txtShortKey.Size = new System.Drawing.Size(157, 21);
            this.txtShortKey.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(87, 253);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(189, 253);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // FrmAddMenuInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 338);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtShortKey);
            this.Controls.Add(this.cboForms);
            this.Controls.Add(this.cboParents);
            this.Controls.Add(this.txtMName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmAddMenuInfo";
            this.Text = "菜单信息页面";
            this.Load += new System.EventHandler(this.FrmAddMenuInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.ComboBox cboParents;
        private System.Windows.Forms.ComboBox cboForms;
        private System.Windows.Forms.TextBox txtShortKey;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
    }
}