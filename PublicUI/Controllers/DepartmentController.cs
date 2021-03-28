using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PublicUI.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
    }
}
