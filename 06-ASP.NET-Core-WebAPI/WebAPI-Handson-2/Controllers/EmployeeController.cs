using Microsoft.AspNetCore.Mvc;
using WebAPIHandson.Models;

namespace WebAPIHandson.Controllers
{
    [ApiController]
    [Route("api/Emp")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John",
                Department = "IT",
                Salary = 50000
            },
            new Employee
            {
                Id = 2,
                Name = "Alice",
                Department = "HR",
                Salary = 45000
            }
        };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);

            return Ok("Employee Added Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp == null)
                return NotFound();

            emp.Name = employee.Name;
            emp.Department = employee.Department;
            emp.Salary = employee.Salary;

            return Ok("Employee Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp == null)
                return NotFound();

            employees.Remove(emp);

            return Ok("Employee Deleted Successfully");
        }
    }
}
