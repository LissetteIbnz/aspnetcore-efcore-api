namespace SchoolManager.Core.Domain
{
    public class CourseAssignment
    {
        public int InstructorID { get; set; }
        public int CourseID { get; set; }

        public Instructor InstructorFk { get; set; }
        public Course CourseFk { get; set; }
    }
}
