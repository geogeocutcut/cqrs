using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.core
{
    public interface IQueryBus
    {
        R Dispatch<R, C>(C querytodo) where C : IQuery<R>;
        void Subscribe(Type t, IHandler h);
    }
}
