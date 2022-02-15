using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform21_自动关闭的MessageBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //启动定时器
            timer1.Interval = 3000;
            timer1.Start();
            // 显示对话框
            //MessageBox.Show("3秒钟，这个对话框后自动关闭！",
            //    "自动关闭的对话框",
            //    MessageBoxButtons.YesNoCancel,
            //    MessageBoxIcon.Information); 
            MessageBox.Show("3秒钟，这个对话框后自动关闭！",
                "自动关闭的对话框",MessageBoxButtons.YesNo);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 停止定时器
            timer1.Stop();
            // 向对话框发送按键 Enter
            SendKeys.Send("ENTER");
        }
    }
}
