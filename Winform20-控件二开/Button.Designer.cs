
namespace Winform20_控件二开
{
    partial class Button
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnBlack = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.timerForFlicker = new System.Windows.Forms.Timer(this.components);
            this.btnTurnOff = new System.Windows.Forms.Button();
            this.BtnTurnOn = new System.Windows.Forms.Button();
            this.btnBulb = new System.Windows.Forms.Button();
            this.btnForWifi = new System.Windows.Forms.Button();
            this.btnForWarn = new System.Windows.Forms.Button();
            this.picWarn = new System.Windows.Forms.PictureBox();
            this.picForWifi = new System.Windows.Forms.PictureBox();
            this.picGreen = new System.Windows.Forms.PictureBox();
            this.picBulb = new System.Windows.Forms.PictureBox();
            this.picRedRed = new System.Windows.Forms.PictureBox();
            this.picLightYellowFlicker = new System.Windows.Forms.PictureBox();
            this.picPower = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWarn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForWifi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBulb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRedRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLightYellowFlicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPower)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBlack
            // 
            this.btnBlack.Location = new System.Drawing.Point(116, 12);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(75, 23);
            this.btnBlack.TabIndex = 1;
            this.btnBlack.Text = "黑";
            this.btnBlack.UseVisualStyleBackColor = true;
            this.btnBlack.Click += new System.EventHandler(this.btnBlack_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.Location = new System.Drawing.Point(116, 41);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(75, 23);
            this.btnBlue.TabIndex = 2;
            this.btnBlue.Text = "蓝";
            this.btnBlue.UseVisualStyleBackColor = true;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.Location = new System.Drawing.Point(116, 70);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(75, 23);
            this.btnGreen.TabIndex = 3;
            this.btnGreen.Text = "绿";
            this.btnGreen.UseVisualStyleBackColor = true;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // timerForFlicker
            // 
            this.timerForFlicker.Enabled = true;
            this.timerForFlicker.Interval = 200;
            this.timerForFlicker.Tick += new System.EventHandler(this.timerForFlicker_Tick);
            // 
            // btnTurnOff
            // 
            this.btnTurnOff.Location = new System.Drawing.Point(334, 94);
            this.btnTurnOff.Name = "btnTurnOff";
            this.btnTurnOff.Size = new System.Drawing.Size(139, 23);
            this.btnTurnOff.TabIndex = 6;
            this.btnTurnOff.Text = "关灯";
            this.btnTurnOff.UseVisualStyleBackColor = true;
            this.btnTurnOff.Click += new System.EventHandler(this.btnTurnOff_Click);
            // 
            // BtnTurnOn
            // 
            this.BtnTurnOn.Location = new System.Drawing.Point(493, 94);
            this.BtnTurnOn.Name = "BtnTurnOn";
            this.BtnTurnOn.Size = new System.Drawing.Size(139, 23);
            this.BtnTurnOn.TabIndex = 6;
            this.BtnTurnOn.Text = "开灯";
            this.BtnTurnOn.UseVisualStyleBackColor = true;
            this.BtnTurnOn.Click += new System.EventHandler(this.BtnTurnOn_Click);
            // 
            // btnBulb
            // 
            this.btnBulb.Location = new System.Drawing.Point(334, 207);
            this.btnBulb.Name = "btnBulb";
            this.btnBulb.Size = new System.Drawing.Size(139, 23);
            this.btnBulb.TabIndex = 8;
            this.btnBulb.Text = "开/关";
            this.btnBulb.UseVisualStyleBackColor = true;
            this.btnBulb.Click += new System.EventHandler(this.btnBulb_Click);
            // 
            // btnForWifi
            // 
            this.btnForWifi.Location = new System.Drawing.Point(493, 207);
            this.btnForWifi.Name = "btnForWifi";
            this.btnForWifi.Size = new System.Drawing.Size(139, 23);
            this.btnForWifi.TabIndex = 8;
            this.btnForWifi.Text = "开/关";
            this.btnForWifi.UseVisualStyleBackColor = true;
            this.btnForWifi.Click += new System.EventHandler(this.btnForWifi_Click);
            // 
            // btnForWarn
            // 
            this.btnForWarn.Location = new System.Drawing.Point(638, 208);
            this.btnForWarn.Name = "btnForWarn";
            this.btnForWarn.Size = new System.Drawing.Size(139, 23);
            this.btnForWarn.TabIndex = 8;
            this.btnForWarn.Text = "开/关";
            this.btnForWarn.UseVisualStyleBackColor = true;
            this.btnForWarn.Click += new System.EventHandler(this.btnForWarn_Click);
            // 
            // picWarn
            // 
            this.picWarn.Image = global::Winform20_控件二开.Properties.Resources.errorYellow;
            this.picWarn.Location = new System.Drawing.Point(684, 150);
            this.picWarn.Name = "picWarn";
            this.picWarn.Size = new System.Drawing.Size(48, 48);
            this.picWarn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picWarn.TabIndex = 11;
            this.picWarn.TabStop = false;
            // 
            // picForWifi
            // 
            this.picForWifi.Image = global::Winform20_控件二开.Properties.Resources.WifiOff;
            this.picForWifi.Location = new System.Drawing.Point(532, 150);
            this.picForWifi.Name = "picForWifi";
            this.picForWifi.Size = new System.Drawing.Size(48, 48);
            this.picForWifi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picForWifi.TabIndex = 10;
            this.picForWifi.TabStop = false;
            // 
            // picGreen
            // 
            this.picGreen.Image = global::Winform20_控件二开.Properties.Resources.lightGreen1;
            this.picGreen.Location = new System.Drawing.Point(493, 12);
            this.picGreen.Name = "picGreen";
            this.picGreen.Size = new System.Drawing.Size(60, 60);
            this.picGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picGreen.TabIndex = 9;
            this.picGreen.TabStop = false;
            // 
            // picBulb
            // 
            this.picBulb.Image = global::Winform20_控件二开.Properties.Resources.LightOff;
            this.picBulb.Location = new System.Drawing.Point(378, 150);
            this.picBulb.Name = "picBulb";
            this.picBulb.Size = new System.Drawing.Size(48, 48);
            this.picBulb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBulb.TabIndex = 7;
            this.picBulb.TabStop = false;
            // 
            // picRedRed
            // 
            this.picRedRed.Image = global::Winform20_控件二开.Properties.Resources.lightRedRed2;
            this.picRedRed.Location = new System.Drawing.Point(413, 12);
            this.picRedRed.Name = "picRedRed";
            this.picRedRed.Size = new System.Drawing.Size(60, 60);
            this.picRedRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRedRed.TabIndex = 5;
            this.picRedRed.TabStop = false;
            // 
            // picLightYellowFlicker
            // 
            this.picLightYellowFlicker.BackColor = System.Drawing.SystemColors.Control;
            this.picLightYellowFlicker.Image = global::Winform20_控件二开.Properties.Resources.lightYellow1;
            this.picLightYellowFlicker.Location = new System.Drawing.Point(334, 12);
            this.picLightYellowFlicker.Name = "picLightYellowFlicker";
            this.picLightYellowFlicker.Size = new System.Drawing.Size(60, 60);
            this.picLightYellowFlicker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLightYellowFlicker.TabIndex = 4;
            this.picLightYellowFlicker.TabStop = false;
            // 
            // picPower
            // 
            this.picPower.Image = global::Winform20_控件二开.Properties.Resources.power_black;
            this.picPower.Location = new System.Drawing.Point(21, 12);
            this.picPower.Name = "picPower";
            this.picPower.Size = new System.Drawing.Size(64, 64);
            this.picPower.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPower.TabIndex = 0;
            this.picPower.TabStop = false;
            this.picPower.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Button
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picWarn);
            this.Controls.Add(this.picForWifi);
            this.Controls.Add(this.btnForWarn);
            this.Controls.Add(this.btnForWifi);
            this.Controls.Add(this.picGreen);
            this.Controls.Add(this.btnBulb);
            this.Controls.Add(this.picBulb);
            this.Controls.Add(this.BtnTurnOn);
            this.Controls.Add(this.btnTurnOff);
            this.Controls.Add(this.picRedRed);
            this.Controls.Add(this.picLightYellowFlicker);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnBlack);
            this.Controls.Add(this.picPower);
            this.Name = "Button";
            this.Text = "Button";
            ((System.ComponentModel.ISupportInitialize)(this.picWarn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForWifi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBulb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRedRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLightYellowFlicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPower;
        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.PictureBox picLightYellowFlicker;
        private System.Windows.Forms.Timer timerForFlicker;
        private System.Windows.Forms.PictureBox picRedRed;
        private System.Windows.Forms.Button btnTurnOff;
        private System.Windows.Forms.Button BtnTurnOn;
        private System.Windows.Forms.PictureBox picBulb;
        private System.Windows.Forms.Button btnBulb;
        private System.Windows.Forms.PictureBox picGreen;
        private System.Windows.Forms.PictureBox picForWifi;
        private System.Windows.Forms.Button btnForWifi;
        private System.Windows.Forms.PictureBox picWarn;
        private System.Windows.Forms.Button btnForWarn;
    }
}