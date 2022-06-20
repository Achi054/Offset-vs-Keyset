using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using KeySetPagination.DataAccess.Entity;

namespace KeySetPagination.DataAccess.Repositories
{
    public interface IEmployeeRepository : IAsyncDisposable
    {
        Task SeedData(int numberOfRecords);

        Task<IEnumerable<Employee>> Get(int pageSize, int pageIndex);

        Task<IEnumerable<Employee>> Get(Expression<Func<Employee, bool>> filter, int pageSize);

        Task<IEnumerable<Employee>> Get(int pageSize);
    }
}
