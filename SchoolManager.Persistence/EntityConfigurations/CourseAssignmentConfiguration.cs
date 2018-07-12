using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManager.Core.Domain;

namespace SchoolManager.Persistence.EntityConfigurations
{
    public class CourseAssignmentConfiguration : IEntityTypeConfiguration<CourseAssignment>
    {
        public void Configure(EntityTypeBuilder<CourseAssignment> builder)
        {
            builder.ToTable("CourseAssignment");
            builder.HasKey(c => new { c.CourseID, c.InstructorID });
            builder.HasIndex(c => c.InstructorID);
            builder.HasOne(c => c.CourseFk)
                       .WithMany(a => a.CourseAssignments)
                       .HasForeignKey(c => c.CourseID)
                       .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.InstructorFk)
                .WithMany(i => i.CourseAssignments)
                .HasForeignKey(c => c.InstructorID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
