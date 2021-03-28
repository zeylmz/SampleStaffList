using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace PublicUI.Models
{
    public class DepartmentListViewModel
    {
        public IDataResult<List<Department>> Departments { get; set; }
        public int CurrentDepartment { get; set; }
    }
}
