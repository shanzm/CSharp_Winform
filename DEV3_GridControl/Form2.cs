﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEV3_GridControl
{
    public partial class Form2 : Form
    {
        public void  Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        /// <summary>
        /// 绑定并刷新数据源
        /// </summary>
        public void BindDataSource()
        {
            List<Company> companies = new List<Company>()
            {
                new Company (){Id=1,Name="小米",Address="北京",LegelPerson="雷军"},
                new Company (){Id=2,Name="华为",Address="深圳",LegelPerson="任正非" },
                new Company (){Id=3,Name="魅族",Address="深圳",LegelPerson="黄章" }
            };


            //数据源是绑定的GridControl,GridView是GirdControl中一种显示数据的方式，GridView是最接近Datatable的样式
            this.gridControl_company.DataSource = companies;
            this.gridView_company.PopulateColumns();
        }


    }
}
