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
        
        //��ȡһ���ļ����������ļ���ȫ·��
        string[] path = Directory.GetFiles("ˮ�Ӣ��","*.jpg");
        private void Form1_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < path.Length; i++)
            {
                //��ȫ·���н�ȡ�ļ�������
                string fileName = Path.GetFileName(path[i]);
                listBox1.Items.Add(fileName);
            }
           
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //ע��Image.FromFile(·����ʹ��
            //ע��listBox1.SelectedIndex��ʹ��
            pictureBox1.Image = Image.FromFile(path[listBox1.SelectedIndex]);
        }
    }
}
