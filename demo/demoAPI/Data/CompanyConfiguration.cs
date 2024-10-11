using demoAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace demoAPI.Data
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");


            builder.HasKey(c => c.Id);


            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(c => c.Address)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(c => c.Country)
                   .HasMaxLength(50);


            builder.HasMany(c => c.Employees)
                   .WithOne(e => e.Company)
                   .HasForeignKey(e => e.CompanyId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
