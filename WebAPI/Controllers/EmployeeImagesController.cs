using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeImagesController : ControllerBase
    {
        IEmployeeImageService _employeeImageService;

        public EmployeeImagesController(IEmployeeImageService employeeImageService)
        {
            _employeeImageService = employeeImageService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _employeeImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getbyemployeeid")]
        public IActionResult GetByEmployeeId(int employeeId)
        {
            var result = _employeeImageService.GetByEmployeeId(employeeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] EmployeeImage employeeImage)
        {
            var result = _employeeImageService.Add(file, employeeImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
