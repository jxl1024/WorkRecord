﻿using WorkRecord.Model.Entity.Base;

namespace WorkRecord.Model.Entity
{
    public class Role: BaseEntity
    {
        /// <summary>
        /// 角色ID，主键
        /// </summary>
        public string RoleID { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string RoleCode { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 是否删除 true删除 false 未删除
        /// </summary>
        public bool IsDel { get; set; }
    }
}
