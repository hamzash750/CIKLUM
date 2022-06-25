
using EmployeeManagement.ViewModel;
using System;
using System.Linq;


namespace EmployeeManagement.Business.Interfaces
{
    public interface IEmployeeService
    {
        IQueryable<EmployeeVM> GetAllEmployee();
        EmployeeVM GetEmployeeDetails(Guid Id);

    }
}
