using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace PublicUI.Models
{
    public class EmployeeListViewModel
    {
        public IDataResult<Employee> GetByIdEmployee { get; set; }
        public IDataResult<List<Employee>> Employees { get; set; }
        public IDataResult<List<EmployeeDetailDto>> EmployeeDetails { get; set; }
        public IDataResult<List<EmployeeImage>> EmployeeImage { get; set; }
        public int CurrentEmployee { get; set; }
    }
}
