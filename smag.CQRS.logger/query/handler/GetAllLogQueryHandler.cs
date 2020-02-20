using smag.CQRS.core;
using smag.CQRS.logger.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.logger.query
{
    public class GetAllLogQueryHandler : QueryHandler<IList<Log>, GetAllLogQuery>
    {
        public IRepository<Guid, Log> repo;
        public GetAllLogQueryHandler(LogRepository repoTmp)
        {
            repo = repoTmp;
        }

        public override IList<Log> handle(GetAllLogQuery querytodo)
        {
            return repo.GetAll();
        }
    }
}
