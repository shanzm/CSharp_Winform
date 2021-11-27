using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev8_Ribbon
{
    //图标来源：https://thenounproject.com/

    public partial class Form3_XtralTabControl : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form3_XtralTabControl()
        {
            InitializeComponent();
        }
        private void Form3_XtralTabControl_Load(object sender, EventArgs e)
        {
            InitDate();
        }


        #region 初始化数据
        void InitDate()
        {
            //初始化日期
            this.barStaticItem1.Caption = "当前日期" + DateTime.Today.ToString("yyyy年MM月dd日") + "    " + DateTime.Today.DayOfWeek.ToString();

            //初始化选中页面
            //this.ribbonControl1.SelectedPage = ribbonPage2;

            //默认折叠ribbon
            //this.ribbonControl1.Minimized = true;
        }

        #endregion

        //选中的页面切换事件
        private void ribbonControl1_SelectedPageChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("test_selectedpage");
        }

        //页面1-创建分组-创建按钮点击事件
        private void barBtnCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TabControlHelper.AddTabPage(e.Item.Caption, xtraTabControl1);

        }

        //页签关闭按钮
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            TabControlHelper.CloseTabPage(xtraTabControl1, e);
        }


        private void barBtnLink_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.baidu.com");
        }



        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            TabControlHelper.AddTabPage("新建", xtraTabControl1);
        }
    }

    //TabControl辅助类
    //用于创建一个页面和关闭一个页面
    public static class TabControlHelper
    {

        /// <summary>
        /// 给指定的XtralTabControl控件添加一个名为tabPageCaption的页面
        /// </summary>
        /// <param name="tabPageCaption">页面的名称</param>
        /// <param name="xtraTabControl">XtraTabControl控件</param>
        public static void AddTabPage(string tabPageCaption, XtraTabControl xtraTabControl)
        {
            string text = tabPageCaption;//按钮的caption
            foreach (XtraTabPage tabPage in xtraTabControl.TabPages)
            {
                if (tabPage.Text == text)
                {
                    xtraTabControl.SelectedTabPage = tabPage;
                    return;
                }
            }

            ChildForm childForm = new ChildForm
            {
                Visible = true,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized,
                TopLevel = false
            };

            XtraTabPage page = new XtraTabPage();
            page.Controls.Add(childForm);
            page.Text = text;
            xtraTabControl.TabPages.Add(page);
            xtraTabControl.SelectedTabPage = page;
        }


        /// <summary>
        /// 点击页面上的关闭按钮，关闭指定XtraTabControl控件的页面
        /// </summary>
        /// <param name="xtraTabControl">XtraTabControl控件</param>
        /// <param name="e">页签自带的关闭按钮</param>
        public static void CloseTabPage(XtraTabControl xtraTabControl, EventArgs e)
        {
            int pageindex = 0;
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs EArg = (DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e;
            string name = EArg.Page.Text;//得到关闭的选项卡的text
            if (name == "首页")
            {
                return;
            }

            foreach (XtraTabPage page in xtraTabControl.TabPages)//遍历得到和关闭的选项卡一样的Text
            {

                if (page.Text == name)
                {
                    pageindex = page.TabIndex;
                    xtraTabControl.TabPages.Remove(page);

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
                    xtraTabControl.SelectedTabPageIndex = pageindex - 1;
                    return;
                }
            }
        }
    }
}

