using smag.CQRS.core;
using System;
using System.Collections.Generic;

namespace smag.CQRS.logger
{
    public class AddLogCommand : ICommand<IList<IEvent>>
    {
        public Log log { get; set; }

        public AddLogCommand(Log logTmp)
        {
            this.log = logTmp;
        }
    }
}
