using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DEV12_ToolTipController
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitToolTip();
            RefreshGridControl1();
        }

        #region 测试1
        //初始化ToolTip的基本样式
        //给特定的控件设定提示信息
        //这里需要需要说明的是：我们可以在控件设计界面，当前拖入一个Tooltip控件后
        //设计界面的某一个控件都会有一个ToolTipControl属性，我们可以直接在设置界面添加提示信息
        //可以设置显示的图标等信息
        private void InitToolTip()
        {
            //设置边框颜色
            this.toolTipController1.Appearance.BorderColor = Color.Green;
            //设置背景色
            this.toolTipController1.Appearance.BackColor = Color.Yellow;
            this.toolTipController1.Appearance.BackColor2 = Color.Yellow;
            //设置是否显示箭头
            this.toolTipController1.ShowBeak = true;
            //设置显示时间2000毫秒
            this.toolTipController1.AutoPopDelay = 2000;
            //设置提示显示的位置
            this.toolTipController1.ToolTipLocation = DevExpress.Utils.ToolTipLocation.TopRight;
            //设置提示显示的风格
            this.toolTipController1.ToolTipType = DevExpress.Utils.ToolTipType.Standard;


            //鼠标移动到控件或指定的位置自动显示：使用ToolTip.SetToolTip 方法
            this.toolTipController1.SetToolTip(this.simpleButton1, "这是一个简单的按钮");
            this.toolTipController1.SetToolTip(this.textEdit1, "这是textEdit1");
        }
        #endregion

        #region 测试3
        //初始化GridControl1
        public void RefreshGridControl1()
        {
            this.companyBindingSource.DataSource = this.GetTable();
        }

        #region 测试数据源
        //Datatable数据源
        public DataTable GetTable()
        {
            DataTable dataTable = new DataTable("TestData");
            dataTable.Columns.Add("Id", Type.GetType("System.Int32"));
            dataTable.Columns.Add("Name", Type.GetType("System.String"));
            dataTable.Columns.Add("Address", Type.GetType("System.String"));
            dataTable.Columns.Add("LegelPerson", Type.GetType("System.String"));
            dataTable.Rows.Add(new object[] { "1", "A公司", "贝克街221号", "歇洛克.福尔摩斯" });
            dataTable.Rows.Add(new object[] { "2", "B公司", "贝克街2212号", "华生" });
            dataTable.Rows.Add(new object[] { "3", "C公司", "贝克街2213号", "歇洛克.福尔摩斯" });
            dataTable.Rows.Add(new object[] { "4", "D公司", "贝克街2214号", "华生" });
            dataTable.Rows.Add(new object[] { "5", "E公司", "贝克街2215号", "歇洛克.福尔摩斯" });
            dataTable.Rows.Add(new object[] { "6", "F公司", "贝克街2216号", "华生" });
            dataTable.Rows.Add(new object[] { "7", "G公司", "贝克街2217号", "歇洛克.福尔摩斯" });
            dataTable.Rows.Add(new object[] { "8", "H公司", "贝克街2218号", "华生" });
            return dataTable;
        }

        //List数据源
        public List<Company> GetList()
        {
            List<Company> companies = new List<Company>()
            {
              new Company (){Id=1,Name="食品公司",Address="人民路",LegelPerson="张三" },
              new Company (){Id=2,Name="服装公司",Address="中山路",LegelPerson="李四" },
              new Company (){Id=3,Name="建筑公司",Address="青年路",LegelPerson="王五"}
            };
            return companies;
        }
        #endregion


        //GriDControl当鼠标放在行头，显示行号
        //https://docs.devexpress.com/WindowsForms/DevExpress.Utils.ToolTipController.GetActiveObjectInfo
        private void toolTipController3_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl!=gridControl1)
            {
                return;
            }

            ToolTipControlInfo info = null;
            GridView view = gridControl1.GetViewAt(e.ControlMousePosition) as GridView;
            if (view==null)
            {
                return;
            }

            GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
            if (hi.HitTest==GridHitTest.RowIndicator)
            {
                object o = hi.HitTest.ToString() + hi.RowHandle.ToString();
                string text = "当前是第" + (hi.RowHandle+1)+"行";
                info = new ToolTipControlInfo(o, text);
            }
            if (info!=null)
            {
                e.Info = info;
            }
        } 
        #endregion
    }
}
