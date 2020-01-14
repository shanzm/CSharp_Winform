using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace _002线程_摇奖机
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        bool b = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                b = true;
                button1.Text = "停止";

                Thread thread = new Thread(Play);
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {
                b = false;
                button1.Text = "开始";
            }

        }



        private void Play()
        {
            Random r = new Random();

            while (b)
            {
                label1.Text = r.Next(0, 10).ToString();
                label2.Text = r.Next(0, 10).ToString();
                label3.Text = r.Next(0, 10).ToString();
            }

            //将随机生成的三个随机数添加到ListBox中
            listBox1.Items.Add(label1.Text + label2.Text + label3.Text);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "开始";
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 跑马灯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = label5.Text.Substring(1) + label5.Text.Substring(0,1);
            label6.Text = label6.Text.Substring(1) + label6.Text.Substring(0, 1);
            label7.Text = label7.Text.Substring(1) + label7.Text.Substring(0, 1);
            label8.Text = label8.Text.Substring(1) + label8.Text.Substring(0, 1);
        }

    }
}
