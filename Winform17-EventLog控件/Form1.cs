using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Winform17_EventLog控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ///注意EventLog是在 System.Diagnostics命名空间下的
        ///

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.List;

            //注意我们需要使用管理员身份运行程序（vs需要使用管理员身份运行）
            //否则报错：未找到源，但未能搜索某些或全部事件日志。  不可访问的日志: Security。

            //查看事件日志：
            //控件面板-->所有控制面板想-->管理工具-->事件查看器-->应用程序和服务日志-->找到我们自定义的日志：newevnetlog

            if (EventLog.SourceExists("logsource"))
            {
                EventLog.DeleteEventSource("logsource");
            }
            EventLog.CreateEventSource("logsource", "neweventlog");//第一个参数：应用程序在本地注册时使用的源名称，第二个参数：日志名称
            eventLog1.Log = "neweventlog";
            eventLog1.Source = "logsource";
            eventLog1.MachineName = ".";//表示为本地机上

        }
        //写入日志按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            if (EventLog.Exists("neweventlog"))
            {
                if (textBox1.Text != "")
                {
                    eventLog1.WriteEntry(textBox1.Text);
                    MessageBox.Show("写入日志成功", "提示");
                    textBox1.Text = "";
                    this.button2_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("日志内容不能为空", "提示");
                }
            }
            else
            {
                MessageBox.Show("日志不存在", "提示");
            }
        }

        //读取日志按钮点击事件
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (eventLog1.Entries.Count > 0)
            {
                foreach (EventLogEntry item in eventLog1.Entries)
                {
                    listView1.Items.Add(item.Message);
                }
            }
            else
            {
                MessageBox.Show("日志中没有记录", "提示");
            }
        }
    }
}
