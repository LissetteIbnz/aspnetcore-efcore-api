using SchoolManager.Core.Repositories;
using System;

namespace SchoolManager.Service
{
    public interface IService : IDisposable
    {
        IStudentRepository Students { get; }

        int Complete();
    }
}
