using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEV4_LayoutControl布局
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.layoutControl1.Visible = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.layoutControl1.Visible = true;
        }
    }
}
