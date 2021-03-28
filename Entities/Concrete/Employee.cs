using Core.Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ManagerId { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
