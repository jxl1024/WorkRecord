using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkRecord.IService.Service;
using WorkRecord.Model.Entity;

namespace WorkRecord.API.Controllers
{
    /// <summary>
    /// User控制器
    /// 这里修改路由
    /// </summary>
    // [Route("api/[controller]")]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="service"></param>
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<User>> GetPageList(int pageIndex, int pageSize)
        {
            Expression<Func<User, string>> keySelector = p => p.UserID;
            IEnumerable<User> list = await _service.GetPatgeListAsync<string>(pageIndex, pageSize, null, false, keySelector);
            return list.ToList();
        }

        [HttpPost]
        public async Task<int> Post([FromBody]User entity)
        {
            entity.UserID = Guid.NewGuid().ToString();
            return await _service.AddAsync(entity);
        }

        [HttpDelete]
        public async Task<int> Delete(string id)
        {
            return await _service.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<int> Put([FromBody]User entity)
        {
            return await _service.UpdateAsync(entity);
        }
    }
}