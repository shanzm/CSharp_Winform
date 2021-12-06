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
    public partial class Form9_上移和下移 : Form
    {
        public Form9_上移和下移()
        {
            InitializeComponent();
        }


        private void Form9_上移和下移_Load(object sender, EventArgs e)
        {
            //错误示例：
            //OrderBy后返回的是 IEnumerable<Company>,在获取的时候，是无法直接as 成List<Company>
            //this.gridControl1.DataSource = GetList().OrderBy(n => n.SortNo);
            this.gridControl1.DataSource = GetList().OrderBy(n => n.SortNo).ToList();
        }

        //光标下移
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //当前光标所在行的索引
            int oldIndex = this.gridView1.GetFocusedDataSourceRowIndex();  //companies.IndexOf(this.gridView1.rowindex);
            MessageBox.Show($"当前的光标索引{oldIndex.ToString()}");
            //光标下移
            this.gridView1.MoveNext();
            //获取当前光标所在行的实体对象
            int selectRow = this.gridView1.GetSelectedRows()[0];
            //因为我们绑定的是对象集合，所以无法使用以下方法
            //DataRow dataRow = gridView1.GetDataRow(selectRow);
            //MessageBox.Show(dataRow["Name"].ToString());

            string name = this.gridView1.GetRowCellValue(selectRow, "Name").ToString();
            MessageBox.Show(name);


        }

        //光标上移动
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //当前光标所在行的索引
            int oldIndex = this.gridView1.GetFocusedDataSourceRowIndex();  //companies.IndexOf(this.gridView1.rowindex);
            MessageBox.Show($"当前的光标索引{oldIndex.ToString()}");
            //光标上移
            this.gridView1.MovePrev();
            int newIndex = this.gridView1.GetFocusedDataSourceRowIndex();  //companies.IndexOf(this.gridView1.rowindex);
        }

        //数据下移
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.gridView1.CloseEditForm();

            List<Company> companies = this.gridView1.DataSource as List<Company>;
            int currentIndex = this.gridView1.GetFocusedDataSourceRowIndex();
            //MessageBox.Show($"当前的光标索引{oldIndex.ToString()}：{companies[oldIndex].Name}");

            if (currentIndex >= companies.Count - 1)
            {
                return;
            }
            //临时变量保存当前数据
            Company CompanyTemp = companies[currentIndex];

            companies[currentIndex] = companies[currentIndex + 1];

            companies[currentIndex + 1] = CompanyTemp;
            this.gridView1.MoveNext();

            this.gridView1.RefreshData();
        }

        //数据上移
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.gridView1.CloseEditForm();

            List<Company> companies = this.gridView1.DataSource as List<Company>;
            int currentIndex = this.gridView1.GetFocusedDataSourceRowIndex();
            //MessageBox.Show($"当前的光标索引{oldIndex.ToString()}：{companies[oldIndex].Name}");

            if (currentIndex ==0)
            {
                return;
            }
            //临时变量保存当前数据
            Company CompanyTemp = companies[currentIndex];

            companies[currentIndex] = companies[currentIndex - 1];

            companies[currentIndex - 1] = CompanyTemp;
            this.gridView1.MovePrev();

            this.gridView1.RefreshData();
        }

        public List<Company> GetList()
        {
            List<Company> companies = new List<Company>()
            {
              new Company (){Id=1,Name="食品公司",Address="人民路",LegelPerson="张三",SortNo=1 },
              new Company (){Id=2,Name="服装公司",Address="中山路",LegelPerson="李四",SortNo=2},
              new Company (){Id=3,Name="建筑公司",Address="青年路",LegelPerson="王五",SortNo=3}
            };
            return companies;
        }


    }
}
