
namespace cqrs.core
{

    public interface IBusResponse<T>
    {
        T GetData();
    }
}
