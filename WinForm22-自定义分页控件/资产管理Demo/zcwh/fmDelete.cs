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
    public partial class fmDelete : Form
    {
        zcgl.myclass.operation oper = new zcgl.myclass.operation();
        public zcgl.fmMain M_fmMain = null;
        public string M_ZCBH = "";
        private zcgl.fmMain.DelegateRefreshDGV dgv;  //委托，更新主页dataGridView1数据
        public fmDelete(zcgl.fmMain.DelegateRefreshDGV _dgv)
        {
            InitializeComponent();
            this.dgv = _dgv;  //委托
        }

        private void fmDelete_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

            DataSet ds = oper.GetZc100(M_ZCBH);  //获得最新1000条数据，获得全部打开很慢
            txtzcbh.Text = ds.Tables[0].Rows[0]["zcbh"].ToString();
            txtzcmc.Text = ds.Tables[0].Rows[0]["zcmc"].ToString();
            txtsl.Text = ds.Tables[0].Rows[0]["sl"].ToString();
            cmbsybm.Text = ds.Tables[0].Rows[0]["sybm"].ToString();
            cmbbgry.Text = ds.Tables[0].Rows[0]["bgry"].ToString();
            cmbsyqk.Text = ds.Tables[0].Rows[0]["syqk"].ToString();
            dtdjrq.Text = ds.Tables[0].Rows[0]["djrq"].ToString();
            dtgxrq.Text = ds.Tables[0].Rows[0]["gxrq"].ToString();
            txtdjry.Text = ds.Tables[0].Rows[0]["djry"].ToString();
            txtqlr.Text = ds.Tables[0].Rows[0]["qlr"].ToString();
            dtqlrq.Text = ds.Tables[0].Rows[0]["qlrq"].ToString();
            txtpzr.Text = ds.Tables[0].Rows[0]["pzr"].ToString();
            txtbz.Text = ds.Tables[0].Rows[0]["beizhu"].ToString();
        }

        private void btnql_Click(object sender, EventArgs e)
        {
            if (txtqlr.TextLength < 1 || txtqlr.TextLength > 20)
            {
                errorProvider1.SetError(txtqlr, "清理人：1-20位任意字符");
                txtqlr.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtqlr, "");
            }
            if (txtpzr.TextLength < 1 || txtpzr.TextLength > 20)
            {
                errorProvider1.SetError(txtpzr, "批准人：1-20位任意字符");
                txtpzr.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtpzr, "");
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
            zcglmain.QLR = txtqlr.Text;
            zcglmain.QLRQ = dtqlrq.Value;
            zcglmain.PZR = txtpzr.Text;
            zcglmain.BEIZHU = txtbz.Text;

            int i = oper.ClearZc(zcglmain);
            int j = oper.DeleteZc(txtzcbh.Text);
            MessageBox.Show("清理成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
