using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev8_Ribbon
{
    public partial class ChildForm : Form
    {
        //关于tabControl切换的时候出现窗口闪屏
        //https://www.cnblogs.com/xing2700/p/6668794.html
        //添加了如下的设置，但是无效

        ///<summary>
        /// 构造函数,设置控件风格
        ///</summary>
        public ChildForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        ///<summary>
        /// 设置控件窗口创建参数的扩展风格
        ///</summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}
