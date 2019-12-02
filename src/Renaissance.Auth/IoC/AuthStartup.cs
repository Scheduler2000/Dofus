using System;
using System.Diagnostics;
using Atarax.Threading;
using Microsoft.Extensions.DependencyInjection;
using Renaissance.Abstract;
using Renaissance.Abstract.Frame.Brain;
using Renaissance.Abstract.Network.Distribution;
using Renaissance.Auth.Database.Authentication;
using Renaissance.Auth.Frame;
using Renaissance.Auth.IoC.Protocol;
using Renaissance.Auth.Networking;
using Renaissance.Threading;

namespace Renaissance.Auth.IoC
{
    public static class AuthStartup
    {
        public static IServiceProvider Configure()
        {
            var watch = new Stopwatch();
            watch.Start();

            var services = new ServiceCollection();

            IContextHandler asyncPool = new AsyncPool(150, "Authentication");

            var messageProvider = new MessageDependency()
                               .Congifure()
                               .Build();

            var frames = new FrameBuilder<AuthClient>()
                                   .RegisterFrame<AuthenticationFrame>()
                                   .Build();

            var frameManager = new FrameManager<AuthClient>(frames, asyncPool);

            var frameDispatcher = new FrameDispatcher(messageProvider, frameManager);

            var authServer = new AuthServer(asyncPool);


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
