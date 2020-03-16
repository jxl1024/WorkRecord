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
            // 使用AutoMapper进行自动映射
            listDto = _mapper.Map<List<UserDTO>>(list);
            return listDto;
        }


        [HttpPost]
        public async Task<ResultMsg> Post([FromBody]UserDTO entity)
        {
            ResultMsg msg = new ResultMsg();
            // UserID赋值
            entity.UserID = Guid.NewGuid().ToString();

            // 映射
            User user = _mapper.Map<User>(entity);
            int result= await _service.AddAsync(user);
            if(result>0)
            {
                msg.Code = 1;
                msg.Message = "成功";
            }
            else
            {
                msg.Code = 2;
                msg.Message = "失败";
            }
            return msg;
        }

        [HttpDelete]
        public async Task<ResultMsg> Delete(string id)
        {
            ResultMsg msg = new ResultMsg();
            int result= await _service.DeleteAsync(id);
            if (result > 0)
            {
                msg.Code = 1;
                msg.Message = "成功";
            }
            else
            {
                msg.Code = 2;
                msg.Message = "失败";
            }
            return msg;
        }

        [HttpPut]
        public async Task<ResultMsg> Put([FromBody]UserDTO entity)
        {
            ResultMsg msg = new ResultMsg();
            User user = _mapper.Map<User>(entity);
            int result= await _service.UpdateAsync(user);
            if (result > 0)
            {
                msg.Code = 1;
                msg.Message = "成功";
            }
            else
            {
                msg.Code = 2;
                msg.Message = "失败";
            }
            return msg;
        }
    }
}