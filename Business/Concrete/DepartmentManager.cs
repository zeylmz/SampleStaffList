using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;
        IEmployeeService _employeeService;

        public DepartmentManager(IDepartmentDal departmentDal, IEmployeeService employeeService)
        {
            _departmentDal = departmentDal;
            _employeeService = employeeService;
        }

        public IResult Add(Department department)
        {
            _departmentDal.Add(department);
            return new SuccessResult(Messages.DepartmentSuccessfullyAdded);
        }

        public IResult Delete(Department department)
        {
            IResult result = BusinessRules.Run
                (
                    CheckIfEmployeeCountofDepartment(department.Id)
                );
            if (result != null)
            {
                return result;
            }
            _departmentDal.Delete(department);
            return new SuccessResult(Messages.DepartmentSuccessfullyDeleted);
        }

        public IDataResult<List<Department>> GetAll()
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetAll(), Messages.DepartmentSuccessfullyListed);
        }

        public IDataResult<Department> GetById(int id)
        {
            return new SuccessDataResult<Department>(_departmentDal.Get(d => d.Id == id));
        }

        public IResult Update(Department department)
        {
            _departmentDal.Update(department);
            return new SuccessResult(Messages.DepartmentSuccessfullyUpdated);
        }

        //Business Logics

        private IResult CheckIfEmployeeCountofDepartment(int departmentId)
        {
            var result = _employeeService.GetAllByDepartmentId(departmentId);
            if (result.Data.Count > 0)
            {
                return new ErrorResult(Messages.EmployeesInThisDepartment);
            }
            return new SuccessResult();
        }
    }
}
