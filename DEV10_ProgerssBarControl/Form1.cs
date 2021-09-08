using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEV10_ProgerssBarControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //设置最小值
            this.progressBarControl1.Properties.Minimum = 0;
            //设置最大值
            this.progressBarControl1.Properties.Maximum = 1000;
            //设置步长，即每次增加的长度
            this.progressBarControl1.Properties.Step = 1;
            //设置进度条的样式
            this.progressBarControl1.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;

            //this.progressBarControl1.Properties.LookAndFeel.Style

            //设置初始进度值
            progressBarControl1.EditValue = 100;
            for (int i = 0; i < progressBarControl1.Properties.Maximum; i++)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
                progressBarControl1.PerformStep();
            }

        }
    }
}
