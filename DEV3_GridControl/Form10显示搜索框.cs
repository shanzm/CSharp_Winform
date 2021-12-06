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
    public partial class Form10显示搜索框 : Form
    {
        public Form10显示搜索框()
        {
            InitializeComponent();
            this.gridControl1.DataSource = GetList();
        }

        //显示隐藏分组框
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.gridView1.OptionsView.ShowGroupPanel = !this.gridView1.OptionsView.ShowGroupPanel;
        }
       //显示隐藏搜索框
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //this.gridView1.IsFindPanelVisible=!this.gridView1.is
            this.gridView1.OptionsFind.AlwaysVisible = !this.gridView1.OptionsFind.AlwaysVisible;
            //this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.ClearFindOnClose = true;
            //this.gridView1.OptionsFind.ShowCloseButton = true;
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
