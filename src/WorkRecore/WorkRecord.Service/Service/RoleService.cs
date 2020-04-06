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
    public class RoleService : BaseService<Role>, IRoleService
    {

        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository) :base(repository)
        {
            _repository = repository;
        }

        //public async Task<int> AddAsync(Role entity)
        //{
        //    return await _repository.AddAsync(entity);
        //}

        //public async Task<int> DeleteAsync(string id)
        //{
        //    return await _repository.DeleteAsync(id);
        //}

        //public async Task<int> GetCountAsync(Expression<Func<Role, bool>> predicate)
        //{
        //    return await _repository.GetCountAsync(predicate);
        //}

        //public async Task<Role> GetEntityAsync(Expression<Func<Role, bool>> predicate)
        //{
        //    return await _repository.GetEntityAsync(predicate);
        //}

        //public async Task<IEnumerable<Role>> GetPatgeListAsync<TKey>(int pageIndex, int pageSize, Expression<Func<Role, bool>> predicate, bool isAsc, 
        //    Expression<Func<Role, TKey>> keySelector)
        //{
        //    return await _repository.GetPatgeListAsync(pageIndex, pageSize, predicate, isAsc, keySelector);
        //}

        //public async Task<int> UpdateAsync(Role entity)
        //{
        //    return await _repository.UpdateAsync(entity);
        //}
    }
}
