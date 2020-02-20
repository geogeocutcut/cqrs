using System;
using System.Collections.Generic;

namespace smag.CQRS.core
{
    public class QueryBus: IQueryBus
    {
        private Dictionary<Type, IHandler> handlers = new Dictionary<Type, IHandler>();

        public void Subscribe(Type t, IHandler h)
        {
            if (!handlers.TryGetValue(t, out var handler))
            {
                handlers.Add(t, h);
            }
        }

        public R Dispatch<R,C>(C commandtodo) where C : IQuery<R>
        {
            return (R) handlers[typeof(C)].handle(commandtodo);
        }
        
    }
}