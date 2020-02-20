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
        

        public AddLogCommandHandler(IRepository<Guid, Log> repoTmp)
        {
            repo = repoTmp;
        }

        public override IList<IEvent> handle(AddLogCommand commandtodo)
        {
            Log log = commandtodo.log;
            repo.Add(log);

            return new List<IEvent> { new LogAddedEvent(log) };
        }
    }
}
