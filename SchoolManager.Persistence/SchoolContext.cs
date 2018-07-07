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

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder
        //        .UseLazyLoadingProxies();
        //        //.UseSqlServer(connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            //modelBuilder.Entity<Enrollment>()
            //    .HasKey(e => new { e.CourseID, e.StudentID });
            //modelBuilder.Entity<CourseAssignment>()
            //    .HasKey(c => new { c.CourseID, c.InstructorID });
            base.OnModelCreating(modelBuilder);
        }
    }
}
