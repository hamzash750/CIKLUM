using EmployeeManagement.API.Controllers;
using EmployeeManagement.Business.Interfaces;
using EmployeeManagement.Model;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementTest
{
    public class EmployeeManagementControllerTest
    {
        private readonly EmployeeManagementController _controller;
        private readonly IEmployeeManagement _service;
        private readonly ILogger<EmployeeManagementController> _logger;

        public EmployeeManagementControllerTest()
        {
            _logger = new Logger<EmployeeManagementController>(new LoggerFactory());
            _service = new EmployeeManagementServiceFake();
            _controller = new EmployeeManagementController(_logger, _service);
        }
        [Fact]
        public void Update_ValidObjectPassed_ReturnedResponseHasEmployee()
        {
            // Arrange
            var testEmp = new EmployeeVM()
            {
                 Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Name = "Hamza Test",
                Address="Test address",
                Age="30",
                DateOfBirth= "2022-06-24",
                Salary=12900
            };
            // Act
            var createdResponse = _controller.UpdateEmployee(testEmp) as OkObjectResult;
            var item = createdResponse.Value as EmployeeVM;
            // Assert
            Assert.IsType<EmployeeVM>(item);
            Assert.Equal("Hamza Test", testEmp.Name);
        }
        [Fact]
        public void Update_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var testEmp = new EmployeeVM()
            {
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c100"),
                Name = "Hamza Test",
                Address = "Test address",
                Age = "30",
                DateOfBirth = "2022-06-24",
                Salary = 12900
            };
            var badResponse = _controller.UpdateEmployee(testEmp) as BadRequestObjectResult;
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
    }
}
