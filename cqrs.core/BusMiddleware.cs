
namespace cqrs.core
{
    public abstract class BusMiddleware : IBusMiddleware
    {
        protected IBusMiddleware _Next;

        public abstract IBusResponse<R> Dispatch<R, E>(E mes);

    }
}
