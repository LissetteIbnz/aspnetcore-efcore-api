using SchoolManager.Core.Repositories;
using SchoolManager.Persistence.Repositories;

namespace SchoolManager.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext _context;

        private IStudentRepository _students;

        public UnitOfWork(SchoolContext context)
        {
            _context = context;
        }

        public IStudentRepository Students => _students ?? (_students = new StudentRepository(_context));

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
