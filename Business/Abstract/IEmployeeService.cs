using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IResult Add(Employee employee);
        IResult Update(Employee employee);
        IResult Delete(Employee employee);
        IDataResult<List<Employee>> GetAll();
        IDataResult<Employee> GetById(int Id);
        IDataResult<List<Employee>> GetAllByDepartmentId(int departmentId);
        IDataResult<List<Employee>> GetAllByManagerId(int managerId);
        IDataResult<List<EmployeeDetailDto>> GetEmployeeDetails() ;
    }
}
