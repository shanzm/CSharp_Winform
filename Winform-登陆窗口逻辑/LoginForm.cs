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
    public partial class LoginForm : Form
    {
        //给子窗体添加一个属性，用于获取主窗体
        public MainForm mainForm { get; set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "admin")
            {
                mainForm.isLogin = true;
                mainForm.userName = txtName.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("登陆失败");
            }
        }
    }
}
