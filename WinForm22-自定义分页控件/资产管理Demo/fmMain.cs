using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace zcgl
{
    public partial class fmMain : Form
    {
        zcgl.myclass.operation oper = new zcgl.myclass.operation();  //加载操作类
        public delegate void DelegateRefreshDGV();  //委托
        public fmMain()
        {
            InitializeComponent();
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;  //设置控件属性
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  //设置控件属性选中整行
        }

        #region Load
        /// <summary>
        /// Load
        /// </summary>
        private void fmMain_Load(object sender, EventArgs e)
        {
            SetTreeView();  //加载treeView1数据
            dataGridView1.DataSource = oper.GetZc100().Tables[0].DefaultView;  //加载dataGridView1数据
            toolStripComboBox1.Text = "资产名称";
        }
        #endregion

        #region 刷新
        /// <summary>
        /// 刷新
        /// </summary>
        private void shuaxintv()
        {
            treeView1.Nodes.Clear();
            SetTreeView();
        }

        private void shuaxindgv()
        {
            dataGridView1.DataSource = oper.GetZc100().Tables[0].DefaultView;
            dataGridView1.ClearSelection();
        }
        #endregion

        #region dataGridView1显示行号
        /// <summary>
        /// dataGridView1显示行号
        /// </summary>
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dataGridView1.RowHeadersWidth - 4,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridView1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        #endregion

        #region 加载treeview
        /// <summary>
        /// 加载treeview
        /// </summary>
        private void SetTreeView()
        {
            treeView1.Nodes.Clear();
            //设置TreeView控件的菜单项
            DataSet ds = null;
            ds = oper.TreeFill();
            TreeNode RootNode = null;
            TreeNode chileNode = null;
            DataTable dt = ds.Tables[0].Copy();     //将资产列表另存一份为dt
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
                    treeView1.SelectedNode = treeView1.Nodes[0]; //选中第一个节点 
                }
            }
            //填充-使用部门
            chileNode = RootNode.Nodes.Add("使用部门", "使用部门", 1);
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                chileNode.Nodes.Add("", ds.Tables[1].Rows[i]["sybm"].ToString(), 2);
            }
            //填充-保管人员
            chileNode = RootNode.Nodes.Add("保管人员", "保管人员", 1);
            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            {
                chileNode.Nodes.Add("", ds.Tables[2].Rows[i]["bgry"].ToString(), 2);
            }
            //填充-使用情况
            chileNode = RootNode.Nodes.Add("使用情况", "使用情况", 1);
            for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
            {
                chileNode.Nodes.Add("", ds.Tables[3].Rows[i]["syqk"].ToString(), 2);
            }
            //展开节点
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
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DataSet ds = null;
            if (e.Node.Text == "全部资产")
            {
                ds = oper.GetZc100();
            }
            else
            {
                switch (e.Node.Parent.Text)
                {
                    case "资产分类":
                        ds = oper.GetZcfl(e.Node.Text);
                        break;
                    case "使用部门":
                        ds = oper.GetZcfl_sybm100(e.Node.Text);
                        break;
                    case "保管人员":
                        ds = oper.GetZcfl_bgry100(e.Node.Text);
                        break;
                    case "使用情况":
                        ds = oper.GetZcfl_syqk100(e.Node.Text);
                        break;
                    default:
                        return;
                }
            }
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        #endregion

        #region 菜单栏-帐号管理、资产编号
        /// <summary>
        /// 帐号管理
        /// </summary>
        private void 帐号管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new zcgl.xtwh.fmUser().ShowDialog();
        }
        /// <summary>
        /// 资产编号
        /// </summary>
        private void 资产编号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new zcgl.xtwh.fmDefault().ShowDialog();
        }
        #endregion

        #region 工具栏-资产分类、基本资料
        /// <summary>
        /// 资产分类
        /// </summary>
        private void btnzcfl_Click(object sender, EventArgs e)
        {
            //委托，刷新主页treeview
            DelegateRefreshDGV tv = new DelegateRefreshDGV (shuaxintv);
            zcgl.xtwh.fmZcfl f1 = new zcgl.xtwh.fmZcfl(tv);
            f1.Show();
        }
        /// <summary>
        /// 基本资料
        /// </summary>
        private void btnjbzl_Click(object sender, EventArgs e)
        {
            //委托，刷新主页treeview
            DelegateRefreshDGV tv = new DelegateRefreshDGV(shuaxintv);
            zcgl.xtwh.fmBasic f2 = new zcgl.xtwh.fmBasic(tv);
            f2.Show();
        }
        #endregion

        #region 工具栏-注销、退出
        /// <summary>
        /// 注销
        /// </summary>
        private void btnzx_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Application.Restart();
        }

        /// <summary>
        /// 退出
        /// </summary>
        private void btntc_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region 工具栏-新增、变更、清理
        /// <summary>
        /// 资产新增
        /// </summary>
        private void btnzcxz_Click(object sender, EventArgs e)
        {
            //new zcgl.zcwh.fmInsert().ShowDialog();
            DelegateRefreshDGV dgv = new DelegateRefreshDGV(shuaxindgv);
            zcgl.zcwh.fmInsert f3 = new zcgl.zcwh.fmInsert(dgv);
            f3.Show();
        }

        /// <summary>
        /// 资产变更
        /// </summary>
        private void btnzcbg_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows.Count < 2)
            {
                //委托，刷新主页dataGridView1
                DelegateRefreshDGV dgv = new DelegateRefreshDGV(shuaxindgv);
                zcgl.zcwh.fmUpdate f4 = new zcgl.zcwh.fmUpdate(dgv);
                f4.M_fmMain = this;
                f4.M_ZCBH = dataGridView1.SelectedCells[1].Value.ToString();
                f4.Show();
            }
            else
            {
                MessageBox.Show("请选择一条数据！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 资产清理
        /// </summary>
        private void btnzcql_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows.Count < 2)
            {
                //委托，刷新主页dataGridView1
                DelegateRefreshDGV dgv = new DelegateRefreshDGV(shuaxindgv);
                zcgl.zcwh.fmDelete f5 = new zcgl.zcwh.fmDelete(dgv);
                f5.M_fmMain = this;
                f5.M_ZCBH = dataGridView1.SelectedCells[1].Value.ToString();
                f5.Show();
            }
            else
            {
                MessageBox.Show("请选择一条数据！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 工具栏-查询、刷新、所有资产
        /// <summary>
        /// 查询
        /// </summary>
        private void btncx_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text == "")
                return;
            string findTitle = "";
            if (toolStripComboBox1.Text == "资产名称")
                findTitle = "zcmc";
            if (toolStripComboBox1.Text == "资产编号")
                findTitle = "zcbh";
            if (toolStripComboBox1.Text == "使用部门")
                findTitle = "sybm";
            if (toolStripComboBox1.Text == "保管人员")
                findTitle = "bgry";
            if (toolStripComboBox1.Text == "使用情况")
                findTitle = "syqk";
            dataGridView1.DataSource = oper.GetZc100(findTitle, txtcxtj.Text).Tables[0].DefaultView;
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnsx_Click(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "资产名称";
            txtcxtj.Text = "";
            dataGridView1.DataSource = oper.GetZc100().Tables[0].DefaultView;  //加载dataGridView1数据
        }

        /// <summary>
        /// 所有资产
        /// </summary>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            zcgl.zcwh.fmAll f6 = new zcgl.zcwh.fmAll();
            f6.Show();
        }
        #endregion

    }
}
