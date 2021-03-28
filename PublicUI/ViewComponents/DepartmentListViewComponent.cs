using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using PublicUI.Models;
using System;

namespace PublicUI.ViewComponents
{
    public class DepartmentListViewComponent : ViewComponent
    {
        IDepartmentService _departmentService;

        public DepartmentListViewComponent(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new DepartmentListViewModel
            {
                Departments = _departmentService.GetAll(),
                CurrentDepartment = Convert.ToInt32(HttpContext.Request.Query["departmentId"])
            };
            return View(model);
        }
    }
}
