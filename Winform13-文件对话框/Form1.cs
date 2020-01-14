using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Winform13_文件对话框
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        /// <summary>
        /// 弹出选择选择文件对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //其实为了快速释放资源，一般是使用using( OpenFileDialog ofd = new OpenFileDialog()){。。。。。}
            OpenFileDialog ofd = new OpenFileDialog();
            //弹出对话框的名称
            ofd.Title = "请选择文件";

            //设置可以多选文件
            ofd.Multiselect = true;

            //设置默认打开路径,不设置则默认是打开的电脑的文档
            ofd.InitialDirectory = @"C:\Users\shanzm\Desktop";

            //设置选择的文件类型
            ofd.Filter = "文本文档|*.txt|word|*.doc|快捷方式|*.lnk";

            //弹出对话框
            ofd.ShowDialog();


            string path = ofd.FileName;//弹出窗口中文件，你选中的的那个文件的路径
            //注意另外一个属性 string[] paths = ofd.FileNames;//FileNames属性返回的是文本对话框中，你（多选）选中的所有文件的的全路径，所以返回值存储在一个数组中
            
            if (path == "")//防止有人打开选择窗口，后不选择文件，直接取消，这样会抛异常
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
        /// 弹出字体对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog();
            textBox1.Font = fd.Font;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();//弹出“选择颜色”对话框

            textBox1.ForeColor = cd.Color;
        }







        /// <summary>
        /// 弹出另存为文件对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "另存为";
            sfd.InitialDirectory = @"C:\Users\shanzm\Desktop";
            sfd.Filter = "文本文档|*.txt|所有文件|*.*";

            sfd.ShowDialog();//弹出“保存文件”对话框

            string path = sfd.FileName;//弹出窗口选择的路径，也就是你要保存文件的路径

            if (path == "")//防止有人打开保存窗口，后不选择路径，直接取消，这样会抛异常
            {
                return;
            }
            using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] butter = Encoding.Default.GetBytes(textBox1.Text);
                fsWrite.Write(butter, 0, butter.Length);
            }
            MessageBox.Show("保存成功");
        }





    }
}
