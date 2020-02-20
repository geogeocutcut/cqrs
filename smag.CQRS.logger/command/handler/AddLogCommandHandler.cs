using smag.CQRS.core;
using smag.CQRS.logger.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.logger.command.handler
{
    public class AddLogCommandHandler:CommandHandler<IList<IEvent>,AddLogCommand>
    {
        public IRepository<Guid, Log> repo;

        public IList<IEvent> events = new List<IEvent>();
        public AddLogCommandHandler(LogRepository repoTmp)
        {
            repo = repoTmp;
        }

        public override IList<IEvent> handle(AddLogCommand commandtodo)
        {
            Log log = commandtodo.log;
            repo.Add(log);

            events.Add(new LogAddedEvent(log));
            return events;
        }
    }
}
