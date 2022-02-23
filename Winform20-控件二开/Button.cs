using System;
using System.Windows.Forms;

namespace Winform20_控件二开
{
    public partial class Button : Form
    {
        public Button()
        {
            InitializeComponent();
        }

        public bool IsPower { get; set; } = false;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!IsPower)
            {
                picPower.Image = global::Winform20_控件二开.Properties.Resources.power_green;
                IsPower = true;
            }
            else
            {
                picPower.Image = global::Winform20_控件二开.Properties.Resources.power_black;
                IsPower = false;
            }

        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            picPower.Image = global::Winform20_控件二开.Properties.Resources.power_black;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            picPower.Image = global::Winform20_控件二开.Properties.Resources.power_blue;
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            this.picPower.Image = global::Winform20_控件二开.Properties.Resources.power_green;
        }

        private void timerForFlicker_Tick(object sender, EventArgs e)
        {
            #region 黄灯闪烁
            if (Convert.ToInt32(this.picLightYellowFlicker.Image.Tag) == 1)
            {
                this.picLightYellowFlicker.Image = global::Winform20_控件二开.Properties.Resources.lightYellow2;
                this.picLightYellowFlicker.Image.Tag = 2;

            }
            else
            {
                this.picLightYellowFlicker.Image = global::Winform20_控件二开.Properties.Resources.lightYellow1;
                this.picLightYellowFlicker.Image.Tag = 1;
            }
            #endregion


            #region 红灯闪烁
            if (Convert.ToInt32(this.picRedRed.Image.Tag) == 1)
            {
                this.picRedRed.Image = global::Winform20_控件二开.Properties.Resources.lightRedRed2;
                this.picRedRed.Image.Tag = 2;

            }
            else
            {
                this.picRedRed.Image = global::Winform20_控件二开.Properties.Resources.lightRedRed1;
                this.picRedRed.Image.Tag = 1;
            }
            #endregion

            #region 绿灯闪烁
            if (Convert.ToInt32(this.picGreen.Image.Tag) == 1)
            {
                this.picGreen.Image = global::Winform20_控件二开.Properties.Resources.lightGreen2;
                this.picGreen.Image.Tag = 2;

            }
            else
            {
                this.picGreen.Image = global::Winform20_控件二开.Properties.Resources.lightGreen1;
                this.picGreen.Image.Tag = 1;
            }
            #endregion


        }

        //关灯
        private void btnTurnOff_Click(object sender, EventArgs e)
        {
            this.timerForFlicker.Enabled = false;
            this.picRedRed.Image = Winform20_控件二开.Properties.Resources.lightBlack;
            this.picLightYellowFlicker.Image = Properties.Resources.lightBlack;
            this.picGreen.Image = Properties.Resources.lightBlack;
        }

        //开灯
        private void BtnTurnOn_Click(object sender, EventArgs e)
        {
            this.timerForFlicker.Enabled = true;
        }

        private void btnBulb_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.picBulb.Image.Tag) == 1)
            {
                this.picBulb.Image = global::Winform20_控件二开.Properties.Resources.LightOff;
                this.picBulb.Image.Tag = 2;
            }
            else
            {
                this.picBulb.Image = global::Winform20_控件二开.Properties.Resources.LightOn;
                this.picBulb.Image.Tag = 1;
            }
        }

        //Wifi开关
        private void btnForWifi_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.picForWifi.Image.Tag) == 1)
            {
                this.picForWifi.Image = global::Winform20_控件二开.Properties.Resources.WifiOff;
                this.picForWifi.Image.Tag = 2;
            }
            else
            {
                this.picForWifi.Image = global::Winform20_控件二开.Properties.Resources.WifiOn;
                this.picForWifi.Image.Tag = 1;
            }
        }

        //警告标志
        private void btnForWarn_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.picWarn.Image.Tag) == 1)
            {
                this.picWarn.Image = global::Winform20_控件二开.Properties.Resources.errorRed;
                this.picWarn.Image.Tag = 2;
            }
            else
            {
                this.picWarn.Image = global::Winform20_控件二开.Properties.Resources.errorYellow;
                this.picWarn.Image.Tag = 1;
            }
        }
    }
}
