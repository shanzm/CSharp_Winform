using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winform_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示窗体2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //在内存中创建窗体2对象
            Form2 form2 = new Form2();
            //显示窗体2
            form2.Show();
        }

        /// <summary>
        /// 加载窗口Form1时 ，把窗口1对象复制给"transmitForm1"类中的字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            transmitForm1._form1 = this;
        }

       
    }
}
