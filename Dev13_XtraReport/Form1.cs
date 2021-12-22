using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Windows.Forms;

namespace Dev13_XtraReport
{
    //0. 参考：https://blog.51cto.com/970076933/1902131
    //1. 添加一张报表：右键添加新项目：Devexpress v19.1 Report
    //2. 设置报表样式：Blank(空白的样式，有的版本是Empty Report)
    //3. 在报表设计页面设置


    //说明：若是在报表的页面上显示了：this application was created using the trial version of the xtrareports 
    //可以删除当前项目现有的license.lic即可


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 静态报表
        //预览
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MyXtraReport myXtraReport = new MyXtraReport();
            ReportPrintTool reportPrintTool = new ReportPrintTool(myXtraReport);
            //设置“文件”菜单下显示的选项
            //tool.PrintingSystem.SetCommandVisibility(new PrintingSystemCommand[]{
            //                                             //PrintingSystemCommand.Open,
            //                                             //PrintingSystemCommand.Save,
            //                                             //PrintingSystemCommand.ClosePreview,
            //                                             //PrintingSystemCommand.Customize,
            //                                             //PrintingSystemCommand.SendCsv,
            //                                             //PrintingSystemCommand.SendFile,
            //                                             //PrintingSystemCommand.SendGraphic,
            //                                             //PrintingSystemCommand.SendMht,
            //                                             //PrintingSystemCommand.SendPdf,
            //                                             //PrintingSystemCommand.SendRtf,
            //                                             //PrintingSystemCommand.SendTxt,
            //                                             PrintingSystemCommand.SendXls
            //                                             }, CommandVisibility.None);
            reportPrintTool.ShowPreview();
        }

        //打印
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            MyXtraReport myXtraReport = new MyXtraReport();
            ReportPrintTool tool = new ReportPrintTool(myXtraReport);
            tool.Print();
        }

        //编辑
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            MyXtraReport myXtraReport = new MyXtraReport();
            ReportDesignTool tool = new ReportDesignTool(myXtraReport);
            tool.ShowDesignerDialog();
        }
        #endregion


        #region 动态获取数据
        //预览
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            MyXtraReport2 myXtraReport2 = new MyXtraReport2();
        } 
        #endregion
    }
}
