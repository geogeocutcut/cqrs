using cqrs.core.dal;
using cqrs.example.aggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cqrs.example.dal
{
    public class InMemoryMessageStore : IStore<Guid, Message>
    {
        private IDictionary<Guid, Message> db = new Dictionary<Guid, Message>();
        public IList<Message> FindAll()
        {
            return db.Values.ToList();
        }

        public Message FindById(Guid id)
        {
            return db[id];
        }

        public void Remove(Message entity)
        {
            db.Remove(entity.Id);
        }

        public void Upsert(Message entity)
        {
            if (db.TryGetValue(entity.Id, out var entdb))
            {
                entdb = entity;
            }
            else
            {
                db.Add(entity.Id, entity);
            }
        }
    }
}
