using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winform8_ComboBox控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 在窗口一加载时，年份的下拉框就会将年份的选项加入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            for (int i = year; i >= 1949; i--)
            {
                cboYears.Items.Add(i + "年");//下拉框添加选项

            }

        }

        /// <summary>
        /// 注意只有年份的下拉框选中年份后，才会出现月份的选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            //注意每次年份选项改变，都会再添加12个月份的选项，所以，添加之前，要把之前的12个月份的选项清空
            cboMonth.Items.Clear();
            for (int i = 1; i < 13; i++)
            {
                cboMonth.Items.Add(i + "月");
            }
        }



        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDays.Items.Clear();
            int day = 0;
            /*☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
             * 注意此句，split返回的是一个数组
             * 注意cboMonth中的属性有SelectedValue，SelectedText等，但是只有SelectedItem返回的是选中项的内容
             * ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆*/
            string strMonth = cboMonth.SelectedItem.ToString().Split(new char[] { '月' })[0];
            string strYear = cboYears.SelectedItem.ToString().Split(new char[] { '年' })[0];
            int year = Convert.ToInt32(strYear);
            int month = Convert.ToInt32(strMonth);
            //不同年份，不同月份的天数判断
            switch (month)
            {
                case 1:
                case 3://注意这种写法
                case 5:
                case 7:
                case 8:
                case 10:
                case 12: day = 31;
                    break;
                case 2:
                    if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))//润年判断
                    {
                        day = 29;
                    }
                    else
                    {
                        day = 28;
                    }
                    break;

                default: day = 30;
                    break;
            }

            for (int i = 1; i <= day; i++)
            {
                cboDays.Items.Add(i + "日");
            }


        }
    }
}
