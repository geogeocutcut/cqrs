using smag.CQRS.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.logger.controller
{
    public class LogController
    {
        private ICommandBus _CmdBus;
        private IQueryBus _QueryBus;
        public LogController(ICommandBus cmdbus, IQueryBus querybus)
        {
            _CmdBus = cmdbus;
            _QueryBus = querybus;
        }

        public void AddMessage(string message)
        {
            Log log = new Log();
            log.updateMessage(message);
            _CmdBus.Dispatch<IList<IEvent>, AddLogCommand>(new AddLogCommand(log));
        }

        public IList<Log> GetAllLogs()
        {
            return _QueryBus.Dispatch<IList<Log>, GetAllLogQuery>(new GetAllLogQuery());
        }

        public IList<Log> GetAllLogsRead2()
        {
            return _QueryBus.Dispatch<IList<Log>, GetAllLog2Query>(new GetAllLog2Query());
        }
    }
}
