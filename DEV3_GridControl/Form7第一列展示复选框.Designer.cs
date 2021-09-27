
namespace DEV3_GridControl
{
    partial class Form7第一列展示复选框
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
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLegelPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.companyBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gridControl1.Size = new System.Drawing.Size(800, 450);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(DEV3_GridControl.Company);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsChecked,
            this.colId,
            this.colName,
            this.colAddress,
            this.colLegelPerson});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colIsChecked
            // 
            this.colIsChecked.Caption = " ";
            this.colIsChecked.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsChecked.FieldName = "IsChecked";
            this.colIsChecked.MinWidth = 25;
            this.colIsChecked.Name = "colIsChecked";
            this.colIsChecked.Visible = true;
            this.colIsChecked.VisibleIndex = 0;
            this.colIsChecked.Width = 94;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 1;
            this.colId.Width = 94;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 25;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 94;
            // 
            // colAddress
            // 
            this.colAddress.FieldName = "Address";
            this.colAddress.MinWidth = 25;
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 3;
            this.colAddress.Width = 94;
            // 
            // colLegelPerson
            // 
            this.colLegelPerson.FieldName = "LegelPerson";
            this.colLegelPerson.MinWidth = 25;
            this.colLegelPerson.Name = "colLegelPerson";
            this.colLegelPerson.Visible = true;
            this.colLegelPerson.VisibleIndex = 4;
            this.colLegelPerson.Width = 94;
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // checkEdit1
            // 
            this.checkEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkEdit1.Location = new System.Drawing.Point(89, 46);
            this.checkEdit1.MinimumSize = new System.Drawing.Size(50, 15);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "";
            this.checkEdit1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.checkEdit1.Size = new System.Drawing.Size(50, 19);
            this.checkEdit1.TabIndex = 1;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(110, 388);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(289, 29);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "修改第三行复选框，点击查看当前值";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Form7第一列展示复选框
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form7第一列展示复选框";
            this.Text = "Form7第一列展示复选框";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colLegelPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colIsChecked;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}