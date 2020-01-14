using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm_GDI_验证码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            string str = null;

            //随机生成一个有5个数字组成的字符串
            for (int i = 0; i < 5; i++)
            {
                int num = r.Next(0, 10);
                str += num;//☆☆☆☆☆注意整形变量+字符串类型变量就会隐式转换为整形
            }


            Bitmap bmp = new Bitmap(120, 30);//新建一张位图（就是平时见到的后缀是.bmp类型的图片），使用的是第五个重载,长120像素，宽20像素
            Graphics grap = Graphics.FromImage(bmp);//在图像bmp上生成的绘图区

            //分别绘制字符串str中的每一个字符
            for (int i = 0; i < 5; i++)
            {
                String[] fonts = new String[] { "微软雅黑", "宋体", "隶书", "仿宋体", "黑体" };

                Color[] color = new Color[] { Color.Red, Color.Black, Color.Blue, Color.Green, Color.Gray };
                Brush bursh = new SolidBrush(color[r.Next(0, 5)]);//Brush类中的构造函数无法使用数组参数，SolidBrush时Brush的子类，他的参数可以是一个Color类型的数组。此处就是一个父类Brush类型的对象赋值一个他的子类SolidBrush对象

                grap.DrawString(str[i].ToString(), new Font(fonts[r.Next(0, 5)], 20, FontStyle.Bold), bursh, new Point(i * 20, 0));//Point (i*20,0)就是隔20个像素，绘制一个数字，
            }

            //随机在bmp中画一些线
            for (int i = 0; i < 20; i++)//画20条
            {
                Point p1 = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                Point p2 = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                grap.DrawLine(new Pen(Brushes.Green), p1, p2);
            }


            //随机在bmp中画一些点
            for (int i = 0; i < 100; i++)
            {
                bmp.SetPixel(r.Next(0, bmp.Width), r.Next(0, bmp.Height), Color.Blue);
            }

            pictureBox1.Image = bmp;
        }
    }
}
