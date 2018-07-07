using System;
using System.Collections.ObjectModel;

namespace SchoolManager.Core.Domain
{
    public class Student : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public string FullName => $"{LastName} , {FirstName}";

        public virtual Collection<Enrollment> Enrollments { get; set; }
    }
}
