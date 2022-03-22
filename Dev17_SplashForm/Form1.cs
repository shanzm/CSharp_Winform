using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DevExpress.XtraSplashScreen; 

namespace SplashForm
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            Thread.Sleep(5000);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
                SplashScreenManager.ShowForm(typeof(WaitForm1));
                Thread.Sleep(3000);
                SplashScreenManager.CloseForm();
         }

        
    }
}
