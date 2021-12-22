using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev13_XtraReport
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MyXtraReport2 myXtraReport2 = new MyXtraReport2();
            ReportPrintTool reportPrintTool = new ReportPrintTool(myXtraReport2);
            reportPrintTool.ShowPreview();
        }
    }
}
