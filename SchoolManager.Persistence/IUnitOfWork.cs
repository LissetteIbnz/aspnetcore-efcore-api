using SchoolManager.Core.Repositories;
using System;

namespace SchoolManager.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }

        int Complete();
    }
}
