using SchoolManager.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManager.Core.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetStudentWithCourses(int id);
        Task<IEnumerable<Student>> GetTopStudents(int count);
        Task<IEnumerable<Student>> GetStudentsWithCourse(int pageIndex = 1, int pageSize = 10);
    }
}
