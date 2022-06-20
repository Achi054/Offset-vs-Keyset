using System;
using System.Threading.Tasks;

using KeySetPagination.DataAccess.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace KeySetPagination.Benchmark
{
    public static class TestContextSetupHelper
    {
        public static async Task<IEmployeeRepository> GlobalSetup(int seedCount = 100000)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var repo = serviceProvider.GetRequiredService<IEmployeeRepository>();

            Console.WriteLine($"Seeding {seedCount} data...");
            await repo.SeedData(seedCount);
            Console.WriteLine("Seeding complete");

            return repo;
        }
    }
}
