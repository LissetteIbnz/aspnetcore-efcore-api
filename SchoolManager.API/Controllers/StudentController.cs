using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolManager.API.Extensions;
using SchoolManager.Service;
using System.Threading.Tasks;

namespace SchoolManager.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        protected ILogger Logger;
        private readonly ISchoolManagerService SchoolManagerService;

        public StudentController(ILogger<StudentController> logger, ISchoolManagerService schoolManagerService)
        {
            Logger = logger;
            SchoolManagerService = schoolManagerService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetStudentsAsync()
        {
            Logger?.LogDebug("{0} has been invoked", nameof(GetStudentsAsync));
            var response = await SchoolManagerService.GetStudentsAsync();

            return response.ToHttpResponse();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetStudentAsync(int id)
        {
            Logger?.LogDebug("{0} has been invoked", nameof(GetStudentAsync));
            var response = await SchoolManagerService.GetStudentAsync(id);

            return response.ToHttpResponse();
        }
    }
}