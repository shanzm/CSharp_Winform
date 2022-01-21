using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEV3_GridControl
{
    public partial class Form8第一列展示复选框2 : Form
    {
        public Form8第一列展示复选框2()
        {
            InitializeComponent();
            InitTable();
        }

        private void InitTable()
        {
            this.bindingSource1.DataSource = GetTable();
            this.bindingSource2.DataSource = GetList();

            //gridControl1绑定bindingSource1,bindingSource1代码实现绑定Table
            gridControl1.DataSource = this.bindingSource1;
            //gridControl2绑定bindingSource2,bingingSource2代码实现绑定List
            gridControl2.DataSource = this.bindingSource2;
            //设计界面gridControl3绑定bindingSouce3，bindingSource
            this.bindingSource3.DataSource = GetList();
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
            dataTable.Columns.Add("IsChecked", Type.GetType("System.Boolean"));//------------------------这里添加一个bool类型的列
            dataTable.Rows.Add(new object[] { "1", "A公司", "贝克街221号", "歇洛克.福尔摩斯",true });
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
              new Company (){Id=3,Name="建筑公司",Address="青年路",LegelPerson="王五" }
            };
            return companies;
        }
        #endregion
    }
}
