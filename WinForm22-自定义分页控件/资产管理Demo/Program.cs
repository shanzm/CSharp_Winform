using System;
using System.Windows.Forms;
using zcgl.zcwh;

namespace zcgl
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
            //Application.Run(new fmLogin());
            fmLogin fl = new fmLogin();
            if (fl.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new fmMain());
            }         
        }

    }
}
