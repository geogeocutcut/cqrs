using System;

namespace cqrs.core
{
    public abstract class AggregateRoot<TId>
    {
        public TId Id { get; set; }

    }
}
