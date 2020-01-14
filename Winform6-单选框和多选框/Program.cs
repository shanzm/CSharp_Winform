using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Winform6_单选框和多选框
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
            Application.Run(new Form1());
        }
    }
}
