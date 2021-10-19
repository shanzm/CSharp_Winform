using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.WinPM
{
    public class FUtility
    {
        /// <summary>
        /// 判断Form是否已打开
        /// </summary>
        /// <param name="frmName"></param>
        /// <returns></returns>
        public static bool CheckForm(string frmName)
        {
            bool bl = false;
            foreach(Form frm in Application.OpenForms)
            {
                if(frm.Name ==frmName)
                {
                    bl = true;
                    break;
                }
            }
            return bl;
        }

        /// <summary>
        /// 显示已打开窗体
        /// </summary>
        /// <param name="frmName"></param>
        public static void  OpenForm(string frmName)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == frmName)
                {
                    if(!frm.Visible)
                       frm.Show();
                    frm.Activate();
                    break;
                }
            }
           
        }

        /// <summary>
        /// 获取已经打开的Form
        /// </summary>
        /// <param name="frmName"></param>
        /// <returns></returns>
        public static Form GetOpenForm(string frmName)
        {
            Form form = null;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == frmName)
                {
                    form = frm;
                    break;
                }
            }
            return form;
        }

    }
}
