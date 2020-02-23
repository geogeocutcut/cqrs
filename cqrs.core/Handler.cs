using System;

namespace cqrs.core
{
    public abstract class Handler<R,E>:IHandler 
    {

        public Type ListenTo()
        {
            return typeof(E);
        }

        public abstract R handle(E obj);

        public object handle(object obj)
        {
            return handle((E)obj);
        }
    }
}
