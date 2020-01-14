using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Winform12_ListBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //获取一个文件夹中所有文件的全路径
        string[] path = Directory.GetFiles("水浒英雄","*.jpg");
        private void Form1_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < path.Length; i++)
            {
                //从全路径中截取文件的名称
                string fileName = Path.GetFileName(path[i]);
                listBox1.Items.Add(fileName);
            }
           
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //注意Image.FromFile(路径）使用
            //注意listBox1.SelectedIndex的使用
            pictureBox1.Image = Image.FromFile(path[listBox1.SelectedIndex]);
        }
    }
}
