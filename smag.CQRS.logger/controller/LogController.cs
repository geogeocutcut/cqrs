using smag.CQRS.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.logger.controller
{
    public class LogController
    {
        public LogController()
        {
        }

        public void AddMessage(ICommandBus bus,string message)
        {
            Log log = new Log();
            log.updateMessage(message);
            bus.Dispatch<IList<IEvent>, AddLogCommand>(new AddLogCommand(log));
        }

        public IList<Log> GetAllLogs(IQueryBus bus)
        {
            return bus.Dispatch<IList<Log>, GetAllLogQuery>(new GetAllLogQuery());
        }

        public IList<Log> GetAllLogsRead2(IQueryBus bus)
        {
            return bus.Dispatch<IList<Log>, GetAllLogRead2Query>(new GetAllLogRead2Query());
        }
    }
}
