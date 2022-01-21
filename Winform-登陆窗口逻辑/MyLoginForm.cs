using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_登陆窗口逻辑
{
    public partial class MyLoginForm : Form
    {

        #region 说明
        /// <summary>
        /// 1. 窗口设置
        /// 不显示标题栏：ControlBox:false
        /// 居中弹出：StartPosition：CenterScreen
        /// 
        /// 2.左右两个Panel
        /// 左Panel背景色：BackColor:41, 128, 185
        /// 右Panel背景色：默认
        /// 
        /// 3. 关闭按钮：btnColose
        /// 设置背景色为：BackColor：control
        /// FlatStyle:Flat
        /// FlatAppearance:BorderSize:0
        /// Text:X
        /// ForeColor:41, 128, 185
        /// UserVisualStyleBackColor:true
        /// 
        /// 4. 用用户名和密码框，将textBox设置无边框
        ///    两条横线为GroupBox设置高度为1，backCOlor:41, 128, 185
        ///    
        /// 5. forget your password为按钮，设置按钮无边框
        /// </summary>
        #endregion
        public MyLoginForm()
        {
            InitializeComponent();
            txtUserName.Focus();
        }


        /// <summary>
        /// 关闭窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            txtPwd.BackColor = SystemColors.Control;
            panelForPwd.BackColor = SystemColors.Control;

            txtUserName.BackColor = Color.White;
            panelForUserName.BackColor = Color.White;
        }

        private void txtPwd_Click(object sender, EventArgs e)
        {
            txtPwd.BackColor = Color.White;
            panelForPwd.BackColor = Color.White;

            txtUserName.BackColor = SystemColors.Control;
            panelForUserName.BackColor = SystemColors.Control;
        }


        //鼠标按下明文显示密码
        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            txtPwd.UseSystemPasswordChar = false;
        }
        //鼠标点击后
        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            txtPwd.UseSystemPasswordChar = true;
        }
    }
}
