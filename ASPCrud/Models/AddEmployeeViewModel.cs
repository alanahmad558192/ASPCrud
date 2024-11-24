namespace ASPCrud.Models
{
    // ViewModel used for adding a new employee
    public class AddEmployeeViewModel
    {
        // Employee's full name (required for creating a new employee)
        public string Name { get; set; }

        // Employee's email address (required for creating a new employee)
        public string Email { get; set; }

        // Employee's salary (stored as a long integer to handle large values)
        public long Salary { get; set; }

        // Employee's date of birth
        public DateTime DateOfBirth { get; set; }

        // The department to which the employee belongs
        public string Department { get; set; }
    }
}
