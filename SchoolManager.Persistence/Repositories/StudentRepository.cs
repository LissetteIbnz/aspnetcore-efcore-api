using Microsoft.EntityFrameworkCore;
using SchoolManager.Core.Domain;
using SchoolManager.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManager.Persistence.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolContext context) : base(context)
        {
        }

        public Student GetStudentWithCourses(int id)
        {
            return SchoolContext.Students.Include(s => s.Enrollments).SingleOrDefault(s => s.ID == id);
        }

        public IEnumerable<Student> GetStudentsWithCourse(int pageIndex, int pageSize)
        {
            return SchoolContext.Students
                .Include(s => s.Enrollments)
                .OrderBy(s => s.LastName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Student> GetTopStudents(int count)
        {
            return SchoolContext.Students
                .Include(s => s.Enrollments)
                .Where(s => s.Enrollments.Any())
                .OrderByDescending(s => s.Enrollments.OrderByDescending(e => e.Grade))
                .Take(count)
                .ToList();
        }

        public SchoolContext SchoolContext
        {
            get { return Context as SchoolContext; }
        }
    }
}
