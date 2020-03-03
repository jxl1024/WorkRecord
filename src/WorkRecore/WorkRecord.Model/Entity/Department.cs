using WorkRecord.Model.Entity.Base;

namespace WorkRecord.Model.Entity
{
    public class Department: BaseEntity
    {
        /// <summary>
        /// 部门ID，主键
        /// </summary>
        public string DeptID { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        public string DeptCode { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }
    }
}
