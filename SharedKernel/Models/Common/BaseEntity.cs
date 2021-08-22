using System.Collections.Generic;

namespace SharedKernel.Models.Common
{
    public abstract class BaseEntity<T> where T :struct
    {
        public T Id {  get; set; }
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
