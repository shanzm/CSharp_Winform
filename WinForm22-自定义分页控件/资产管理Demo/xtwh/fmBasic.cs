using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zcgl.xtwh
{
    public partial class fmBasic : Form
    {
        zcgl.myclass.operation oper = new zcgl.myclass.operation();
        private zcgl.fmMain.DelegateRefreshDGV tv;
        public fmBasic(zcgl.fmMain.DelegateRefreshDGV _tv)
        {
            InitializeComponent();
            this.tv = _tv;
        }

        private void fmBasic_Load(object sender, EventArgs e)
        {
            this.btnsybm_Click(sender, e);
        }

        #region 使用部门
        /// <summary>
        /// 使用部门显隐
        /// </summary>
        private void sybm(bool con)
        {
            this.comboBox1.Visible = con;
            this.label2.Visible = con;
        }
        /// <summary>
        /// 使用部门
        /// </summary>
        private void btnsybm_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = oper.Getsybm().Tables[0].DefaultView;
            listBox1.DisplayMember = "sybm";
            listBox1.ValueMember = "id";
            label1.Text = btnsybm.Text;
            sybm(false);
            txtname.Text = "";
            btntj.Enabled = true;
            btnsc.Enabled = true;
            btnbc.Enabled = true;
            btnqx.Enabled = false;
        }
        #endregion

        #region 保管人员
        /// <summary>
        /// 读取使用部门数据
        /// </summary>
        private void sybmComboBox()
        {
            comboBox1.DataSource = oper.Getsybm().Tables[0].DefaultView;
            comboBox1.ValueMember = "sybm";
        }
        /// <summary>
        /// 保管人员
        /// </summary>
        private void btnbgry_Click(object sender, EventArgs e)
        {
            sybm(true);
            this.sybmComboBox();
            listBox1.DataSource = oper.Getbgry().Tables[0].DefaultView;
            listBox1.DisplayMember = "bgry";
            listBox1.ValueMember = "id";
            label1.Text = btnbgry.Text;
            label2.Text = btnsybm.Text;
            txtname.Text = "";
            btntj.Enabled = true;
            btnsc.Enabled = true;
            btnbc.Enabled = true;
            btnqx.Enabled = false;
        }
        #endregion

        #region 使用情况
        /// <summary>
        /// 使用情况
        /// </summary>
        private void btnsyqk_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = oper.Getsyqk().Tables[0].DefaultView;
            listBox1.DisplayMember = "syqk";
            listBox1.ValueMember = "id";
            label1.Text = btnsyqk.Text;
            sybm(false);
            txtname.Text = "";
            btntj.Enabled = true;
            btnsc.Enabled = true;
            btnbc.Enabled = true;
            btnqx.Enabled = false;
        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        private void btntj_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtname.Focus();
            btntj.Enabled = false;
            btnsc.Enabled = false;
            btnbc.Enabled = true;
            btnqx.Enabled = true;
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        private void btnbc_Click(object sender, EventArgs e)
        {
            if (txtname.TextLength > 25)
            {
                MessageBox.Show("输入内容超出上限！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Focus();
                return;
            }
            if (txtname.Text == "")
            {
                MessageBox.Show("请输入名称！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Focus();
                return;
            }
            else
            {
                switch (label1.Text)
                {
                    case "使用部门":
                        int j = oper.Insertsybm(txtname.Text);
                        this.btnsybm_Click(sender, e);
                        break;
                    case "使用情况":
                        int ck = oper.Insertsyqk(txtname.Text);
                        this.btnsyqk_Click(sender, e);
                        break;
                    case "保管人员":
                        if (this.comboBox1.SelectedItem.ToString() == "")
                        {
                            MessageBox.Show("请选择部门！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.comboBox1.Focus();
                            return;
                        }
                        int co = oper.Insertbgry(txtname.Text, this.comboBox1.SelectedValue.ToString());
                        this.btnbgry_Click(sender, e);
                        break;
                }
                btntj.Enabled = true;
                btnsc.Enabled = true;
                btnbc.Enabled = true;
                btnqx.Enabled = false;
            }
        }
        #endregion

        #region 取消
        /// <summary>
        /// 取消
        /// </summary>
        private void btnqx_Click(object sender, EventArgs e)
        {
            btntj.Enabled = true;
            btnsc.Enabled = true;
            btnbc.Enabled = true;
            btnqx.Enabled = false;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        private void btnsc_Click(object sender, EventArgs e)
        {
            switch (label1.Text)
            {
                case "使用部门":
                    int cj = oper.Deletesybm(listBox1.SelectedValue.ToString());
                    this.btnsybm_Click(sender, e);
                    break;
                case "使用情况":
                    int ck = oper.Deletesyqk(listBox1.SelectedValue.ToString());
                    this.btnsyqk_Click(sender, e);
                    break;
                case "保管人员":
                    /*int co = oper.DeleteBaseBgry(lbName.SelectedValue.ToString());
                    this.btnBGRY_Click(sender, e);
                    break;*/
                    if (listBox1.SelectedValue.ToString() != "")
                    {
                        DialogResult dialog = MessageBox.Show("删除保管人员：" + listBox1.Text.ToString() + "？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialog == DialogResult.Yes)
                        {
                            int m = oper.Deletebgry(listBox1.SelectedValue.ToString());
                            this.btnbgry_Click(sender, e);
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;
            }
            btntj.Enabled = true;
            btnsc.Enabled = true;
            btnbc.Enabled = true;
            btnqx.Enabled = false;
        }
        #endregion

        #region 关闭
        /// <summary>
        /// 关闭
        /// </summary>
        private void btngb_Click(object sender, EventArgs e)
        {
            //调用委托
            tv();
            this.Close();
        }
        /// <summary>
        /// 右上角关闭
        /// </summary>
        protected override void WndProc(ref Message msg)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
            {
                tv();  //加入想要处理的逻辑
                this.Close();
                return;  //阻止了窗体关闭
            }
            base.WndProc(ref msg);
        }
        #endregion

    }
}
