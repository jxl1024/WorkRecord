using WordRecord.IRepository.Repository;
using WorkRecord.IService.Service;
using WorkRecord.Model.Entity;
using WorkRecord.Service.Base;

namespace WorkRecord.Service.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _repository;

        /// <summary>
        /// 通过构造函数给父类传值
        /// </summary>
        /// <param name="repository"></param>
        public UserService(IUserRepository repository)    :base(repository)
        {
            _repository = repository;
            // 父类传值
            // base.BaseRepository = repository;
        } 
    }
}
