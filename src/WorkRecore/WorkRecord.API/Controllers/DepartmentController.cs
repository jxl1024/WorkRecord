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
        /// 分页获取数据
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示的条数</param>
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

        /// <summary>
        /// 新增部门
        /// </summary>
        /// <param name="entity">部门实体</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultMsg> Post([FromBody]DepartmentDTO entity)
        {
            ResultMsg msg = new ResultMsg();
            entity.DepartmentID = Guid.NewGuid().ToString();

            Department dept = _mapper.Map<Department>(entity);
            int result= await _service.AddAsync(dept);
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

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id">部门ID</param>
        /// <returns></returns>
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

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="entity">部门实体</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultMsg> Put([FromBody]DepartmentDTO entity)
        {
            ResultMsg msg = new ResultMsg();
            Department dept = _mapper.Map<Department>(entity);
            int result= await _service.UpdateAsync(dept);
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