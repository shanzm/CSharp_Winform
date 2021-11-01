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
            this.gridControl1.DataSource = GetList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //List<Company> companies = this.gridControl1.DataSource as List<Company>;
            //companies.IndexOf(this.gridView1.rowindex);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

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
    }
}
