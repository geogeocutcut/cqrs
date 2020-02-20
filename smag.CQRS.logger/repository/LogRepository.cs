using smag.CQRS.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.logger.repository
{
    public class LogRepository : IRepository<Guid, Log>
    {
        private IStore<Guid, Log> store;

        public LogRepository(IStore<Guid, Log> storeTmp)
        {
            store = storeTmp;
        }

        public void Add(Log root)
        {
            store.Upsert(root);
        }

        public void Delete(Log root)
        {
            store.Remove(root);
        }

        public IList<Log> GetAll()
        {
            return store.FindAll();
        }

        public Log GetRoot(Guid id)
        {
            return store.FindById(id);
        }
    }
}
