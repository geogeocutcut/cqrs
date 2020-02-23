
namespace cqrs.core
{
    public class BusResponse<T>: IBusResponse<T>
    {
        public T Data { get; private set; }


        public BusResponse()
        {
        }

        public BusResponse(T data) 
        {
            Data = data;
        }
        

        public T GetData()
        {
            return Data;
        }
    }
}
