using System;
using System.Data;
using System.Windows.Forms;

namespace zcgl.zcwh
{
    public partial class fmInsert : Form
    {
        zcgl.myclass.operation oper = new zcgl.myclass.operation();
        private zcgl.fmMain.DelegateRefreshDGV dgv;  //委托，更新主页dataGridView1数据
        public fmInsert(zcgl.fmMain.DelegateRefreshDGV _dgv)
        {
            InitializeComponent();
            this.dgv = _dgv;  //委托
        }

        #region 获取下拉菜单值
        /// <summary>
        /// 获取下拉菜单值
        /// </summary>
        private void xialacaidan()
        {
            cmbsybm.DataSource = oper.Getsybm().Tables[0].DefaultView;
            cmbsybm.ValueMember = "sybm";

            cmbbgry.DataSource = oper.Getbgry().Tables[0].DefaultView;
            cmbbgry.ValueMember = "bgry";

            cmbsyqk.DataSource = oper.Getsyqk().Tables[0].DefaultView;
            cmbsyqk.ValueMember = "syqk";
        }
        #endregion

        #region Load
        /// <summary>
        /// Load
        /// </summary>
        private void fmInsert_Load(object sender, EventArgs e)
        {
            xialacaidan();
            label8.Visible = false;  //隐藏更新日期字段名
            dtgxrq.Visible = false;  //隐藏更新日期输入框
            txtzcbh.Enabled = false;  //置灰资产编号
            btndytm.Enabled = false;  //置灰打印条码

            #region 获取递增编号
            /// <summary>
            /// 获取递增编号
            /// </summary>
            DataSet ds = oper.GetDefault();
            DataSet dszcglmain = oper.GetZcNo();
            string firstNO = ds.Tables[0].Rows[0]["bhqz"].ToString();  //编号前缀
            int defaultNO = Convert.ToInt32(ds.Tables[0].Rows[0]["bhcz"].ToString());  //编号默认值
            if (dszcglmain.Tables[0].Rows.Count > 0)
            {
                int i = Convert.ToInt32(dszcglmain.Tables[0].Rows[0]["id"].ToString());
                int j = i + 1;
                txtzcbh.Text = firstNO + j;
            }
            else
            {
                txtzcbh.Text = firstNO + 1;
            }

            /*//数据多的时候，资产新增很慢，遍历表计算自动编号的缘故
            DataSet ds = oper.GetDefault();
            DataSet dszcglmain = oper.GetZc();
            string firstNO = ds.Tables[0].Rows[0]["bhqz"].ToString();
            int defaultNO = Convert.ToInt32(ds.Tables[0].Rows[0]["bhcz"].ToString());

            if (dszcglmain.Tables[0].Rows.Count > 0)
            {
                int j = defaultNO + Convert.ToInt32(dszcglmain.Tables[0].Rows[dszcglmain.Tables[0].Rows.Count - 1]["id"]);

                txtzcbh.Text = firstNO + j;
            }
            else
            {
                txtzcbh.Text = firstNO + defaultNO.ToString();
            }*/
            #endregion
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        private void btnbc_Click(object sender, EventArgs e)
        {
            if (txtzcmc.TextLength < 1 || txtzcmc.TextLength > 20)
            {
                errorProvider1.SetError(txtzcmc, "资产名称：1-20位任意字符！");
                txtzcmc.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtzcmc, "");
            }
            if (txtdjry.TextLength < 1 || txtdjry.TextLength > 20) 
            {
                errorProvider1.SetError(txtdjry, "登记人员：1-20位任意字符！");
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

            int i = oper.InsertZc(zcglmain);
            MessageBox.Show("保存成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgv();  //更新主页
            this.Close();
        }
        #endregion

        #region 关闭
        /// <summary>
        /// 关闭
        /// </summary>
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
                dgv();  //加入处理逻辑
                this.Close();
                return;  //阻止窗体关闭
            }
            base.WndProc(ref msg);
        }
        #endregion

    }
}
