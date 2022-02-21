namespace zcgl.zcwh
{
    partial class fmAll
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvPageControl1 = new DatapagerData.DatapagerData();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(569, 308);
            this.dataGridView1.TabIndex = 19;
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
            this.dgvPageControl1.Datapager_PageSize = 12;
            this.dgvPageControl1.Datapager_procQueryTableRecordCountName = "";
            this.dgvPageControl1.Datapager_procSplitPageName = "";
            this.dgvPageControl1.Datapager_tableName = "";
            this.dgvPageControl1.Datapager_TotalCount = 0;
            this.dgvPageControl1.Datapager_YuShu = 0;
            this.dgvPageControl1.Location = new System.Drawing.Point(12, 342);
            this.dgvPageControl1.Name = "dgvPageControl1";
            this.dgvPageControl1.Size = new System.Drawing.Size(570, 43);
            this.dgvPageControl1.TabIndex = 20;
            // 
            // fmAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 388);
            this.Controls.Add(this.dgvPageControl1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "fmAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "所有资产";
            this.Load += new System.EventHandler(this.fmAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private DatapagerData.DatapagerData dgvPageControl1;
    }
}