﻿using System;
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
        /// 分页获取角色信息
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示的条数</param>
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

        /// <summary>
        /// 新增角色信息
        /// </summary>
        /// <param name="entity">角色实体</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultMsg> Post([FromBody]Role entity)
        {
            ResultMsg msg = new ResultMsg();
            entity.RoleID = Guid.NewGuid().ToString();
            int result= await _service.AddAsync(entity);
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
        /// 删除角色
        /// </summary>
        /// <param name="id">角色ID</param>
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
        /// 更新角色信息
        /// </summary>
        /// <param name="entity">角色实体</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultMsg> Put([FromBody]Role entity)
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