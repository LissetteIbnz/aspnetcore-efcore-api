using Microsoft.EntityFrameworkCore;
using SchoolManager.Common;
using SchoolManager.Persistence;
using SchoolManager.Service;
using SchoolManager.Service.Repositories;

namespace SchoolManager.API.Test
{
    public static class ServiceMocker
    {
        private static string ConnectionString
            => "server=.\\SQLEXPRESS;database=SchoolApi;integrated security=yes;MultipleActiveResultSets=True;";

        public static ISchoolManagerService GetSchoolManagerService()
        {
            var options = new DbContextOptionsBuilder<SchoolContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            return new SchoolManagerService(LogHelper.GetLogger<SchoolManagerService>(), new SchoolContext(options));
        }
    }
}
