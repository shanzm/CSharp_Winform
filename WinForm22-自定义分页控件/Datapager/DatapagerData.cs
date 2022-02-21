using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DatapagerData
{
    public class dgvData
    {
        #region 准备执行一个命令
        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">Sql连接</param>
        /// <param name="trans">Sql事务</param>
        /// <param name="cmdText">命令文本,例如：Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            //判断连接的状态。如果是关闭状态，则打开
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            //cmd属性赋值
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            //是否需要用到事务处理
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            //cmd.CommandType = CommandType.Text;
            cmd.CommandType = cmdType;
            //添加cmd需要的存储过程参数
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
        #endregion

        #region 调用存储过程，返回受影响的行数
        /// <summary>
        /// 调用存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int invokeProc_NonQuery(string connStr, string procName, params SqlParameter[] commandParameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand sqlCmd = new SqlCommand();
                PrepareCommand(sqlCmd, conn, null, CommandType.StoredProcedure, procName, commandParameters);
                int flag = sqlCmd.ExecuteNonQuery();
                sqlCmd.Parameters.Clear();
                return flag;
            }

        }
        #endregion

        #region 调用存储过程，返回DataTable对象
        /// <summary>
        /// 调用存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回DataTable对象</returns>
        public static DataTable invokeProc_DataTable(string connStr, string procName, params SqlParameter[] commandParameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand sqlCmd = new SqlCommand();
                PrepareCommand(sqlCmd, conn, null, CommandType.StoredProcedure, procName, commandParameters);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                try
                {
                    //填充ds
                    da.Fill(dt);
                    // 清除cmd的参数集合 
                    sqlCmd.Parameters.Clear();
                    //返回ds
                    return dt;
                }
                catch (Exception ex)
                {
                    //LogLib.LogHelper.ERROR(ex);
                    MessageBox.Show(ex.Message);

                    //关闭连接，抛出异常
                    conn.Close();
                    throw;
                }
            }
        }
        #endregion

        #region 调用存储过程，用指定的数据库连接执行一个命令并返回一个数据集的第一列
        /// <summary>
        /// 调用存储过程，用指定的数据库连接执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="commandParameters"></param>
        /// <returns>返回一个数据集的第一列</returns>
        public static object invokeProc_ExecuteScalar(string connStr, string procName, params SqlParameter[] commandParameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand sqlCmd = new SqlCommand();
                PrepareCommand(sqlCmd, conn, null, CommandType.StoredProcedure, procName, commandParameters);
                object flag = sqlCmd.ExecuteScalar();
                sqlCmd.Parameters.Clear();
                return flag;
            }
        }
        #endregion

    }
}