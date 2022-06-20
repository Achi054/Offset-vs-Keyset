using System;

using MassTransit;

namespace KeySetPagination.DataAccess.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
