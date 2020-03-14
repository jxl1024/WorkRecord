using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WordRecord.IRepository.Repository;
using WorkRecord.Data.Context;
using WorkRecord.Model.Entity;

namespace WordRecord.Repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="dbContext"></param>
        public RoleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Role entity)
        {
            _dbContext.Roles.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(string id)
        {
            Role entity = _dbContext.Roles.Find(id);
            if (entity != null)
            {
                _dbContext.Roles.Remove(entity);
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> GetCountAsync(Expression<Func<Role, bool>> predicate)
        {
            return await Task.Run<int>(() =>
            {
                return predicate != null ? _dbContext.Roles.Where(predicate).Count() : _dbContext.Users.Count();
            });
        }

        public async Task<Role> GetEntityAsync(Expression<Func<Role, bool>> predicate)
        {
            return await Task.Run<Role>(() =>
            {
                return _dbContext.Roles.FirstOrDefault(predicate);
            });
        }

        public async Task<IEnumerable<Role>> GetPatgeListAsync<TKey>(int pageIndex, int pageSize, Expression<Func<Role, bool>> predicate, bool isAsc,
            Expression<Func<Role, TKey>> keySelector)
        {
            List<Role> list = new List<Role>();
            var skip = (pageIndex - 1) * pageSize;
            list = await Task.Run<List<Role>>(() =>
            {
                if (predicate == null)
                {
                    if (isAsc)
                    {
                        return _dbContext.Roles.OrderBy(keySelector).Skip(skip).Take(pageSize).ToList();
                    }
                    else
                    {
                        return _dbContext.Roles.OrderByDescending(keySelector).Skip(skip).Take(pageSize).ToList();
                    }

                }
                else
                {
                    if (isAsc)
                    {
                        return _dbContext.Roles.Where(predicate).OrderBy(keySelector).Skip(skip).Take(pageSize).ToList();
                    }
                    else
                    {
                        return _dbContext.Roles.Where(predicate).OrderByDescending(keySelector).Skip(skip).Take(pageSize).ToList();
                    }

                }
            });


            return list;
        }

        public async Task<int> UpdateAsync(Role entity)
        {
            Role role = _dbContext.Roles.Find(entity.RoleID);
            if (role != null)
            {
                role.RoleName = entity.RoleName;
                _dbContext.Entry<Role>(role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
