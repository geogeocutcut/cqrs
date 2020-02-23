using System;
using System.Collections.Generic;
using System.Linq;

namespace cqrs.core.events
{
    public class VoidDispatcherMiddleware : BusMiddleware
    {
        private Dictionary<Type, IEnumerable<IHandler>> _Handlers = new Dictionary<Type, IEnumerable<IHandler>>();

        public VoidDispatcherMiddleware(IEnumerable<IHandler> handlers)
        {
            foreach (var h in handlers)
            {
                Subscribe(h);
            }
        }

        public void Subscribe(IHandler h)
        {

            if (!_Handlers.TryGetValue(h.ListenTo(), out var handlerList))
            {
                _Handlers[h.ListenTo()]=new[] { h };
            }
            else
            {
                handlerList = handlerList.Concat(new[] { h });
                _Handlers[h.ListenTo()] = handlerList;
            }
        }

        public override IBusResponse<R> Dispatch<R, E>(E eventtodo)
        {
            if (_Handlers.TryGetValue(eventtodo.GetType(), out var handlers))
            {
                foreach (IHandler h in handlers)
                {
                    h.handle(eventtodo);
                }
            }
            return new BusResponse<R>();
        }
    }
}
