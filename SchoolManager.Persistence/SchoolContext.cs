using System;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Core.Domain;
using SchoolManager.Persistence.EntityConfigurations;

namespace SchoolManager.Persistence
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignment { get; set; }
        public DbSet<CourseAssignment> CourseAssignment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new CourseAssignmentConfiguration())
                .ApplyConfiguration(new CourseConfiguration())
                .ApplyConfiguration(new DepartmentConfiguration())
                .ApplyConfiguration(new EnrollmentConfiguration())
                .ApplyConfiguration(new InstructorConfiguration())
                .ApplyConfiguration(new OfficeAssignmentsConfiguration())
                .ApplyConfiguration(new StudentConfiguration());
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreationDateTime").CurrentValue = DateTime.UtcNow;
                    entry.Property("LastUpdateDateTime").CurrentValue = DateTime.UtcNow;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("LastUpdateDateTime").CurrentValue = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
}
