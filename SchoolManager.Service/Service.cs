using Microsoft.Extensions.Logging;
using SchoolManager.Persistence;

namespace SchoolManager.Service
{
    public abstract class Service : IService
    {
        protected ILogger Logger;
        protected bool Disposed;
        protected readonly SchoolContext DbContext;
        protected IUnitOfWork m_unitOfWork;

        public Service(ILogger logger, SchoolContext dbContext)
        {
            Logger = logger;
            DbContext = dbContext;
            
        }

        protected IUnitOfWork UnitOfWork
            => m_unitOfWork ?? (m_unitOfWork = new UnitOfWork(DbContext));
    }

    public interface IService { }
}
