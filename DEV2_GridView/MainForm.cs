using DevExpress.XtraGrid.Menu;
using System;
using System.Windows.Forms;


/// <summary>
/// 这个项目创建的时候是选择的DevExpress项目：DevExpressv18.1 Template Gallery
/// </summary>

namespace DEV2_GridView
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gridControl.DataSource = DbSource.GetUserList();//注意绑定数据是绑定到GridControl控件

            gridControl.ContextMenu = new ContextMenu();

            gvwUser.Columns[0].Visible = false;                        //隐藏指定的列（可以在Run Desiger中的Columns中设置Visible属性）
            gvwUser.OptionsBehavior.Editable = false;                  //禁止可编辑

            gvwUser.OptionsCustomization.AllowFilter = false;          //禁止过滤功能
            gvwUser.OptionsCustomization.AllowSort = false;            //禁止排序
            gvwUser.OptionsCustomization.AllowQuickHideColumns = false;//禁止隐藏列
            gvwUser.OptionsCustomization.AllowColumnMoving = false;    //禁止鼠标可以移动列
            gvwUser.OptionsCustomization.AllowGroup = false;           //取消分组功能

            //在GridView显示的Datatable上方有一行，用于拖动某列可以分组
            //gvwUser.OptionsView.ShowGroupPanel = false;              //隐藏分组依据框，否则默认是显示的


            gvwUser.OptionsView.EnableAppearanceEvenRow = true;         //奇偶行显示不同的颜色
            gvwUser.OptionsView.EnableAppearanceOddRow = true;

            //关于右键菜单栏
            //gvwUser.OptionsMenu.EnableColumnMenu = false;             //禁止列头的右键菜单栏
            //gvwUser.OptionsMenu.EnableGroupPanelMenu = false;         //禁止分组依据框的右键菜单栏
        }


        /// <summary>
        /// GridView列头右键菜单栏的选项的设置
        /// </summary>
        private void gvwUser_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)//判断是否是列标题的右键菜单
            {
                GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
                //menu.Items.RemoveAt(8);//移除右键菜单中的第7个功能，从0开始
                //menu.Items.Clear();//清除所有功能
                // string strDisp = 自己需要增加的右键信息
                // DXMenuItem dxm = new DXMenuItem();
                // dxm.Caption = strDisp;
                // menu.Items.Add(dxm);
            }
        }
    }
}
