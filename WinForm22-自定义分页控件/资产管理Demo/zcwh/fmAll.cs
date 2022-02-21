using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatapagerData;

namespace zcgl.zcwh
{
    public partial class fmAll : Form
    {
        zcgl.myclass.operation oper = new zcgl.myclass.operation();  //加载操作类
        public fmAll()
        {
            InitializeComponent();
        }

        #region 加载dgv数据
        /// <summary>
        /// 加载dgv数据
        /// </summary>
        private void fmAll_Load(object sender, EventArgs e)
        {
            //指定控件对象
            dgvPageControl1.Datapager_DataGridView = dataGridView1;

            //可以在代码中设置dataGirdView控件属性，也可以在【属性】窗格设置
            dgvPageControl1.Datapager_Connstr = "Data Source=.;DataBase=zcgl;uid=sa;pwd=123456";
            dgvPageControl1.Datapager_tableName = "tb_zcgl";
            dgvPageControl1.Datapager_procQueryTableRecordCountName = "p_queryTableRecordCount";
            dgvPageControl1.Datapager_procSplitPageName = "p_splitPage";

            //调用控件方法，绑定数据
            dgvPageControl1.Datapager_initDataGirdView();

            // 设置 dataGridView1 的第1列整列单元格为只读
            dgvPageControl1.Datapager_DataGridView.Columns[0].ReadOnly = true;
            // 设定包括Header和所有单元格的列宽自动调整
            dgvPageControl1.Datapager_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // 设定包括Header和所有单元格的行高自动调整
            dgvPageControl1.Datapager_DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }
        #endregion
    }
}
