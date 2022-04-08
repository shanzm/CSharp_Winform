using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WORKALERT;

namespace DevGridController分页
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int curPage = 1;
        public int pageSize = 100;
        public int allpage = 1000;

        public void ExportEvents(bool singlePage)     
        {
            //导出GridControl代码写在这。
        }
        public void RefreshGridList()
        {
            FillGridListCtrlQuery(curPage);//自己实现FillGridListCtrlQuery函数。      
        }
        private void FillGridListCtrlQuery(int curPage = 1)
        {
            gridControl1.DataSource = new DataTable();//WebService.Pager(。。。。。//显示分页结果
            mgncPager1.RefreshPager(pageSize, allpage, curPage);//更新分页控件显示。
        }
        private void MyPagerEvents(int curPage, int pageSize)
        {
            this.curPage = curPage;
            this.pageSize = pageSize;
            FillGridListCtrlQuery(curPage);
        }
        private void mgncPager1_Load(object sender, EventArgs e)
        {
            mgncPager1.myPagerEvents += new MgncPager.MyPagerEvents(MyPagerEvents);
            mgncPager1.exportEvents += new MgncPager.ExportEvents(ExportEvents);
            RefreshGridList();
        }
    }
}
