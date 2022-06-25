using System;

namespace EmployeeManagement.ViewModel
{
    public class EmployeeVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
    }
}
