using Microsoft.AspNetCore.Mvc;
using SchoolManager.API.Controllers;
using SchoolManager.Common;
using SchoolManager.Core.Domain;
using SchoolManager.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchoolManager.API.Test
{
    public class StudentControllerTest
    {
        [Fact]
        public async Task GetAllStudents()
        {
            // Arrange
            var logger = LogHelper.GetLogger<StudentController>();
            var schoolManagerService = ServiceMocker.GetSchoolManagerService();

            using (var controller = new StudentController(logger, schoolManagerService))
            {
                // Act
                var response = await controller.GetStudentsAsync() as ObjectResult;
                var value = response.Value as IListResponse<Student>;

                // Assert
                Assert.False(value.DidError);
                Assert.True(value.Model != null);
            }
        }

        [Fact]
        public async Task GetStudentById()
        {
            var logger = LogHelper.GetLogger<StudentController>();
            var schoolManagerService = ServiceMocker.GetSchoolManagerService();
            var studentID = 0;

            using (var controller = new StudentController(logger, schoolManagerService))
            {
                var response = await controller.GetStudentByIdAsync(studentID) as ObjectResult;
                var value = response.Value as ISingleResponse<Student>;

                Assert.False(value.DidError);
                Assert.True(value.Model == null);
            }
        }
    }
}
