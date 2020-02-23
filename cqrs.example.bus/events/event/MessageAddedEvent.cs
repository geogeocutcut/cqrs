using cqrs.core;
using cqrs.core.events;
using cqrs.example.aggregate;
using System;

namespace cqrs.example.bus.events
{
    public class MessageAddedEvent : Event<Guid, Message>
    {
        public Message Message { get; set; }
        public MessageAddedEvent(Message entity) : base(entity)
        {
            this.Message = entity;
        }
    }
}
