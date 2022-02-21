using System;
using System.Windows.Forms;

namespace zcgl
{
    public partial class fmLogin : Form
    {
        zcgl.myclass.operation operation = new zcgl.myclass.operation();  //加载操作类

        public fmLogin()
        {
            InitializeComponent();
        }

        #region 加载
        /// <summary>
        /// 加载
        /// </summary>
        private void fmLogin_Load(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;  //禁用记住密码
            txtzhanghao.TextChanged += new EventHandler(txtzhanghao_TextChanged);  //文本改变=清空提示
            txtmima.TextChanged += new EventHandler(txtmima_TextChanged);  //文本改变=清空提示
        }
        #endregion

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        private void btndenglu_Click(object sender, EventArgs e)
        {
            if (operation.Login1(txtzhanghao.Text).Tables[0].Rows.Count > 0)
            {
                if (operation.Login2(txtzhanghao.Text, txtmima.Text).Tables[0].Rows.Count > 0)
                {
                    //Program.cs中修改启动配置，解决关闭主页不会退出程序
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    label3.Text = "*密码错误！";
                    txtmima.Focus();
                    return;
                }
            }
            else
            {
                label3.Text = "*帐号不存在！";
                txtzhanghao.Focus();
                return;
            }        
        }
        #endregion

        #region 提示
        /// <summary>
        /// 文本改变=清空提示
        /// </summary>
        private void txtzhanghao_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "";
        }
        private void txtmima_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "";
        }
        #endregion

        #region 重置
        /// <summary>
        /// 重置
        /// </summary>
        private void btnchongzhi_Click(object sender, EventArgs e)
        {
            txtzhanghao.Text = "";
            txtmima.Text = "";
            txtzhanghao.Focus();
        }
        #endregion

        #region 注册
        /// <summary>
        /// 注册
        /// </summary>
        private void btnzhuce_Click(object sender, EventArgs e)
        {
            new fmRegister().ShowDialog();
        }
        #endregion

        #region 回车
        /// <summary>
        /// 回车换行、上下左右、回车登录
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!(ActiveControl is Button))
            {
                //账密正确，回车=登录
                if (operation.Login2(txtzhanghao.Text, txtmima.Text).Tables[0].Rows.Count > 0 && keyData == Keys.Enter)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                if (keyData == Keys.Down || keyData == Keys.Enter)  //↓或回车=下一行
                {
                    return this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
                else if (keyData == Keys.Up)  //↑=上一行
                {
                    return this.SelectNextControl(this.ActiveControl, false, true, true, true);
                }
                return false;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        #endregion

    }
}
