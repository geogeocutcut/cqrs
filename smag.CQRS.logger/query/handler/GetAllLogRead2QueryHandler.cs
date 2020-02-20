using smag.CQRS.core;
using smag.CQRS.logger.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.logger.query
{
    public class GetAllLogRead2QueryHandler : QueryHandler<IList<Log>, GetAllLogRead2Query>
    {
        public IRepository<Guid, Log> repo;
        public GetAllLogRead2QueryHandler(LogRepository repoTmp)
        {
            repo = repoTmp;
        }

        public override IList<Log> handle(GetAllLogRead2Query querytodo)
        {
            return repo.GetAll();
        }
    }
}
