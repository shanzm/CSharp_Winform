using System;
using System.Windows.Forms;
using System.Drawing;

namespace zcgl
{
    public partial class fmRegister : Form
    {
        //加载操作类
        zcgl.myclass.operation operation = new zcgl.myclass.operation();
        zcgl.myclass.random yanzhengma = new zcgl.myclass.random(4, zcgl.myclass.random.CodeType.Numbers);

        public fmRegister()
        {
            InitializeComponent();
        }

        #region 加载
        /// <summary>
        /// 加载
        /// </summary>
        private void fmRegister_Load(object sender, EventArgs e)
        {
            //用户协议未实现，暂时屏蔽
            checkBox1.Enabled = false;

            //加载4位验证码
            pictureBox1.Image = Bitmap.FromStream(yanzhengma.CreateCheckCodeImage());
            pictureBox1.Text = yanzhengma.CheckCode;

            //帐号改值，去掉提示
            this.txtzhanghao.TextChanged += new EventHandler(txtzhanghao_TextChanged);
            this.txtmima.TextChanged += new EventHandler(txtmima_TextChanged);
            this.txtquerenmima.TextChanged += new EventHandler(txtquerenmima_TextChanged);
            this.txtnicheng.TextChanged += new EventHandler(txtnicheng_TextChanged);
            this.txtyanzhengma.TextChanged += new EventHandler(txtyanzhengma_TextChanged);
        }
        #endregion

        #region 注册
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="LoginSystem1">验证帐号是否存在</param>
        /// <param name="LoginSystem2">验证帐密是否正确</param>
        /// <returns></returns>
        private void btnzhuce_Click(object sender, EventArgs e)
        {
            if (operation.Login1(txtzhanghao.Text).Tables[0].Rows.Count > 0)
            {
                tszh.Text = "帐号已存在！";
                txtzhanghao.Focus();
                return;
            }
            else
            {
                //校验帐号
                if (operation.jiaoyan1(txtzhanghao.Text))
                {
                    tszh.Text = "帐号：1-20位(英文、数字、下划线)";
                    this.txtzhanghao.Focus();
                    return;
                }

                //校验密码
                if (operation.jiaoyan1(txtmima.Text))
                {
                    tsmm.Text = "密码：1-20位(英文、数字、下划线)";
                    this.txtmima.Focus();
                    return;
                }
                if (txtquerenmima.Text != txtmima.Text)
                {
                    tsqrmm.Text = "确认密码与密码不一致！";
                    this.txtquerenmima.Focus();
                    return;
                }

                //校验昵称
                if (txtnicheng.TextLength > 20)
                {
                    tsnc.Text = "昵称：最多20个字！";
                    this.txtnicheng.Focus();
                    return;
                }

                //校验验证码
                if (!this.txtyanzhengma.Text.Equals(pictureBox1.Text))
                {
                    tsyzm.Text = "验证码错误！";
                    this.txtyanzhengma.Focus();
                    return;
                }

                if (operation.Register(txtzhanghao.Text,txtmima.Text,txtnicheng.Text).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("注册成功！", this.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册失败，请检查网络或联系管理员！", this.Text);
                    return;
                }
            }
        }
        #endregion

        #region 提示
        /// <summary>
        /// 提示
        /// </summary>
        private void txtzhanghao_TextChanged(object sender, EventArgs e)
        {
            tszh.Text = "";
        }
        private void txtmima_TextChanged(object sender, EventArgs e)
        {
            tsmm.Text = "";
            tsqrmm.Text = "";
        }
        private void txtquerenmima_TextChanged(object sender, EventArgs e)
        {
            tsmm.Text = "";
            tsqrmm.Text = "";
        }
        private void txtnicheng_TextChanged(object sender, EventArgs e)
        {
            tsnc.Text = "";
        }
        private void txtyanzhengma_TextChanged(object sender, EventArgs e)
        {
            tsyzm.Text = "";
        }
        #endregion

        #region 返回
        /// <summary>
        /// 返回
        /// </summary>
        private void btnfanhui_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (keyData == Keys.Down || keyData == Keys.Enter)
                {
                    return this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
                else if (keyData == Keys.Up)
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
