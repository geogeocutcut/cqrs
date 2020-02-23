
using cqrs.example.controller;
using System;

namespace cqrs.example.test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var commandsbus = BusFactory.BuilderCommandsBus();
            var queriesbus = BusFactory.BuilderQueriesBus();

            MessageController ctrl = new MessageController(commandsbus, queriesbus);

            // Envoi Command Add
            ctrl.AddMessage("test");
            ctrl.AddMessage("test2");
            ctrl.AddMessage("test3");

            var datas1 = ctrl.GetAllMessageRead1();
            foreach (var d in datas1)
            {
                Console.WriteLine($"{ d.Id} : {d.Content}");
            }

            // Envoi Command Add
            ctrl.AddMessage("test4");

            var datas2 = ctrl.GetAllMessageRead2();
            foreach (var d in datas2)
            {
                Console.WriteLine($"{ d.Id} : {d.Content}");
            }

            Console.WriteLine("End!");
            Console.ReadKey();
        }
    }
}
