using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DEV3_GridControl
{
    public partial class Form4_event : Form
    {

        #region 其他一些函数说明
        /// <summary>
        /// 若是GridView 是可以编辑的则编辑后获取最新的数据源，则需要:     this.gridView1.CloseEditor
        /// 
        /// 若是直接改变数据源BindingSource对象则
        ///  BindingSource1.EndEdit();
        ///  this.gridControl1.RefreshDataSource();
        /// </summary>
        #endregion


        public Form4_event()
        {
            InitializeComponent();
            RefreshGridControl1();
            RefreshGridControl2();
        }


        //初始化GridControl1
        public void RefreshGridControl1()
        {
            this.companyBindingSource1.DataSource = this.GetTable();
        }

        //初始化GridControl2
        public void RefreshGridControl2()
        {
            this.companyBindingSource2.DataSource = this.GetList();
        }


        //DataView1中的选中行改变事件
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // this.companyBindingSource.EndEdit();
            //若是我们编辑了Datarow则需要执行EndEdit()方可获取修改后的数据
            //这里我们companBindingSource绑定的数据是Datatable,所以Current当前数据是一个DataRowView
            //若是数据源绑定的是一个List<T>则，Current当前数据是一个T对象
            DataRowView dataRowView = this.companyBindingSource1.Current as DataRowView;
            if (null == dataRowView)
            {
                return;
            }

            DataRow dataRow = dataRowView.Row;
            MessageBox.Show(dataRow["Name"].ToString());
        }

        //DataView2中的选中行改变事件：我们可以使用另外一张实现方法
        //选中行改变，就是数据源的Current属性值发生改变
        private void companyBindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            Company company = this.companyBindingSource2.Current as Company;
            if (null == company)
            {
                return;
            }
            MessageBox.Show(company.Name);

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


    }
}
