using SchoolManager.Core.Domain;
using SchoolManager.Service.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManager.Service
{
    public interface ISchoolManagerService : IService
    {
        Task<IListResponse<Student>> GetStudentsAsync();
        Task<ISingleResponse<Student>> GetStudentAsync(int id);

        Task<ISingleResponse<Student>> AddStudentAsync(Student model);
        Task<IListResponse<Student>> AddRangeStudentsAsync(IEnumerable<Student> model);

        ISingleResponse<Student> RemoveStudent(Student model);
        IListResponse<Student> RemoveRangeStudents(IEnumerable<Student> model);
    }
}
