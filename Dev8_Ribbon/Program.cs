using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace Dev8_Ribbon
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");//皮肤主题
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new Form2_Demo());
            Application.Run(new Form3_XtralTabControl());
        }
    }
}
