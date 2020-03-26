using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordRecord.IRepository.Repository;
using WorkRecord.IService.Service;
using WorkRecord.Model.Entity;

namespace WorkRecord.Service.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;

        public LoginService(ILoginRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> GetSingleEntityAsync(Expression<Func<User, bool>> predicate)
        {
            return await _repository.GetSingleEntityAsync(predicate);
        }
    }
}
