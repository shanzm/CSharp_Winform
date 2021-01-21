using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV2_GridView
{
    public static class DbSource
    {

        /// <summary>
        /// 数据源,用于测试
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUserList()
        {
            DataTable dt = new DataTable("Users");
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Age", typeof(int));
            dt.Columns.Add("Gender", typeof(string));
            dt.Rows.Add(new object[] { "0", "张三", 20, "男" });
            for (int i = 1; i < 20; i++)
            {
                dt.Rows.Add(new object[] { i, "测试" + i, 20, "男" });
            }
            return dt;
        }
    }
}
