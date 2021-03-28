using AdminUI.Models;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUI.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService _employeeService;
        IEmployeeImageService _employeeImageService;
        IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IEmployeeImageService employeeImageService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _employeeImageService = employeeImageService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var model = new EmployeeListViewModel()
            {               
                Employees = _employeeService.GetAll(),
                Depatments = _departmentService.GetAll()
            };
            return View(model);
        }
        
        public IActionResult EmployeeUpdate(int employeeId)
        {

            var model = new EmployeeListViewModel
            {
                EmployeeImage = _employeeImageService.GetByEmployeeId(employeeId),
                EmployeeDetails = _employeeService.GetEmployeeDetails(),
                GetByIdEmployee = _employeeService.GetById(employeeId),
                CurrentEmployee = Convert.ToInt32(HttpContext.Request.Query["employeeId"]),
                employeeDetail = new EmployeeDetail(),
                Depatments = _departmentService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EmployeeUpdate(EmployeeDetail employeeDetail)
        {
            var result = _employeeService.Update(employeeDetail);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
            
        }
    }
}
