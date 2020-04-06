using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WordRecord.IRepository.Base;
using WordRecord.IRepository.UnitOfWork;
using WorkRecord.Data.Context;

namespace WordRecord.Repository.BASE
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            //_dbContext.Users.Add(entity);
            //return await _dbContext.SaveChangesAsync();

            _dbContext.Add<TEntity>(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetEntityAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetPatgeListAsync<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate, bool isAsc, 
            Expression<Func<TEntity, TKey>> keySelector)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
