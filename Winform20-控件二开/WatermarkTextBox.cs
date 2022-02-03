using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Winform20_控件二开
{
    /// <summary>
    /// 创建：添加-->用户控件
    /// 继承TextBox自定义一个控件，实现TextBox添加一个水印属性：WatermarkText
    /// 用于提示用户的输入，当鼠标焦点在工输入框后则隐藏该水印
    /// </summary>

    public partial class WatermarkTextBox : TextBox
    {
        public WatermarkTextBox()
        {
            InitializeComponent();
        }

        private const uint ECM_FIRST = 0x1500;
        private const uint EM_SETCUEBANNER = ECM_FIRST + 1;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private string watermarkText;
        public string WatermarkText
        {
            get => watermarkText;
            set
            {
                watermarkText = value;
                SetWatermark(watermarkText);
            }
        }

        private void SetWatermark(string watermarkText)
        {
            SendMessage(Handle, EM_SETCUEBANNER, 0, watermarkText);
        }
    }
}
