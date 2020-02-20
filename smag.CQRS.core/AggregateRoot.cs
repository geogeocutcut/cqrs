using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.core
{
    public abstract class AggregateRoot<TId>
    {
        public TId Id { get; set; }
        
    }
}
