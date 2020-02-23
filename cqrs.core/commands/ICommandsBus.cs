using cqrs.core.events;
using System.Collections.Generic;

namespace cqrs.core.commands
{
    public interface ICommandsBus
    {
        IBusResponse<IList<IEvent>> Dispatch<E>(E mes);
    }
}