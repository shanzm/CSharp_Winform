using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zcgl.xtwh
{
    public partial class fmUser : Form
    {
        zcgl.myclass.operation oper = new zcgl.myclass.operation();
        public fmUser()
        {
            InitializeComponent();
            //设置控件属性选中整行
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //设置鼠标点击事件
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dataGridView1.RowHeadersWidth - 4,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridView1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btntj_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btntj.Enabled = true;
            btnxg.Enabled = false;
            btnsc.Enabled = false;
            btnbc.Enabled = true;
            btnqx.Enabled = true;
            txtzh.Text = "";
            txtmm.Text = "";
            txtnc.Text = "";
            txtzh.Focus();
        }

        private void btnqx_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            btntj.Enabled = true;
            btnxg.Enabled = true;
            btnsc.Enabled = true;
            btnbc.Enabled = false;
            btnqx.Enabled = false;
        }

        private void btnxg_Click(object sender, EventArgs e)
        {
            if (txtzh.Text == "")
            {
                MessageBox.Show("先选数据，再点修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                groupBox1.Enabled = true;
                btntj.Enabled = false;
                btnxg.Enabled = true;
                btnsc.Enabled = false;
                btnbc.Enabled = true;
                btnqx.Enabled = true;
            }
        }

        private void btnbc_Click(object sender, EventArgs e)
        {
            if (oper.jiaoyan1(txtzh.Text))
            {
                MessageBox.Show("帐号：1-20位(英文、数字、下划线)", this.Text);
                this.txtzh.Focus();
                return;
            }
            if (oper.jiaoyan1(txtmm.Text))
            {
                MessageBox.Show("密码：1-20位(英文、数字、下划线)", this.Text);
                this.txtmm.Focus();
                return;
            }
            if (txtnc.TextLength > 20)
            {
                MessageBox.Show("昵称：最多20个字符，1个汉字等于2个字符！", this.Text);
                this.txtnc.Focus();
                return;
            }
            if (btntj.Enabled && groupBox1.Enabled)
            {
                if (oper.Login1(txtzh.Text).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("帐号已存在！", this.Text);
                    txtzh.Focus();
                    return;
                }
                else
                {
                    oper.InsertUser(txtzh.Text, txtmm.Text, txtnc.Text);
                    MessageBox.Show("添加成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (btnxg.Enabled && groupBox1.Enabled)
            {
                oper.UpdateUser(dataGridView1.SelectedCells[0].Value.ToString(), txtzh.Text, txtmm.Text, txtnc.Text);
                MessageBox.Show("修改成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            groupBox1.Enabled = false;
            btntj.Enabled = true;
            btnxg.Enabled = true;
            btnsc.Enabled = true;
            btnbc.Enabled = false;
            btnqx.Enabled = false;
            txtzh.Text = "";
            txtmm.Text = "";
            txtnc.Text = "";
            dataGridView1.DataSource = oper.GetDataSetUser().Tables[0].DefaultView;
            dataGridView1.ClearSelection();
        }

        private void fmUser_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            btntj.Enabled = true;
            btnxg.Enabled = true;
            btnsc.Enabled = true;
            btnbc.Enabled = false;
            btnqx.Enabled = false;
            txtzh.Text = "";
            txtmm.Text = "";
            txtnc.Text = "";
            dataGridView1.DataSource = oper.GetDataSetUser().Tables[0].DefaultView;
            dataGridView1.ClearSelection();
        }

        //dataGridView窗体，CellMouseClick属性设置为dataGridView1_CellMouseClick
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtzh.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            txtmm.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            txtnc.Text = dataGridView1[3, e.RowIndex].Value.ToString();
        }

        private void btnsc_Click(object sender, EventArgs e)
        {
            if (txtzh.Text == "")
            {
                MessageBox.Show("先选数据，再点删除！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult RSS = MessageBox.Show("删除选中行数据？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                switch (RSS)
                {
                    case DialogResult.Yes:
                        for (int i = this.dataGridView1.SelectedRows.Count; i > 0; i--)
                        {
                            int del = oper.DeleteUser(dataGridView1.SelectedRows[i - 1].Cells[0].Value.ToString());
                            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i - 1].Index);
                        }
                        break;
                    case DialogResult.No:
                        break;
                }
                txtzh.Text = "";
                txtmm.Text = "";
                txtnc.Text = "";
                dataGridView1.DataSource = oper.GetDataSetUser().Tables[0].DefaultView;
                dataGridView1.ClearSelection();
            }
        }

    }
}