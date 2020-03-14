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
            listDto = _mapper.Map<List<WorkItemDTO>>(list);
            return listDto;
        }


        [HttpPost]
        public async Task<int> Post([FromBody]WorkItem entity)
        {
            entity.WorkID = Guid.NewGuid().ToString();
            return await _service.AddAsync(entity);
        }

        [HttpDelete]
        public async Task<int> Delete(string id)
        {
            return await _service.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<int> Put([FromBody]WorkItem entity)
        {
            return await _service.UpdateAsync(entity);
        }
    }
}