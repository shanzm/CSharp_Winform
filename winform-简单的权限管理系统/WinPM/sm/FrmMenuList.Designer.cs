namespace PM.WinPM.sm
{
    partial class FrmMenuList
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.cboParents = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMenus = new System.Windows.Forms.DataGridView();
            this.MenuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenus)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(682, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新增菜单";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.txtMName);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.cboParents);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 66);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件:";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(569, 25);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "查询";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(310, 24);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(155, 21);
            this.txtMName.TabIndex = 3;
            // 
            // cboParents
            // 
            this.cboParents.FormattingEnabled = true;
            this.cboParents.Location = new System.Drawing.Point(78, 25);
            this.cboParents.Name = "cboParents";
            this.cboParents.Size = new System.Drawing.Size(136, 20);
            this.cboParents.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "菜单名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "父级菜单：";
            // 
            // dgvMenus
            // 
            this.dgvMenus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MenuId,
            this.MenuName,
            this.ParentId,
            this.ParentName,
            this.FrmName,
            this.MKey,
            this.Edit,
            this.Delete});
            this.dgvMenus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenus.Location = new System.Drawing.Point(0, 66);
            this.dgvMenus.Name = "dgvMenus";
            this.dgvMenus.RowTemplate.Height = 23;
            this.dgvMenus.Size = new System.Drawing.Size(880, 360);
            this.dgvMenus.TabIndex = 2;
            this.dgvMenus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenus_CellContentClick);
            // 
            // MenuId
            // 
            this.MenuId.DataPropertyName = "MenuId";
            this.MenuId.HeaderText = "编号";
            this.MenuId.Name = "MenuId";
            this.MenuId.ReadOnly = true;
            // 
            // MenuName
            // 
            this.MenuName.DataPropertyName = "MenuName";
            this.MenuName.HeaderText = "菜单名";
            this.MenuName.Name = "MenuName";
            this.MenuName.ReadOnly = true;
            // 
            // ParentId
            // 
            this.ParentId.DataPropertyName = "ParentId";
            this.ParentId.HeaderText = "父级编号";
            this.ParentId.Name = "ParentId";
            this.ParentId.ReadOnly = true;
            // 
            // ParentName
            // 
            this.ParentName.DataPropertyName = "ParentName";
            this.ParentName.HeaderText = "父级菜单";
            this.ParentName.Name = "ParentName";
            this.ParentName.ReadOnly = true;
            // 
            // FrmName
            // 
            this.FrmName.DataPropertyName = "FrmName";
            this.FrmName.FillWeight = 200F;
            this.FrmName.HeaderText = "页面地址";
            this.FrmName.Name = "FrmName";
            this.FrmName.ReadOnly = true;
            // 
            // MKey
            // 
            this.MKey.DataPropertyName = "MKey";
            this.MKey.HeaderText = "快捷键";
            this.MKey.Name = "MKey";
            this.MKey.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "修改";
            this.Edit.Name = "Edit";
            this.Edit.Text = "修改";
            this.Edit.UseColumnTextForLinkValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "删除";
            this.Delete.Name = "Delete";
            this.Delete.Text = "删除";
            this.Delete.UseColumnTextForLinkValue = true;
            // 
            // FrmMenuList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 426);
            this.Controls.Add(this.dgvMenus);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMenuList";
            this.Text = "菜单列表";
            this.Load += new System.EventHandler(this.FrmMenuList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.ComboBox cboParents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMenus;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MKey;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
}