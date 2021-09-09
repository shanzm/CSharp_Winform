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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        ///使用两个SplitContainerControl进行布局
        ///SplitContainerControl1在父容器停靠，分为左右两栏
        ///SplitContainerControl2在SplitContainerControl的右侧栏panel2中停靠，水平分为上下两栏
    }
}
