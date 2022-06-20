using System;
using System.Linq;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using KeySetPagination.DataAccess.Repositories;

using Microsoft.Extensions.DependencyInjection;


namespace KeySetPagination.Benchmark
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var repo = await TestContextSetupHelper.GlobalSetup();
            var employeesWithSkipTakeClause = await repo.Get(10, 10);
            Console.WriteLine("Number of employees using skip and take: {0}", employeesWithSkipTakeClause.Count());

            var employeesWithWhereClause = await repo.Get(10, 10);
            Console.WriteLine("Number of employees using where: {0}", employeesWithWhereClause.Count());

            var employeesWithKeysetPagination = await repo.Get(10);
            Console.WriteLine("Number of employees using Keysetpagination: {0}", employeesWithKeysetPagination.Count());

            BenchmarkRunner.Run<KeySetPaginationBenchmark>();
        }
    }
}
