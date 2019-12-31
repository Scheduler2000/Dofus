using System;
using System.Diagnostics;

using Microsoft.Extensions.DependencyInjection;

using Renaissance.Abstract;
using Renaissance.Threading;
using Renaissance.World.IoC.Database;
using Renaissance.World.IoC.Frame;
using Renaissance.World.IoC.Manager;
using Renaissance.World.Networking;

namespace Renaissance.World.IoC
{
    public static class WorldStartup
    {
        public static IServiceProvider Configure()
        {
            var watch = new Stopwatch();
            watch.Start();

            var services = new ServiceCollection();


            IContextHandler asyncPool = new AsyncPool(150, "World");

            new ManagerDependency(services).RegisterManagers();
            new FrameDependency(services, asyncPool).RegisterFrames();
            new RepositoryDependency(services).RegisterRepositories();


            var authServer = new WorldServer(asyncPool);


            services.AddSingleton(authServer);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            watch.Stop();
            Logger.Instance.Log(LogLevel.Debug, "APPLICATION DATA", $"IoC container initialized in {watch.ElapsedMilliseconds} ms.\n");

            return serviceProvider;
        }
    }
}
