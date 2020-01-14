using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Winform7_照片翻页
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //此处我们使用了相对路径，我把ThinkPad的文件放在了和exe文件相同的路径,即放在了Debug文件中
            pictureBox1.Image = Image.FromFile(@"水浒英雄\001.jpg");

            //设置图片显示格式
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        int i = 0;

        /*☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
         * 获取文件夹中每一文件的路径
         * ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆*/

        string[] path = Directory.GetFiles("水浒英雄");

        /// <summary>
        /// 下一张按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            i++;
            if (i == path.Length)
            {
                i = 0;
            }
            //
            pictureBox1.Image = Image.FromFile(path[i]);
        }


        /// <summary>
        /// 上一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            if (i == 0)
            {
                i = path.Length - 1;
            }
            else
            {
                i--;
            }
            pictureBox1.Image = Image.FromFile(path[i]);
        }
    }
}
