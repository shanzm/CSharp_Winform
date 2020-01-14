using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winform_15_单例模式
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 =  Form2.GetForm ();//Form2类中的构造函数被我们改为私有的了，我们无法使用构造函数创建对象
            //我们使用我们自己编写的函数GetForm来创建一个Form2窗口
            frm2.Show();
        }
    }
}
