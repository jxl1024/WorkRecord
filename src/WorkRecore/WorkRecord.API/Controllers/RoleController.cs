using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkRecord.IService.Service;
using WorkRecord.Model.DTO;
using WorkRecord.Model.Entity;

namespace WorkRecord.API.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        // AutoMapper
        private readonly IMapper _mapper;
        private readonly IRoleService _service;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="service"></param>
        public RoleController(IRoleService service, IMapper mapper)
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
        public async Task<List<RoleDTO>> GetPageList(int pageIndex, int pageSize)
        {
            List<RoleDTO> listDto = new List<RoleDTO>();
            Expression<Func<Role, string>> keySelector = p => p.RoleID;
            IEnumerable<Role> list = await _service.GetPatgeListAsync<string>(pageIndex, pageSize, null, false, keySelector);
            // 使用AutoMapper进行自动映射
            listDto = _mapper.Map<List<RoleDTO>>(list);
            return listDto;
        }


        [HttpPost]
        public async Task<int> Post([FromBody]Role entity)
        {
            entity.RoleID = Guid.NewGuid().ToString();
            return await _service.AddAsync(entity);
        }

        [HttpDelete]
        public async Task<int> Delete(string id)
        {
            return await _service.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<int> Put([FromBody]Role entity)
        {
            return await _service.UpdateAsync(entity);
        }
    }
}