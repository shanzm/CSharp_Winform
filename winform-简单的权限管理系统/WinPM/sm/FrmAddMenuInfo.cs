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

    public partial class FrmAddMenuInfo : Form
    {
        public FrmAddMenuInfo()
        {
            InitializeComponent();
        }
        private MenuDAL menuDAL = new MenuDAL();
        FInfoModel fModel = null;
        int menuId = 0;
        string oldName = "";//修改前的菜单名称
        private void FrmAddMenuInfo_Load(object sender, EventArgs e)
        {
            LoadCboParents();//加载父级菜单下拉框
            LoadCboFrmNames();//加载关联页面下拉框
            if (this.Tag != null)
            {
                fModel = this.Tag as FInfoModel;
                if (fModel != null)
                {
                    menuId = fModel.FId;
                }
            }
            if (menuId > 0)//修改页面的加载
            {
                //加载菜单信息
                MenuInfoModel menuInfo = menuDAL.GetMenuInfo(menuId);
                if (menuInfo != null)
                {
                    txtMName.Text = menuInfo.MenuName;
                    oldName = menuInfo.MenuName;
                    txtShortKey.Text = menuInfo.MKey;
                    cboParents.SelectedValue = menuInfo.ParentId;
                    if (!string.IsNullOrEmpty(menuInfo.FrmName))
                        cboForms.SelectedValue = menuInfo.FrmName;
                }
            }
            else
            {
                txtMName.Clear();
                txtShortKey.Clear();
            }
        }

        /// <summary>
        /// 关联页面下拉框加载
        /// </summary>
        private void LoadCboFrmNames()
        {
            string assName = this.GetType().Assembly.GetName().Name;
            Type[] types = this.GetType().Assembly.GetTypes();
            List<FormInfo> fList = new List<FormInfo>();
            foreach (Type t in types)
            {
                string tName = t.BaseType.Name;
                if (tName == "Form")
                {
                    FormInfo fi = new FormInfo();
                    Form f = (Form)Activator.CreateInstance(t);
                    fi.FName = t.FullName.Substring(assName.Length + 1);
                    fi.FText = f.Text;
                    fList.Add(fi);
                    f.Dispose();
                }
            }
            FormInfo fi0 = new FormInfo()
            {
                FName = "",
                FText = "请选择"
            };
            fList.Insert(0, fi0);

            cboForms.DataSource = fList;
            cboForms.DisplayMember = "FText";
            cboForms.ValueMember = "FName";
            cboForms.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定父级菜单下拉框
        /// </summary>
        private void LoadCboParents()
        {
            DataTable dtParents = menuDAL.GetAllMenus();
            DataRow dr = dtParents.NewRow();
            dr["MenuId"] = "0";
            dr["MenuName"] = "请选择";
            dtParents.Rows.InsertAt(dr, 0);
            cboParents.DataSource = dtParents;
            cboParents.DisplayMember = "MenuName";
            cboParents.ValueMember = "MenuId";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //1.接收页面信息输入
            string mName = txtMName.Text.Trim();
            int parentId = cboParents.SelectedValue.GetInt();
            string frmName = cboForms.SelectedValue.ToString();
            string mKey = txtShortKey.Text.Trim();

            //2.菜单名称是否为空
            if(string.IsNullOrEmpty(mName))
            {
                MsgBoxHelper.MsgErrorShow("菜单名称不能为空！");
                txtMName.Focus();
                return;
            }
            //3.不能重名（判断是否已存在）1）(menuId=0 || menuId>0&&mName!=oldName)
            if(menuId ==0||(menuId >0&& oldName!=mName))
            {
                //判断菜单名是否已存在 
                if(menuDAL.ExistMenuName(mName))
                {
                    MsgBoxHelper.MsgErrorShow("该菜单名称已存在！");
                    txtMName.Focus();
                    return;
                }

            }
            //4.封装信息
            MenuInfoModel menuInfo = new MenuInfoModel()
            {
                MenuName = mName,
                ParentId = parentId,
                FrmName = frmName,
                MKey = mKey
            };
            bool bl = false;
            //5 执行添加、修改
            string actMsg = menuId>0?"修改":"添加";
            if(menuId==0)
            {
                //执行添加操作
                bl = menuDAL.AddMenuInfo(menuInfo);
            }
            else
            {
                //修改操作
                menuInfo.MenuId = menuId;

                bl = menuDAL.UpdateMenuInfo(menuInfo);
            }
            if(bl)
            {
                MsgBoxHelper.MsgBoxShow($"{actMsg}菜单", $"菜单：{mName} 信息{actMsg}成功！");
                //刷新列表数据
                fModel.ReLoadList?.Invoke();
            }
            else
            {
                MsgBoxHelper.MsgErrorShow($"菜单：{mName} 信息{actMsg}失败！");
                return;
            }
        }
    }
}
