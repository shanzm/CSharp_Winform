using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEV3_GridControl
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new Form4_event());//Form4_datasoucre
            //Application.Run(new Form5_根据行中某列数据设置样式());
            //Application.Run(new Form7第一列展示复选框());
            //Application.Run(new Form8第一列展示复选框2());

            Application.Run(new Form9_上移和下移());
            //Application.Run(new Form10显示搜索框());
        }
    }
}
