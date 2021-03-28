using Core.Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class EmployeeImage : IEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
