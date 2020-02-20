using smag.CQRS.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.logger
{
    public class LogAddedEvent : Event<Guid, Log>
    {
        public Log log { get; set; }
        public LogAddedEvent(Log entity) : base(entity)
        {
            this.log = entity;
        }
    }
}
