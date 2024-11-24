namespace ASPCrud.Models
{
    // ViewModel used for updating employee details
    public class UpdateEmployeeViewModel
    {
        // Unique identifier for the employee
        public Guid Id { get; set; }

        // Employee's full name
        public string Name { get; set; }

        // Employee's email address
        public string Email { get; set; }

        // Employee's salary (in numeric format)
        public long Salary { get; set; }

        // Employee's date of birth
        public DateTime DateOfBirth { get; set; }

        // Department the employee belongs to
        public string Department { get; set; }
    }
}
