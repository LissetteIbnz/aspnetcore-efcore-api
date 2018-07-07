using System.ComponentModel.DataAnnotations;

namespace SchoolManager.Core.Domain
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public Course CourseFk { get; set; }
        public Student StudentFk { get; set; }
    }
}
