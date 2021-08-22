using System;

namespace SharedKernel.Models.Common
{
    public abstract class AuditableEntity<T, TCreated, TModified> : BaseEntity<T>
        where T : struct
        where TCreated : struct
        where TModified : struct
    {
        public DateTime CreatedDate { get; set; }
        public TCreated CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public TModified? ModifiedBy { get; set; }
    }
}
