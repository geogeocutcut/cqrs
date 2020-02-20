using smag.CQRS.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.logger
{
    public class GetAllLog2Query : IQuery<IList<Log>>
    {
    }
}
