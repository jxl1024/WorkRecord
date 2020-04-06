using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WordRecord.IRepository.Repository;
using WorkRecord.IService.Service;
using WorkRecord.Model.DTO;
using WorkRecord.Model.Entity;
using WorkRecord.Service.Base;

namespace WorkRecord.Service.Service
{
    public class WorkItemService : BaseService<WorkItem>, IWorkItemService
    {
        private readonly IWorkItemRepository _repository;

        public WorkItemService(IWorkItemRepository repository) :base(repository)
        {
            _repository = repository;
        }

        //public async Task<int> AddAsync(WorkItem entity)
        //{
        //    return await _repository.AddAsync(entity);
        //}

        //public async Task<int> DeleteAsync(string id)
        //{
        //    return await _repository.DeleteAsync(id);
        //}

        //public async Task<int> GetCountAsync(Expression<Func<WorkItem, bool>> predicate)
        //{
        //    return await _repository.GetCountAsync(predicate);
        //}

        //public async Task<WorkItem> GetEntityAsync(Expression<Func<WorkItem, bool>> predicate)
        //{
        //    return await _repository.GetEntityAsync(predicate);
        //}

        //public async Task<IEnumerable<WorkItem>> GetPatgeListAsync<TKey>(int pageIndex, int pageSize, Expression<Func<WorkItem, bool>> predicate, bool isAsc,
        //    Expression<Func<WorkItem, TKey>> keySelector)
        //{
        //    return await _repository.GetPatgeListAsync(pageIndex, pageSize, predicate, isAsc, keySelector);
        //}

        //public async Task<int> UpdateAsync(WorkItem entity)
        //{
        //    return await _repository.UpdateAsync(entity);
        //}
    }
}
