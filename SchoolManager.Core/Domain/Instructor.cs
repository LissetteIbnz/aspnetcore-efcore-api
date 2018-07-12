using System;
using System.Collections.Generic;

namespace SchoolManager.Core.Domain
{
    public class Instructor : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }

        public string FullName => LastName + ", " + FirstName;

        public OfficeAssignment OfficeAssignment { get; set; }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
