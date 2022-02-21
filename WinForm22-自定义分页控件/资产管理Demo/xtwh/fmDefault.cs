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
    public partial class fmDefault : Form
    {
        zcgl.myclass.operation oper = new zcgl.myclass.operation();
        DataSet ds = null;

        public fmDefault()
        {
            InitializeComponent();
        }

        #region 加载默认资产编号
        /// <summary>
        /// 加载默认资产编号
        /// </summary>
        private void fmDefault_Load(object sender, EventArgs e)
        {
            ds = oper.GetDefault();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtqz.Text = ds.Tables[0].Rows[0]["bhqz"].ToString();
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        private void btnbc_Click(object sender, EventArgs e)
        {
            ds = oper.GetDefault();
            if (ds.Tables[0].Rows.Count == 0)
            {
                int i = oper.InserDefault(txtqz.Text);
            }
            else
            {
                int i = oper.UpdateDefault(txtqz.Text);
            }
            MessageBox.Show("设置成功！", "系統提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region 关闭
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnqx_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
