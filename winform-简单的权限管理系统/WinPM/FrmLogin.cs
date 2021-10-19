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

namespace PM.WinPM
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录过程 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //1.接收页面输入
            string userName = txtUName.Text.Trim();
            string userPwd = txtUPwd.Text.Trim();
            //2.判断账号 密码  是否为空
            if (string.IsNullOrEmpty(userName))
            {
                MsgBoxHelper.MsgErrorShow("账号不能为空!");
                txtUName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(userPwd))
            {
                MsgBoxHelper.MsgErrorShow("密码不能为空!");
                txtUPwd.Focus();
                return;
            }
            UserInfoModel userInfo = new UserInfoModel()
            {
                UserName = userName,
                UserPwd = userPwd
            };
            //3.到数据库里检查存在性   ---成功   否则---失败
            UserDAL userDAL = new UserDAL();
            int userId = userDAL.Login(userInfo);
            if (userId > 0)
            {
                MsgBoxHelper.MsgBoxShow("登录提示", "登录成功!");
                //显示到主页面
                FrmMain fMain = new FrmMain();
                fMain.Tag = userId;
                fMain.WindowState = FormWindowState.Maximized;
                fMain.Show();
                this.Hide();
            }
            else
            {
                MsgBoxHelper.MsgErrorShow("账号或密码输入有误!");
                return;
            }
        }
    }
}
