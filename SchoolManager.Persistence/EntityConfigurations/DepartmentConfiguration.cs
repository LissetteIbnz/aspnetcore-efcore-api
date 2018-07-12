using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManager.Core.Domain;

namespace SchoolManager.Persistence.EntityConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(d => d.ID);
            builder.Property(d => d.ID).UseSqlServerIdentityColumn();
            builder.HasIndex(d => d.InstructorID);
            builder.Property(d => d.Budget).HasColumnType("money");
            builder.Property(d => d.StartDate).HasColumnType("datetime");
            builder.HasOne(d => d.AdministratorFk)
                .WithMany()
                .HasForeignKey(d => d.InstructorID);
        }
    }
}
