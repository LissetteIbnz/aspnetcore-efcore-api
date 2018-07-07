using SchoolManager.Core.Repositories;
using System;

namespace SchoolManager.Service
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }

        int Complete();
    }
}
