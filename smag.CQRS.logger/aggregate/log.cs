using smag.CQRS.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.logger
{
    public class Log:AggregateRoot<Guid>
    {

        public string Message { get; set; }


        public Log(Guid idtmp)
        {
            this.Id = idtmp;

        }
        public Log()
        {
            this.Id = Guid.NewGuid();

        }

        public Guid getId()
        {
            return Id;
        }

        public void updateMessage(string mess)
        {
            this.Message = mess;
        }

        public IEvent Create()
        {
            return new LogAddedEvent(this);
        }
    }
}
