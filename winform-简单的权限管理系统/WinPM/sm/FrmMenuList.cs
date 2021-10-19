using PM.Common;
using PM.DAL;
using PM.Models;
using PM.WinPM.FModels;
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
    public partial class FrmMenuList : Form
    {
        public FrmMenuList()
        {
            InitializeComponent();
        }
        private MenuDAL menuDAL = new MenuDAL();
        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowMenuInfoPage(0);
        }

        /// <summary>
        /// 打开菜单新增或修改页面
        /// </summary>
        /// <param name="menuId"></param>
        private void ShowMenuInfoPage(int menuId)
        {
            FrmAddMenuInfo fMenuInfo = new FrmAddMenuInfo();
            fMenuInfo.MdiParent = this.MdiParent;
            fMenuInfo.Tag = new FInfoModel()
            {
                FId = menuId,
                ReLoadList = LoadMenuList
            };
            fMenuInfo.Show();
        }


        /// <summary>
        /// 页面加载 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMenuList_Load(object sender, EventArgs e)
        {
            LoadCboParents();
            LoadMenuList();
        }

        /// <summary>
        /// 加载菜单信息列表
        /// </summary>
        private void LoadMenuList()
        {
            int selMenuId = cboParents.SelectedValue.GetInt();
            string mName = txtMName.Text.Trim();
            //查询的菜单列表
            List<MenuInfoAllModel> menuList = menuDAL.GetMenuList(selMenuId, mName);
            dgvMenus.AutoGenerateColumns = false;//不自动创建列
            dgvMenus.DataSource = menuList;//指定数据源
        }

        /// <summary>
        /// 父级菜单下拉框绑定
        /// </summary>
        private void LoadCboParents()
        {
            DataTable dtParent = menuDAL.GetParentList();
            //数据库里应该存的是有意义的数据
            DataRow dr = dtParent.NewRow();
            dr["ParentId"] = 0;
            dr["MenuName"] = "请选择";
            //dtParent.Rows.Add(dr);//表的末尾添加
            dtParent.Rows.InsertAt(dr, 0);//插入到第一行
            cboParents.DataSource = dtParent;
            cboParents.DisplayMember = "MenuName";
            cboParents.ValueMember = "ParentId";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadMenuList();
        }

        /// <summary>
        /// 行操作---单击单元格内的内容时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMenus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var curCell = dgvMenus.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewLinkCell;
            string cellValue = curCell.FormattedValue.ToString().Trim();
            MenuInfoAllModel menuInfo = dgvMenus.Rows[e.RowIndex].DataBoundItem as MenuInfoAllModel;
            switch (cellValue)
            {
                case "修改":
                    ShowMenuInfoPage(menuInfo.MenuId);
                    break;
                case "删除":
                    //提示
                    if(MsgBoxHelper.MsgBoxConfirm("删除菜单","您确定要删除该条菜单数据吗?删除菜单数据会连同角色菜单关系数据一并删除？")==DialogResult.Yes)
                    {
                        //调用删除操作方法
                      bool blDel =  menuDAL.DeleteMenu(menuInfo.MenuId);
                        if(blDel)
                        {
                            MsgBoxHelper.MsgBoxShow("成功提示", $"菜单：{menuInfo.MenuName} 信息删除成功！");
                            LoadMenuList();
                        }
                        else
                        {
                            MsgBoxHelper.MsgErrorShow($"菜单：{menuInfo.MenuName} 信息删除失败！");
                            return;
                        }
                    }
                    break;
            }
        }
    }
}
