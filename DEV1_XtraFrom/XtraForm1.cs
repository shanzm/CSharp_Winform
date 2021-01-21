using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DEV1_XtraFrom
{
    ///说明：原生的Winform中的Form窗口是继承与From类，而XtraForm窗口是继承于XtraForm类的
    ///将原生Form窗口，转换为XtraFrom窗口则可以的设计界面中：点开控件的三角符号From任务中：convert to XXXXFrom 
    ///DEV中的控件的名称和Winform中原生控件，一般是同名，只是加了一个Control结尾或Edit结尾


    ///在新建的项目的时候可以选择是DevExpress的窗体项目也可以是默认的WInform窗体项目
    ///其中WInform窗体项目也是可以使用DevExpress组件

    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }
    }
}