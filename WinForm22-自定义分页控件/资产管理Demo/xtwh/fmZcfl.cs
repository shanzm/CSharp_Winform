using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zcgl.xtwh
{
    public partial class fmZcfl : Form
    {
        zcgl.myclass.operation oper = new zcgl.myclass.operation();
        int zclbID = 0;
        private zcgl.fmMain.DelegateRefreshDGV tv;
        public fmZcfl(zcgl.fmMain.DelegateRefreshDGV _tv)
        {
            InitializeComponent();
            this.tv = _tv;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            treeView1.MouseDoubleClick += treeView1_MouseDoubleClick;  //双击编辑
            treeView1.HideSelection = false;  //失去焦点仍保持选中
        }

        private void fmZcfl_Load(object sender, EventArgs e)
        {
            FillTreeView();
            btnSave.Visible = false;
        }

        #region treeView
        /// <summary>
        /// treeView
        /// </summary>
        private void FillTreeView()
        {
            treeView1.Nodes.Clear();
            //设置TreeView控件的菜单项
            DataSet ds = null;
            ds = oper.TreeFill();
            TreeNode RootNode = null;
            DataTable dt = ds.Tables[0].Copy();  //将资产列表另存一份为dt
            DataView dv = new DataView(dt);
            dv.RowFilter = "firstID = -1";
            //将数据集中的所有记录逐个根据他们之间的关系添加到树形表中去
            if (dv.Count > 0)
            {
                foreach (DataRowView myRow in dv)
                {
                    //设置根节点,然后该函数会递归添加所有子节点。
                    treeView1.Nodes.Add(RootNode = new TreeNode(myRow["zclb"].ToString()));
                    childTreeView(myRow["zclb"].ToString(), treeView1.Nodes[0], myRow);
                    treeView1.SelectedNode = treeView1.Nodes[0];  //选中第一个节点 
                }
            }
            treeView1.ExpandAll();
        }
        private void childTreeView(string childPart, TreeNode childNode, DataRowView childRow)
        {
            string strdeptName = "";
            DataSet ds = null;
            ds = oper.TreeFill();
            DataTable dt = ds.Tables[0].Copy();
            DataView dv = new DataView(dt);
            //筛选获得当前传递过来的节点的子项，并将其添加到树形图中
            //判断方法是凡parentIndex等于传递过来的节点的absIndex的，就是该节点的子项
            dv.RowFilter = "firstID = '" + childRow["secondID"].ToString() + "'";
            //递归的添加每一个节点的所有子节点
            foreach (DataRowView myRow in dv)
            {
                strdeptName = myRow["zclb"].ToString();
                TreeNode myNode = new TreeNode(strdeptName);
                childNode.Nodes.Add(myNode);
                //函数递归调用，将所有节点按顺序添加完毕
                childTreeView(strdeptName, myNode, myRow);
            }
        }
        #endregion

        #region 单击事件
        /// <summary>
        /// 单击事件
        /// </summary>
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                DataSet ds = oper.GetZcfl(e.Node.Text);
                zclbID = Convert.ToInt16(ds.Tables[0].Rows[0]["ID"].ToString());
            }
            catch
            { }
        }
        #endregion

        #region 双击编辑
        /// <summary>
        /// 鼠标双击事件，允许对双击到的结点修改标签
        /// </summary>
        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo hitInfo = treeView1.HitTest(new Point(e.X, e.Y));
            treeView1.SelectedNode = hitInfo.Node;
            TreeNode node = treeView1.SelectedNode;
            if (node != null)
            {
                treeView1.LabelEdit = true;
                //nodeCurrentSelect = node;
                //strOldLable = node.Text;
                //node.BeginEdit();
                treeView1.SelectedNode.BeginEdit();
            }
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataSet ds = oper.GetZcfl(treeView1.SelectedNode.Text);
            if (ds.Tables[0].Rows[0]["firstID"].ToString() != "-1" && ds.Tables[0].Rows[0]["firstID"].ToString() != "0")
            {
                treeView1.LabelEdit = true;  //开启标签编辑
                treeView1.SelectedNode.BeginEdit();
            }
        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        private void btnMain_Click(object sender, EventArgs e)
        {
            DataSet ds = oper.GetZcfl(treeView1.SelectedNode.Text);
            if (ds.Tables[0].Rows[0]["firstID"].ToString() != "-1" && ds.Tables[0].Rows[0]["firstID"].ToString() != "0")
            {
                string firstID = ds.Tables[0].Rows[0]["firstID"].ToString();
                int d = oper.InsertZcfl(firstID, "新的分类", (Convert.ToInt16(firstID) + 1).ToString());
                this.treeView1.SelectedNode.Parent.Nodes.Add("新的分类");
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataSet ds = oper.GetZcfl(treeView1.SelectedNode.Text);
            if (ds.Tables[0].Rows[0]["firstID"].ToString() != "-1" && ds.Tables[0].Rows[0]["firstID"].ToString() != "0")
            {
                DialogResult dialog = MessageBox.Show("删除所选节点？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                oper.DeleteZcfl(Convert.ToInt16(ds.Tables[0].Rows[0]["id"].ToString()));
                this.FillTreeView();
                }
                else
                {
                    return;
                }
            }
        }
        #endregion

        #region 保存-隐藏
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            oper.UpdateZcfl(zclbID, treeView1.SelectedNode.Text);
            this.FillTreeView();
            treeView1.LabelEdit = false;　　//关闭标签编辑
        }
        #endregion

        #region 关闭
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            //保存
            oper.UpdateZcfl(zclbID, treeView1.SelectedNode.Text);
            this.FillTreeView();
            treeView1.LabelEdit = false;　　//关闭标签编辑

            //委托
            tv();
            this.Close();
        }
         /// <summary>
        /// 右上角关闭
        /// </summary>
        protected override void WndProc(ref Message msg)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
            {
                //保存
                oper.UpdateZcfl(zclbID, treeView1.SelectedNode.Text);
                this.FillTreeView();
                treeView1.LabelEdit = false;　　//关闭标签编辑

                tv();  //加入想要处理的逻辑
                this.Close();
                return;  //阻止了窗体关闭
            }
            base.WndProc(ref msg);
        }
        #endregion

    }
}
