using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordRecord.IRepository.Repository;
using WorkRecord.Data.Context;
using WorkRecord.Model.Entity;

namespace WordRecord.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _dbContext;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="dbContext"></param>
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(User entity)
        {
            _dbContext.Users.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(string id)
        {
            User entity = _dbContext.Users.Find(id);
            if (entity != null)
            {
                _dbContext.Users.Remove(entity);
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> GetCountAsync(Expression<Func<User, bool>> predicate)
        {
            return await Task.Run<int>(() =>
            {
                return predicate != null ? _dbContext.Users.Where(predicate).Count() : _dbContext.Users.Count();
            });
        }

        public async Task<User> GetEntityAsync(Expression<Func<User, bool>> predicate)
        {
            return await Task.Run<User>(() =>
            {
                return _dbContext.Users.FirstOrDefault(predicate);
            });
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="whereLambda"></param>
        /// <param name="isAsc"></param>
        /// <param name="orderByLambda"></param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetPatgeListAsync<TKey>(int pageIndex, int pageSize, Expression<Func<User, bool>> predicate, bool isAsc, 
            Expression<Func<User, TKey>> keySelector)
        {
            List<User> list = new List<User>();
            var skip = (pageIndex - 1) * pageSize;
            list = await Task.Run<List<User>>(() =>
            {
                if (predicate == null)
                {
                    if(isAsc)
                    {
                        return _dbContext.Users.OrderBy(keySelector).Skip(skip).Take(pageSize).ToList();
                    }
                    else
                    {
                        return _dbContext.Users.OrderByDescending(keySelector).Skip(skip).Take(pageSize).ToList();
                    }
                   
                }
                else
                {
                    if(isAsc)
                    {
                        return _dbContext.Users.Where(predicate).OrderBy(keySelector).Skip(skip).Take(pageSize).ToList();
                    }
                    else
                    {
                        return _dbContext.Users.Where(predicate).OrderByDescending(keySelector).Skip(skip).Take(pageSize).ToList();
                    }
                   
                }
            });


            return list;
        }

        public async Task<int> UpdateAsync(User entity)
        {
            User user = _dbContext.Users.Find(entity.UserID);
            if (user != null)
            {
                user.Name = entity.Name;
                user.Password = entity.Password;
                _dbContext.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
