using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
        List<EmployeeDetailDto> GetEmployeeDetails(Expression<Func<EmployeeDetailDto, bool>> filter = null);
    }
}
