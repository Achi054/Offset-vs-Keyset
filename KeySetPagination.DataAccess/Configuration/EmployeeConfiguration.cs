using KeySetPagination.DataAccess.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeySetPagination.DataAccess.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserId);
            builder.Property(x => x.Name);
            builder.Property(x => x.UserId);

            builder.ToTable(nameof(Employee));
        }
    }
}
