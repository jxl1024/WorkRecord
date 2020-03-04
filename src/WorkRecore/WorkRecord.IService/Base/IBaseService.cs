using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WorkRecord.IService.Base
{
    /// <summary>
    /// 泛型接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseService<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> AddAsync(TEntity entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(string id);


        /// <summary>
        /// 分页条件查询
        /// </summary>
        /// <typeparam name="TKey">排序类型</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="predicate">条件表达式</param>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="keySelector">排序表达式</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetPatgeListAsync<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate,
            bool isAsc, Expression<Func<TEntity, TKey>> keySelector);

        ///// <summary>
        ///// 获取单个实体(主键)
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //TEntity GetEntityById(object id);

        /// <summary>
        /// 获取实体（条件）
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        Task<TEntity> GetEntityAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
