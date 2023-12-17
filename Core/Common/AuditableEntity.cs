using System;

namespace Core.Common
{
    public class AuditableEntity
    {
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
