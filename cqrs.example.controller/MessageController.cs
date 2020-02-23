
using cqrs.core.commands;
using cqrs.core.queries;
using cqrs.example.aggregate;
using cqrs.example.bus.commands;
using cqrs.example.bus.queries;
using System.Collections.Generic;

namespace cqrs.example.controller
{
    public class MessageController
    {
        private ICommandsBus _CmdBus;
        private IQueriesBus _QueryBus;
        public MessageController(ICommandsBus cmdbus, IQueriesBus querybus)
        {
            _CmdBus = cmdbus;
            _QueryBus = querybus;
        }

        public void AddMessage(string message)
        {
            Message mes = new Message();
            mes.UpdateContent(message);
            _CmdBus.Dispatch<AddMessageCommand>(new AddMessageCommand(mes));
        }

        public IList<Message> GetAllMessageRead1()
        {
            return _QueryBus.Dispatch<IList<Message>, GetAllMessage1Query>(new GetAllMessage1Query());
        }

        public IList<Message> GetAllMessageRead2()
        {
            return _QueryBus.Dispatch<IList<Message>, GetAllMessage2Query>(new GetAllMessage2Query());
        }
    }
}
