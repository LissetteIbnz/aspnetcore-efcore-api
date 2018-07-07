using System;
using System.Collections.ObjectModel;

namespace SchoolManager.Core.Domain
{
    public class Instructor : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        public OfficeAssignment OfficeAssignmentFk { get; set; }
        public virtual Collection<CourseAssignment> CourseAssignments { get; set; }
    }
}
