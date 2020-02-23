namespace cqrs.core.queries
{
    public class QueriesBus : IQueriesBus
    {
        IBusMiddleware _Next;

        public QueriesBus(IBusMiddleware next)
        {
            _Next = next;
        }

        public R Dispatch<R,E>(E mes)
        {
            var resp = _Next.Dispatch<R, E>(mes);
            return resp.GetData();
        }
    }
}
