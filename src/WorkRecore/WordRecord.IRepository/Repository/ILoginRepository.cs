using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorkRecord.Model.Entity;

namespace WordRecord.IRepository.Repository
{
    public interface ILoginRepository
    {
        /// <summary>
        /// 获取单个实体（条件）
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        Task<User> GetSingleEntityAsync(Expression<Func<User, bool>> predicate);
    }
}
