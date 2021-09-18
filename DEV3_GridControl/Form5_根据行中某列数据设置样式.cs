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
    public partial class Form5_根据行中某列数据设置样式 : Form
    {
        public Form5_根据行中某列数据设置样式()
        {
            InitializeComponent();
        }


        private void Form5_根据行中某列数据设置样式_Load(object sender, EventArgs e)
        {
            RefershAll();
        }

        ///通过FromatRule设置GridView具有某个特征的行或单元个格的样式
        ///比如说这里设置了：当列Name值为“小米”的时候背景色为绿色

        private void RefershAll()
        {
            List<Company> companies = new List<Company>()
            {
                new Company (){Id=1,Name="小米",Address="北京",LegelPerson="雷军"},
                new Company (){Id=2,Name="华为",Address="深圳",LegelPerson="任正非" },
                new Company (){Id=3,Name="魅族",Address="深圳",LegelPerson="黄章" },
                new Company (){Id=1,Name="小米",Address="北京",LegelPerson="雷军"}
            };

            this.companyBindingSource.DataSource = companies;
        }

    }
}
