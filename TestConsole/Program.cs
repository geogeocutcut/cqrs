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
            InMemoryLogStore storeWrite = new InMemoryLogStore();
            InMemoryLogStore storeRead = new InMemoryLogStore();
            InMemoryLogStore storeRead2 = new InMemoryLogStore();
            //InMemoryLogStore cacheRead = new InMemoryLogStore();

            IEventBus evntBus = new EventBus();
            evntBus.Subscribe(typeof(LogAddedEvent),new LogAddedEventReadUpdater(new LogRepository(storeRead)));
            evntBus.Subscribe(typeof(LogAddedEvent), new LogAddedEventRead2Updater(new LogRepository(storeRead2)));


            ICommandBus cmdBus = new CommandBus(evntBus);
            cmdBus.Subscribe(typeof(AddLogCommand), new AddLogCommandHandler(new LogRepository(storeWrite)));
            IQueryBus queryBus = new QueryBus();
            queryBus.Subscribe(typeof(GetAllLogQuery), new GetAllLogQueryHandler(new LogRepository(storeRead)));
            queryBus.Subscribe(typeof(GetAllLogRead2Query), new GetAllLogRead2QueryHandler(new LogRepository(storeRead2)));

            LogController ctrl = new LogController(cmdBus,queryBus);

            // Envoi Command Add
            ctrl.AddMessage("test");
            ctrl.AddMessage("test2");
            ctrl.AddMessage("test3");

            // Envoi Query GetAll
            var logs =ctrl.GetAllLogs();
            foreach (Log log in logs)
            {
                Console.WriteLine("Log : {0} - {1}", log.Id, log.Message);
            }

            // Envoi Command Add
            ctrl.AddMessage("test4");
            // Envoi Query GetAll2
            logs = ctrl.GetAllLogsRead2();
            foreach (Log log in logs)
            {
                Console.WriteLine("Log : {0} - {1}", log.Id, log.Message);
            }

            Console.ReadLine();
        }
    }
}
