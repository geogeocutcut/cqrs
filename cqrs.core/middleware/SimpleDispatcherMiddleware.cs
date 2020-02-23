using System;
using System.Collections.Generic;

namespace cqrs.core.middleware
{
    public class SimpleDispatcherMiddleware : BusMiddleware
    {
        private Dictionary<Type, IHandler> _Handlers = new Dictionary<Type, IHandler>();

        public SimpleDispatcherMiddleware(IEnumerable<IHandler> handlers)
        {
            foreach(var h in handlers)
            {
                Subscribe(h);
            }
        }

        public void Subscribe(IHandler h)
        {
            if (!_Handlers.ContainsKey(h.ListenTo()))
            {
                _Handlers.Add(h.ListenTo(), h);
            }
        }

        public override IBusResponse<R> Dispatch<R, E>(E evt)
        {
            if (_Handlers.TryGetValue(typeof(E), out var handler))
            {
                return new BusResponse<R>((R)handler.handle(evt));
            }
            return new BusResponse<R>();
        }
    }
}
