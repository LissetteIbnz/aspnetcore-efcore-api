using SchoolManager.Core.Domain;
using System.Collections.Generic;

namespace SchoolManager.Core.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetStudentWithCourses(int id);
        IEnumerable<Student> GetTopStudents(int count);
        IEnumerable<Student> GetStudentsWithCourse(int pageIndex = 1, int pageSize = 10);
    }
}
