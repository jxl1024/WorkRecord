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
    public class WorkItemRepository : IWorkItemRepository
    {
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="dbContext"></param>
        public WorkItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> AddAsync(WorkItem entity)
        {
            _dbContext.WorkItems.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(string id)
        {
            WorkItem entity = _dbContext.WorkItems.Find(id);
            if (entity != null)
            {
                _dbContext.WorkItems.Remove(entity);
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> GetCountAsync(Expression<Func<WorkItem, bool>> predicate)
        {
            return await Task.Run<int>(() =>
            {
                return predicate != null ? _dbContext.WorkItems.Where(predicate).Count() : _dbContext.Users.Count();
            });
        }

        public async Task<WorkItem> GetEntityAsync(Expression<Func<WorkItem, bool>> predicate)
        {
            return await Task.Run<WorkItem>(() =>
            {
                return _dbContext.WorkItems.FirstOrDefault(predicate);
            });
        }

        public async Task<IEnumerable<WorkItem>> GetPatgeListAsync<TKey>(int pageIndex, int pageSize, Expression<Func<WorkItem, bool>> predicate, bool isAsc, 
            Expression<Func<WorkItem, TKey>> keySelector)
        {
            List<WorkItem> list = new List<WorkItem>();
            var skip = (pageIndex - 1) * pageSize;
            list = await Task.Run<List<WorkItem>>(() =>
            {
                if (predicate == null)
                {
                    if (isAsc)
                    {
                        return _dbContext.WorkItems.OrderBy(keySelector).Skip(skip).Take(pageSize).ToList();
                    }
                    else
                    {
                        return _dbContext.WorkItems.OrderByDescending(keySelector).Skip(skip).Take(pageSize).ToList();
                    }

                }
                else
                {
                    if (isAsc)
                    {
                        return _dbContext.WorkItems.Where(predicate).OrderBy(keySelector).Skip(skip).Take(pageSize).ToList();
                    }
                    else
                    {
                        return _dbContext.WorkItems.Where(predicate).OrderByDescending(keySelector).Skip(skip).Take(pageSize).ToList();
                    }

                }
            });


            return list;
        }

        public async Task<int> UpdateAsync(WorkItem entity)
        {
            WorkItem item = _dbContext.WorkItems.Find(entity.CreatedTime);
            if (item != null)
            {
                item.WorkContent = entity.WorkContent;
                _dbContext.Entry<WorkItem>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
