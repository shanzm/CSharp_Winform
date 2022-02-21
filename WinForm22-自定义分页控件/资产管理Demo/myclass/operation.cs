using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace zcgl.myclass
{
    class operation
    {
        database data = new database();

        #region 验证合法输入（0123456789.）
        /// <summary>
        /// 验证合法输入（0123456789.）
        /// </summary>
        /// <param name="strCode">验证字符</param>
        /// <returns></returns>
        public bool IsNumeric(string strCode)
        {
            if (strCode == null || strCode.Length == 0)
                return false;
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] byteStr = ascii.GetBytes(strCode);
            foreach (byte code in byteStr)
            {
                if (code == 190 || code == 110)
                    if (code < 48 || code > 57)
                        return false;
            }
            return true;
        }
        #endregion

        #region 验证合法输入（英文、数字、下划线）
        /// <summary>
        /// 验证合法输入（英文、数字、下划线）
        /// </summary>
        /// <param name="strCode">验证字符</param>
        /// <returns></returns>
        public bool jiaoyan1(string strCode)
        {
            if (strCode.Length < 1 || strCode.Length > 20)
                return true;
            else
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(strCode, @"^[a-zA-Z0-9_]*$"))
                    return false;
                else
                    return true;
            }
        }
        #endregion

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="tb_user">用户表</param>
        /// <param name="Login1">验证帐号是否存在</param>
        /// <param name="Login2">验证帐密是否正确</param>
        /// <returns></returns>
        public DataSet Login1(string zhanghao)
        {
            return data.RunProcReturn("select zhanghao from tb_user where zhanghao='" + zhanghao + "'", "tb_user");
        }
        public DataSet Login2(string zhanghao, string mima)
        {
            return data.RunProcReturn("select * from tb_user where zhanghao='" + zhanghao + "'and mima='" + mima + "'", "tb_user");
        }
        #endregion

        #region 注册
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="tb_user">用户表</param>
        public DataSet Register(string zhanghao, string mima, string nicheng)
        {
            return data.RunProcReturn("insert into tb_user (zhanghao,mima,nicheng) values ('" + zhanghao + "','" + mima + "','" + nicheng + "') select * from tb_user where zhanghao='" + zhanghao + "'and mima='" + mima + "'and nicheng='" + nicheng + "'", "tb_user");
        }
        #endregion

        #region 菜单栏-帐号管理
        /// <summary>
        /// 添加帐号
        /// </summary>
        /// <param name="zhanghao"></param>
        /// <param name="mima"></param>
        /// <param name="nicheng"></param>
        /// <returns></returns>
        public int InsertUser(string zhanghao, string mima, string nicheng)
        {
            SqlParameter[] prams = { 
                data.MakeInParam("@zhanghao",SqlDbType.VarChar,50,zhanghao),
                data.MakeInParam("@mima",SqlDbType.VarChar,50,mima),
                data.MakeInParam("@nicheng",SqlDbType.VarChar,20,nicheng),
            };
            return data.RunProc("insert into tb_user (zhanghao,mima,nicheng) values (@zhanghao,@mima,@nicheng)", prams);
        }
        /// <summary>
        /// 修改帐号
        /// </summary>
        /// <param name="zhanghao"></param>
        /// <param name="mima"></param>
        /// <param name="nicheng"></param>
        /// <returns></returns>
        public int UpdateUser(string id, string zhanghao, string mima, string nicheng)
        {
            SqlParameter[] prams = { 
                data.MakeInParam("@zhanghao",SqlDbType.VarChar,50,zhanghao),
                data.MakeInParam("@mima",SqlDbType.VarChar,50,mima),
                data.MakeInParam("@nicheng",SqlDbType.VarChar,20,nicheng),
            };
            return data.RunProc("update tb_user set zhanghao=@zhanghao,mima=@mima,nicheng=@nicheng where id=" + id + "", prams);
        }
        /// <summary>
        /// 删除帐号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteUser(string id)
        {
            return data.RunProc("delete from tb_user where id=" + id + "");
        }
        /// <summary>
        /// 获得所有帐号信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataSetUser()
        {
            return data.RunProcReturn("select ID as 编号,zhanghao as 帐号,mima as 密码,nicheng as 昵称 from tb_user order by createdate desc", "tb_user");
        }
        /// <summary>
        /// 根据指定的ID获得帐号信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet GetDataSetUser(string id)
        {
            return data.RunProcReturn("select * from tb_user where id='" + id + "'", "tb_user");
        }
        #endregion

        #region 菜单栏-资产编号
        /// <summary>
        /// 查询是否存在默认资产编号
        /// </summary>
        /// <returns></returns>
        public DataSet GetDefault()
        {
            return data.RunProcReturn("select * from tb_zcbh", "tb_zcbh");
        }

        /// <summary>
        /// 创建默认资产编号
        /// </summary>
        /// <param name="bhqz"></param>
        /// <returns></returns>
        public int InserDefault(string bhqz)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@bhqz", SqlDbType.VarChar, 50, bhqz),
			};
            return (data.RunProc("INSERT INTO tb_zcbh (bhqz) VALUES (@bhqz)", prams));
        }

        /// <summary>
        /// 修改默认资产编号
        /// </summary>
        /// <param name="bhqz"></param>
        /// <param name="bhcz"></param>
        /// <returns></returns>
        public int UpdateDefault(string bhqz)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@bhqz", SqlDbType.VarChar, 50, bhqz),
			};
            return (data.RunProc("Update tb_zcbh Set bhqz=@bhqz where id=1", prams));
        }
        #endregion

        #region 工具栏-资产分类
        /// <summary>
        /// 查询资产分类
        /// </summary>
        /// <param name="zcName">资产名称</param>
        /// <returns></returns>
        public DataSet GetZcfl(string zcName)
        {
            return data.RunProcReturn("select * from tb_zcfl where zclb='" + zcName + "'", "tb_zcfl");
        }
        public DataSet GetZcfl()
        {
            return data.RunProcReturn("select * from tb_zcfl where firstID=1", "tb_zcfl");
        }
        /// <summary>
        /// 添加资产分类
        /// </summary>
        /// <param name="firstID"></param>
        /// <param name="zclb"></param>
        /// <param name="secondID"></param>
        /// <returns></returns>
        public int InsertZcfl(string firstID, string zclb, string secondID)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@firstID",  SqlDbType.VarChar, 10, firstID),
                						data.MakeInParam("@zclb",  SqlDbType.VarChar, 10, zclb),
                						data.MakeInParam("@secondID",  SqlDbType.VarChar, 10, secondID),
			};
            return (data.RunProc("INSERT INTO tb_zcfl (firstID,zclb,secondID) VALUES (@firstID,@zclb,@secondID)", prams));
        }
        /// <summary>
        /// 删除资产分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteZcfl(int id)
        {
            return data.RunProc("delete from tb_zcfl where id='" + id + "'");
        }
        /// <summary>
        /// 修改资产分类
        /// </summary>
        /// <param name="zclb"></param>
        /// <returns></returns>
        public int UpdateZcfl(int ID, string zclb)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",SqlDbType.Int,4,ID),
                						data.MakeInParam("@zclb",  SqlDbType.VarChar, 10, zclb),
			};
            return (data.RunProc("update tb_zcfl set zclb=@zclb where id='" + ID + "'", prams));
        }
        /// <summary>
        /// 获取主页TreeView菜单项
        /// </summary>
        /// <returns></returns>
        public DataSet TreeFill()
        {
            return data.RunProcReturn("select * from tb_zcfl select * from tb_sybm select * from tb_bgry select * from tb_syqk", "tb_zcfl");
        }
        #endregion

        #region treeView查询
        /// <summary>
        /// treeView查询
        /// </summary>
        public DataSet GetZcfl_sybm(string sybm)
        {
            return data.RunProcReturn("select * from tb_zcgl where sybm='" + sybm + "'", "tb_zcgl");
        }
        public DataSet GetZcfl_bgry(string bgry)
        {
            return data.RunProcReturn("select * from tb_zcgl where bgry='" + bgry + "'", "tb_zcgl");
        }
        public DataSet GetZcfl_syqk(string syqk)
        {
            return data.RunProcReturn("select * from tb_zcgl where syqk='" + syqk + "'", "tb_zcgl");
        }
        #endregion

        #region 工具栏-基本资料
        /// <summary>
        /// 查询基本资料
        /// </summary>
        /// <returns></returns>
        public DataSet Getsybm()
        {
            return data.RunProcReturn("select * from tb_sybm", "tb_sybm");
        }
        public DataSet Getbgry()
        {
            return data.RunProcReturn("select * from tb_bgry", "tb_bgry");
        }
        public DataSet Getsyqk()
        {
            return data.RunProcReturn("select * from tb_syqk", "tb_syqk");
        }
        /// <summary>
        /// 添加基本资料
        /// </summary>
        /// <returns></returns>
        public int Insertsybm(string sybm)
        {
            SqlParameter[] prams = { data.MakeInParam("@sybm", SqlDbType.VarChar, 50, sybm), };
            return (data.RunProc("INSERT INTO tb_sybm (sybm) VALUES (@sybm)", prams));
        }
        public int Insertbgry(string bgry, string sybm)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@bgry", SqlDbType.VarChar, 50, bgry),
            data.MakeInParam("@sybm", SqlDbType.VarChar, 50, sybm),};
            return (data.RunProc("INSERT INTO tb_bgry (bgry,sybm) VALUES (@bgry,@sybm)", prams));
        }
        public int Insertsyqk(string syqk)
        {
            SqlParameter[] prams = {data.MakeInParam("@syqk", SqlDbType.VarChar, 50, syqk),};
            return (data.RunProc("INSERT INTO tb_syqk (syqk) VALUES (@syqk)", prams));
        }
        /// <summary>
        /// 删除基本资料
        /// </summary>
        /// <returns></returns>
        public int Deletesybm(string id)
        {
            return data.RunProc("delete from tb_sybm where id='" + id + "'");
        }
        public int Deletebgry(string id)
        {
            return data.RunProc("delete from tb_bgry where id='" + id + "'");
        }
        public int Deletesyqk(string id)
        {
            return data.RunProc("delete from tb_syqk where id='" + id + "'");
        }
        #endregion

        #region 工具栏-资产查询、新增、更新、清理
        /// <summary>
        /// 获取所有资产
        /// </summary>
        /// <returns></returns>
        public DataSet GetZc()
        {
            return data.RunProcReturn("select * from tb_zcgl ORDER BY id", "tb_zcgl");
        }
        public DataSet GetZc(string findTitle, string findContent)
        {
            return data.RunProcReturn("select * from tb_zcgl where " + findTitle + " like '%" + findContent + "%' ORDER BY ID", "tb_zcgl");
        }
        /// <summary>
        /// 获取指定编号的资产
        /// </summary>
        /// <param name="ZCBH"></param>
        /// <returns></returns>

        public DataSet GetZc(string ZCBH)
        {
            return data.RunProcReturn("select * from tb_zcgl where zcbh='" + ZCBH + "'", "tb_zcgl");
        }
        /// <summary>
        /// 资产新增
        /// </summary>
        /// <returns></returns>
        public int InsertZc(zcglmain zcglmain)
        {
            SqlParameter[] prams = {   
                                       data.MakeInParam("@zcbh", SqlDbType.VarChar, 50, zcglmain.ZCBH),
                                       data.MakeInParam("@zcmc", SqlDbType.VarChar, 50, zcglmain.ZCMC),
                                       data.MakeInParam("@sl", SqlDbType.Int, 10, zcglmain.SL),
                                       data.MakeInParam("@sybm", SqlDbType.VarChar, 50, zcglmain.SYBM),
                                       data.MakeInParam("@bgry", SqlDbType.VarChar, 50, zcglmain.BGRY),
                                       data.MakeInParam("@syqk", SqlDbType.VarChar, 50, zcglmain.SYQK),
                                       data.MakeInParam("@djrq", SqlDbType.DateTime, 8, zcglmain.DJRQ),
                                       data.MakeInParam("@gxrq", SqlDbType.DateTime, 8, zcglmain.GXRQ),
                                       data.MakeInParam("@djry", SqlDbType.VarChar, 50, zcglmain.DJRY),
                                   };
            return (data.RunProc("INSERT INTO tb_zcgl (zcbh,zcmc,sl,sybm,bgry,syqk,djrq,gxrq,djry) VALUES (@zcbh,@zcmc,@sl,@sybm,@bgry,@syqk,@djrq,@gxrq,@djry)", prams));
        }
        /// <summary>
        /// 资产更新
        /// </summary>
        /// <returns></returns>
        public int UpdateZc(zcglmain zcglmain)
        {
            SqlParameter[] prams = {
                                       data.MakeInParam("@zcbh", SqlDbType.VarChar, 50, zcglmain.ZCBH),
                                       data.MakeInParam("@zcmc", SqlDbType.VarChar, 50, zcglmain.ZCMC),
                                       data.MakeInParam("@sl", SqlDbType.Int, 10, zcglmain.SL),
                                       data.MakeInParam("@sybm", SqlDbType.VarChar, 50, zcglmain.SYBM),
                                       data.MakeInParam("@bgry", SqlDbType.VarChar, 50, zcglmain.BGRY),
                                       data.MakeInParam("@syqk", SqlDbType.VarChar, 50, zcglmain.SYQK),
                                       data.MakeInParam("@djrq", SqlDbType.DateTime, 8, zcglmain.DJRQ),
                                       data.MakeInParam("@gxrq", SqlDbType.DateTime, 8, zcglmain.GXRQ),
                                       data.MakeInParam("@djry", SqlDbType.VarChar, 50, zcglmain.DJRY),
                                   };
            return (data.RunProc("UPDATE tb_zcgl SET zcmc=@zcmc,sl=@sl,sybm=@sybm,bgry=@bgry,syqk=@syqk,djrq=@djrq,gxrq=@gxrq,djry=djry WHERE zcbh=@zcbh", prams));
        }
        /// <summary>
        /// 删除资产
        /// </summary>
        /// <param name="ZCBH"></param>
        /// <returns></returns>
        public int DeleteZc(string ZCBH)
        {
            return data.RunProc("delete from tb_zcgl where zcbh='" + ZCBH + "'");
        }
        /// <summary>
        /// 清理资产（清理到tb_clear中）
        /// </summary>
        /// <param name="zcglmain"></param>
        /// <returns></returns>
        public int ClearZc(zcglmain zcglmain)
        {
            SqlParameter[] prams = {
                                       data.MakeInParam("@zcbh", SqlDbType.VarChar, 50, zcglmain.ZCBH),
                                       data.MakeInParam("@zcmc", SqlDbType.VarChar, 50, zcglmain.ZCMC),
                                       data.MakeInParam("@sl", SqlDbType.Int, 10, zcglmain.SL),
                                       data.MakeInParam("@sybm", SqlDbType.VarChar, 50, zcglmain.SYBM),
                                       data.MakeInParam("@bgry", SqlDbType.VarChar, 50, zcglmain.BGRY),
                                       data.MakeInParam("@syqk", SqlDbType.VarChar, 50, zcglmain.SYQK),
                                       data.MakeInParam("@djrq", SqlDbType.DateTime, 8, zcglmain.DJRQ),
                                       data.MakeInParam("@gxrq", SqlDbType.DateTime, 8, zcglmain.GXRQ),
                                       data.MakeInParam("@djry", SqlDbType.VarChar, 50, zcglmain.DJRY),

                                       data.MakeInParam("@qlr", SqlDbType.VarChar, 50, zcglmain.QLR),
                                       data.MakeInParam("@qlrq", SqlDbType.DateTime, 8, zcglmain.QLRQ),
                                       data.MakeInParam("@pzr", SqlDbType.VarChar, 50, zcglmain.PZR),
                                       data.MakeInParam("@beizhu", SqlDbType.VarChar, 500, zcglmain.BEIZHU),
			};
            return (data.RunProc("INSERT INTO tb_clear (zcbh,zcmc,sl,sybm,bgry,syqk,djrq,gxrq,djry,qlr,qlrq,pzr,beizhu) VALUES (@zcbh,@zcmc,@sl,@sybm,@bgry,@syqk,@djrq,@gxrq,@djry,@qlr,@qlrq,@pzr,@beizhu)", prams));
        }
        #endregion

        #region 展示最新100条数据
        //获取最新资产
        public DataSet GetZcNo()
        {
            return data.RunProcReturn("select top 1 * from tb_zcgl order by id desc", "tb_zcgl");
        }
        //获取所有资产-100
        public DataSet GetZc100()
        {
            return data.RunProcReturn("select top 100 * from tb_zcgl ORDER BY id desc", "tb_zcgl");
        }
        //根据查询条件获取资产-100
        public DataSet GetZc100(string findTitle, string findContent)
        {
            return data.RunProcReturn("select top 100 * from tb_zcgl where " + findTitle + " like '%" + findContent + "%' ORDER BY id desc", "tb_zcgl");
        }
        //获取指定编号的资产-100
        public DataSet GetZc100(string ZCBH)
        {
            return data.RunProcReturn("select top 100 * from tb_zcgl where zcbh='" + ZCBH + "' ORDER BY id desc", "tb_zcgl");
        }
        //主页treeview快查
        public DataSet GetZcfl_sybm100(string sybm)
        {
            return data.RunProcReturn("select top 100 * from tb_zcgl where sybm='" + sybm + "' order by id desc", "tb_zcgl");
        }
        public DataSet GetZcfl_bgry100(string bgry)
        {
            return data.RunProcReturn("select top 100 * from tb_zcgl where bgry='" + bgry + "' order by id desc", "tb_zcgl");
        }
        public DataSet GetZcfl_syqk100(string syqk)
        {
            return data.RunProcReturn("select top 100 * from tb_zcgl where syqk='" + syqk + "' order by id desc", "tb_zcgl");
        }
        #endregion

    }

    #region 资产实体类
    public class zcglmain
    {
        /// <summary>
        /// 默认值
        /// </summary>
        private string zcbh = "";
        private string zcmc = "";
        private int sl = 1;
        private string sybm = "";
        private string bgry = "";
        private string syqk = "";
        private DateTime djrq = DateTime.Now;
        private DateTime gxrq = DateTime.Now;
        private string djry = "";
        private string qlr = "";
        private DateTime qlrq = DateTime.Now;
        private string pzr = "";
        private string beizhu = "";
        /// <summary>
        /// 资产编号
        /// </summary>
        public string ZCBH
        {
            get { return zcbh; }
            set { zcbh = value; }
        }
        /// <summary>
        /// 资产名称
        /// </summary>
        public string ZCMC
        {
            get { return zcmc; }
            set { zcmc = value; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int SL
        {
            get { return sl; }
            set { sl = value; }
        }
        /// <summary>
        /// 使用部门
        /// </summary>
        public string SYBM
        {
            get { return sybm; }
            set { sybm = value; }
        }
        /// <summary>
        /// 保管人员
        /// </summary>
        public string BGRY
        {
            get { return bgry; }
            set { bgry = value; }
        }
        /// <summary>
        /// 使用情况
        /// </summary>
        public string SYQK
        {
            get { return syqk; }
            set { syqk = value; }
        }
        ///<summary>
        /// 登记日期
        /// </summary>
        public DateTime DJRQ
        {
            get { return djrq; }
            set { djrq = value; }
        }
        ///<summary>
        /// 更新日期
        /// </summary>
        public DateTime GXRQ
        {
            get { return gxrq; }
            set { gxrq = value; }
        }
        /// <summary>
        /// 登记人员
        /// </summary>
        public string DJRY
        {
            get { return djry; }
            set { djry = value; }
        }

        /// <summary>
        /// 清理人
        /// </summary>
        public string QLR
        {
            get { return qlr; }
            set { qlr = value; }
        }
        ///<summary>
        /// 清理日期
        /// </summary>
        public DateTime QLRQ
        {
            get { return qlrq; }
            set { qlrq = value; }
        }
        /// <summary>
        /// 批准人
        /// </summary>
        public string PZR
        {
            get { return pzr; }
            set { pzr = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string BEIZHU
        {
            get { return beizhu; }
            set { beizhu = value; }
        }
    }
    #endregion

}