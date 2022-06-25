using EmployeeManagement.ViewModel;
using System;

namespace EmployeeManagement.Business.Interfaces
{
    public interface IEmployeeManagement
    {
        EmployeeVM DeleteEmployee(Guid Id);
        EmployeeVM InsertEmployee(EmployeeVM Uvm);
        EmployeeVM UpdateEmployee(EmployeeVM Uvm);
    }
}
