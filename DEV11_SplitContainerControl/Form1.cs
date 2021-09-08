using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEV11_SplitContainerControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ///SplitContainerControl将窗口界面分为两个区域
            ///默认是左右区域
            ///若是需要改为左右，则设置属性Horizontal：False


            ///设置伸缩箭头，指向panel1：CollapsePanel:Panel1
           
        }
    }
}
