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
    [Route("api/workitem")]
    [ApiController]
    public class WorkItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWorkItemService _service;

        public WorkItemController(IWorkItemService service,IMapper mapper)
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
        public async Task<List<WorkItemDTO>> GetPageList(int pageIndex, int pageSize)
        {
            List<WorkItemDTO> listDto = new List<WorkItemDTO>();
            Expression<Func<WorkItem, string>> keySelector = p => p.WorkID;
            IEnumerable<WorkItem> list = await _service.GetPatgeListAsync<string>(pageIndex, pageSize, null, false, keySelector);
            // 使用AutoMapper进行自动映射
            listDto = _mapper.Map<List<WorkItemDTO>>(list);
            return listDto;
        }


        [HttpPost]
        public async Task<ResultMsg> Post([FromBody]WorkItem entity)
        {
            entity.WorkID = Guid.NewGuid().ToString();
            //return await _service.AddAsync(entity);

            ResultMsg msg = new ResultMsg();
            entity.WorkID = Guid.NewGuid().ToString();
            int result = await _service.AddAsync(entity);
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

        [HttpDelete]
        public async Task<ResultMsg> Delete(string id)
        {
            ResultMsg msg = new ResultMsg();
            int result = await _service.DeleteAsync(id);
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
        public async Task<ResultMsg> Put([FromBody]WorkItem entity)
        {
            ResultMsg msg = new ResultMsg();
            int result = await _service.UpdateAsync(entity);
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