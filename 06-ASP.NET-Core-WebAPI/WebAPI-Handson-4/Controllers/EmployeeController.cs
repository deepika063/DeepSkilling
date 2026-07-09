using Microsoft.AspNetCore.Mvc;
using WebAPIHandson.Models;

namespace WebAPIHandson.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John",
                Salary = 50000,
                Permanent = true,
                DateOfBirth = new DateTime(1998,5,10),
                Department = new Department
                {
                    Id = 1,
                    Name = "IT"
                },
                Skills = new List<Skill>
                {
                    new Skill{Id=1,Name="C#"},
                    new Skill{Id=2,Name=".NET"}
                }
            },
            new Employee
            {
                Id = 2,
                Name = "Alice",
                Salary = 45000,
                Permanent = false,
                DateOfBirth = new DateTime(1999,8,15),
                Department = new Department
                {
                    Id = 2,
                    Name = "HR"
                },
                Skills = new List<Skill>
                {
                    new Skill{Id=3,Name="Excel"}
                }
            }
        };

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existing = employees.FirstOrDefault(e => e.Id == id);

            if (existing == null)
            {
                return BadRequest("Invalid employee id");
            }

            existing.Name = employee.Name;
            existing.Salary = employee.Salary;
            existing.Permanent = employee.Permanent;
            existing.Department = employee.Department;
            existing.Skills = employee.Skills;
            existing.DateOfBirth = employee.DateOfBirth;

            return Ok(existing);
        }
    }
}
