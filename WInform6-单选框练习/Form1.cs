using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WInform6_单选框练习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();
            if (rbtnStudent.Checked || rbtnTeacher.Checked)
            {


                if (rbtnStudent.Checked)
                {

                    if (UserName == "s" && Password == "s")
                    {
                        MessageBox.Show("学生登陆成功！");
                    }
                    else
                    {
                        MessageBox.Show("密码或用户名有误，请重新登陆");
                        txtUserName.Clear();
                        txtPassword.Clear();
                        txtUserName.Focus();
                    }
                }
                else
                {
                    if (UserName == "t" && Password == "t")
                    {
                        MessageBox.Show("老师登陆成功！");
                    }
                    else
                    {
                        MessageBox.Show("密码或用户名有误，请重新登陆");
                        txtUserName.Clear();
                        txtPassword.Clear();
                        txtUserName.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择学生或老师");
            }
        }
    }
}
