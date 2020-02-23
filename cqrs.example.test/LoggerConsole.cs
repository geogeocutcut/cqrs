using cqrs.core.tools;
using System;

namespace cqrs.example.test
{
    public class LoggerConsole : ILogger
    {
        public void Info(string log)
        {
            Console.WriteLine(log);
        }
    }
}
