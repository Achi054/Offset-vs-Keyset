using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using KeySetPagination.DataAccess.Entity;

using MassTransit;

using Microsoft.EntityFrameworkCore;

using MR.EntityFrameworkCore.KeysetPagination;

using Randomizer;

namespace KeySetPagination.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
            => _context = context;

        public async Task SeedData(int numberOfRecords)
        {
            _context.Database.EnsureCreated();

            // Look for any Employees.
            if (_context.Employees.Any())
            {
                // DB has been seeded
                return;
            }

            RandomAlphanumericStringGenerator randomAlphanumericString = new RandomAlphanumericStringGenerator();
            RandomDateTimeGenerator randomDate = new RandomDateTimeGenerator();
            for (int i = 1; i <= numberOfRecords; i++)
            {
                _context.Employees.Add(new Employee
                {
                    UserId = NewId.Next().ToGuid(),
                    Name = randomAlphanumericString.GenerateValue(),
                    DateOfBirth = randomDate.GenerateValue(),
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> Get(int pageSize, int pageIndex)
        {
            return await _context.Employees
                .OrderBy(x => x.Id)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Get(Expression<Func<Employee, bool>> filter, int pageSize)
        {
            return await _context.Employees
                .OrderBy(x => x.Id)
                .Where(filter)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Get(int pageSize)
        {
            var context = _context.Employees.KeysetPaginate(x => x.Ascending(entity => entity.Id), KeysetPaginationDirection.Forward, _context.Employees.FirstOrDefault(x => x.Id == 99990));

            return await context
                        .Query
                        .Take(pageSize)
                        .ToListAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }
    }
}
