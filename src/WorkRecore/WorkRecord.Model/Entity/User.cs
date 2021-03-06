﻿using WorkRecord.Model.Entity.Base;

namespace WorkRecord.Model.Entity
{
    public class User: BaseEntity
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
        public string Name { get; set; }

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
    }
}
