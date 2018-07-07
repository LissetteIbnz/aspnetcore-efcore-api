using System;

namespace SchoolManager.Core.Domain
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public bool Deactivated { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
    }
}
