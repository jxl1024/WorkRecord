using System;
using WorkRecord.Model.Entity.Base;

namespace WorkRecord.Model.DTO
{
    public class UserDTO 
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 用户登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 角色ID，对应角色表主键ID
        /// </summary>
        public string RoleID { get; set; }

        /// <summary>
        /// 部门ID，对应部门表主键ID
        /// </summary>
        public string DepartmentID { get; set; }

        /// <summary>
        /// 是否删除 true 删除 false 未删除
        /// </summary>
        public bool IsDel { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public string CreatedUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public string UpdatedUserId { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedTime { get; set; }
    }
}
