using PM.Common;
using PM.DAL;
using PM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.WinPM.sm
{
    public partial class FrmRight : Form
    {
        public FrmRight()
        {
            InitializeComponent();
        }
        int roleId = 0;
        RoleDAL roleDAL = new RoleDAL();
        MenuDAL menuDAL = new MenuDAL();
        bool blFlag = false;
        bool IsAdmin = false;
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRight_Load(object sender, EventArgs e)
        {
            if(this.Tag!=null)
            {
                roleId = this.Tag.ToString().GetInt();
            }
            //1）加载角色下拉框
            LoadCboRoles();
            blFlag = true;
            //2）加载菜单树
            LoadTvMenus();

            //3）加载角色已设置的菜单关系（菜单树中节点勾选）
            LoadRightSet();
            chkAll.Checked = false;
        }

        private void LoadRightSet()
        {
            if(roleId>0)
            {
                cboRoles.SelectedValue = roleId;
                cboRoles.Enabled = false;
            }
        }

        private void LoadTvMenus()
        {
            //获取菜单数据: 编号  名称  父级编号
            List<MenuInfoModel> menuList = menuDAL.GetUserMenuList("");
            tvMenus.Nodes.Clear();
            tvMenus.CheckBoxes = true;
            TreeNode rootNode = new TreeNode("系统菜单");
            rootNode.Name = "0";
            tvMenus.Nodes.Add(rootNode);
            CreateTreeNode(menuList, rootNode, 0);
            tvMenus.ExpandAll();

        }

        /// <summary>
        /// 创建节点
        /// </summary>
        /// <param name="menuList"></param>
        /// <param name="pNode"></param>
        /// <param name="parentId"></param>
        private void CreateTreeNode(List<MenuInfoModel> menuList,TreeNode pNode,int parentId)
        {
            var childList = menuList.Where(m => m.ParentId == parentId);
            foreach(MenuInfoModel menu in childList)
            {
                TreeNode tn = new TreeNode(menu.MenuName);
                tn.Name = menu.MenuId.ToString();
                if (pNode != null)
                    pNode.Nodes.Add(tn);
                CreateTreeNode(menuList, tn, menu.MenuId);
            }
        }

        private void LoadCboRoles()
        {
            DataTable dt = roleDAL.GetCboRoles();
            DataRow dr = dt.NewRow();
            dr["RoleId"] = 0;
            dr["RoleName"] = "请选择";
            dt.Rows.InsertAt(dr, 0);
            cboRoles.DataSource = dt;
            cboRoles.DisplayMember = "RoleName";
            cboRoles.ValueMember = "RoleId";
            cboRoles.SelectedIndex = 0;
        }

        /// <summary>
        /// 选择角色，加载相应的权限设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(blFlag)
            {
                CheckIsAdmin(cboRoles.SelectedValue.GetInt());
                if(IsAdmin)
                {
                    CheckNodes(tvMenus.Nodes[0].Nodes, true);
                    btnConfirm.Enabled = false;
                }
                else
                {
                    CheckNodes(tvMenus.Nodes[0].Nodes, false);
                    List<MenuInfoModel> menuList = menuDAL.GetUserMenuList(cboRoles.SelectedValue.ToString());

                    if (menuList.Count > 0)
                    {
                        List<int> MenuIds = menuList.Select(m => m.MenuId).ToList();

                        CheckTvNodes(tvMenus.Nodes[0].Nodes, MenuIds);
                    }
                    btnConfirm.Enabled = true;
                }
              
            }
        }

        /// <summary>
        /// 判断当前选择的角色是否是超级管理员
        /// </summary>
        /// <param name="roleId"></param>
        private void CheckIsAdmin(int roleId)
        {
            IsAdmin = false;
            RoleInfoModel roleInfo = roleDAL.GetRole(roleId);
            if (roleInfo != null)
                IsAdmin = roleInfo.IsAdmin == 1;
        }

        /// <summary>
        /// 将已设置的菜单节点选中
        /// </summary>
        /// <param name="tnc"></param>
        /// <param name="menuIds"></param>
        private void CheckTvNodes(TreeNodeCollection tnc,List<int> menuIds)
        {
            foreach(TreeNode tn in tnc)
            {
                if(menuIds.Contains(tn.Name.GetInt()))
                {
                    tn.Checked = true;
                }
                CheckTvNodes(tn.Nodes, menuIds);
            }
        }

        /// <summary>
        /// 全选或全不选
        /// </summary>
        /// <param name="tnc"></param>
        /// <param name="blCheck"></param>
        private void CheckNodes(TreeNodeCollection tnc,bool blCheck)
        {
            foreach (TreeNode tn in tnc)
            {
                tn.Checked = blCheck;
                CheckNodes(tn.Nodes, blCheck);
            }
        }

        /// <summary>
        /// 全选与全不选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckNodes(tvMenus.Nodes, chkAll.Checked);
        }

        /// <summary>
        /// 勾选状态更改后发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvMenus_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Action ==TreeViewAction.ByKeyboard|| e.Action == TreeViewAction.ByMouse)
            {
                //e.Node 当前操作的节点
                //更改当前节点下面子节点的勾选
                SetChildNodesCheckState(e.Node);
                SetParentNodesCheckState(e.Node);
            }
        }
        /// <summary>
        /// 父节点的勾选处理
        /// </summary>
        /// <param name="node"></param>
        private void SetParentNodesCheckState(TreeNode node)
        {
            TreeNode pNode = node.Parent;
            if(pNode!=null)
            {
                bool bl = false;
                foreach (TreeNode tn in pNode.Nodes)
                {
                    if (tn.Checked)
                    {
                        bl = true;
                        break;
                    }
                }
                pNode.Checked = bl;
                SetParentNodesCheckState(pNode);
            }
           
        }

        /// <summary>
        /// 当前节点子节点的勾选
        /// </summary>
        /// <param name="node"></param>
        private void SetChildNodesCheckState(TreeNode node)
        {
            foreach(TreeNode child in node.Nodes)
            {
                child.Checked = node.Checked;
                SetChildNodesCheckState(child);
            }
        }
        /// <summary>
        /// 提交权限设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int roleId = cboRoles.SelectedValue.GetInt();
            if(roleId>0)
            {
                List<int> menuIds = new List<int>();
                menuIds = GetCheckedMenuIds(tvMenus.Nodes[0].Nodes, menuIds);
                //保存权限设置
                bool bl = roleDAL.SaveRight(roleId, menuIds);
                if(bl)
                {
                    MsgBoxHelper.MsgBoxShow("权限设置", "权限菜单设置成功！");
                }
                else
                {
                    MsgBoxHelper.MsgErrorShow("权限菜单设置失败！");
                    return;
                }
            }
        }

        /// <summary>
        /// 获取已勾选的菜单编号集合
        /// </summary>
        /// <param name="tnc"></param>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        private List<int> GetCheckedMenuIds(TreeNodeCollection tnc,List<int> menuIds)
        {
            foreach(TreeNode tn in tnc)
            {
                if(tn.Checked)
                {
                    int mId = tn.Name.GetInt();
                    if (!menuIds.Contains(mId))
                        menuIds.Add(mId);
                }
                GetCheckedMenuIds(tn.Nodes, menuIds);
            }

            return menuIds;
        }
    }
}
