using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winform_MouseEnter练习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowLove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("我也爱你");
            this.Close();
        }


        
        int i=0;
        private void Move_MouseEnter(object sender, EventArgs e)
        {
            
            i++;
            if (i<=20)
            {

            int x = this.ClientSize.Width-Move .Width ;//clientSize意味着，你把窗口托大，传来的就是托大后的宽度
            int y = this.ClientSize.Height-Move.Height ;
            Random r=new Random ();

            Move.Location = new Point(r.Next(x + 1), r.Next(y + 1));

            }
            else
            {
                MessageBox.Show("好吧！祝你幸福！");
            }
           
        }
        

    }
}
