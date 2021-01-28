using System;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// 使用WebBrower控件加载一个网页，
/// 网页中使用百度地图api,显示一个地图
/// </summary>

namespace Winform_WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //这个文件于可执行文件放在同一目录
                // webBrowser1.Url = new Uri(Path.Combine(Application.StartupPath, "百度地图.html"));

                //string fullPath = AppDomain.CurrentDomain.BaseDirectory;//Debug目录
                //string fullPath = Directory.GetCurrentDirectory();//Debug目录
                string fullPath = Application.StartupPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(fullPath);
                string htmlPath = directoryInfo.Parent.Parent.FullName;//获取当前根目录的上上级目录
                webBrowser1.Url = new Uri(Path.Combine(htmlPath, "百度地图.html"));
                //Exception ex = new Exception(message: "测试异常捕获");
                //throw ex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "出现异常,请联系管理员", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //这里传入x、y的值，调用JavaScript脚本
            webBrowser1.Document.InvokeScript("setLocation", new object[] { 121.504, 39.212 });
        }
    }
}
