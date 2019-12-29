using System;
using System.Diagnostics;

using Microsoft.Extensions.DependencyInjection;

using Renaissance.Abstract;
using Renaissance.Abstract.Database.Share;
using Renaissance.Abstract.Frame.Brain;
using Renaissance.Abstract.Network.Distribution;
using Renaissance.Threading;
using Renaissance.World.Frame;
using Renaissance.World.IoC.Protocol;
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

            var messageProvider = new MessageDependency()
                               .Congifure()
                               .Build();

            var frames = new FrameBuilder<WorldClient>()
                                   .RegisterFrame<ApproachFrame>()
                                   .Build();

            var frameManager = new FrameManager<WorldClient>(frames, asyncPool);

            var frameDispatcher = new FrameDispatcher(messageProvider, frameManager);


            var authServer = new WorldServer(asyncPool);


            services.AddSingleton(authServer)
                    .AddSingleton(frameDispatcher)
                    .AddSingleton(new AccountRepository());

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            watch.Stop();
            Logger.Instance.Log(LogLevel.Debug, "APPLICATION DATA", $"IoC container initialized in {watch.ElapsedMilliseconds} ms.\n");

            return serviceProvider;
        }
    }
}
