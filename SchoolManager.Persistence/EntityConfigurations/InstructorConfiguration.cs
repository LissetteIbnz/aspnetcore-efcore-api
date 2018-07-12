using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManager.Core.Domain;

namespace SchoolManager.Persistence.EntityConfigurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructor");
            builder.HasKey(s => s.ID);
            builder.Property(s => s.ID).UseSqlServerIdentityColumn();
            builder.Property(s => s.ID).HasColumnType("int").IsRequired();
            builder.Property(s => s.HireDate).HasColumnType("datetime");
        }
    }
}
