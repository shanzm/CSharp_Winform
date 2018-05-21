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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 关闭所有窗体，因为关闭主窗体就可以把所有窗体关闭，所以只要关闭主窗体Form1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();//关闭的仅仅是第三个窗口
            transmitForm1._form1.Close();
        }
    }
}
