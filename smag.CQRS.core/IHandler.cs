using System;
using System.Collections.Generic;
using System.Text;

namespace smag.CQRS.core
{
    public interface IHandler
    {
        object handle(object obj);
    }
}
