using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkRecord.IService.Service;
using WorkRecord.Model.DTO;
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
        // AutoMapper
        private readonly IMapper _mapper;
        private readonly IUserService _service;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="service"></param>
        public UserController(IUserService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<List<User>> GetPageList(int pageIndex, int pageSize)
        //{
        //    Expression<Func<User, string>> keySelector = p => p.UserID;
        //    IEnumerable<User> list = await _service.GetPatgeListAsync<string>(pageIndex, pageSize, null, false, keySelector);
        //    return list.ToList();
        //}


        /// <summary>
        /// 这里修改为返回List<UserDto>类型
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<UserDTO>> GetPageList(int pageIndex, int pageSize)
        {
            List<UserDTO> listDto = new List<UserDTO>();
            Expression<Func<User, string>> keySelector = p => p.UserID;
            IEnumerable<User> list = await _service.GetPatgeListAsync<string>(pageIndex, pageSize, null, false, keySelector);
            //// 循环赋值 为了演示方便，只给几个字段赋值
            //foreach (var item in list)
            //{
            //    UserDto entity = new UserDto();
            //    entity.UserID = item.UserID;
            //    entity.Name = item.Name;
            //    entity.Password = item.Password;
            //    entity.Account = item.Account;
            //    listDto.Add(entity);
            //}

            // 使用AutoMapper进行自动映射
            listDto = _mapper.Map<List<UserDTO>>(list);
            return listDto;
        }


        [HttpPost]
        public async Task<int> Post([FromBody]UserDTO entity)
        {
            // UserID赋值
            entity.UserID = Guid.NewGuid().ToString();

            // 映射
            User user = _mapper.Map<User>(entity);
            return await _service.AddAsync(user);
        }

        [HttpDelete]
        public async Task<int> Delete(string id)
        {
            return await _service.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<int> Put([FromBody]UserDTO entity)
        {
            User user = _mapper.Map<User>(entity);
            return await _service.UpdateAsync(user);
        }
    }
}