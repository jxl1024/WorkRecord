using System;
using WorkRecord.Model.Entity.Base;

namespace WorkRecord.Model.Entity
{
    public class WorkItem: BaseEntity
    {
        /// <summary>
        /// ID，主键
        /// </summary>
        public string WorkID { get; set; }

        /// <summary>
        /// 工作内容
        /// </summary>
        public string WorkContent { get; set; }

        /// <summary>
        /// 表示记录的是哪一天的工作内容
        /// </summary>
        public DateTime RecordTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memos { get; set; }
    }
}
