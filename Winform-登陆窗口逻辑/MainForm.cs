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
    public partial class MainForm : Form
    {
        public bool isLogin { get; set; }
        public string userName { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        //主窗口初始化时候弹出登陆窗口
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm() { mainForm = this };
            loginForm.ShowDialog();
            if (isLogin)
            {
                labUserName.Text += userName;
            }
            else
            {
                this.Close();
            }
        }

        //退出
        private void btnLogOut_Click(object sender, EventArgs e)
        {

            //1.this.Close(); 只是关闭当前窗口，若不是主窗体的话，是无法退出程序的，另外若有托管线程（非主线程），也无法干净地退出；

            //2.Application.Exit(); 强制所有消息中止，退出所有的窗体，但是若有托管线程（非主线程），也无法干净地退出；

            //3.Application.ExitThread(); 强制中止调用线程上的所有消息，同样面临其它线程无法正确退出的问题；

            //4.System.Environment.Exit(0); 这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净。

            //5.Application.Restar(); 注销 开启新实例

            System.Environment.Exit(0);
        }
    }
}
