using Core.Entities.Abstract;
using System;

namespace Entities.DTOs
{
    public class EmployeeDetailDto : IDto
    {
        public int Id { get; set; }
        public int DeparmentId { get; set; }
        public int ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string DeparmentName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
