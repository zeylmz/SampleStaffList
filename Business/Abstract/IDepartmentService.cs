using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        IDataResult<List<Department>> GetAll();
        IDataResult<Department> GetById(int id);
        IResult Add(Department department);
        IResult Delete(Department department);
        IResult Update(Department department);
    }
}
