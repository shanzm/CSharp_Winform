using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEV5_选中行右键操作
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }


        /// <summary>
        /// 绑定并刷新数据源
        /// </summary>
        public void BindDataSource()
        {
            List<Company> companies = new List<Company>()
            {
                new Company (){Id=1,Name="小米",Address="北京",LegelPerson="雷军"},
                new Company (){Id=2,Name="华为",Address="深圳",LegelPerson="任正非" },
                new Company (){Id=3,Name="魅族",Address="深圳",LegelPerson="黄章" }
            };

            //同时新增一个空白行，用于用户添加编辑
            companies.Add(new Company() { });


            //数据源是绑定的GridControl,GridView是GirdControl中一种显示数据的方式，GridView是最接近Datatable的样式

            this.gridControl_Company.DataSource = companies;
            //this.gridView_Company.PopulateColumns();
        }
        public class Company
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string LegelPerson { get; set; }
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得选中的行，如果是单选模式，则直接取第一个
            int selectRow =this.gridView_Company.GetSelectedRows()[0];
            //指定行和列属性名取单元格数据
            string name = this.gridView_Company.GetRowCellValue(selectRow, "Name").ToString();
            MessageBox.Show(name);
        }
    }


}
