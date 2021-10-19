using PM.Common;
using PM.DAL.Helper;
using PM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL
{
    public class MenuDAL
    {
        /// <summary>
        /// 获取用户角色菜单列表
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public List<MenuInfoModel> GetUserMenuList(string roleIds)
        {
            List<MenuInfoModel> list = new List<MenuInfoModel>();
            string sql = "";
            if (string.IsNullOrEmpty(roleIds))
                sql = "select * from MenuInfos";
            else 
             sql = "select rm.MenuId,MenuName,ParentId,FrmName,MKey from RoleMenuInfos rm inner join MenuInfos m on rm.MenuId = m.MenuId where rm.RoleId in (" + roleIds + ")";
            SqlDataReader dr = DBHelper.ExecuteReader(sql, 1);
            while (dr.Read())
            {
                MenuInfoModel menuInfo = new MenuInfoModel();
                menuInfo.MenuId = int.Parse(dr["MenuId"].ToString());
                menuInfo.MenuName = dr["MenuName"].ToString();
                menuInfo.ParentId = int.Parse(dr["ParentId"].ToString());
                menuInfo.FrmName = dr["FrmName"].ToString();
                menuInfo.MKey = dr["MKey"].ToString();
                list.Add(menuInfo);
            }
            dr.Close();//关闭阅读器
            return list;
        }

        /// <summary>
        /// 获取父级菜单列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetParentList()
        {
            string sql = "select m.ParentId,p.MenuName,count(1) count from MenuInfos m  inner join MenuInfos p on m.ParentId = p.MenuId group by m.ParentId,p.MenuName";
            DataTable dt = DBHelper.GetDataTable(sql, 1);
            return dt;
        }

        /// <summary>
        /// 条件查询菜单信息
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="mName"></param>
        /// <returns></returns>
        public List<MenuInfoAllModel> GetMenuList(int parentId,string mName)
        {
            List<MenuInfoAllModel> list = new List<MenuInfoAllModel>();
            string sql = "select m.MenuId,m.MenuName,m.ParentId,p.MenuName ParentName,m.FrmName,m.MKey from MenuInfos m left join MenuInfos p on m.ParentId = p.MenuId where 1=1 ";
            if (parentId > 0)
                sql += " and m.ParentId=@parentId";
            if (!string.IsNullOrEmpty(mName))
                sql += " and m.MenuName like @mName";
            SqlParameter[] paras =
            {
                new SqlParameter("@parentId",parentId),
                new SqlParameter("@mName",$"%{mName}%")
            };
            SqlDataReader dr = DBHelper.ExecuteReader(sql, 1, paras);
            while(dr.Read())
            {
                MenuInfoAllModel menu = new MenuInfoAllModel();
                menu.MenuId = int.Parse(dr["MenuId"].ToString());
                menu.MenuName = dr["MenuName"].ToString();
                menu.ParentId= int.Parse(dr["ParentId"].ToString());
                menu.ParentName = dr["ParentName"].ToString();
                menu.FrmName = dr["FrmName"].ToString();
                menu.MKey = dr["MKey"].ToString();
                list.Add(menu);
            }
            return list;
        }

        /// <summary>
        /// 删除菜单信息
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public bool DeleteMenu(int menuId)
        {
            string sqlDelRoleMenu = "delete from RoleMenuInfos where MenuId=@menuId";
            string sqlDelMenu = "delete from MenuInfos where MenuId=@menuId";
            SqlParameter[] paras = {
                new SqlParameter("@menuId", menuId)
            };
            List<CommandInfo> comList = new List<CommandInfo>();
            comList.Add(new CommandInfo()
            {
                CommandText = sqlDelRoleMenu,
                IsProc = false,
                Paras = paras
            });
            comList.Add(new CommandInfo()
            {
                CommandText = sqlDelMenu,
                IsProc = false,
                Paras = paras
            });
            return DBHelper.ExecuteTrans(comList);
        }

        /// <summary>
        /// 获取所有菜单项数据（主要用于绑定下拉框）
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllMenus()
        {
            string sql = "select MenuId,MenuName from MenuInfos";
            return DBHelper.GetDataTable(sql, 1);
        }

        /// <summary>
        /// 加载菜单树(所有菜单数据)
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTvMenus()
        {
            string sql = "select MenuId,MenuName,ParentId from MenuInfos";
            return DBHelper.GetDataTable(sql, 1);
        }
        /// <summary>
        /// 获取指定的菜单信息
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public MenuInfoModel  GetMenuInfo(int menuId)
        {
            MenuInfoModel menuInfo = default(MenuInfoModel);
            string sql = "select MenuId,MenuName,ParentId,FrmName,MKey from MenuInfos where MenuId=@menuId";
            SqlParameter paraId = new SqlParameter("@menuId", menuId);
            SqlDataReader dr = DBHelper.ExecuteReader(sql, 1, paraId);
            if(dr.Read())
            {
                menuInfo = new MenuInfoModel();
                string strId = dr["MenuId"].ToString();
                menuInfo.MenuId = strId.GetInt();
                menuInfo.MenuName = dr["MenuName"].ToString();
                menuInfo.ParentId = dr["ParentId"].ToString().GetInt();
                menuInfo.FrmName= dr["FrmName"].ToString();
                menuInfo.MKey = dr["MKey"].ToString();
            }
            dr.Close();
            return menuInfo;
        }

        /// <summary>
        /// 判断菜单名是否已存在
        /// </summary>
        /// <param name="menuName"></param>
        /// <returns></returns>
        public bool ExistMenuName(string menuName)
        {
            string sql = "select count(1) from MenuInfos where MenuName=@menuName";
            SqlParameter paraName = new SqlParameter("@menuName", menuName);
            object oCount = DBHelper.ExecuteScalar(sql, 1, paraName);
            if (oCount != null && oCount.ToString() != "")
                return oCount.GetInt() > 0;
            else
                return false;
        }

        /// <summary>
        /// 添加菜单信息
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        public bool AddMenuInfo(MenuInfoModel menuInfo)
        {
            string sql = "insert into MenuInfos (MenuName,ParentId,FrmName,MKey) values (@menuName,@parentId,@frmName,@mKey)";
            SqlParameter[] paras =
            {
                new SqlParameter("@menuName",menuInfo.MenuName),
                new SqlParameter("@parentId",menuInfo.ParentId),
                new SqlParameter("@frmName",menuInfo.FrmName),
                new SqlParameter("@mKey",menuInfo.MKey)
            };
            return DBHelper.ExecuteNonQuery(sql, 1, paras) > 0;

        }

        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        public bool UpdateMenuInfo(MenuInfoModel menuInfo)
        {
            string sql= "update MenuInfos set MenuName=@menuName,ParentId=@parentId,FrmName=@frmName,MKey=@mKey where MenuId=@menuId";
            SqlParameter[] paras =
           {
                new SqlParameter("@menuName",menuInfo.MenuName),
                new SqlParameter("@parentId",menuInfo.ParentId),
                new SqlParameter("@frmName",menuInfo.FrmName),
                new SqlParameter("@mKey",menuInfo.MKey),
                new SqlParameter("@menuId",menuInfo.MenuId)
            };
            
            return DBHelper.ExecuteNonQuery(sql, 1, paras) > 0;
        }
    }
}
