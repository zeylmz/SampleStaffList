using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using PublicUI.Models;
using System;

namespace PublicUI.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService _employeeService;
        IEmployeeImageService _employeeImageService;

        public EmployeeController(IEmployeeService employeeService, IEmployeeImageService employeeImageService)
        {
            _employeeService = employeeService;
            _employeeImageService = employeeImageService;
        }

        public IActionResult Index(int departmentId, int employeeId)
        {
            var model = new EmployeeListViewModel
            {
                Employees = departmentId > 0 ? _employeeService.GetAllByDepartmentId(departmentId) : _employeeService.GetAll()
            };
            return View(model);
        }
        public IActionResult EmployeeDetail(int employeeId)
        {
            var model = new EmployeeListViewModel
            {
                EmployeeImage = _employeeImageService.GetByEmployeeId(employeeId),
                GetByIdEmployee = _employeeService.GetById(employeeId),
                CurrentEmployee = Convert.ToInt32(HttpContext.Request.Query["employeeId"])
            };
            return View(model);
        }
    }
}
