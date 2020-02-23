using cqrs.core;
using cqrs.example.aggregate;
using System;
using System.Collections.Generic;
using cqrs.core.events;
using cqrs.core.dal;
using cqrs.example.bus.events;

namespace cqrs.example.bus.commands
{
    public class AddMessageCommandHandler : Handler<IList<IEvent>, AddMessageCommand>
    {
        public IRepository<Guid, Message> repo;


        public AddMessageCommandHandler(IRepository<Guid, Message> repoTmp)
        {
            repo = repoTmp;
        }

        public override IList<IEvent> handle(AddMessageCommand commandtodo)
        {
            Message mes = commandtodo.Message;
            repo.Add(mes);

            return new List<IEvent> { new MessageAddedEvent(mes) };
        }
    }
}
