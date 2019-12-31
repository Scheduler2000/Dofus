using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Renaissance.Abstract;
using Renaissance.Abstract.Database.Share;

namespace Renaissance.World.IoC.Database
{
    public class RepositoryDependency
    {
        private IServiceCollection m_serviceCollection;

        public RepositoryDependency(IServiceCollection serviceCollection)
        { this.m_serviceCollection = serviceCollection; }


        public void RegisterRepositories()
        {
            IEnumerable<Type> repositories = typeof(RepositoryDependency).Assembly
                                                                .GetTypes()
                                                                .Where(x => x.Name.Contains("Repository")
                                                                && x.Namespace.Contains("Renaissance.World.Database"));


            foreach (var repository in repositories)
                m_serviceCollection = m_serviceCollection.AddSingleton(repository);

            m_serviceCollection.AddSingleton(new AccountRepository());

            Logger.Instance.Log(LogLevel.Debug, $"MANAGER-BUILDER",
               $"{ repositories.Count()} registered repositories.");

        }
    }
}
