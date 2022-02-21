using System;
using System.Windows.Forms;

namespace TestPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitDataGirdView();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
         InitDataGirdView(  $"Name='{this.cmbName.SelectedItem}'" );
        }



        /// <summary>
        /// 刷新DataGridView
        /// </summary>
        /// <param name="condition">筛选条件，格式："字段名='value'"</param>
        private void InitDataGirdView(string condition="")
        {
            //指定控件对象
            dgvPageControl1.Datapager_DataGridView = dataGridView1;

            //可以在代码中设置dataGirdView控件属性，也可以在【属性】窗格设置
            dgvPageControl1.Datapager_Connstr = "Data Source=.;DataBase=zcgl;uid=sa;pwd=123456";
            dgvPageControl1.Datapager_tableName = "UserInfo";
            dgvPageControl1.Datapager_procQueryTableRecordCountName = "p_queryTableRecordCount";
            dgvPageControl1.Datapager_procSplitPageName = "p_splitPage";
            dgvPageControl1.Datapager_condition = condition;

            //调用控件方法，绑定数据
            dgvPageControl1.Datapager_initDataGirdView();

            // 设置 dataGridView1 的第1列整列单元格为只读
            dgvPageControl1.Datapager_DataGridView.Columns[0].ReadOnly = true;
            // 设定包括Header和所有单元格的列宽自动调整
            dgvPageControl1.Datapager_DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // 设定包括Header和所有单元格的行高自动调整
            dgvPageControl1.Datapager_DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
    }
}


#region 分页需要的两个存储过程
//CREATE PROC[dbo].[p_queryTableRecordCount]
//(
//   @tableName VARCHAR(20),
//    @condition VARCHAR(MAX)= ''
//)
//AS
//BEGIN
//    DECLARE @sqlCommand VARCHAR(MAX) = 'SELECT COUNT(*) AS 总记录数 FROM {@TableName} WHERE 1=1 AND	{@Conndition}';
//SET @sqlCommand = REPLACE(@sqlCommand, '{@TableName}', @tableName);
//SET @sqlCommand = REPLACE(@sqlCommand, '{@Conndition}', CASE  @condition WHEN '' THEN '1=1' ELSE @condition END)

//    EXEC (@sqlCommand);
//END;
//GO



//CREATE PROC[dbo].[p_splitpage]
//(
//   @pageSize VARCHAR(50),
//    @currentPage VARCHAR(50),
//    @tableName VARCHAR(50),
//    @condition VARCHAR(MAX) = ''
//) --创建存储过程，定义三个变量 '每页显示的条数'、'当前页'、‘表名’
//AS
//BEGIN
//    DECLARE @sqlcommand VARCHAR(MAX)
//        = 'select  top {@pageSize} * from 
//            (select ROW_NUMBER() over(order by id desc) as rowid, *from { @tableName}
//where 1 = 1 and
//{ @condition})as A

//            where rowid > ({@pageSize})*({ @currentPage}
//-1)';
//    SET @sqlcommand = REPLACE(@sqlcommand, '{@pageSize}', @pageSize);
//SET @sqlcommand = REPLACE(@sqlcommand, '{@tableName}', @tableName);
//SET @sqlcommand = REPLACE(@sqlcommand, '{@condition}', CASE  @condition WHEN '' THEN '1=1' ELSE @condition END);
//SET @sqlcommand = REPLACE(@sqlcommand, '{@currentPage}', @currentPage);
//EXEC(@sqlcommand);
//END;
//--测试：
//--EXEC p_splitpage '10','1','tb_zcgl','djry=''szm'''--分号转义在其前面加一个分号
//GO
#endregion