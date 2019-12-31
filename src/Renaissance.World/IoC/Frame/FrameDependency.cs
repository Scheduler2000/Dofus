using System;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using Renaissance.Abstract.Frame;
using Renaissance.Abstract.Frame.Brain;
using Renaissance.Abstract.Network.Distribution;
using Renaissance.Threading;
using Renaissance.World.IoC.Protocol;
using Renaissance.World.Networking;

namespace Renaissance.World.IoC.Frame
{
    public class FrameDependency
    {
        private ServiceCollection m_serviceCollection;
        private IContextHandler m_contextHandler;

        public FrameDependency(ServiceCollection serviceCollection, IContextHandler contextHandler)
        {
            this.m_serviceCollection = serviceCollection;
            this.m_contextHandler = contextHandler;
        }

        public void RegisterFrames()
        {
            var framesTypes = typeof(FrameDependency).Assembly
                                                .GetTypes()
                                                .Where(t => typeof(IFrame).IsAssignableFrom(t));

            var messageProvider = new MessageDependency()
                                  .Congifure()
                                  .Build();

            var frameBuilder = new FrameBuilder<WorldClient>();
            foreach (var frameType in framesTypes)
            {
                dynamic frame = Convert.ChangeType(Activator.CreateInstance(frameType), frameType);
                frameBuilder.RegisterFrame(frame);
            }

            var frames = frameBuilder.Build();
            var frameManager = new FrameManager<WorldClient>(frames, m_contextHandler);
            var frameDispatcher = new FrameDispatcher(messageProvider, frameManager);

            m_serviceCollection.AddSingleton(frameDispatcher);
        }
    }
}
