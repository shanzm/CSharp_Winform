
namespace DEV3_GridControl
{
    partial class Form2
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
            this.gridControl_company = new DevExpress.XtraGrid.GridControl();
            this.gridView_company = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CompanyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CompanyAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CompanyLegelPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_company)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_company)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_company
            // 
            this.gridControl_company.Location = new System.Drawing.Point(1, 0);
            this.gridControl_company.MainView = this.gridView_company;
            this.gridControl_company.Name = "gridControl_company";
            this.gridControl_company.Size = new System.Drawing.Size(798, 450);
            this.gridControl_company.TabIndex = 0;
            this.gridControl_company.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_company});
            // 
            // gridView_company
            // 
            this.gridView_company.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CompanyId,
            this.CompanyName,
            this.CompanyAddress,
            this.CompanyLegelPerson});
            this.gridView_company.GridControl = this.gridControl_company;
            this.gridView_company.Name = "gridView_company";
            // 
            // CompanyId
            // 
            this.CompanyId.Caption = "公司Id";
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
            // CompanyAddress
            // 
            this.CompanyAddress.Caption = "公司地址";
            this.CompanyAddress.FieldName = "Address";
            this.CompanyAddress.MinWidth = 25;
            this.CompanyAddress.Name = "CompanyAddress";
            this.CompanyAddress.Visible = true;
            this.CompanyAddress.VisibleIndex = 2;
            this.CompanyAddress.Width = 94;
            // 
            // CompanyLegelPerson
            // 
            this.CompanyLegelPerson.Caption = "公司法人";
            this.CompanyLegelPerson.FieldName = "LegelPerson";
            this.CompanyLegelPerson.MinWidth = 25;
            this.CompanyLegelPerson.Name = "CompanyLegelPerson";
            this.CompanyLegelPerson.Visible = true;
            this.CompanyLegelPerson.VisibleIndex = 3;
            this.CompanyLegelPerson.Width = 94;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl_company);
            this.Name = "Form2";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_company)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_company)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_company;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_company;
        private DevExpress.XtraGrid.Columns.GridColumn CompanyId;
        private DevExpress.XtraGrid.Columns.GridColumn CompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn CompanyAddress;
        private DevExpress.XtraGrid.Columns.GridColumn CompanyLegelPerson;
    }
}

