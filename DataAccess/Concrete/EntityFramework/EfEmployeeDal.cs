using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, StaffListContext>, IEmployeeDal
    {
        public List<EmployeeDetailDto> GetEmployeeDetails(Expression<Func<EmployeeDetailDto, bool>> filter = null)
        {
            using (StaffListContext context = new StaffListContext())
            {
                var result = from e in context.Employees
                             join d in context.Departments on e.DepartmentId equals d.Id
                             join em in context.Employees on e.ManagerId equals em.Id
                             select new EmployeeDetailDto
                             {
                                 Id = e.Id,
                                 FirstName = e.FirstName,
                                 LastName = e.LastName,
                                 Title = e.Title,
                                 PhoneNumber = e.PhoneNumber,
                                 DeparmentId = e.DepartmentId,
                                 DeparmentName = d.Name,
                                 DateOfBirth = e.DateOfBirth,
                                 ManagerId = e.ManagerId,
                                 ManagerFirstName = em.FirstName,
                                 ManagerLastName = em.LastName
                             };
                if (filter == null)
                    return result.ToList();
                else
                    return result.Where(filter).ToList();
            }
        }
    }
}
