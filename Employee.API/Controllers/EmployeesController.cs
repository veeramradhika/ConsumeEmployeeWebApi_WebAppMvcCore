using Employee.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeData _employeeData;

        public EmployeesController(EmployeeData employeeData) => _employeeData = employeeData;

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeViewModel>> GetEmployees()
        {
            return Ok(_employeeData.employeesList);
        }
        [HttpPost]
        public ActionResult PostEmployees([FromBody] EmployeeViewModel emp)
        {
            var employees = (_employeeData.employeesList);

            employees.Add(new EmployeeViewModel 
            { 
                Id = emp.Id, 
                FirstName = emp.FirstName, 
                LastName = emp.LastName, 
                MobileNumber = emp.MobileNumber,
                Email = emp.Email,
                AddressLine1 = emp.AddressLine1,
                AddressLine2 = emp.AddressLine2,
                City = emp.City, 
                PostalCode= emp.PostalCode,
                Country = emp.Country
                
                });
            return Ok(employees);
        }
        [HttpPut]
        public IActionResult UpdateEmployee(int empId, EmployeeViewModel employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee object can't be null");
            }
            if (_employeeData.employeesList == null)
            {
                return NotFound("Table doesn't exists");
            }
            var Update = _employeeData.employeesList.Where(e => e.Id == empId).FirstOrDefault();
            if (Update == null)
            {
                return NotFound("Employee with this empId doesn't exists");
            }
            _employeeData.employeesList.Remove(Update);
            Update.Id = employee.Id;
            Update.FirstName = employee.FirstName;
            Update.LastName = employee.LastName;
            Update.MobileNumber = employee.MobileNumber;
            Update.Email = employee.Email;
            Update.AddressLine1 = employee.AddressLine1;
            Update.AddressLine2 = employee.AddressLine2;
            Update.City = employee.City;
            Update.PostalCode = employee.PostalCode;
            Update.Country = employee.Country;

            _employeeData.employeesList.Add(Update);

            return Ok(_employeeData.employeesList);

        }
        [HttpDelete]
        public ActionResult DeleteEmployee(int empId)
        {
            if (_employeeData.employeesList == null)
            {
                return NotFound("Table doesn't exists");
            }
            var employeeToDelete = _employeeData.employeesList.Where(e => e.Id == empId).FirstOrDefault();
            if (employeeToDelete == null)
            {
                return NotFound("Employee with this empId doesn't exists");
            }
            _employeeData.employeesList.Remove(employeeToDelete);
            return Ok(_employeeData.employeesList);
        }
        [HttpGet("{searchString}")]

        public async Task<IActionResult> Show(string searchString)
        {
            if (searchString == null)
            {
                return BadRequest("input can't be null");
            }
            if (_employeeData.employeesList == null)
            {
                return NotFound("Table doesn't exists");
            }
            var employee = _employeeData.employeesList.Where(e => e.FirstName.Contains(searchString) || e.LastName.Contains(searchString) || e.City.Contains(searchString) || e.Country.Contains(searchString)).ToList();
            if (employee == null)
            {
                return NotFound("Record doesn't exists");
            }
            return Ok(employee);
        }
    }
}
