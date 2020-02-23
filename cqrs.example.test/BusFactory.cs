using cqrs.core;
using cqrs.core.commands;
using cqrs.core.events;
using cqrs.core.middleware;
using cqrs.core.queries;
using cqrs.core.tools;
using cqrs.example.bus.commands;
using cqrs.example.bus.events;
using cqrs.example.bus.middleware;
using cqrs.example.bus.queries;
using cqrs.example.store;

namespace cqrs.example.test
{
    public class BusFactory
    {

        // 3 bases de données
        // base d'écriture
        public static InMemoryMessageStore storeWrite = new InMemoryMessageStore();
        // base de lecture 1
        public static InMemoryMessageStore storeRead = new InMemoryMessageStore();
        // base de lecture 2
        public static InMemoryMessageStore storeRead2 = new InMemoryMessageStore();

        public static ILogger logger = new LoggerConsole();


        public static CommandsBus BuilderCommandsBus()
        {
            var eventsBus = new EventsBus(
                                new VoidDispatcherMiddleware(
                                    new IHandler[]
                                    {
                                        new MessageAddedEventRead1Handler(new MessageRepository(storeRead)),
                                        new MessageAddedEventRead2Handler(new MessageRepository(storeRead2))
                                    }
                                )
                            );


            return new CommandsBus(
                        new TracerMiddleware(
                            new EventReRouterMiddleware(
                                new SimpleDispatcherMiddleware(
                                    new IHandler[]
                                    {
                                        new AddMessageCommandHandler(new MessageRepository(storeWrite))
                                    }
                                ),
                                eventsBus
                            ),
                            logger
                        )
                    );


        }

        public static QueriesBus BuilderQueriesBus()
        {

            
            return new QueriesBus(
                        new TracerMiddleware(
                            new SimpleDispatcherMiddleware(
                                new IHandler[]
                                {
                                    new GetAllMessage1QueryHandler(new MessageRepository(storeRead)),
                                    new GetAllMessage2QueryHandler(new MessageRepository(storeRead2))
                                }
                            ),
                            logger
                        )
                    );
        }
    }
}
