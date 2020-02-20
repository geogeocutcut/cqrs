using smag.CQRS.core;
using smag.CQRS.logger;
using smag.CQRS.logger.command.handler;
using smag.CQRS.logger.controller;
using smag.CQRS.logger.query;
using smag.CQRS.logger.repository;
using smag.CQRS.logger.store;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LogController ctrl = new LogController();
            InMemoryLogStore storeWrite = new InMemoryLogStore();
            InMemoryLogStore storeRead = new InMemoryLogStore();
            InMemoryLogStore storeRead2 = new InMemoryLogStore();
            //InMemoryLogStore cacheRead = new InMemoryLogStore();

            IEventBus evntBus = new EventBus();
            evntBus.Subscribe(typeof(LogAddedEvent),new LogAddedEventReadUpdater(new LogRepository(storeRead)));
            evntBus.Subscribe(typeof(LogAddedEvent), new LogAddedEventRead2Updater(new LogRepository(storeRead2)));


            ICommandBus cmdBus = new CommandBus(evntBus);
            cmdBus.Subscribe(typeof(AddLogCommand), new AddLogCommandHandler(new LogRepository(storeWrite)));
            ctrl.AddMessage(cmdBus, "test");
            ctrl.AddMessage(cmdBus, "test2");
            ctrl.AddMessage(cmdBus, "test3");


            IQueryBus queryBus = new QueryBus();
            queryBus.Subscribe(typeof(GetAllLogQuery), new GetAllLogQueryHandler(new LogRepository(storeRead)));
            var logs =ctrl.GetAllLogs(queryBus);

            ctrl.AddMessage(cmdBus, "test4");

            foreach (Log log in logs)
            {
                Console.WriteLine("Log : {0} - {1}", log.Id, log.Message);
            }

            
            queryBus.Subscribe(typeof(GetAllLogRead2Query), new GetAllLogRead2QueryHandler(new LogRepository(storeRead2)));
            logs = ctrl.GetAllLogsRead2(queryBus);

            foreach (Log log in logs)
            {
                Console.WriteLine("Log : {0} - {1}", log.Id, log.Message);
            }

            Console.ReadLine();
        }
    }
}
