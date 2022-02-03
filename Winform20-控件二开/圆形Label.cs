using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


#region 
/// <summary>
/// 根据继承Label标签，将lable标签扩展为一个圆形控件
/// </summary>
#endregion


namespace Winform20_控件二开
{
    public partial class 圆形Label : Form
    {
        private bool isOpen = false;
        public 圆形Label()
        {
            InitializeComponent();
            this.circleLabel1.BackColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isOpen = !isOpen;

            if (isOpen)
            {
                this.circleLabel1.BackColor = Color.LightGreen;
            }
            else
            {
                this.circleLabel1.BackColor = Color.Red;
            }

        }
    }


    #region 圆形标签类
    public class CircleLabel : Label//继承标签类    重新生成解决方案就能看见在工具箱中看到该二开的控件
    {
        protected override void OnPaint(PaintEventArgs e)//重新设置控件的形状   protected 保护  override重新
        {
            base.OnPaint(e);//递归  每次重新都发生此方法,保证其形状为自定义形状
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(2, 2, Width - 6, Height - 6);
            //Graphics g = e.Graphics;
            //g.DrawEllipse(new Pen(Color.Red, 2), 2, 2, Width - 6, Height - 6);
            Region = new Region(path);

            AutoSize = false;//默认将自动大小关闭

            Text = "";
        }
    }

    #endregion
}
