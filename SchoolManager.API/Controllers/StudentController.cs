using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolManager.Service;
using System.Threading.Tasks;
using SchoolManager.API.Responses;

namespace SchoolManager.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly ILogger _logger;
        private readonly ISchoolManagerService _schoolManagerService;

        public StudentController(ILogger<StudentController> logger, ISchoolManagerService schoolManagerService)
        {
            _logger = logger;
            _schoolManagerService = schoolManagerService;
        }

        /// <summary>
        /// Retrieve all students (async)
        /// </summary>
        /// <returns>A list of students</returns>
        [HttpGet("Get")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStudentsAsync(int? pageSize = 10, int? pageNumber = 1)
        {
            _logger?.LogInformation("{0} has been invoked", nameof(GetStudentsAsync));
            var response = await _schoolManagerService.GetStudentsAsync();

            return response.ToHttpResponse();
        }

        [HttpGet("GetWithCourses")]
        public async Task<IActionResult> GetStudentsWithCoursesAsync()
        {
            _logger?.LogDebug("{0} has been invoked", nameof(GetStudentsWithCoursesAsync));
            var response = await _schoolManagerService.GetStudentsWithCoursesAsync();

            return response.ToHttpResponse();
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            _logger?.LogDebug("{0} has been invoked", nameof(GetStudentByIdAsync));
            var response = await _schoolManagerService.GetStudentAsync(id);

            return response.ToHttpResponse();
        }
    }
}