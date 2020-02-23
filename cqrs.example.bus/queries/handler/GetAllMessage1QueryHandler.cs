using cqrs.core;
using cqrs.core.dal;
using cqrs.example.aggregate;
using System;
using System.Collections.Generic;

namespace cqrs.example.bus.queries
{
    public class GetAllMessage1QueryHandler : Handler<IList<Message>, GetAllMessage1Query>
    {
        public IRepository<Guid, Message> repo;
        public GetAllMessage1QueryHandler(IRepository<Guid, Message> repoTmp)
        {
            repo = repoTmp;
        }

        public override IList<Message> handle(GetAllMessage1Query querytodo)
        {
            return repo.GetAll();
        }
    }
}
