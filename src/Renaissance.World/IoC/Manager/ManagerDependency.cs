using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using Renaissance.Abstract;
using Renaissance.Abstract.Manager.Interface;

namespace Renaissance.World.IoC.Manager
{
    public class ManagerDependency
    {
        private IServiceCollection m_serviceCollection;

        public ManagerDependency(IServiceCollection serviceCollection)
        { this.m_serviceCollection = serviceCollection; }


        public void RegisterManagers()
        {
            IEnumerable<Type> managers = typeof(ManagerDependency).Assembly
                                                                  .GetTypes()
                                                                  .Where(x => typeof(IManager).IsAssignableFrom(x));


            foreach (var manager in managers)
                m_serviceCollection = m_serviceCollection.AddSingleton(manager);

            Logger.Instance.Log(LogLevel.Debug, $"REPOSITORY-BUILDER",
               $"{ managers.Count()} registered managers.");

        }
    }
}
