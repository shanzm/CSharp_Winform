using System;
using System.Windows.Forms;

namespace Winform18_TrackBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitTrackBarControl();
        }
        //滚动事件
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //拖动滑块，在label中显示value
            labTrackBarValue.Text = trackBar1.Value.ToString();

            textBox1.Text = trackBar1.Value.ToString();
            //注意：TrackBar的value是int类型，所以若是需要设置精度为小数则，可以按照比率来，比如TrackBar值与真实值1：0.1
            textBox2.Text = ((double)trackBar1.Value / 100).ToString();
        }

        //选中值发生变化的事件
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void InitTrackBarControl()
        {
            this.trackBar1.Minimum = 0;
            this.trackBar1.Maximum = 100;
        }
    }
}
