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
    public partial class FrmRoleInfo : Form
    {
        public FrmRoleInfo()
        {
            InitializeComponent();
        }
        FInfoModel fModel = null;
        private RoleDAL roleDAL = new RoleDAL();
        private string oldName = "";
        /// <summary>
        /// 页面加载  新增、修改共用页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRoleInfo_Load(object sender, EventArgs e)
        {
            if(this.Tag!=null)
            {
                fModel = this.Tag as FInfoModel;
                if(fModel!=null)
                {
                    if (fModel.FId == 0)//新增
                    {
                        txtRName.Clear();
                        txtRemark.Clear();
                        this.Text += "--新增";
                    }
                    else if (fModel.FId > 0)//修改
                    {
                        RoleInfoModel roleInfo = roleDAL.GetRole(fModel.FId);
                        if (roleInfo != null)
                        {
                            oldName = roleInfo.RoleName;
                            txtRName.Text = roleInfo.RoleName;
                            txtRemark.Text = roleInfo.Remark;

                        }
                        this.Text += "--修改";
                    }
                }
            }
        }

        /// <summary>
        /// 新增或修改提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //接收页面输入
            string roleName = txtRName.Text.Trim();
            string remark = txtRemark.Text.Trim();
            //判断角色名称是否为空
            if(string.IsNullOrEmpty(roleName))
            {
                MsgBoxHelper.MsgErrorShow("角色名称不能为空！");
                txtRName.Focus();
                return;
            }
            //判断存在性
            if(fModel.FId ==0||oldName!="" && oldName !=roleName)
            {
                if(roleDAL.ExistRole(roleName))
                {
                    MsgBoxHelper.MsgErrorShow("角色名称已存在！");
                    txtRName.Focus();
                    return;
                }
            }
            //信息封装
            RoleInfoModel roleInfo = new RoleInfoModel()
            {
                RoleName = roleName,
                Remark = remark
            };
            //信息提交  到底新增还是修改？fModel.FId的值来决定
            bool bl = false;
            string actMsg=fModel.FId==0?"新增":"修改";
            if(fModel.FId==0)
            {
                bl = roleDAL.AddRole(roleInfo);
            }
            else if(fModel.FId>0)//修改
            {
                roleInfo.RoleId = fModel.FId;
                bl = roleDAL.UpdateRole(roleInfo);
            }
            if(bl)
            {
                MsgBoxHelper.MsgBoxShow($"{actMsg}角色", $"角色：{roleName} 信息{actMsg}成功！");
                fModel.ReLoadList?.Invoke();
            }
            else
            {
                MsgBoxHelper.MsgErrorShow($"角色：{roleName} 信息{actMsg}失败！");
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
