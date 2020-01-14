using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Winform14_完整记事本
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.WordWrap = false;
            panel1.Visible = false;
        }


        List<string> listPath = new List<string>();


        /// <summary>
        /// 打开文件对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "选择文件";//弹出框名称
            fd.Multiselect = false;//不可以多选
            fd.Filter = "文本文档|*.txt|所有文件|*.*";//filter单词意思是过滤器，选择文档类型
            fd.InitialDirectory = @"C:\Users\shanzm\Desktop";//打开的默认路径

            fd.ShowDialog();

            string path = fd.FileName;

            ////////////////////////////////////////////////////此处将文件的全路径，存储进一个在方法外的泛型集合中，便于其他方法的使用
            listPath.Add(path);

            ////////////////////////////////////////////////////此处就是完成“打开记录”的功能
            string fileName = Path.GetFileName(path);
            listBox1.Items.Add(fileName);


            if (path == "")
            {
                return;
            }
            using (FileStream fsRead = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] butter = new byte[1024 * 1024 * 5];
                int r = fsRead.Read(butter, 0, butter.Length);

                textBox1.Text = Encoding.Default.GetString(butter, 0, r);
            }


        }

        /// <summary>
        /// 保存对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存地址";
            sfd.Filter = "文本文档|*.txt|所有文件|*.*";
            sfd.InitialDirectory = @"C:\Users\shanzm\Desktop";

            sfd.ShowDialog();

            string path = sfd.FileName;
            if (path == "")
            {
                return;
            }
            using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] butter = Encoding.Default.GetBytes(textBox1.Text);
                fsWrite.Write(butter, 0, butter.Length);

            }
        }

        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (自动换行ToolStripMenuItem.Text == "自动换行")
            {
                textBox1.WordWrap = true;
                自动换行ToolStripMenuItem.Text = "取消自动换行";
            }
            else
            {
                textBox1.WordWrap = false;
                自动换行ToolStripMenuItem.Text = "自动换行";
            }
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog();

            textBox1.Font = fd.Font;
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();

            textBox1.ForeColor = cd.Color;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void 隐藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
        /// <summary>
        /// 实现双击列表栏中打开记录中的文件名，后自动打开
        /// 我们需要列表中文件的路径，所以我们把一开始“打开ToolStripMenuItem_Click”  方法中打开文件的全路径path，在外面存储在一个泛型list中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string path = listPath[listBox1.SelectedIndex];

            //string[] contain = File.ReadAllLines(path);
            //foreach (string item in contain)
            //{
            //    listBox1.Text += item;
            //}
            using (FileStream fsRead = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] butter = new byte[1024 * 1024 * 5];
                int r = fsRead.Read(butter, 0, butter.Length);

                textBox1.Text = Encoding.Default.GetString(butter, 0, r);
            }
            ///???????????????????????????????????????????????????????????????
            ///错在哪？，错在listBox1.Text，应该是 textBox1.Text 
            //using (FileStream fsRead=new FileStream (path ,FileMode.OpenOrCreate ,FileAccess .Read   ))
            //{
            //    byte[] butter = new byte[1024 * 1024 * 5];
            //    int r = fsRead.Read(butter,0,butter.Length );

            //    listBox1.Text = Encoding.Default.GetString(butter, 0, r);

            //}

        }




    }
}
