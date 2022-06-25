using EmployeeManagement.Business.Interfaces;
using EmployeeManagement.Business.Services;
using EmployeeManagement.Model;
using EmployeeManagement.Repository;
using EmployeeManagement.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementTest
{
    public class EmployeeManagementServiceFake : IEmployeeManagement
    {
        private ILogger logger;
        private readonly IEmployeeService _userService;
        private readonly List<Employee> _empList;
        private readonly EmployeeManagementService _service;
        private readonly ILogger<EmployeeManagementService> _logger;
        public EmployeeManagementServiceFake()
        {
            _logger = new Logger<EmployeeManagementService>(new LoggerFactory());
            this._userService = new EmployeeServiceFake();
            _service = new EmployeeManagementService(null, _logger, this._userService);
            _empList = new List<Employee>()
            {
                new Employee() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Name = "Hamza",Address="Test address",Age="30",DateofBirht=DateTime.Now.AddYears(-30),Salary=12900 },
                new Employee() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                     Name = "Jhon",Address="Test Jhon address",Age="31",DateofBirht=DateTime.Now.AddYears(-20),Salary=12300 },
                new Employee() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                        Name = "Smith",Address="Test  Smithaddress",Age="34",DateofBirht=DateTime.Now.AddYears(-25),Salary=15900 },
            };
          
        }

        public EmployeeVM DeleteEmployee(Guid Id)
        {
            throw new NotImplementedException();
        }

        public EmployeeVM InsertEmployee(EmployeeVM Uvm)
        {
            throw new NotImplementedException();
        }

        public EmployeeVM UpdateEmployee(EmployeeVM Uvm)
        {
            var findEmployee = _empList.FirstOrDefault(x => x.Id == Uvm.Id);
            if (findEmployee != null)
            {
                findEmployee.Name = Uvm.Name;
                findEmployee.Address = Uvm.Address;
                findEmployee.Age = Uvm.Age;
                findEmployee.DateofBirht = Convert.ToDateTime(Uvm.DateOfBirth);
                findEmployee.Salary = Uvm.Salary;
                return Uvm;
            }
            else
            {
                return new EmployeeVM();
            }
        }
    }
}
