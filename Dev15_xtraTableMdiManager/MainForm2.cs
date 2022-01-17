using DevExpress.Utils;

namespace Dev15_xtraTableMdiManager
{
    public partial class MainForm2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static DefaultForm defaultForm = null;
        private static ChildrenForm1 childrenForm1 = null;
        private static ChildrenForm2 childrenForm2 = null;
        public MainForm2()
        {
            InitializeComponent();
            InitDefaultForm();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (childrenForm1 == null || childrenForm1.IsDisposed)
            {
                childrenForm1 = new ChildrenForm1();
            }
            else
            {
                //让已经打开的窗体获取焦点
                childrenForm1.Activate();
            }

            childrenForm1.MdiParent = this;
            childrenForm1.Show();
        }


        //初始化默认首页吗
        private void InitDefaultForm()
        {
            if (defaultForm == null || defaultForm.IsDisposed)
            {
                defaultForm = new DefaultForm();
            }
            else
            {
                //让已经打开的窗体获取焦点
                defaultForm.Activate();
            }


            defaultForm.MdiParent = this;
            defaultForm.Show();
            //第一个页面不显示关闭按钮
            xtraTabbedMdiManager1.Pages[0].ShowCloseButton = DefaultBoolean.False;
        }


        //新建子窗口1
        public static ChildrenForm2 GetWindow()
        {
            if (childrenForm2 == null || childrenForm2.IsDisposed)
            {
                childrenForm2 = new ChildrenForm2();
            }
            else
            {
                //让已经打开的窗体获取焦点
                childrenForm2.Activate();
            }
            return childrenForm2;
        }


        //新建子窗口2
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildrenForm2 childrenForm2 = MainForm.GetWindow();
            childrenForm2.MdiParent = this;
            childrenForm2.Show();
        }
    }
}
