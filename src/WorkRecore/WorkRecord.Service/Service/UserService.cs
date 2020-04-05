using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordRecord.IRepository.Repository;
using WorkRecord.IService.Service;
using WorkRecord.Model.Entity;

namespace WorkRecord.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }


        public async Task<int> AddAsync(User entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<int> GetCountAsync(Expression<Func<User, bool>> predicate)
        {
            return await _repository.GetCountAsync(predicate);
        }

        public async Task<User> GetEntityAsync(Expression<Func<User, bool>> predicate)
        {
            return await _repository.GetEntityAsync(predicate);
        }

        public async Task<IEnumerable<User>> GetPatgeListAsync<TKey>(int pageIndex, int pageSize, Expression<Func<User, bool>> predicate, bool isAsc, 
            Expression<Func<User, TKey>> keySelector)
        {
            try
            {
                return await _repository.GetPatgeListAsync(pageIndex, pageSize, predicate, isAsc, keySelector);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> UpdateAsync(User entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
