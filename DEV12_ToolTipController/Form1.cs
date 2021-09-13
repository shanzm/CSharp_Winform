using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEV12_ToolTipController
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 1.首先拖入一个ToolTipController
        /// 2.修改textEdit1的toolTipController属性为刚刚拖入的toolTipController1
        /// 3.实现toolTipController1的GetActiveObjectInfo方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            MessageBox.Show("test");
        }
    }
}
