using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WordRecord.IRepository.Base;
using WorkRecord.IService.Base;

namespace WorkRecord.Service.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        // 通过子类的构造函数进行注入
        public IBaseRepository<TEntity> BaseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            BaseRepository = baseRepository;
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            return await BaseRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(string id)
        {
            return await BaseRepository.DeleteAsync(id);
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await BaseRepository.GetCountAsync(predicate);
        }

        public async Task<TEntity> GetEntityAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await BaseRepository.GetEntityAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetPatgeListAsync<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate, bool isAsc, 
            Expression<Func<TEntity, TKey>> keySelector)
        {
            try
            {
                return await BaseRepository.GetPatgeListAsync(pageIndex, pageSize, predicate, isAsc, keySelector);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            return await BaseRepository.UpdateAsync(entity);
        }
    }
}
