using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winform7_MDI窗体
{
    /// <summary>
    /// MDI是Multiple Document Interface的缩写,即多文档界面
    /// 注意interface还是接口的关键字
    /// interface这个单词有界面和接口的含义
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 显示窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.MdiParent = this;
            frm2.Show();

            Form3 frm3 = new Form3();
            frm3.MdiParent = this;
            frm3.Show();

            Form4 frm4 = new Form4();
            frm4.MdiParent = this;
            frm4.Show();

        }

        private void 横向排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 纵向排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
