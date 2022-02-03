using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_登陆窗口逻辑
{
    #region 说明
    /// <summary>
    /// 
    /// 窗口设置：
    /// Start Position=Center Screen
    /// Size:308,486
    /// FormBorderStyle=None
    /// BackColor=White
    /// 
    /// 
    /// 添加PictureBox控件——显示logo
    /// Size:87,71
    /// 
    /// 添加Label——显示名称
    /// Text:LOG IN 
    /// Fore Color:0,117,214
    /// Font:Bauhaus 95,FontStyle=Bold,FontSize=24
    /// 
    /// 添加PictureBox——显示用户名iCON
    /// Size:25,25
    /// SizeModel:Zoom
    /// 
    /// 
    /// 添加Panel——显示为横线
    /// Size:236,1
    /// BackColor:0,117,114
    /// 
    /// 添加TextBox——输入
    /// FontSize:11
    /// FontColor:0,117,214
    /// BorderStyle:None
    /// 
    /// 
    /// 选中上述PictureBox和Panel和textBox复制一个
    /// Ctrl+拖动
    /// 
    /// 
    /// 添加Button——登陆按钮
    /// SIze：236,33
    /// FontSize:14
    /// ForceColor:white
    /// FontStyle=Bold
    /// FlastSylt:flat
    /// FlastApprentice-BorderSize:0
    /// BackColor:0,117,214
    /// 
    /// 
    /// 添加Button——关闭按钮
    /// 
    /// </summary>
    #endregion

    public partial class MyLoginForm2 : Form
    {
        public MyLoginForm2()
        {
            InitializeComponent();
        }


        //退出
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
