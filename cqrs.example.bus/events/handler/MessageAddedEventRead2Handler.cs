using cqrs.core;
using cqrs.core.dal;
using cqrs.example.aggregate;
using System;

namespace cqrs.example.bus.events
{
    public class MessageAddedEventRead2Handler : Handler<object, MessageAddedEvent>
    {
        public IRepository<Guid, Message> repo;
        public MessageAddedEventRead2Handler(IRepository<Guid, Message> repoTmp)
        {
            repo = repoTmp;
        }
        public override object handle(MessageAddedEvent eventtodo)
        {
            Message mes = eventtodo.Message;
            repo.Add(mes);
            return null;
        }
    }
}
