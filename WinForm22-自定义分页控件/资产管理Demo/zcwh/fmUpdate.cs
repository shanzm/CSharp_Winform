using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zcgl.zcwh
{
    public partial class fmUpdate : Form
    {
        zcgl.myclass.operation oper = new zcgl.myclass.operation();
        public zcgl.fmMain M_fmMain = null;
        public string M_ZCBH = "";
        private zcgl.fmMain.DelegateRefreshDGV dgv;  //委托，更新主页dataGridView1数据
        public fmUpdate(zcgl.fmMain.DelegateRefreshDGV _dgv)
        {
            InitializeComponent();
            this.dgv = _dgv;  //委托
        }

        private void xialacaidan()
        {
            cmbsybm.DataSource = oper.Getsybm().Tables[0].DefaultView;
            cmbsybm.ValueMember = "sybm";

            cmbbgry.DataSource = oper.Getbgry().Tables[0].DefaultView;
            cmbbgry.ValueMember = "bgry";

            cmbsyqk.DataSource = oper.Getsyqk().Tables[0].DefaultView;
            cmbsyqk.ValueMember = "syqk";
        }

        private void fmUpdate_Load(object sender, EventArgs e)
        {
            txtzcbh.Text = M_ZCBH;
            xialacaidan();
            label8.Visible = false;
            dtgxrq.Visible = false;
            txtzcbh.Enabled = false;
            dtdjrq.Enabled = false;
            dtgxrq.Enabled = false;
            btndytm.Enabled = false;

            DataSet ds = oper.GetZc100(txtzcbh.Text);  //获得最新1000条数据，获得全部打开很慢
            txtzcbh.Text = ds.Tables[0].Rows[0]["zcbh"].ToString();
            txtzcmc.Text = ds.Tables[0].Rows[0]["zcmc"].ToString();
            txtsl.Text = ds.Tables[0].Rows[0]["sl"].ToString();
            cmbsybm.Text = ds.Tables[0].Rows[0]["sybm"].ToString();
            cmbbgry.Text = ds.Tables[0].Rows[0]["bgry"].ToString();
            cmbsyqk.Text = ds.Tables[0].Rows[0]["syqk"].ToString();
            dtdjrq.Text = ds.Tables[0].Rows[0]["djrq"].ToString();
            dtgxrq.Text = DateTime.Now.ToString();
            txtdjry.Text = ds.Tables[0].Rows[0]["djry"].ToString();
        }

        private void btnbc_Click(object sender, EventArgs e)
        {
            if (txtzcmc.TextLength < 1 || txtzcmc.TextLength > 20)
            {
                errorProvider1.SetError(txtzcmc, "资产名称：1-20位任意字符");
                txtzcmc.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtzcmc, "");
            }
            if (txtdjry.TextLength < 1 || txtdjry.TextLength > 20)
            {
                errorProvider1.SetError(txtdjry, "登记人员：1-20位任意字符");
                txtdjry.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtdjry, "");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtsl.Text, @"^[0-9]+$"))
            {
                errorProvider1.SetError(txtsl, "数量：只能输入数字！");
                txtsl.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtsl, "");
            }

            zcgl.myclass.zcglmain zcglmain = new zcgl.myclass.zcglmain();
            zcglmain.ZCBH = txtzcbh.Text;
            zcglmain.ZCMC = txtzcmc.Text;
            zcglmain.SL = Convert.ToInt32(txtsl.Text);  //数量
            zcglmain.SYBM = cmbsybm.Text;
            zcglmain.BGRY = cmbbgry.Text;
            zcglmain.SYQK = cmbsyqk.Text;
            zcglmain.DJRQ = dtdjrq.Value;  //日期
            zcglmain.GXRQ = dtgxrq.Value;
            zcglmain.DJRY = txtdjry.Text;

            int i = oper.UpdateZc(zcglmain);
            MessageBox.Show("修改成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgv();  //更新主页
            this.Close();
        }

        private void btngb_Click(object sender, EventArgs e)
        {
            dgv();
            this.Close();
        }

        protected override void WndProc(ref Message msg)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
            {
                dgv();  //加入想要处理的逻辑
                this.Close();
                return;  //阻止了窗体关闭
            }
            base.WndProc(ref msg);
        }

    }
}
