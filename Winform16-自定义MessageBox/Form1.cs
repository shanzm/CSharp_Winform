using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform16_自定义MessageBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MyMsgBox.Show("       \n\t       批号与颜色不统一，\n\t       是否仍要保存？", "提示", MyMsgBox.MyButtons.YesNo, MyMsgBox.MyIcon.Stop );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("test");
            }

            if (result == DialogResult.No)
            {
                //MyMsgBox.Show("你好。。?", "提示", MyMsgBox.MyButtons.AbortRetryIgnore, MyMsgBox.MyIcon.Stop);
                return;
            }
        }
    }
}
