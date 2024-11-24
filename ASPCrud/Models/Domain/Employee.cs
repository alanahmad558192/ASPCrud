namespace ASPCrud.Models.Domain
{
    // Represents the Employee entity in the application
    public class Employee
    {
        // Unique identifier for each employee
        public Guid Id { get; set; }

        // Employee's full name
        public string Name { get; set; }

        // Employee's email address
        public string Email { get; set; }

        // Employee's salary (stored as a long integer to handle large values)
        public long Salary { get; set; }

        // Employee's date of birth
        public DateTime DateOfBirth { get; set; }

        // The department to which the employee belongs
        public string Department { get; set; }
    }
}
