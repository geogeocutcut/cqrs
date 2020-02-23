using cqrs.core;
using cqrs.core.events;
using System.Collections.Generic;

namespace cqrs.example.bus.commands
{
    public class EventReRouterMiddleware : BusMiddleware
    {
        private IEventsBus _EventBus;

        public EventReRouterMiddleware(IBusMiddleware next, IEventsBus eventBus)
        {
            _Next = next;
            _EventBus = eventBus;
        }

        public override IBusResponse<R> Dispatch<R, E>(E mes)
        {
            var response = _Next.Dispatch<R, E>(mes);
            if(typeof(IEvent).IsAssignableFrom(typeof(R)))
            {
                var evt = (IEvent)response.GetData();
                _EventBus.Dispatch<IEvent>(evt);
            }
            else if (typeof(IEnumerable<IEvent>).IsAssignableFrom(typeof(R)) )
            {
                var evts = (IEnumerable<IEvent>)response.GetData();
                foreach (IEvent e in evts)
                {
                    _EventBus.Dispatch<IEvent>(e);
                }
            }
            return response;
        }
    }
}
