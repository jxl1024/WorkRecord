using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkRecord.Model.DTO;
using WorkRecord.Model.Entity;

namespace WorkRecord.API.AutoMapper
{
    public class RoleProfile: Profile
    {
        /// <summary>
        /// 构造函数来创建映射关系
        /// </summary>
        public RoleProfile()
        {
            // 第一次参数是源类型（这里是Model类型），第二个参数是目标类型（这里是DTO类型）
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
