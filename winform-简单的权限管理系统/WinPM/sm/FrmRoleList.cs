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
    public partial class FrmRoleList : Form
    {
        public FrmRoleList()
        {
            InitializeComponent();
        }
        RoleDAL roleDAL = new RoleDAL();
        /// <summary>
        /// 打开角色新增页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowRoleInfoPage(0);
        }

        /// <summary>
        /// 打开角色信息页面(新增\修改)
        /// </summary>
        /// <param name="roleId"></param>
        private void ShowRoleInfoPage(int roleId)
        {
            FrmRoleInfo fRole = new FrmRoleInfo();
            fRole.Tag = new FInfoModel()
            {
                FId = roleId,
                ReLoadList = LoadAllRoles
            };
            fRole.MdiParent = this.MdiParent;
            fRole.Show();
        }

        private void FrmRoleList_Load(object sender, EventArgs e)
        {
            LoadAllRoles();
        }

        /// <summary>
        /// 加载所有角色列表
        /// </summary>
        private void LoadAllRoles()
        {
            List<RoleInfoModel> list = roleDAL.GetAllRoles();
            dgvRoles.AutoGenerateColumns = false;
            dgvRoles.DataSource = list;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            ShowRightPage(0);
        }
        /// <summary>
        /// 打开权限设置页面
        /// </summary>
        /// <param name="roleId"></param>
        private void ShowRightPage(int roleId)
        {
            FrmRight fRight = null;
            if (!FUtility.CheckForm("FrmRight"))
            {
                fRight = new FrmRight();
            }
            else
            {
                fRight = (FrmRight)FUtility.GetOpenForm("FrmRight");
            }
            fRight.Tag = roleId;
            fRight.MdiParent = this.MdiParent;
            if (!fRight.Visible)
                fRight.Show();
            else
                fRight.Activate();
        }

        /// <summary>
        /// 行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                var curCell = dgvRoles.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string val = curCell.FormattedValue.ToString();
                RoleInfoModel roleInfo = dgvRoles.Rows[e.RowIndex].DataBoundItem as RoleInfoModel;
                switch(val)
                {
                    case "修改":
                        ShowRoleInfoPage(roleInfo.RoleId);
                        break;
                    case "权限分配":
                        ShowRightPage(roleInfo.RoleId);
                        break;
                    case "删除":
                        if(MsgBoxHelper.MsgBoxConfirm("角色删除","您确定要删除该角色信息吗？与连同相关的角色关系数据一并删除？")==DialogResult.Yes)
                        {
                            bool bl = roleDAL.DeleteRole(roleInfo.RoleId);
                            if(bl)
                            {
                                MsgBoxHelper.MsgBoxShow("角色删除", "该角色信息删除成功!");
                                LoadAllRoles();
                            }
                            else
                            {
                                MsgBoxHelper.MsgErrorShow("该角色信息删除失败!");
                                return;
                            }
                        }
                        break;
                }
            }
        }
    }
}
