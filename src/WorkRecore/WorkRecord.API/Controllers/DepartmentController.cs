using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkRecord.IService.Service;
using WorkRecord.Model.DTO;
using WorkRecord.Model.Entity;

namespace WorkRecord.API.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service,IMapper mapper)
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
        public async Task<List<DepartmentDTO>> GetPageList(int pageIndex, int pageSize)
        {
            List<DepartmentDTO> listDto = new List<DepartmentDTO>();
            Expression<Func<Department, string>> keySelector = p => p.DeptID;
            IEnumerable<Department> list = await _service.GetPatgeListAsync<string>(pageIndex, pageSize, null, false, keySelector);
            // 使用AutoMapper进行自动映射
            listDto = _mapper.Map<List<DepartmentDTO>>(list);
            return listDto;
        }


        [HttpPost]
        public async Task<int> Post([FromBody]DepartmentDTO entity)
        {
            entity.DepartmentID = Guid.NewGuid().ToString();

            Department dept = _mapper.Map<Department>(entity);
            return await _service.AddAsync(dept);
        }

        [HttpDelete]
        public async Task<int> Delete(string id)
        {
            return await _service.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<int> Put([FromBody]DepartmentDTO entity)
        {
            Department dept = _mapper.Map<Department>(entity);
            return await _service.UpdateAsync(dept);
        }
    }
}