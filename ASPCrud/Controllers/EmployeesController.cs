using ASPCrud.Data;
using ASPCrud.Models.Domain; 
using ASPCrud.Models; 
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore; 

namespace ASPCrud.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="mvcDemoDbContext">Database context for interacting with employees data.</param>
        public EmployeesController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        /// <summary>
        /// Retrieves the list of employees and displays it in the Index view.
        /// </summary>
        /// <returns>A view containing the list of employees.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await mvcDemoDbContext.Employees.ToListAsync();
            return View(employees);
        }

        /// <summary>
        /// Displays the Add Employee form.
        /// </summary>
        /// <returns>The Add view.</returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Handles the submission of the Add Employee form and saves the new employee to the database.
        /// </summary>
        /// <param name="addEmployeeRequest">The employee details submitted from the form.</param>
        /// <returns>Redirects to the Index view after adding the employee.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            Employee employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                Department = addEmployeeRequest.Department,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
            };

            await mvcDemoDbContext.Employees.AddAsync(employee);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays the details of a specific employee for viewing or editing.
        /// </summary>
        /// <param name="id">The ID of the employee to view.</param>
        /// <returns>The View page for the specified employee, or redirects to the Index view if not found.</returns>
        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            Employee employee = await mvcDemoDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                UpdateEmployeeViewModel viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    Department = employee.Department,
                    DateOfBirth = employee.DateOfBirth,
                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Handles the submission of the updated employee details and saves the changes to the database.
        /// </summary>
        /// <param name="model">The updated employee details submitted from the form.</param>
        /// <returns>Redirects to the Index view after updating the employee.</returns>
        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            Employee employee = await mvcDemoDbContext.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Department = model.Department;

                await mvcDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Handles the deletion of a specific employee from the database.
        /// </summary>
        /// <param name="model">The employee to delete, identified by ID.</param>
        /// <returns>Redirects to the Index view after deleting the employee.</returns>
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            Employee employee = await mvcDemoDbContext.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                mvcDemoDbContext.Employees.Remove(employee);
                await mvcDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
