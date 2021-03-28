using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUI.Models
{
    public class EmployeeListViewModel
    {
        public IDataResult<Employee> GetByIdEmployee { get; set; }
        public IDataResult<List<Employee>> Employees { get; set; }
        public IDataResult<List<EmployeeDetailDto>> EmployeeDetails { get; set; }
        public IDataResult<List<EmployeeImage>> EmployeeImage { get; set; }
        public int CurrentEmployee { get; set; }
        public EmployeeDetail employeeDetail { get; set; }
        public IDataResult<List<Department>> Depatments { get; set; }
    }
}
