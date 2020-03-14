using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkRecord.Model.DTO;
using WorkRecord.Model.Entity;

namespace WorkRecord.API.AutoMapper
{
    public class DepartmentProfile: Profile
    {
        /// <summary>
        /// 构造函数来创建映射关系
        /// </summary>
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDTO>()
                    .ForMember(destinationMember: des => des.DepartmentID,
                memberOptions: opt =>
                {
                    opt.MapFrom(mapExpression: src => src.DeptID);
                })
             .ForMember(destinationMember: des => des.DepartmentCode,
             memberOptions: opt =>
             {
                 opt.MapFrom(mapExpression: src => src.DeptCode);
             })
             .ForMember(destinationMember: des => des.DepartmentName,
             memberOptions: opt =>
             {
                 opt.MapFrom(mapExpression: src => src.DeptName);
             }).ReverseMap();
        }
    }
}
