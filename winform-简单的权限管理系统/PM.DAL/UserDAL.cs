using PM.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.DAL.Helper;
using PM.Common;
using System.Data;

namespace PM.DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Login(UserInfoModel user)
        {
            string sql = "select UserId from UserInfos where UserName=@UserName and UserPwd=@UserPwd";
            SqlParameter[] paras =
            {
                new SqlParameter("@UserName",user.UserName),
                new SqlParameter("@UserPwd",user.UserPwd)
            };
            object oId = DBHelper.ExecuteScalar(sql, 1, paras);
            if (oId != null && oId.ToString() != "")
            {
                return oId.GetInt();
            }
            else
                return 0;
        }

        public List<RoleInfoModel> GetUserRoles(int userId)
        {
            string sql = "select r.RoleId,RoleName,IsAdmin from UserRoleInfos ur inner join RoleInfos r on r.RoleId = ur.RoleId where UserId = @userId";
            SqlParameter paraId = new SqlParameter("@userId", userId);
            SqlDataReader dr = DBHelper.ExecuteReader(sql, 1, paraId);
            List<RoleInfoModel> list = new List<RoleInfoModel>();
            while(dr.Read())
            {
                RoleInfoModel roleInfo = new RoleInfoModel();
                roleInfo.RoleId = int.Parse(dr["RoleId"].ToString());
                roleInfo.RoleName = dr["RoleName"].ToString();
                roleInfo.IsAdmin = int.Parse(dr["IsAdmin"].ToString());
                list.Add(roleInfo);
            }
            dr.Close();//关闭阅读器
            return list;
        }


    }
}
