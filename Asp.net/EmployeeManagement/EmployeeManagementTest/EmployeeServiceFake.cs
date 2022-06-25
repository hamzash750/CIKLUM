using EmployeeManagement.Business.Interfaces;
using EmployeeManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementTest
{
    public class EmployeeServiceFake: IEmployeeService
    {
        public IQueryable<EmployeeVM> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public EmployeeVM GetEmployeeDetails(Guid Id)
        {
            return new EmployeeVM()
            {
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Name = "Hamza Test",
                Address = "Test address",
                Age = "30",
                DateOfBirth = "2022-06-24",
                Salary = 12900
            };
        }
    }
}
