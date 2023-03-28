using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoMessageBox
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //启动线程
            //这个方法是自动关闭消息框
            MessageBoxHelper.IsWorking = true;
            MessageBoxHelper.FindAndKillWindow();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //线程终止标识
            MessageBoxHelper.IsWorking = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "你在吗？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnYesNo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "不好吗？", "请选择", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnYesNoCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "出去吗？", "请选择", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
        }

        private void btnOkCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "可以吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void btnRetryCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "重试一次吗？", "错误", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }

        private void btnAbortRetryCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "重试一次吗？终止吗？", "请选择", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);
        }
    }
}
