using EmployeeManagement.Business.Interfaces;
using EmployeeManagement.Model;
using EmployeeManagement.Repository;
using EmployeeManagement.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;


namespace EmployeeManagement.Business.Services
{
    public class EmployeeManagementService : IEmployeeManagement
    {
        private EmployeeManagementContext context = null;
        private ILogger logger;
        private readonly IEmployeeService _userService;
        public EmployeeManagementService(EmployeeManagementContext context,
            ILogger<EmployeeManagementService> logger, IEmployeeService userService)
        {
            this.context = context;
            this.logger = logger;
            _userService = userService;
        }
        public EmployeeVM InsertEmployee(EmployeeVM Uvm)
        {
            try
            {
                this.logger.LogDebug("In EmployeeManagementService.InsertEmployee");
                var emp = new Employee();
                emp.Name = Uvm.Name;
                emp.Age = Uvm.Age;
                emp.DateofBirht = Convert.ToDateTime(Uvm.DateOfBirth);
                emp.Salary = Uvm.Salary;
                emp.Address = Uvm.Address;
                var InsertUser = context.Employees.Add(emp);
                context.SaveChanges();
                return _userService.GetEmployeeDetails(emp.Id);
            }
            catch (Exception e)
            {

                this.logger.LogDebug("In EmployeeManagementService.InsertEmployee Exception Message= " + e.Message);
                return new EmployeeVM();
            }
            finally
            {
                this.logger.LogDebug("Out EmployeeManagementService.InsertEmployee");
            }
        }

        public EmployeeVM UpdateEmployee(EmployeeVM Uvm)
        {
            try
            {
                this.logger.LogDebug("In EmployeeManagementService.UpdateEmployee: Id {0}");
                var emp = context.Employees.FirstOrDefault(x => x.Id == Uvm.Id);
                if (emp != null)
                {
                    emp.Name = Uvm.Name;
                    emp.Age = Uvm.Age;
                    emp.DateofBirht = Convert.ToDateTime(Uvm.DateOfBirth);
                    emp.Salary = Uvm.Salary;
                    emp.Address = Uvm.Address;
                    context.SaveChanges();
                    return _userService.GetEmployeeDetails(emp.Id);
                }
                else
                {
                    return new EmployeeVM();
                }

            }
            catch (Exception e)
            {

                this.logger.LogDebug("In EmployeeManagementService.UpdateEmployee Exception Message= " + e.Message);
                return new EmployeeVM();
            }
            finally
            {
                this.logger.LogDebug("Out EmployeeManagementService.UpdateEmployee");
            }
        }

        public EmployeeVM DeleteEmployee(Guid Id)
        {
            try
            {
                this.logger.LogDebug("In EmployeeManagementService.DeleteEmployee: Id {0}", Id);
                var query = from emp in context.Employees

                            where (emp.Id == Id)
                            select new
                            {
                                employee = emp,
                                empVM = new EmployeeVM()
                                {
                                    Id = emp.Id,
                                    Name = emp.Name,
                                    Address = emp.Address,
                                    Age = emp.Age,
                                    DateOfBirth = emp.DateofBirht.ToShortDateString(),
                                    Salary = emp.Salary
                                }
                            };
                var currentUser = query.FirstOrDefault().empVM;
                var employeeEntity = query.FirstOrDefault().employee;
                context.Employees.Attach(employeeEntity);
                context.Employees.Remove(employeeEntity);
                context.SaveChanges();
                return currentUser;
            }
            catch (Exception e)
            {

                this.logger.LogDebug("In EmployeeManagementService.DeleteEmployee Exception Message= " + e.Message);
                return new EmployeeVM();
            }
            finally
            {
                this.logger.LogDebug("Out EmployeeManagementService.DeleteEmployee");
            }
        }
     

    }
}
