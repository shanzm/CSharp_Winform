using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm_GDI_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绘制一条直线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics grap = this.CreateGraphics();//不能使用new来创建
            Pen pen = new Pen(Brushes.Red);//参数为画笔颜色
            Point p1 = new Point(0, 0);
            Point p2 = new Point(120, 120);
            //Point p2 = new Point(this.Width, this.Height);//注意现在是在Form1类中，我们调用自己的类的对象是使用this关键字，不能直接使用类名，因为这只是一个类，我们使用的是类的对象

            grap.DrawLine(pen, p1, p2);

            ///注意这样运行代码后，你只要拖动窗口到边缘，把你画的线放到屏幕外，你就会发现你画的线被擦掉了
            ///因为，你一但拖动窗口到了屏幕外，Form1就会重新创建对象，在你现在所在的窗口绘制该图线
            ///，你只要设置一个Form1 中的Paint事件，再次绘制以上内容

        }


        int i = 0;


        public int I
        {
            get { return i; }
            set { i = value; }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            i++;
            label1.Text = i.ToString();//这是为你你观察你移动一次窗口，就会重新绘制一次
            Graphics grap = this.CreateGraphics();//不能使用new来创建
            Pen pen = new Pen(Brushes.Red);
            Point p1 = new Point(0, 0);
            Point p2 = new Point(120, 120);
            //Point p2 = new Point(this.Width, this.Height);

            grap.DrawLine(pen, p1, p2);
        }



        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Graphics Grap1 = this.CreateGraphics();
            Pen pen = new Pen(Brushes.Red);

            //注意这个Size类
            Size size = new System.Drawing.Size(120, 120);//长宽
            Rectangle rect = new Rectangle(new Point(20, 20), size);//绘制矩形的方法
            Grap1.DrawRectangle(pen, rect);
        }

        /// <summary>
        /// 绘制扇形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Graphics grap = this.CreateGraphics();
            Pen pen = new Pen(Brushes.Red);
            Size size = new System.Drawing.Size(120, 120);
            Rectangle rect = new Rectangle(new Point(20, 20), size);

            ///记住，画扇形的参数其中有一个是一个矩形rect，扇形的圆心就在这个矩形的中心
            ///画扇形的初试角度0是和Form窗口平行的（也就是x轴），顺时针旋转一个角度（这也就是最后一个参数），从而形成一个扇形
            grap.DrawPie(pen, rect, 0, 45);
        }


        /// <summary>
        /// 绘制文本文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Graphics grap = this.CreateGraphics();
            Pen pen = new Pen(Brushes.Red);


            //以下是grap.DrawString ()的参数
            string s = "长风破浪会有时";
            Font font = new System.Drawing.Font("宋体", 20, FontStyle.Bold);
            Brush brush = Brushes.Black;
            PointF point = new Point(20, 20);///PointF与Point完全相同，但X和Y属性的类型是float，而不是int。
                                             ///PointF用于坐标不是整数值的情况。已经为这些结构定义了数据类型转换，这样就可以把Point隐式地转换为 PointF。    

            //注意你不知道一个新的方法的参数，所以你是打出这个方法后，才根据提示知道的她的参数，回去补充了上面的代码
            grap.DrawString(s, font, brush, point);

            ///在Winform程序调试的时候，我们想要输出某一个结果时,我们没必要新建一个按钮显示一个MessageBox
            ///我们还是可以直接Console.WriteLine，虽然不显示在窗口，
            ///但是可以通过 调试-窗口-输出 来看运行结果
            //foreach (FontFamily  item in FontFamily.Families  )
            //{
            //    //输出本计算机上所有的字体
            //    Console.WriteLine(item.Name );
            //}


        }
    }
}
