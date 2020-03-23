using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkRecord.IService.Service;
using WorkRecord.Model.Entity;
using WorkRecord.Model.Jwt;

namespace WorkRecord.JwtServer.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpGet]
        public string Get()
        {
            return "Success";
        }


        [HttpPost]
        public async Task<ValidateInfo>  Post([FromBody]User entity)
        {
            ValidateInfo validateInfo = new ValidateInfo();

            Expression<Func<User, bool>> keySelector = p => p.Account.Equals(entity.Account);

            User user = await _service.GetSingleEntityAsync(keySelector);
            if (null != user && user.Password.Equals(entity.Password))
            {
                validateInfo.Code = 0;
                validateInfo.Message = "成功";
            }
            else
            {
                validateInfo.Code = 1;
                validateInfo.Message = "失败";
            }
            return validateInfo;
        }
    }
}