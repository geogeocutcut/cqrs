using System.Collections.Generic;

namespace cqrs.core.dal
{
    public interface IRepository<TId, TRoot>
    {
        TRoot GetRoot(TId id);

        void Add(TRoot root);

        void Delete(TRoot root);

        IList<TRoot> GetAll();
    }
}
