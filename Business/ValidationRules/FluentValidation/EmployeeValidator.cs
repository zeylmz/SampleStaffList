using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.PhoneNumber).NotEmpty();
            RuleFor(e => e.Title).NotEmpty();
            RuleFor(e => e.DepartmentId).NotEmpty();
            RuleFor(e => e.DateOfBirth).NotEmpty();
        }
    }
}
