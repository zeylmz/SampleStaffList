using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IEmployeeImageService
    {
        IDataResult<List<EmployeeImage>> GetAll();
        IDataResult<EmployeeImage> GetById(int id);
        IDataResult<List<EmployeeImage>> GetByEmployeeId(int employeeId);
        IResult Add(IFormFile file, EmployeeImage employeeImage);
        IResult Delete(EmployeeImage employeeImage);
        IResult Update(IFormFile file, EmployeeImage employeeImage);
    }
}
