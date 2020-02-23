using cqrs.core.events;
using System.Collections.Generic;

namespace cqrs.core.commands
{
    public class CommandsBus : ICommandsBus
    {
        IBusMiddleware _Next;

        public CommandsBus(IBusMiddleware next)
        {
            _Next = next;
        }

        public IBusResponse<IList<IEvent>> Dispatch<E>(E mes)
        {
            return _Next.Dispatch<IList<IEvent>, E>(mes);
        }
    }
}
