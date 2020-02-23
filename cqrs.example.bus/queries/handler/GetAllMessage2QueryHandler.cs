using cqrs.core;
using cqrs.core.dal;
using cqrs.example.aggregate;
using System;
using System.Collections.Generic;

namespace cqrs.example.bus.queries
{
    public class GetAllMessage2QueryHandler : Handler<IList<Message>, GetAllMessage2Query>
    {
        public IRepository<Guid, Message> repo;
        public GetAllMessage2QueryHandler(IRepository<Guid, Message> repoTmp)
        {
            repo = repoTmp;
        }

        public override IList<Message> handle(GetAllMessage2Query querytodo)
        {
            return repo.GetAll();
        }
    }
}
