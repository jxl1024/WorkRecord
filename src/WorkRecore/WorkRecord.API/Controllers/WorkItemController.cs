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
        /// 分页获取日志信息
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示的条数</param>
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


        /// <summary>
        /// 新增日志信息
        /// </summary>
        /// <param name="entity">日志实体</param>
        /// <returns></returns>
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

        /// <summary>
        /// 根据日志ID删除日志
        /// </summary>
        /// <param name="id">日志ID</param>
        /// <returns></returns>
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

        /// <summary>
        /// 更新日志
        /// </summary>
        /// <param name="entity">日志信息实体</param>
        /// <returns></returns>
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