using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordRecord.IRepository.UnitOfWork;

namespace WordRecord.Repository.UnitOfWork
{
    public class UnitOfWork<TDbContext> : IUnitOfWork,IDisposable where TDbContext : DbContext
    {
        /// <summary>
        /// dbContext上下文
        /// </summary>
        private readonly TDbContext _dbContext;

        public UnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangeAsync()
        {
            int code;
            try
            {
                code =await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.InnerException == null ? e.Message : e.InnerException.Message);
            }
            return code;
        }
    }
}
