﻿using smag.CQRS.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.logger
{
    public class GetAllLogQuery:IQuery<IList<Log>>
    {
    }
}
