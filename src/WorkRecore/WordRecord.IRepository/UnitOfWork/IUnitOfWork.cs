using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkRecord.Data.Context;

namespace WordRecord.IRepository.UnitOfWork
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangeAsync();
    }
}
