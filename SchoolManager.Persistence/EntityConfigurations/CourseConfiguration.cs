using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManager.Core.Domain;

namespace SchoolManager.Persistence.EntityConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Mapping for table
            builder.ToTable("Course");
            // Set key for entity
            builder.HasKey(e => e.ID);
            // Set identity for entity (auto increment)
            builder.Property(e => e.ID).UseSqlServerIdentityColumn();
            // Set mapping for columns
            builder.Property(e => e.ID).HasColumnType("int").IsRequired();
            builder.Property(e => e.Title).HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Credits).HasColumnType("smallint").IsRequired();
            // Add configuration for foreign keys
            builder
                .HasOne(p => p.DepartmentFk)
                .WithMany(b => b.Courses)
                .HasForeignKey(p => p.DepartmentID);
        }
    }
}
