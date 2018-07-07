namespace SchoolManager.Core.Domain
{
    public class CourseAssignment
    {
        public int InstructorID { get; set; }
        public int CourseID { get; set; }

        public virtual Instructor InstructorFk { get; set; }
        public virtual Course CourseFk { get; set; }
    }
}
