namespace SchoolManager.Core.Domain
{
    public class BaseEntity : AuditableEntity
    {
        public int ID { get; set; }
        public bool Deactivated { get; set; }
    }
}
