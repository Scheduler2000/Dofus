using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Renaissance.Database.Pattern
{
    public class Repository<TContext, TEntity> :
    IRepository<TEntity>, IDisposable where TEntity : class, IEntity where TContext : DofusContext<TEntity>, new()

    {
        private readonly TContext m_context;
        private readonly DbSet<TEntity> m_database;
        private readonly ReaderWriterLockSlim m_sync = new ReaderWriterLockSlim();

        public List<TEntity> Entities => m_database.ToList();


        public Repository()
        {
            this.m_context = new TContext();
            this.m_database = m_context.Table;
        }


        public void Create(TEntity entity)
        {
            m_sync.EnterWriteLock();

            try
            {
                m_database.Add(entity);
                m_context.SaveChanges();
            }
            finally
            { m_sync.ExitWriteLock(); }

        }

        public void Delete(TEntity entity)
        {
            m_sync.EnterWriteLock();

            try
            {
                m_database.Remove(entity);
                m_context.SaveChanges();
            }
            finally
            { m_sync.ExitWriteLock(); }

        }

        public void Update(TEntity entity)
        {
            m_sync.EnterWriteLock();

            try
            {
                m_context.Entry(entity).State = EntityState.Modified;
                m_context.SaveChanges();
            }
            finally
            { m_sync.ExitWriteLock(); }

        }

        public TEntity GetEntity(Func<TEntity, bool> predicate)
        {
            m_sync.EnterReadLock();

            try
            { return m_database.FirstOrDefault(predicate); }

            finally
            { m_sync.ExitReadLock(); }

        }

        public IEnumerable<TEntity> GetEntities(Func<TEntity, bool> predicate)
        {
            m_sync.EnterReadLock();

            try
            { return m_database.Where(predicate); }

            finally
            { m_sync.ExitReadLock(); }
        }

        public void Dispose()
        {
            m_sync.EnterWriteLock();
            try { m_context.Dispose(); }
            finally { m_sync.ExitWriteLock(); }
        }
    }
}
