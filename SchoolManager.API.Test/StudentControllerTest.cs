using Microsoft.AspNetCore.Mvc;
using SchoolManager.API.Controllers;
using SchoolManager.Common;
using SchoolManager.Core.Domain;
using SchoolManager.Service.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchoolManager.API.Test
{
    public class StudentControllerTest
    {
        [Fact]
        public async Task GetStudentsTestAsync()
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
            }
        }
    }
}
