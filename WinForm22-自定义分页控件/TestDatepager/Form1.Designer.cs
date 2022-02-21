
namespace TestPage
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.dgvPageControl1 = new DatapagerData.DatapagerData();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(576, 288);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(395, 20);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(171, 23);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "筛选";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // cmbName
            // 
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Items.AddRange(new object[] {
            "张三",
            "李四",
            "王五",
            "赵六"});
            this.cmbName.Location = new System.Drawing.Point(67, 22);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(153, 20);
            this.cmbName.TabIndex = 5;
            // 
            // dgvPageControl1
            // 
            this.dgvPageControl1.Datapager_condition = "";
            this.dgvPageControl1.Datapager_Connstr = "";
            this.dgvPageControl1.Datapager_CurrentPageCount = 0;
            this.dgvPageControl1.Datapager_CurrentPageIndex = 1;
            this.dgvPageControl1.Datapager_DataGridView = null;
            this.dgvPageControl1.Datapager_IsAutoUpdateLabelTip = true;
            this.dgvPageControl1.Datapager_LbInfo = "当前|总共：1|1";
            this.dgvPageControl1.Datapager_PageCount = 0;
            this.dgvPageControl1.Datapager_PageSize = 10;
            this.dgvPageControl1.Datapager_procQueryTableRecordCountName = "";
            this.dgvPageControl1.Datapager_procSplitPageName = "";
            this.dgvPageControl1.Datapager_tableName = "";
            this.dgvPageControl1.Datapager_TotalCount = 0;
            this.dgvPageControl1.Datapager_YuShu = 0;
            this.dgvPageControl1.Location = new System.Drawing.Point(10, 363);
            this.dgvPageControl1.Name = "dgvPageControl1";
            this.dgvPageControl1.Size = new System.Drawing.Size(578, 43);
            this.dgvPageControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 406);
            this.Controls.Add(this.cmbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgvPageControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DatapagerData.DatapagerData dgvPageControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbName;
    }
}

