using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev8_Ribbon
{
    public partial class Form2_Demo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form2_Demo()
        {
            InitializeComponent();
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;//不要显示Ribbon左上角的按钮
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("test");
        }
    }
}
