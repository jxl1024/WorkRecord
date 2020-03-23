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
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="dbContext"></param>
        public LoginRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 根据条件表达式获取单一实体
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        public async Task<User> GetSingleEntityAsync(Expression<Func<User, bool>> predicate)
        {
            return await Task.Run<User>(() =>
            {
                return _dbContext.Users.FirstOrDefault(predicate);
            });
        }
    }
}
