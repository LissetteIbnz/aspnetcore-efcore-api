using System.Collections.Generic;

namespace SchoolManager.Core.Domain
{
    public class Course : BaseEntity
    {
        //public Course()
        //{
        //}

        //public Course(int id) => ID = id;

        public string Title { get; set; }
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        public Department DepartmentFk { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
