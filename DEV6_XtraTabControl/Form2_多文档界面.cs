using DevExpress.XtraTab;
using System;
using System.Windows.Forms;

namespace DEV6_XtraTabControl
{
    public partial class Form2_多文档界面 : Form
    {
        /// <summary>
        /// 1. 我们的目的是使用TabControl实现一个多文档窗口界面
        /// 2. 首先我们可以设置TabControl的ClosePageButtonShowModel属性，设置为InAllTabPageHeaders，则每一个页签都显示关闭窗口
        /// 注意需要同时实现关闭事件方有效：xtraTabControl1_CloseButtonClick
        /// 若是我们期望第一个页面一直保留，作为首页面，禁止关闭，设置ShowColseButton：False
        /// </summary>

        public Form2_多文档界面()
        {
            InitializeComponent();
        }


        //新建按钮点击事件
        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string text = e.Item.Caption;//按钮的caption
            foreach (XtraTabPage tabPage in xtraTabControl1.TabPages)
            {
                if (tabPage.Text == text)
                {
                    xtraTabControl1.SelectedTabPage = tabPage;
                    return;
                }
            }

            Form21 form21 = new Form21
            {
                Visible = true,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized,
                TopLevel = false
            };

            XtraTabPage page = new XtraTabPage();
            page.Controls.Add(form21);
            page.Text = text;
            xtraTabControl1.TabPages.Add(page);
            xtraTabControl1.SelectedTabPage = page;

        }


        //页签关闭按钮的点击事件
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            int pageindex = 0;
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs EArg = (DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e;
            string name = EArg.Page.Text;//得到关闭的选项卡的text
            if (name == "首页")
            {
                return;
            }

            foreach (XtraTabPage page in xtraTabControl1.TabPages)//遍历得到和关闭的选项卡一样的Text
            {

                if (page.Text == name)
                {
                    pageindex = page.TabIndex;
                    xtraTabControl1.TabPages.Remove(page);

                    foreach (Control t in page.Controls)
                    {
                        if (t is System.Windows.Forms.Form)
                        {
                            (t as Form).Close();
                            (t as Form).Dispose();//这里手动释放窗口资源
                            /// 在以下两种情况下调用 Close 不会释放窗体：
                            /// (1) 窗体是多文档界面(MDI) 应用程序的一部分且是不可见的；
                            /// (2) 您是使用 ShowDialog 显示的该窗体。在这些情况下，需要手动调用 Dispose 来将窗体的所有控件都标记为需要进行垃圾回收。
                        }
                    }
                    page.Dispose();
                    xtraTabControl1.SelectedTabPageIndex = pageindex - 1;
                    return;
                }
            }
        }
    }
}
