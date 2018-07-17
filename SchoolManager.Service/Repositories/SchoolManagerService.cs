using Microsoft.Extensions.Logging;
using SchoolManager.Core.Domain;
using SchoolManager.Persistence;
using SchoolManager.Service.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManager.Service.Repositories
{
    public class SchoolManagerService : Service, ISchoolManagerService
    {
        public SchoolManagerService(ILogger<SchoolManagerService> logger, SchoolContext dbContext) : base(logger, dbContext)
        {
        }

        public async Task<IListResponse<Student>> GetStudentsAsync()
        {
            Logger?.LogDebug("{0} has been invoked", nameof(GetStudentsAsync));

            var response = new ListResponse<Student>();

            try
            {
                response.Model = await UnitOfWork.Students.GetAll();
            }
            catch (Exception ex)
            {
                response.SetError(ex, Logger);
            }

            return response;
        }

        public async Task<ISingleResponse<Student>> GetStudentAsync(int id)
        {
            Logger?.LogDebug("{0} has been invoked", nameof(GetStudentAsync));

            var response = new SingleResponse<Student>();

            try
            {
                response.Model = await UnitOfWork.Students.Get(id);
            }
            catch (Exception ex)
            {
                response.SetError(ex, Logger);
            }

            return response;
        }

        public Task<ISingleResponse<Student>> AddStudentAsync(Student model)
        {
            throw new NotImplementedException();
        }

        public Task<IListResponse<Student>> AddRangeStudentsAsync(IEnumerable<Student> model)
        {
            throw new NotImplementedException();
        }

        public ISingleResponse<Student> RemoveStudent(Student model)
        {
            throw new NotImplementedException();
        }

        public IListResponse<Student> RemoveRangeStudents(IEnumerable<Student> model)
        {
            throw new NotImplementedException();
        }
    }
}
