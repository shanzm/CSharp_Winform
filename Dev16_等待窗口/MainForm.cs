using DevExpress.Utils;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Dev6_等待窗口
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        //原生DEV等待窗口
        private void BtnShowWait_Click(object sender, EventArgs e)
        {
            //WaitDialogForm sdf = new WaitDialogForm("提示", "正在登录......");
            WaitDialogForm sdf = new WaitDialogForm(caption: "加载数据中", title: "正在初始化数据，请耐心等待......", size: new Size(250, 100));
            int i = 10;
            for (int j = 1; j < i; j++)
            {
                Thread.Sleep(1000);
                sdf.SetCaption("执行进度（" + j.ToString() + "/" + i.ToString() + "）");
            }
            sdf.Close();
        }


        //自定义带进度条的等待窗口
        private void BtnShowMyWait_Click(object sender, EventArgs e)
        {
            int i = 1999;
            ShowDialogForm sdf = new ShowDialogForm("提示", "正在登录......", "请耐心等候，正在验证您的身份！", i);
            for (int j = 1; j < i; j++)
            {
                sdf.SetCaption("执行进度（" + j.ToString() + "/" + i.ToString() + "）");
            }
            sdf.Close();
        }
    }
}
