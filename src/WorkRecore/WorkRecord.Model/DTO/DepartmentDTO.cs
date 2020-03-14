using System;
using System.Collections.Generic;
using System.Text;

namespace WorkRecord.Model.DTO
{
    public class DepartmentDTO
    {
        /// <summary>
        /// 部门ID，主键
        /// </summary>
        public string DepartmentID { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
