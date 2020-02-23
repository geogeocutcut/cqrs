namespace cqrs.core.events
{
    public class EventsBus : IEventsBus
    {
        IBusMiddleware _Next;

        public EventsBus(IBusMiddleware next)
        {
            _Next = next;
        }

        public void Dispatch<E>(E mes)
        {
            _Next.Dispatch<object, E>(mes);
        }
    }
}
