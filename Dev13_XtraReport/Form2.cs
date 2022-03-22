using DevExpress.XtraPrinting;
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

        private void btnForChiChu_Click(object sender, EventArgs e)
        {
            //XtraReport3ForChichu chichu = new XtraReport3ForChichu();
            //ReportPrintTool reportPrintTool = new ReportPrintTool(chichu);
            //reportPrintTool.ShowPreview();

            XtraReport3ForChichu chichu = new XtraReport3ForChichu();

            //var mlc = sp.tiaoma.ToList();
            //chichu.DataSource = mlc;

            ReportPrintTool tool = new ReportPrintTool(chichu);



            //操作要显示什么按钮
            tool.PrintingSystem.SetCommandVisibility(new PrintingSystemCommand[]{
                                                         PrintingSystemCommand.Open,
                                                         PrintingSystemCommand.Save,
                                                         PrintingSystemCommand.ClosePreview,
                                                         PrintingSystemCommand.Customize,
                                                         PrintingSystemCommand.SendCsv,
                                                         PrintingSystemCommand.SendFile,
                                                         PrintingSystemCommand.SendGraphic,
                                                         PrintingSystemCommand.SendMht,
                                                         PrintingSystemCommand.SendPdf,
                                                         PrintingSystemCommand.SendRtf,
                                                         PrintingSystemCommand.SendTxt,
                                                         PrintingSystemCommand.SendXls
                                                         }, CommandVisibility.None);
            tool.ShowPreview();
        }
    }
}
