using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManager.Core.Domain;

namespace SchoolManager.Persistence.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Mapping for table
            builder.ToTable("Student");
            // Set key for entity
            builder.HasKey(s => s.ID);
            // Set identity for entity (auto increment)
            builder.Property(s => s.ID).UseSqlServerIdentityColumn();
            // Set mapping for columns
            builder.Property(s => s.ID).HasColumnType("int").IsRequired();
            builder.Property(s => s.LastName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(s => s.FirstName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(s => s.EnrollmentDate).HasColumnType("datetime");
        }
    }
}
