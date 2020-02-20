using smag.CQRS.core;
using smag.CQRS.logger.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.logger
{
    public class LogAddedEventRead2Updater : core.EventHandler<LogAddedEvent>
    {
        public IRepository<Guid, Log> repo;
        public LogAddedEventRead2Updater(LogRepository repoTmp)
        {
            repo = repoTmp;
        }
        public override LogAddedEvent handle(LogAddedEvent eventtodo)
        {
            Log log = eventtodo.log;
            repo.Add(log);
            return eventtodo;
        }
    }
}
