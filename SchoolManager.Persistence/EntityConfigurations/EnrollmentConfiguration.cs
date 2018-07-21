using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManager.Core.Domain;

namespace SchoolManager.Persistence.EntityConfigurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment");
            builder.HasKey(s => new { s.StudentID, s.CourseID });
            builder.HasOne(e => e.CourseFk)
                .WithMany(b => b.Enrollments)
                .HasForeignKey(e => e.CourseID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.StudentFk)
                .WithMany(b => b.Enrollments)
                .HasForeignKey(e => e.StudentID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
