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
    #region 说明
    /// 参考：https://blog.csdn.net/u011421608/article/details/44413217
    /// 1. 我们数据源添加一个bool类型的IsChecked
    /// 2.设置该列为ColumnEdit为CheckEidt列
    /// 3. 拖动一个CheckEdit控件放在该复选框列的列头，做全选功能：注意调整其位置Anchor:Top,Right
    #endregion


    public partial class Form7第一列展示复选框 : Form
    {
        public Form7第一列展示复选框()
        {
            InitializeComponent();
            RefreshGridView();
        }



        #region 数据源
        private void RefreshGridView()
        {
            List<Company> companies = new List<Company>()
            {
                new Company (){Id=1,Name="小米",Address="北京",LegelPerson="雷军"},
                new Company (){Id=2,Name="华为",Address="深圳",LegelPerson="任正非",IsChecked=true },
                new Company (){Id=3,Name="魅族",Address="深圳",LegelPerson="黄章" },
                new Company (){Id=1,Name="小米",Address="北京",LegelPerson="雷军"}
            };

            this.companyBindingSource.DataSource = companies;
        }
        #endregion


        //全选框
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if ((bool)checkEdit1.EditValue==true)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["IsChecked"],true);
                }
            }
            else if((bool)checkEdit1.EditValue==false)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["IsChecked"], false);
                }
            }
            gridView1.RefreshData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.companyBindingSource.EndEdit();
            List<Company> companies = companyBindingSource.DataSource as List<Company>;
            MessageBox.Show(companies[2].IsChecked.ToString());
        }
    }
}
