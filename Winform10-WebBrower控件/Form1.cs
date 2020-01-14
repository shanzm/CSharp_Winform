using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winform8_WebBrower控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string address = textBox1.Text;
            ///uri是统一资源标识符，可以唯一的确定一个资源
            ///url是统一资源定位符，不仅可以确定一个资源，还可以找到该资源的路径
            ///也就是说，uri应该是包含url
            Uri url = new Uri("http://" + address);
            webBrowser1.Url = url;
 
        }
    }
}
