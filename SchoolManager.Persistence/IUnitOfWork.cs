using System;
using SchoolManager.Core.Repositories;

namespace SchoolManager.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }

        int Complete();
    }
}
