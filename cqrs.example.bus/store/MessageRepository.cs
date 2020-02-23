using cqrs.core.dal;
using cqrs.example.aggregate;
using System;
using System.Collections.Generic;

namespace cqrs.example.store
{
    public class MessageRepository : IRepository<Guid, Message>
    {
        private IStore<Guid, Message> store;

        public MessageRepository(IStore<Guid, Message> storeTmp)
        {
            store = storeTmp;
        }

        public void Add(Message root)
        {
            store.Upsert(root);
        }

        public void Delete(Message root)
        {
            store.Remove(root);
        }

        public IList<Message> GetAll()
        {
            return store.FindAll();
        }

        public Message GetRoot(Guid id)
        {
            return store.FindById(id);
        }
    }
}
