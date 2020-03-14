using AutoMapper;
using WorkRecord.Model.DTO;
using WorkRecord.Model.Entity;

namespace WorkRecord.API.AutoMapper
{
    /// <summary>
    /// 继承自AutoMapper的Profile
    /// </summary>
    public class UserProfile : Profile
    {
        /// <summary>
        /// 构造函数来创建映射关系
        /// </summary>
        public UserProfile()
        {
            // 第一次参数是源类型（这里是Model类型），第二个参数是目标类型（这里是DTO类型）
            //CreateMap<User, UserDto>();

            // 将User的Name映射为UserDto的UserName
            CreateMap<User, UserDTO>()
               .ForMember(
               // 目标
               destinationMember: des => des.UserName,
               memberOptions: opt =>
               // 源
               opt.MapFrom(mapExpression: src => src.Name)).ReverseMap();
        }
    }
}
