using System;

namespace SchoolManager.Core.Domain
{
    public class AuditableEntity
    {
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
    }
}
