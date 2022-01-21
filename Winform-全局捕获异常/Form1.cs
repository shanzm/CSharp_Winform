using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_全局捕获异常
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Exception exception = new Exception() ;
            throw exception;
        }
    }
}
