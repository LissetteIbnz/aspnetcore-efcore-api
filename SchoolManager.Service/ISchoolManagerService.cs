using SchoolManager.Core.Domain;
using SchoolManager.Service.Responses;
using System.Threading.Tasks;

namespace SchoolManager.Service
{
    public interface ISchoolManagerService : IService
    {
        Task<ISingleResponse<Student>> GetStudentAsync(int id);
    }
}
