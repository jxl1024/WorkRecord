using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WordRecord.IRepository.Repository;
using WorkRecord.IService.Service;
using WorkRecord.Model.Entity;
using WorkRecord.Model.Jwt;

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

            //ValidateInfo validateInfo = new ValidateInfo();

            //Expression<Func<User, bool>> keySelector = p => p.Account.Equals(entity.Account);

            //User user= await _repository.GetSingleEntityAsync(keySelector);
            //if (null != user && user.Password.Equals(entity.Password))
            //{
            //    validateInfo.Code = 0;
            //    validateInfo.Message = "成功";
            //}
            //    return validateInfo;

            return await _repository.GetSingleEntityAsync(predicate);
        }
    }
}
