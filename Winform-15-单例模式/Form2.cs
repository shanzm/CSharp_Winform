using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winform_15_单例模式
{
    public partial class Form2 : Form
    {
        ///全局唯一单例（就是一个字段，为GetForm中新建Form时作限制
        ///为什么是静态的呢？因为GetForm函数是静态的，只能调用静态成员
        public static Form2 Form2Single;

      private  Form2()//首先将构造函数改为私有
        {
            InitializeComponent();
        }


        public static Form2 GetForm()
        {
            if (Form2Single==null)
            {
                Form2Single = new Form2();
            }
           return Form2Single;
        }
    }
}
