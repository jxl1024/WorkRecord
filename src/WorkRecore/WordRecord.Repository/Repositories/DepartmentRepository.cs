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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(Department entity)
        {
            _dbContext.Departments.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(string id)
        {
            Department entity = _dbContext.Departments.Find(id);
            if (entity != null)
            {
                _dbContext.Departments.Remove(entity);
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> GetCountAsync(Expression<Func<Department, bool>> predicate)
        {
            return await Task.Run<int>(() =>
            {
                return predicate != null ? _dbContext.Departments.Where(predicate).Count() : _dbContext.Users.Count();
            });
        }

        public async Task<Department> GetEntityAsync(Expression<Func<Department, bool>> predicate)
        {
            return await Task.Run<Department>(() =>
            {
                return _dbContext.Departments.FirstOrDefault(predicate);
            });
        }

        public async Task<IEnumerable<Department>> GetPatgeListAsync<TKey>(int pageIndex, int pageSize, Expression<Func<Department, bool>> predicate,
            bool isAsc, Expression<Func<Department, TKey>> keySelector)
        {
            List<Department> list = new List<Department>();
            var skip = (pageIndex - 1) * pageSize;
            list = await Task.Run<List<Department>>(() =>
            {
                if (predicate == null)
                {
                    if (isAsc)
                    {
                        return _dbContext.Departments.OrderBy(keySelector).Skip(skip).Take(pageSize).ToList();
                    }
                    else
                    {
                        return _dbContext.Departments.OrderByDescending(keySelector).Skip(skip).Take(pageSize).ToList();
                    }

                }
                else
                {
                    if (isAsc)
                    {
                        return _dbContext.Departments.Where(predicate).OrderBy(keySelector).Skip(skip).Take(pageSize).ToList();
                    }
                    else
                    {
                        return _dbContext.Departments.Where(predicate).OrderByDescending(keySelector).Skip(skip).Take(pageSize).ToList();
                    }

                }
            });


            return list;
        }

        public async Task<int> UpdateAsync(Department entity)
        {
            Department dept = _dbContext.Departments.Find(entity.DeptID);
            if (dept != null)
            {
                dept.DeptName = entity.DeptName;
                _dbContext.Entry<Department>(dept).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
