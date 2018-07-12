using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManager.Core.Domain;

namespace SchoolManager.Persistence.EntityConfigurations
{
    public class OfficeAssignmentsConfiguration : IEntityTypeConfiguration<OfficeAssignment>
    {
        public void Configure(EntityTypeBuilder<OfficeAssignment> builder)
        {
            builder.ToTable("OfficeAssignment");
            builder.HasKey(o => o.InstructorID);
            builder.HasOne("SchoolManager.Core.Domain.Instructor", "InstructorFk")
                .WithOne("OfficeAssignment")
                .HasForeignKey("SchoolManager.Core.Domain.OfficeAssignment", "InstructorID")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
