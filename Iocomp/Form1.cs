using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace IocompDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sevenSegmentClockSmpte1.Value = DateTime.Now;
        }

        private void switchLed1_ValueChanged(object sender, Iocomp.Classes.ValueBooleanEventArgs e)
        {
            led1.Value = !led1.Value;

            switchRocker1.Value = !switchRocker1.Value;

            switchLever1.Value = !switchLever1.Value;

            switchToggle1.Value = !switchToggle1.Value;

            valve1.Value = !valve1.Value;
        }



        //数据条拖动
        private void slider1_ValueChanged(object sender, Iocomp.Classes.ValueDoubleEventArgs e)
        {
            Debug.WriteLine(slider1.Value);
            //计量管
            gaugeTube1.Value = slider1.Value;
            //计量条
            gaugeLinear1.Value = slider1.Value;
            //LED条
            ledBar1.Value = slider1.Value;
            //环形LED条
            ledSpiral1.Value = slider1.Value;


            //刻度盘
            gaugeAngular1.Value = slider1.Value;
            gaugeAngular2.Value = slider1.Value;

            //温度计
            thermometer1.Value = slider1.Value;
        }

        private void switchRocker1_ValueChanged(object sender, Iocomp.Classes.ValueBooleanEventArgs e)
        {

        }

        private void phonePad1_ButtonClick(object sender, Iocomp.Classes.MatrixButtonEventArgs e)
        {
            //MessageBox.Show(e.Button.Text);
            editString1.Value += e.Button.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //时间LED
            sevenSegmentClockSmpte1.Value = DateTime.Now.AddSeconds(1).ToLongTimeString();
            //整数LED
            sevenSegmentInteger1.Value = sevenSegmentInteger1.Value.AsInteger + 1;

            //里程表
            odometer1.Value = odometer1.Value.AsDouble + 20.1;
        }


        //旋钮转动
        private void knob2_ValueChanged(object sender, Iocomp.Classes.ValueDoubleEventArgs e)
        {
            textBox1.Text = $@"{e.ValueNew.ToString("#0.00")}";
        }

        private void switchRocker3Way1_ValueChanged(object sender, Iocomp.Classes.ValueDoubleEventArgs e)
        {
            MessageBox.Show(e.ValueNew.ToString());
        }


        //x方向修改值
        private void switchQuad1_ValueXChanged(object sender, Iocomp.Classes.ValueDoubleEventArgs e)
        {
            this.textBox2.Text = $"X:{e.ValueNew}";
        }
        //y方向修改值
        private void switchQuad1_ValueYChanged(object sender, Iocomp.Classes.ValueDoubleEventArgs e)
        {
            this.textBox2.Text = $"Y:{e.ValueNew}";
        }
    }
}
