using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;


namespace Winform4_Timer练习_闹钟
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //仅仅这样获得时间，在第一秒时，label的显示内容是label.text属性中设置的内容
            lbltime.Text = DateTime.Now.ToString();

            if (lbltime.Text == "2018-5-15 14:09:53")
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = @"F:\BaiduYunDownload\小工具\屏幕录像专家 V2011 Build0626 绿色破解版\pmlxzj\mc6.wav";
                player.Play();
            }
                 
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //为了窗口一显示的便是时间，要在窗口的load事件中说明
            lbltime.Text = DateTime.Now.ToString();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"F:\BaiduYunDownload\小工具\屏幕录像专家 V2011 Build0626 绿色破解版\pmlxzj\mc6.wav";
            player.Play();
            MessageBox.Show("测试声音的播放");
        }
    }
}
