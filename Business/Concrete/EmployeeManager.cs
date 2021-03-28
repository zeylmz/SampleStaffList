using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult(Messages.EmployeeSuccessfullyAdded);
        }

        public IResult Delete(Employee employee)
        {
            IResult result = BusinessRules.Run
                (
                    IsTheEmployeeManager(employee.Id)
                );
            if (result != null)
            {
                return result;
            }
            _employeeDal.Delete(employee);
            return new SuccessResult(Messages.EmployeeSuccessfullyDeleted);
        }

        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(), Messages.EmployeeSuccessfullyListed);
        }

        public IDataResult<List<Employee>> GetAllByDepartmentId(int departmentId)
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e => e.DepartmentId == departmentId));
        }

        public IDataResult<List<Employee>> GetAllByManagerId(int managerId)
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(e => e.ManagerId == managerId));
        }

        public IDataResult<Employee> GetById(int Id)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(e => e.Id == Id));
        }

        public IDataResult<List<EmployeeDetailDto>> GetEmployeeDetails()
        {
            return new SuccessDataResult<List<EmployeeDetailDto>>(_employeeDal.GetEmployeeDetails(), Messages.EmployeeDetailsListed);
        }

        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult(Messages.EmployeeSuccessfullyUpdated);
        }

        private IResult IsTheEmployeeManager(int employeeId)
        {
            var result = _employeeDal.GetAll(e => e.ManagerId == employeeId).Count;
            if (result > 0)
            {
                return new ErrorResult(Messages.ThisIsAEmployeeManager);
            }
            return new SuccessResult();
        }
    }
}
