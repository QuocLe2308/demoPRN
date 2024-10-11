using demoAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace demoAPI.Data
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(e => e.Age)
                   .IsRequired();

            builder.Property(e => e.Position)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasOne(e => e.Company)
                   .WithMany(c => c.Employees)
                   .HasForeignKey(e => e.CompanyId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
