using System.Collections.Generic;

namespace smag.CQRS.core
{
    public interface IStore<TId,TEntity>
    {
        TEntity FindById(TId id);
        void Upsert(TEntity entity);
        void Remove(TEntity entity);
        IList<TEntity> FindAll();
    }
}