using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WordRecord.IRepository.Repository;
using WorkRecord.IService.Service;
using WorkRecord.Model.Entity;
using WorkRecord.Service.Base;

namespace WorkRecord.Service.Service
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)  :base(repository)
        {
            _repository = repository;
        }

        //public async Task<int> AddAsync(Department entity)
        //{
        //    return await _repository.AddAsync(entity);
        //}

        //public async Task<int> DeleteAsync(string id)
        //{
        //    return await _repository.DeleteAsync(id);
        //}

        //public async Task<int> GetCountAsync(Expression<Func<Department, bool>> predicate)
        //{
        //    return await _repository.GetCountAsync(predicate);
        //}

        //public async Task<Department> GetEntityAsync(Expression<Func<Department, bool>> predicate)
        //{
        //    return await _repository.GetEntityAsync(predicate);
        //}

        //public async Task<IEnumerable<Department>> GetPatgeListAsync<TKey>(int pageIndex, int pageSize, Expression<Func<Department, bool>> predicate, bool isAsc,
        //    Expression<Func<Department, TKey>> keySelector)
        //{
        //    return await _repository.GetPatgeListAsync(pageIndex, pageSize, predicate, isAsc, keySelector);
        //}

        //public async Task<int> UpdateAsync(Department entity)
        //{
        //    return await _repository.UpdateAsync(entity);
        //}
    }
}
