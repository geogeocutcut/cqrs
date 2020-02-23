using cqrs.core;
using cqrs.core.tools;
using System.Diagnostics;

namespace cqrs.example.bus.middleware
{
    public class TracerMiddleware : BusMiddleware
    {
        private ILogger _Logger;
        public TracerMiddleware(IBusMiddleware next,ILogger logger)
        {
            _Next = next;
            _Logger = logger;
        }
        public override IBusResponse<R> Dispatch<R, E>(E mes)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            var result =  _Next.Dispatch<R,E>(mes);
            st.Stop();
            _Logger.Info($"Log event : {mes.GetType().ToString()} - {st.ElapsedMilliseconds} ms");
            return result;
        }
    }
}
