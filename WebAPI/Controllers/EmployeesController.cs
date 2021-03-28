using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbydepartment")]
        public IActionResult GetByDepartmentId(int departmentId)
        {
            var result = _employeeService.GetAllByDepartmentId(departmentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbymanager")]
        public IActionResult GetByManagerId(int managerId)
        {
            var result = _employeeService.GetAllByManagerId(managerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyemployeedetails")]
        public IActionResult GetEmployeeDetails()
        {
            var result = _employeeService.GetEmployeeDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Employee employee)
        {
            var result = _employeeService.Add(employee);
            if (result.Success)
            {
                
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Employee employee)
        {
            var result = _employeeService.Delete(employee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Employee employee)
        {
            var result = _employeeService.Update(employee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
