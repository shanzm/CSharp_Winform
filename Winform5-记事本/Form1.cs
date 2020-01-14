using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Winform5_记事本
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnWordWrap.Visible = false;
            btnSave.Visible = false;
            txtWords.Visible = false;
            //开始的时候默认是不自动换行
            txtWords.WordWrap = false;
        }

        /// <summary>
        /// 登录模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text  =="admin"&&txtPassword.Text  =="admin")
            {
                MessageBox.Show("登录成功！");

                btnLogin.Visible = false;
                btnReset.Visible = false;
                lblPassword.Visible = false;
                lblUserName.Visible = false;
                txtPassword.Visible = false;
                txtUserName.Visible = false;

                btnWordWrap.Visible = true ;
                btnSave.Visible = true;
                txtWords.Visible = true;

            }
            else
            {
                MessageBox.Show("密码或用户名错误，请重新登录");
                //清空密码textbox和用户名TextBox
                txtUserName.Clear();
                txtPassword.Clear();

                //光标在用户名TextBox
                txtUserName.Focus();
            }
        }

        /// <summary>
        /// 密码输入重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }
        
        /// <summary>
        /// 文本换行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWordWrap_Click(object sender, EventArgs e)
        {
            if (btnWordWrap .Text =="自动换行")
            {
                txtWords.WordWrap = true;
                btnWordWrap.Text = "取消自动换行";   
            }
            else
            {
                txtWords.WordWrap = false;
                btnWordWrap.Text = "自动换行";
            }
        }

        
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (FileStream fsWrite = new FileStream(@"C:\Users\shanzm\Desktop\新建文本.txt",FileMode.OpenOrCreate , FileAccess.Write ))
            {
                string text = txtWords.Text.Trim();
                byte[] butter =Encoding.Default.GetBytes(text);//System.Text.Encoding.DeFault.GetBytes(text);
                fsWrite.Write(butter, 0, butter.Length);
            }
            MessageBox.Show("保存成功！");
        }


    }
}
