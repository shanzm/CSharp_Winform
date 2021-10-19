using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.WinPM
{
    public class MsgBoxHelper
    {
        /// <summary>
        /// 消息提示框
        /// </summary>
        /// <param name="titile"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public static DialogResult MsgBoxShow(string titile,string Msg)
        {
           return MessageBox.Show(Msg, titile, MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        /// <summary>
        /// Confirm问题询问框
        /// </summary>
        /// <param name="title"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public static DialogResult MsgBoxConfirm(string title,string Msg)
        {
            return MessageBox.Show(Msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void MsgErrorShow(string msg)
        {
            MessageBox.Show(msg, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
