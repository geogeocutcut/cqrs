using smag.CQRS.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smag.CQRS.logger.store
{
    public class InMemoryLogStore : IStore<Guid, Log>
    {
        private IDictionary<Guid, Log> db = new Dictionary<Guid, Log>();
        public IList<Log> FindAll()
        {
            return db.Values.ToList();
        }

        public Log FindById(Guid id)
        {
            return db[id];
        }

        public void Remove(Log entity)
        {
            db.Remove(entity.Id);
        }

        public void Upsert(Log entity)
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
