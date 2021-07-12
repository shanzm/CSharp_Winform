
namespace DEV5_选中行右键操作
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
            this.gridControl_Company = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView_Company = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CompanyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CheckBox = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Company)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Company)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Company
            // 
            this.gridControl_Company.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl_Company.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Company.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Company.MainView = this.gridView_Company;
            this.gridControl_Company.Name = "gridControl_Company";
            this.gridControl_Company.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl_Company.Size = new System.Drawing.Size(800, 450);
            this.gridControl_Company.TabIndex = 0;
            this.gridControl_Company.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Company});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 52);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // gridView_Company
            // 
            this.gridView_Company.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CheckBox,
            this.CompanyId,
            this.CompanyName});
            this.gridView_Company.GridControl = this.gridControl_Company;
            this.gridView_Company.Name = "gridView_Company";
            // 
            // CompanyId
            // 
            this.CompanyId.Caption = "公司ID";
            this.CompanyId.FieldName = "Id";
            this.CompanyId.MinWidth = 25;
            this.CompanyId.Name = "CompanyId";
            this.CompanyId.Visible = true;
            this.CompanyId.VisibleIndex = 0;
            this.CompanyId.Width = 94;
            // 
            // CompanyName
            // 
            this.CompanyName.Caption = "公司名称";
            this.CompanyName.FieldName = "Name";
            this.CompanyName.MinWidth = 25;
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.Visible = true;
            this.CompanyName.VisibleIndex = 1;
            this.CompanyName.Width = 94;
            // 
            // CheckBox
            // 
            this.CheckBox.Caption = "选择";
            this.CheckBox.ColumnEdit = this.repositoryItemCheckEdit1;
            this.CheckBox.MinWidth = 25;
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Visible = true;
            this.CheckBox.VisibleIndex = 2;
            this.CheckBox.Width = 94;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl_Company);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Company)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Company)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Company;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Company;
        private DevExpress.XtraGrid.Columns.GridColumn CompanyId;
        private DevExpress.XtraGrid.Columns.GridColumn CompanyName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn CheckBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}

