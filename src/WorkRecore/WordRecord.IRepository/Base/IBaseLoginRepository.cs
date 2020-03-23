using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WordRecord.IRepository.Base
{
    public interface IBaseLoginRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 获取单个实体（条件）
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        Task<TEntity> GetSingleEntityAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
