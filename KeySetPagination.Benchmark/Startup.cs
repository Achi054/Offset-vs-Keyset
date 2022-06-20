using System;

using KeySetPagination.DataAccess;
using KeySetPagination.DataAccess.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KeySetPagination
{
    internal sealed class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddDbContext<EmployeeContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection"));
                options.LogTo(Console.WriteLine, LogLevel.Information);
            });
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
