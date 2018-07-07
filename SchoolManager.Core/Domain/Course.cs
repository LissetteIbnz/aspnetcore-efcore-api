using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchoolManager.Core.Domain
{
    public class Course : BaseEntity
    {
        public Course()
        {
        }

        public Course(int id) => ID = id;

        public string Title { get; set; }
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        public virtual Department DepartmentFk { get; set; }

        public virtual Collection<Enrollment> Enrollments { get; set; }
        public virtual Collection<CourseAssignment> CourseAssignments { get; set; }
    }
}
