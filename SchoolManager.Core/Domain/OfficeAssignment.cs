namespace SchoolManager.Core.Domain
{
    public class OfficeAssignment : AuditableEntity
    {
        public int InstructorID { get; set; }
        public string Location { get; set; }

        public Instructor InstructorFk { get; set; }
    }
}
