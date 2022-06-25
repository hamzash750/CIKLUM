using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagement.Repository
{
    public class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext()
        {
        }

        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
  
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = Guid.NewGuid(), Name = "John", Age = "10", DateofBirht = DateTime.Now.AddDays(-20), Salary = 1000,  Address = "John test Address" },
                 new Employee() { Id = Guid.NewGuid(), Name = "Mark", Age = "20", DateofBirht = DateTime.Now.AddDays(-15), Salary = 34341000, Address = "Mark test Address" },
                  new Employee() { Id = Guid.NewGuid(), Name = "Smith", Age = "30", DateofBirht = DateTime.Now.AddDays(-10), Salary = 341000, Address = "Smith test Address" }
                  );

        }
    }
}
