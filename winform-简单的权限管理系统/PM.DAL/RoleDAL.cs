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
    public class RoleDAL
    {
        /// <summary>
        /// 获取所有角色列表
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetAllRoles()
        {
            List<RoleInfoModel> list = new List<RoleInfoModel>();
            string sql = "select RoleId,RoleName,Remark from RoleInfos";
           SqlDataReader dr= DBHelper.ExecuteReader(sql, 1);
            while(dr.Read())
            {
                RoleInfoModel role = new RoleInfoModel();
                role.RoleId = int.Parse(dr["RoleId"].ToString());
                role.RoleName = dr["RoleName"].ToString();
                role.Remark = dr["Remark"].ToString();
                list.Add(role);
            }
            dr.Close();
            return list;
        }

        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <returns></returns>
        public DataTable GetCboRoles()
        {
            string sql = "select RoleId,RoleName from RoleInfos";
            return DBHelper.GetDataTable(sql, 1);
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool DeleteRole(int roleId)
        {
            //先删除关系表,再删除主键表
            string delUserRole = $"delete from UserRoleInfos where RoleId={roleId}";
            string delRoleMenu = $"delete from RoleMenuInfos where RoleId={roleId}";
            string delRole = $"delete from RoleInfos where RoleId={roleId}";
            List<string> list = new List<string>();
            list.Add(delUserRole);
            list.Add(delRoleMenu);
            list.Add(delRole);
            return DBHelper.ExecuteTrans(list);
        }

        /// <summary>
        /// 获取指定的角色信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleInfoModel GetRole(int roleId)
        {
            RoleInfoModel role = default(RoleInfoModel);
            string sql = $"select RoleId,RoleName,Remark,IsAdmin from RoleInfos where RoleId={roleId}";
            SqlDataReader dr = DBHelper.ExecuteReader(sql, 1);
            if(dr.Read())
            {
                role = new RoleInfoModel();
                role.RoleId = int.Parse(dr["RoleId"].ToString());
                role.RoleName = dr["RoleName"].ToString();
                role.Remark = dr["Remark"].ToString();
                role.IsAdmin = dr["IsAdmin"].ToString().GetInt();
            }
            dr.Close();
            return role;
        }

        /// <summary>
        /// 判断角色名称是否已存在
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public bool ExistRole(string roleName)
        {
            string sql = "select count(1) from RoleInfos where RoleName=@roleName";
            SqlParameter paraName = new SqlParameter("@roleName", roleName);
            object oCount = DBHelper.ExecuteScalar(sql, 1, paraName);
            if (oCount != null && oCount.ToString() != "")
                return oCount.GetInt() > 0;
            else
                return false;
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool AddRole(RoleInfoModel roleInfo)
        {
            string sql = "insert into RoleInfos(RoleName,Remark) values (@roleName,@remark)";
            SqlParameter[] paras =
            {
                new SqlParameter("@roleName",roleInfo.RoleName),
                new SqlParameter("@remark",roleInfo.Remark)
            };
            return DBHelper.ExecuteNonQuery(sql, 1, paras) > 0;
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool UpdateRole(RoleInfoModel roleInfo)
        {
            string sql = "update RoleInfos set RoleName=@roleName,Remark=@remark where RoleId=@roleId";
            SqlParameter[] paras =
            {
                new SqlParameter("@roleName",roleInfo.RoleName),
                new SqlParameter("@remark",roleInfo.Remark),
                new SqlParameter("@roleId",roleInfo.RoleId)
            };
            return DBHelper.ExecuteNonQuery(sql, 1, paras) > 0;
        }

        /// <summary>
        /// 保存权限设置
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        public bool SaveRight(int roleId,List<int> menuIds)
        {
            List<string> sqlList = new List<string>();
            sqlList.Add($"delete from RoleMenuInfos where RoleId={roleId}");
            foreach (int menuId in menuIds)
            {
                string sql = $"insert into RoleMenuInfos (RoleId,MenuId) values ({roleId},{menuId})";
                sqlList.Add(sql);
            }

            return DBHelper.ExecuteTrans(sqlList);
        }
    }
}
