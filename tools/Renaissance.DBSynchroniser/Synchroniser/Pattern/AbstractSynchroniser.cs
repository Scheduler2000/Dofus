using System;
using System.Collections.Generic;
using System.Linq;

using Konsole;

using Renaissance.Database.Pattern;
using Renaissance.Protocol.datacenter;

namespace Renaissance.DBSynchroniser.Synchroniser.Pattern
{
    public abstract class AbstractSynchroniser<TEntity, TData> : ISynchroniser where TEntity : IRecord where TData : IDataCenter
    {
        private readonly IEnumerable<TData> m_datas;
        private readonly IRepository<TEntity> m_database;

        protected AbstractSynchroniser(IEnumerable<TData> datas, IRepository<TEntity> database)
        {
            this.m_datas = datas;
            this.m_database = database;
        }


        public void Synchronize()
        {
            string name = typeof(TEntity).Name;

            if (m_database.Entities.Count == 0)
            {
                int counter = 0;
                int total = m_datas.Count();
                var bar = new ProgressBar(PbStyle.SingleLine, 100);
                bar.Refresh(0, name);

                foreach (var data in m_datas)
                {
                    var entity = BuildEntity(data);
                    m_database.Create(entity);
                    counter++;
                    bar.Refresh(counter * 100 / total, name);
                }
            }
            else Console.WriteLine($"Please clean <{name}>'s table before sync !");
        }

        protected abstract TEntity BuildEntity(TData data);

    }
}
