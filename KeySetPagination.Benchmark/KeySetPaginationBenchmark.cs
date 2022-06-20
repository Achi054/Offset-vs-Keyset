using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

using KeySetPagination.DataAccess.Repositories;

namespace KeySetPagination.Benchmark
{
    [MemoryDiagnoser]
    public class KeySetPaginationBenchmark
    {
        private IEmployeeRepository _repo;

        [GlobalSetup]
        public async Task GlobalSetup()
        {
            _repo = await TestContextSetupHelper.GlobalSetup();
        }

        [Benchmark]
        public async Task GetEmployeeWithTakeAndSkipClause()
        {
            await _repo.Get(10, 9000);
        }

        [Benchmark]
        public async Task GetEmployeeWithWhereClause()
        {
            await _repo.Get(x => x.Id > 99990, 10);
        }

        [Benchmark]
        public async Task GetEmployeeWithKeysetPagination()
        {
            await _repo.Get(10);
        }

        [GlobalCleanup]
        public async Task GlobalCleanup()
        {
            await _repo.DisposeAsync();
        }
    }
}
