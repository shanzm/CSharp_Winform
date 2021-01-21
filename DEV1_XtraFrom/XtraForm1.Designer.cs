namespace DEV1_XtraFrom
{
    partial class XtraForm1
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
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labUserName = new DevExpress.XtraEditors.LabelControl();
            this.dataBrithday = new DevExpress.XtraEditors.DateEdit();
            this.labBrithday = new DevExpress.XtraEditors.LabelControl();
            this.labClass = new DevExpress.XtraEditors.LabelControl();
            this.cmbClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labGrade = new DevExpress.XtraEditors.LabelControl();
            this.txtGrade = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBrithday.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBrithday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrade.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(230, 84);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(185, 24);
            this.txtUserName.TabIndex = 1;
            // 
            // labUserName
            // 
            this.labUserName.Location = new System.Drawing.Point(139, 87);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(45, 18);
            this.labUserName.TabIndex = 2;
            this.labUserName.Text = "姓名：";
            // 
            // dataBrithday
            // 
            this.dataBrithday.EditValue = null;
            this.dataBrithday.Location = new System.Drawing.Point(230, 132);
            this.dataBrithday.Name = "dataBrithday";
            this.dataBrithday.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataBrithday.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataBrithday.Size = new System.Drawing.Size(185, 24);
            this.dataBrithday.TabIndex = 3;
            // 
            // labBrithday
            // 
            this.labBrithday.Location = new System.Drawing.Point(139, 135);
            this.labBrithday.Name = "labBrithday";
            this.labBrithday.Size = new System.Drawing.Size(45, 18);
            this.labBrithday.TabIndex = 4;
            this.labBrithday.Text = "生日：";
            // 
            // labClass
            // 
            this.labClass.Location = new System.Drawing.Point(139, 185);
            this.labClass.Name = "labClass";
            this.labClass.Size = new System.Drawing.Size(45, 18);
            this.labClass.TabIndex = 5;
            this.labClass.Text = "班级：";
            // 
            // cmbClass
            // 
            this.cmbClass.Location = new System.Drawing.Point(230, 185);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbClass.Properties.Items.AddRange(new object[] {
            "一年级一班",
            "二年级二班",
            "三年级三班"});
            this.cmbClass.Size = new System.Drawing.Size(185, 24);
            this.cmbClass.TabIndex = 6;
            // 
            // labGrade
            // 
            this.labGrade.Location = new System.Drawing.Point(139, 235);
            this.labGrade.Name = "labGrade";
            this.labGrade.Size = new System.Drawing.Size(45, 18);
            this.labGrade.TabIndex = 7;
            this.labGrade.Text = "分数：";
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(230, 235);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(185, 24);
            this.txtGrade.TabIndex = 8;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 382);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.labGrade);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.labClass);
            this.Controls.Add(this.labBrithday);
            this.Controls.Add(this.dataBrithday);
            this.Controls.Add(this.labUserName);
            this.Controls.Add(this.txtUserName);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBrithday.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBrithday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrade.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labUserName;
        private DevExpress.XtraEditors.DateEdit dataBrithday;
        private DevExpress.XtraEditors.LabelControl labBrithday;
        private DevExpress.XtraEditors.LabelControl labClass;
        private DevExpress.XtraEditors.ComboBoxEdit cmbClass;
        private DevExpress.XtraEditors.LabelControl labGrade;
        private DevExpress.XtraEditors.TextEdit txtGrade;
    }
}