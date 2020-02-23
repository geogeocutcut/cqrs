using System;
using System.Collections.Generic;
using System.Text;

namespace cqrs.core.dal
{
    public interface IStore<TId, TEntity>
    {
        TEntity FindById(TId id);
        void Upsert(TEntity entity);
        void Remove(TEntity entity);
        IList<TEntity> FindAll();
    }
}
