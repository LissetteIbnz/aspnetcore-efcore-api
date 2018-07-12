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

        [HttpGet("Student")]
        public async Task<IActionResult> GetStudentAsync(int id)
        {
            Logger?.LogDebug("{0} has been invoked", nameof(GetStudentAsync));

            // Get response from business logic
            var response = await SchoolManagerService.GetStudentAsync(id);

            // Return as http response
            return response.ToHttpResponse();
        }
    }
}