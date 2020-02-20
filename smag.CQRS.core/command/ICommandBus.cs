using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.core
{
    public interface ICommandBus
    {
        R Dispatch<R, C>(C commandtodo)
            where C : ICommand<R>;
        void Subscribe(Type t, IHandler h);
    }
}
