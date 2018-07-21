using Microsoft.EntityFrameworkCore;
using SchoolManager.Core.Domain;
using SchoolManager.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManager.Persistence.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolContext context) : base(context)
        {
        }

        public async Task<Student> GetStudentWithCourses(int id)
        {
            return await SchoolContext.Student.Include(s => s.Enrollments).FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<IEnumerable<Student>> GetStudentsWithCourses(int pageIndex, int pageSize)
        {
            return await SchoolContext.Student
                .Include(s => s.Enrollments)
                .OrderBy(s => s.LastName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }   

        public async Task<IEnumerable<Student>> GetTopStudents(int count)
        {
            return await SchoolContext.Student
                .Include(s => s.Enrollments)
                .Where(s => s.Enrollments.Any())
                .OrderByDescending(s => s.Enrollments.OrderByDescending(e => e.Grade))
                .Take(count)
                .ToListAsync();
        }

        public SchoolContext SchoolContext
        {
            get { return Context as SchoolContext; }
        }
    }
}
