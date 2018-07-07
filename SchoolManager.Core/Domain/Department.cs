using System;
using System.Collections.ObjectModel;

namespace SchoolManager.Core.Domain
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }

        public int? InstructorID { get; set; }

        public Instructor AdministratorFk { get; set; }
        public virtual Collection<Course> Courses { get; set; }
    }
}
