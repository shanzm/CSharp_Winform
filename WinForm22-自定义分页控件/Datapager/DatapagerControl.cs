using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatapagerData
{
    public partial class DatapagerData : UserControl
    {
        public DatapagerData()
        {
            InitializeComponent();
        }

        #region 变量定义
        private int datapager_totalCount = 0;//总数据个数
        private int datapager_pageCount = 0;//总页数
        private int datapager_currentPageCount = 0;//当前页数据记录数
        private int datapager_currentPageIndex = 1;//当前页索引
        private int datapager_pageSize = 10;//每页分页大小
        private int datapager_yuShu = 0;//最后一页剩余个数
        private DataGridView datapager_dataGirdView = null;
        private string datapager_connStr = "";//数据库连接字符串
        private string datapager_tableName = "";//DataGridViewd要绑定的表名
        private string datapager_condition = "";//存储过程筛选条件
        private string datapager_procSplitPageName = "";//DataGridViewd要绑定的分页存储过程名称
        private string datapager_procQueryTableRecordCountName = "";//DataGridViewd要绑定的数据个数查询存储过程名称
        private bool datapager_isAutoUpdateLabelTip = true;//获取或设置是否自动更新分页标签内容提示，默认为true
        #endregion

        #region 控件事件定义
        //[Category("Datapager"), Description("【上一页，<<】点击事件")]
        //public event EventHandler lbForwardClick;

        //[Category("Datapager"), Description("【下一页，>>】点击事件")]
        //public event EventHandler lbNextClick;

        //[Category("Datapager"), Description("【最后一页，>>|】点击事件")]
        //public event EventHandler lbLastClick;

        //[Category("Datapager"), Description("【首页，|<<】点击事件")]
        //public event EventHandler lbFirstClick;

        //[Category("Datapager"), Description("【显示记录数】修改事件")]
        //public event EventHandler txtPageCountKeyPress;

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbFirst_Click(object sender, EventArgs e)
        {
            datapager_currentPageIndex = 1;
            Datapager_initDataGirdView();
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbForward_Click(object sender, EventArgs e)
        {
            if (datapager_currentPageIndex <= datapager_pageCount && datapager_currentPageIndex != 1)
                datapager_currentPageIndex--;
            Datapager_initDataGirdView();
            if (Datapager_IsAutoUpdateLabelTip)
                Datapager_updateSplitPageLabelTip();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbNext__Click(object sender, EventArgs e)
        {
            if (datapager_currentPageIndex < datapager_pageCount && datapager_currentPageIndex != datapager_pageCount)
                datapager_currentPageIndex++;
            Datapager_initDataGirdView();
            if (Datapager_IsAutoUpdateLabelTip)
                Datapager_updateSplitPageLabelTip();
        }

        /// <summary>
        /// 末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbLast_Click(object sender, EventArgs e)
        {
            datapager_currentPageIndex = datapager_pageCount;
            Datapager_initDataGirdView();
        }
        #endregion

        #region 修改每页显示数据
        /// <summary>
        /// 修改每页显示数据
        /// </summary>
        private void txtPageCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    datapager_pageSize = Convert.ToInt32(this.txtPageCount.Text);
                }
                catch (FormatException ex)
                {
                    //MessageBox.Show("输入每页数量必须为整数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPageCount.Text = datapager_pageSize.ToString();//输入非整数则直接给转为默认值
                }
                calcPageInfo();
                Datapager_initDataGirdView();
                lbFirst_Click(sender,e);//跳转到首页
            }
        }
        #endregion

        #region 属性定义
        /// <summary>
        /// 分页控件使用的存储过程所需要的连接字符串
        /// </summary>
        [Category("Datapager"), Description("分页控件使用的连接字符串"), Browsable(true)]
        public string Datapager_Connstr
        {
            get { return datapager_connStr; }
            set { datapager_connStr = value; }
        }

        /// <summary>
        /// 获取或设置是否自动更新分页标签内容提示，默认为true，false：不自动更新，可由开发者自行获取数据设置
        /// </summary>
        [Category("Datapager"), Description("获取或设置是否自动更新分页标签内容提示，默认为true，false：不自动更新，可由开发者自行获取数据设置"), Browsable(true)]
        public bool Datapager_IsAutoUpdateLabelTip
        {
            get { return datapager_isAutoUpdateLabelTip; }
            set { datapager_isAutoUpdateLabelTip = value; }
        }

        /// <summary>
        /// 获取或设置DataGridViewd要绑定的表名
        /// </summary>
        [Category("Datapager"), Description("获取或设置DataGridViewd要绑定的表名"), Browsable(true)]
        public string Datapager_tableName
        {
            get { return datapager_tableName; }
            set { datapager_tableName = value; }
        }

        /// <summary>
        /// 存储过程筛选条件
        /// </summary>
        [Category("Datapager"), Description("筛选条件"), Browsable(true)]
        public string Datapager_condition
        {
            get { return datapager_condition; }
            set { datapager_condition = value; }
        }

        /// <summary>
        /// 获取或设置DataGridViewd要绑定的分页存储过程名称
        /// </summary>
        [Category("Datapager"), Description("获取或设置DataGridViewd要绑定的分页存储过程名称"), Browsable(true)]
        public string Datapager_procSplitPageName
        {
            get { return datapager_procSplitPageName; }
            set { datapager_procSplitPageName = value; }
        }

        /// <summary>
        /// 获取或设置DataGridViewd要绑定的数据个数查询存储过程名称
        /// </summary>
        [Category("Datapager"), Description("获取或设置DataGridViewd要绑定的数据个数查询存储过程名称"), Browsable(true)]
        public string Datapager_procQueryTableRecordCountName
        {
            get { return datapager_procQueryTableRecordCountName; }
            set { datapager_procQueryTableRecordCountName = value; }
        }

        /// <summary>
        /// 获取或设置DataGridViewd对象
        /// </summary>
        [Category("Datapager"), Description("获取或设置DataGridViewd对象"), Browsable(true)]
        public DataGridView Datapager_DataGridView
        {
            get { return datapager_dataGirdView; }
            set { datapager_dataGirdView = value; }
        }

        /// <summary>
        /// 获取或设置分页提示标签内容
        /// </summary>
        [Category("Datapager"), Description("获取或设置分页提示标签内容"), Browsable(true)]
        public string Datapager_LbInfo
        {
            get { return lbInfo.Text; }
            set
            {
                lbInfo.Text = value.ToString();
            }
        }

        /// <summary>
        /// 获取总数据个数控价对象
        /// </summary>
        [Category("Datapager"), Description("总数据个数控价对象"), Browsable(false)]
        public TextBox Datapager_TxtPageCount
        {
            get { return txtPageCount; }
        }

        /// <summary>
        /// 获取或设置总数据个数
        /// </summary>
        [Category("Datapager_Field"), Description("获取或设置总数据个数"), Browsable(true)]
        public int Datapager_TotalCount
        {
            get { return datapager_totalCount; }
            set { datapager_totalCount = value; }
        }

        /// <summary>
        /// 获取或设置总页数
        /// </summary>获取或设置
        [Category("Datapager_Field"), Description("获取或设置总页数"), Browsable(true)]
        public int Datapager_PageCount
        {
            get { return datapager_pageCount; }
            set { datapager_pageCount = value; }
        }

        /// <summary>
        /// 获取或设置每页分页大小
        /// </summary>
        [Category("Datapager_Field"), Description("获取或设置每页分页大小"), Browsable(true)]
        public int Datapager_PageSize
        {
            get { return datapager_pageSize; }
            set
            {
                datapager_pageSize = value;
                txtPageCount.Text = value.ToString();
            }
        }

        /// <summary>
        /// 获取或设置当前页数据记录数
        /// </summary>
        [Category("Datapager_Field"), Description("获取或设置当前页数据记录数"), Browsable(true)]
        public int Datapager_CurrentPageCount
        {
            get { return datapager_currentPageCount; }
            set { datapager_currentPageCount = value; }
        }

        /// <summary>
        /// 获取或设置当前页索引
        /// </summary>
        [Category("Datapager_Field"), Description("获取或设置当前页索引"), Browsable(true)]
        public int Datapager_CurrentPageIndex
        {
            get { return datapager_currentPageIndex; }
            set { datapager_currentPageIndex = value; }
        }

        /// <summary>
        /// 获取或设置最后一页剩余个数
        /// </summary>
        [Category("Datapager_Field"), Description("获取或设置最后一页剩余个数"), Browsable(true)]
        public int Datapager_YuShu
        {
            get { return datapager_yuShu; }
            set { datapager_yuShu = value; }
        }
        #endregion

        #region 调用存储过程（分页存储过程）初始化dataGirdView
        /// <summary>
        /// 调用存储过程（分页存储过程）初始化dataGirdView
        /// </summary>
        /// <param name="tableName">要绑定的表名</param>
        /// <param name="procSplitPageName">分页查询的存储过程名称:p_splitPage</param>
        /// <param name="procQueryTableRecordCountName">查询数据个数的存储过程名称:p_queryTableRecordCount</param>
        public void Datapager_initDataGirdView()
        {
            //#region szm：这里我补充，使之每页多少行行之有效
            //try
            //{
            //    datapager_pageSize = Convert.ToInt32(this.txtPageCount.Text);
            //}
            //catch (FormatException ex)
            //{
            //    MessageBox.Show("输入每页数量必须为整数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.txtPageCount.Text = datapager_pageSize.ToString();
            //}
            //#endregion


            if (Datapager_tableName.Length == 0)
            {
                MessageBox.Show("initDataGirdView方法未指定表名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlParameter[] sp = new SqlParameter[] {
                     new SqlParameter("@pageSize",datapager_pageSize),
                     new SqlParameter("@currentPage",datapager_currentPageIndex),
                     new SqlParameter("@tableName",Datapager_tableName),
                     new SqlParameter ("@condition",Datapager_condition)
                };
                datapager_dataGirdView.DataSource = dgvData.invokeProc_DataTable(Datapager_Connstr, Datapager_procSplitPageName, sp);

                #region dataGridView相关属性设置【抛出，不在此设置】
                //// 设置 dataGridView1 的第1列整列单元格为只读
                //dataGirdView.Columns[0].ReadOnly = true;
                //// 设定包括Header和所有单元格的列宽自动调整
                //dataGirdView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //// 设定包括Header和所有单元格的行高自动调整
                //dataGirdView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                #endregion

                //查询表记录数
                Datapager_queryDataCount();

                calcPageInfo();
            }
        }
        #endregion

        #region 调用存储过程查询表记录数
        /// <summary>
        /// 调用存储过程查询表记录数
        /// </summary>
        private void Datapager_queryDataCount()
        {
            if ((Datapager_tableName != null && Datapager_tableName.Trim().Length != 0) && (Datapager_procQueryTableRecordCountName != null && Datapager_procQueryTableRecordCountName.Trim().Length != 0))
            {
                //查询表记录数
                SqlParameter[] sp = new SqlParameter[] {
                    new SqlParameter("@tableName", Datapager_tableName) ,
                    new SqlParameter("@condition",Datapager_condition)};
                object flag = dgvData.invokeProc_ExecuteScalar(Datapager_Connstr, Datapager_procQueryTableRecordCountName, sp);
                datapager_totalCount = Convert.ToInt32(flag);
            }
            else
            {
                MessageBox.Show("queryDataCount参数有误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 计算页信息，当前页/总共页
        /// <summary>
        /// 当前页/总共页
        /// </summary>
        public void Datapager_updateSplitPageLabelTip()
        {
            //lbInfo.Text = "总共" + Datapager_pageCount + "页" + "，当前第：" + Datapager_currentPageIndex + "页，其中最后一页有" + Datapager_yuShu + "条数据";
            lbInfo.Text = "当前/总共：" + datapager_currentPageIndex + "/" + datapager_pageCount + "页";
        }

        /// <summary>
        /// 计算页信息
        /// </summary>
        /// <param name="totalCount">总记录数</param>
        /// <param name="pageSize">每页要显示的条数</param>
        private void calcPageInfo()
        {
            datapager_pageCount = datapager_totalCount /datapager_pageSize; //取模
            datapager_yuShu = datapager_totalCount % datapager_pageSize;//取余
            if (datapager_yuShu > 0)
            {
                datapager_pageCount++;
            }
            Console.WriteLine("页大小：" + datapager_pageSize);
            Console.WriteLine("当前页索引：" + datapager_currentPageIndex);
            Console.WriteLine("pageCount：" + datapager_totalCount + " / " + datapager_pageSize + "=" + datapager_pageCount);
            Console.WriteLine("yuShu：" + datapager_totalCount + " % " + datapager_pageSize + "=" + datapager_yuShu);
            //Console.WriteLine("总共" + Datapager_pageCount + "页" + "，当前第：" + Datapager_currentPageIndex + "页，其中最后一页有" + Datapager_yuShu + "条数据");
            Console.WriteLine("当前/总共：" + datapager_currentPageIndex + "/" + datapager_pageCount + "页");
            if (Datapager_IsAutoUpdateLabelTip)
                Datapager_updateSplitPageLabelTip();
        }
        #endregion

    }
}
