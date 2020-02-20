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
            // 3 bases de données
            // base d'écriture
            InMemoryLogStore storeWrite = new InMemoryLogStore();
            // base de lecture 1
            InMemoryLogStore storeRead = new InMemoryLogStore();
            // base de lecture 2
            InMemoryLogStore storeRead2 = new InMemoryLogStore();
            //InMemoryLogStore cacheRead = new InMemoryLogStore();

            // On construit un bus d'événemment qui nous permettra de mettre à jour les deux bases de lecture
            // en emettant un évenement d'ajout de log
            IEventBus evntBus = new EventBus();
            // On souscrit deux handlers pour mettre à jour chacune des bases de lecture sur l'événement d'ajout de log
            evntBus.Subscribe(typeof(LogAddedEvent),new LogAddedEventReadUpdater(new LogRepository(storeRead)));
            evntBus.Subscribe(typeof(LogAddedEvent), new LogAddedEventRead2Updater(new LogRepository(storeRead2)));

            // On construit un bus pour les commands. Pas de middleware
            // on passe un bus pour gérer les événments générés par la commande
            ICommandBus cmdBus = new CommandBus(evntBus);
            // On soucrit un handler à la command d'ajout de log.
            cmdBus.Subscribe(typeof(AddLogCommand), new AddLogCommandHandler(new LogRepository(storeWrite)));

            // On construit un bus pour les query. Pas de middleware
            IQueryBus queryBus = new QueryBus();
            // on inscrit un handler pour chaque query
            // La première query est à destination de la base de lecture 1
            queryBus.Subscribe(typeof(GetAllLogQuery), new GetAllLogQueryHandler(new LogRepository(storeRead)));
            // La première query est à destination de la base de lecture 2
            queryBus.Subscribe(typeof(GetAllLog2Query), new GetAllLog2QueryHandler(new LogRepository(storeRead2)));

            LogController ctrl = new LogController(cmdBus,queryBus);

            // Envoi Command Add
            ctrl.AddMessage("test");
            ctrl.AddMessage("test2");
            ctrl.AddMessage("test3");

            // Envoi Query GetAll sur la base 1
            var logs =ctrl.GetAllLogs();
            foreach (Log log in logs)
            {
                Console.WriteLine("Log : {0} - {1}", log.Id, log.Message);
            }

            // Envoi Command Add
            ctrl.AddMessage("test4");

            // Envoi Query GetAll sur la base 2
            logs = ctrl.GetAllLogsRead2();
            foreach (Log log in logs)
            {
                Console.WriteLine("Log : {0} - {1}", log.Id, log.Message);
            }

            Console.ReadLine();
        }
    }
}
