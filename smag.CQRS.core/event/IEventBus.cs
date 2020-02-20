using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace smag.CQRS.core
{
    public interface IEventBus
    {
        void Subscribe(Type t, IHandler h);

        void Dispatch<E>(E eventtodo) where E : IEvent;
    }
}
