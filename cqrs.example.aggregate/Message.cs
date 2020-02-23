using cqrs.core;
using System;

namespace cqrs.example.aggregate
{
    public class Message : AggregateRoot<Guid>
    {

        public string Content { get; set; }


        public Message(Guid idtmp)
        {
            this.Id = idtmp;

        }
        public Message()
        {
            this.Id = Guid.NewGuid();

        }

        public Guid getId()
        {
            return Id;
        }

        public void UpdateContent(string mess)
        {
            this.Content = mess;
        }
    }
}
