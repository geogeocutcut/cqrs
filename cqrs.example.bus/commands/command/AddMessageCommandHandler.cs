using cqrs.example.aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace cqrs.example.bus.commands
{
    public class AddMessageCommand
    {
        public Message Message { get; set; }

        public AddMessageCommand(Message mes)
        {
            Message = mes;
        }
    }
}
