using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace _002线程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        ///如果仅仅这样取运行程序，你就会发现，在代码执行过程中，窗口的其他行为都不能执行，比如说你不能移动窗口
        ///这就是因为单线程导致程序假死锁；
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Test();
        //}

        //private void Test()
        //{
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}

        Thread thread;
        private void button1_Click(object sender, EventArgs e)
        {
            
            //补充：关于线程的其他方法
            //该线程（程序），休眠5s
            Thread.Sleep(5000);//注意这是线程类的方法，不是某一个线程实例化对象的方法



            //创建一个新的线程去执行Test（）
            //注意创建的是前台线程，前台线程全关闭了程序才能关闭
            thread = new Thread(Test);//注意直接在参数的括号中写方法名
            ///若果线程执行的方式是在参数的，则参数必须为object类型，
            ///当然，参数为object类型的，你在方法体中可以在转换为任何类型再使用
            ///而且线程执行的方法的参数，不写在此处，而是写在thread.Start (参数);
            

            //设置为后台线程，后台线程是当所有的前台线程都结束，后台线程自动结束
            //你若是不设置为后台线程，它默认为前台线程，当你把窗口关闭了，他依然在执行
            //可是在“调试-窗口-输出”中显示
            thread.IsBackground=true ;

            //start并不表示执行该线程，而是表示，此时已经准备好，什么时候可以执行，由CPU执行，我们无法决定
            thread.Start ();
        }

        private void Test()
        {
            for (int i = 0; i < 10000; i++)
            {
                
               // Console.WriteLine(i);
                textBox1.Text = i.ToString ();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //.Net中是不许跨线程访问的
            //通过下面语句，取消跨线程的检查
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 在窗口关闭之时，判断新线程是否为null
        /// 你要知道若是有新线程不为空，则在窗口关闭时，程序会抛异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread !=null)///你要注意“！=”是一个运算符，不能在“！”和“=”之间含有空格，这同样包括>=和<=
            {
                //结束这个线程，abort单词有使结束，使流产
                //注意一旦一个进程结束了，你就不能在使他开始
                thread.Abort ();
            }
        }
    }
}




