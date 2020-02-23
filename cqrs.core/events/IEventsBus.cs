namespace cqrs.core.events
{
    public interface IEventsBus
    {
        void Dispatch<E>(E mes);
    }
}