
namespace cqrs.core
{
    public interface IBusMiddleware
    {
        IBusResponse<R> Dispatch<R,E>(E mes);
    }
}
