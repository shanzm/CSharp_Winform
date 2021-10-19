using PM.Common;
using PM.DAL;
using PM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.WinPM
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        UserDAL userDAL = new UserDAL();
        MenuDAL menuDAL = new MenuDAL();
        int userId = 0;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //获取传递过来的UserId
            if (this.Tag != null)
            {
                userId = this.Tag.GetInt();
            }
            if (userId > 0)
            {
                //获取用户的角色信息
                List<RoleInfoModel> roles = userDAL.GetUserRoles(userId);
                bool bl = false;
                List<MenuInfoModel> menuList = new List<MenuInfoModel>();
                foreach (RoleInfoModel role in roles)
                {
                    if (role.IsAdmin == 1)
                    {
                        bl = true;
                        //加载所菜单列表
                        menuList = menuDAL.GetUserMenuList("");
                        break;
                    }
                }
                if (!bl)
                {
                    string roleIds = string.Join(",", roles.Select(r => r.RoleId));
                    //权限菜单
                    menuList = menuDAL.GetUserMenuList(roleIds);
                }
                //加载菜单树
                TreeNode rootNode = new TreeNode();
                rootNode.Name = "0";
                rootNode.Text = "权限管理系统";
                tvMenus.Nodes.Add(rootNode);
                CreateNode(menuList, rootNode, 0);
                tvMenus.ExpandAll();
            }

        }

        //自己调用自己
        /// <summary>
        /// 递归添加菜单树节点
        /// </summary>
        /// <param name="menuList"></param>
        /// <param name="pNode"></param>
        /// <param name="parentId"></param>
        private void CreateNode(List<MenuInfoModel> menuList, TreeNode pNode, int parentId)
        {
            if (menuList.Count > 0)
            {
                //获取所有子菜单数据
                var childList = menuList.Where(m => m.ParentId == parentId);
                foreach (MenuInfoModel menu in childList)
                {
                    TreeNode tn = new TreeNode();
                    tn.Name = menu.MenuId.ToString();
                    tn.Text = menu.MenuName;
                    if (!string.IsNullOrEmpty(menu.FrmName))
                        tn.Tag = menu.FrmName;
                    if (pNode != null)
                        pNode.Nodes.Add(tn);//节点添加
                    else tvMenus.Nodes.Add(tn);
                    CreateNode(menuList, tn, menu.MenuId);
                }
            }
        }

        /// <summary>
        /// 菜单树节点响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvMenus_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selNode = tvMenus.SelectedNode;
            if (selNode.Tag != null)
            {
                string url = selNode.Tag.ToString();
                Form f = null;
                bool bl = false;
                //判断--当前我要实例化的窗体是否已打开
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name == url.Split('.')[1])
                    {
                        bl = true;
                        f = frm;
                        // f.Show();
                        if (!f.Visible)
                            f.Show();
                        else 
                            f.Activate();
                        break;
                    }
                }
                if(!bl)
                {
                    //获取程序集的名称
                    string assName = this.GetType().Assembly.GetName().Name;
                    //ObjectHandle obj = Activator.CreateInstance(assName, assName + "." + url);
                    object obj1 = Activator.CreateInstance(Type.GetType(assName + "." + url));
                    f = (Form)obj1;
                    f.MdiParent = this;
                    f.Show();
                }
               
            }
        }


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //特别不友好---加个判断，让用户确认，到底要不要退出？ 是--退出；否则--不退出 
            if (MsgBoxHelper.MsgBoxConfirm("退出系统", "您确定要退出系统吗”") == DialogResult.Yes)
            {
                Application.ExitThread();//有问题？ 弹两次？--解决
            }
            else
                e.Cancel = true;//如果没有这一句，主页面仍然关闭了，但没有退出应用程序
        }
    }
}
