﻿using smag.CQRS.core;
using smag.CQRS.logger.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smag.CQRS.logger.query
{
    public class GetAllLog2QueryHandler : QueryHandler<IList<Log>, GetAllLog2Query>
    {
        public IRepository<Guid, Log> repo;
        public GetAllLog2QueryHandler(LogRepository repoTmp)
        {
            repo = repoTmp;
        }

        public override IList<Log> handle(GetAllLog2Query querytodo)
        {
            return repo.GetAll().Select(x=>{ x.Message = "from query 2 :"+ x.Message; return x; }).ToList();
        }
    }
}