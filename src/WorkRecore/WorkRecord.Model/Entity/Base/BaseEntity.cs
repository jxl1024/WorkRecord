using System;

namespace WorkRecord.Model.Entity.Base
{
    public class BaseEntity
    {
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
