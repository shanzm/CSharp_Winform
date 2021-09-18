
namespace Winform19_TreeView
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("总经办");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("人事行政");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("IT");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("苏州分公司", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("北京分公司");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("上海分公司");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("天津分公司");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("总公司", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点6";
            treeNode1.Text = "总经办";
            treeNode2.Name = "节点8";
            treeNode2.Text = "人事行政";
            treeNode3.Name = "节点9";
            treeNode3.Text = "IT";
            treeNode4.Name = "节点1";
            treeNode4.Text = "苏州分公司";
            treeNode5.Name = "节点2";
            treeNode5.Text = "北京分公司";
            treeNode6.Name = "节点3";
            treeNode6.Text = "上海分公司";
            treeNode7.Name = "节点4";
            treeNode7.Text = "天津分公司";
            treeNode8.Name = "节点0";
            treeNode8.Text = "总公司";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(281, 597);
            this.treeView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 621);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
    }
}

