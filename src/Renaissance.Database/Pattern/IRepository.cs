using System;
using System.Collections.Generic;

namespace Renaissance.Database.Pattern
{
    public interface IRepository<TEntity> where TEntity : IRecord
    {
        List<TEntity> Entities { get; }

        void Create(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        TEntity GetEntity(Func<TEntity, bool> predicate);

        IEnumerable<TEntity> GetEntities(Func<TEntity, bool> predicat);

    }
}
