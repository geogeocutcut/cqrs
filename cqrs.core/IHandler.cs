using System;

namespace cqrs.core
{
    public interface IHandler
    {
        Type ListenTo();
        object handle(object obj);
    }
}
