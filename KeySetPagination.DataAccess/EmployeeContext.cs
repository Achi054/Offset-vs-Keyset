using KeySetPagination.DataAccess.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KeySetPagination.DataAccess
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class EmployeeContextFactory : IDesignTimeDbContextFactory<EmployeeContext>
    {
        public EmployeeContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<EmployeeContext> optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();
            optionsBuilder.UseSqlServer(args[0]);

            return new EmployeeContext(optionsBuilder.Options);
        }
    }
}
