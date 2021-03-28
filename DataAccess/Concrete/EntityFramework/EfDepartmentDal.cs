using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentDal : EfEntityRepositoryBase<Department, StaffListContext>, IDepartmentDal
    {
    }
}
