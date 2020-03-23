using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkRecord.IService.Base;
using WorkRecord.Model.Entity;
using WorkRecord.Model.Jwt;

namespace WorkRecord.IService.Service
{
   //public interface ILoginService   : IBaseLoginService<User>
   // {
   // }


    public interface ILoginService
    {
        /// <summary>
        /// 获取单个实体（条件）
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        Task<User> GetSingleEntityAsync(Expression<Func<User, bool>> predicate);
    }
}
