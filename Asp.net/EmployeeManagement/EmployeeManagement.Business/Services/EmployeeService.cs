using EmployeeManagement.Business.Interfaces;
using EmployeeManagement.Repository;
using EmployeeManagement.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;


namespace EmployeeManagement.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeManagementContext context = null;
        private ILogger logger;
        private IConfiguration configuration;

        public EmployeeService()
        {
        }

        public EmployeeService(EmployeeManagementContext context,
            ILogger<EmployeeService> logger, IConfiguration configuration)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }
        public IQueryable<EmployeeVM> GetAllEmployee()
        {
            try
            {
                this.logger.LogDebug("In EmployeeService.GetAllEmployee");
                var query = from emp in context.Employees
                            select new EmployeeVM()
                            {
                                Id = emp.Id,
                                Name = emp.Name,
                                Address= emp.Address,
                                Age= emp.Age,
                                DateOfBirth= emp.DateofBirht.ToShortDateString(),
                                Salary= emp.Salary

                            };
                return query;
            }
            catch (Exception e)
            {

                this.logger.LogDebug("In EmployeeService.GetAllEmployee Exception Message= " + e.Message);
                return new EmployeeVM[] { }.AsQueryable();
            }
            finally
            {
                this.logger.LogDebug("Out EmployeeService.GetAllEmployee");
            }
        }
        public EmployeeVM GetEmployeeDetails(Guid Id)
        {
            try
            {
                this.logger.LogDebug("In EmployeeService.GetEmployeeDetails: Id {0}", Id);
                var query = from emp in context.Employees
                            where (emp.Id == Id)
                            select new EmployeeVM()
                            {
                                Id = emp.Id,
                                Name = emp.Name,
                                Address = emp.Address,
                                Age = emp.Age,
                                DateOfBirth = emp.DateofBirht.ToShortDateString(),
                                Salary = emp.Salary
                            };
                return query.FirstOrDefault();
            }
            catch (Exception e)
            {

                this.logger.LogDebug("In EmployeeService.GetEmployeeDetails Exception Message= " + e.Message);
                return new EmployeeVM();
            }
            finally
            {
                this.logger.LogDebug("Out EmployeeService.GetEmployeeDetails");
            }
        }


    }
}
