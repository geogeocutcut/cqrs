namespace cqrs.core.queries
{
    public interface IQueriesBus
    {
        R Dispatch<R, E>(E mes);
    }
}