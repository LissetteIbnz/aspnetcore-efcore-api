using SchoolManager.Core.Repositories;
using SchoolManager.Persistence;
using SchoolManager.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManager.Service
{
    public class Service : IUnitOfWork
    {
        private readonly SchoolContext _context;

        private IStudentRepository students = null;

        public Service(SchoolContext context)
        {
            _context = context;
        }

        public IStudentRepository Students => students ?? (students = new StudentRepository(_context));

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
