using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Renaissance.Abstract;
using Renaissance.Abstract.Network;
using Renaissance.Abstract.Network.Distribution;
using Renaissance.Auth.IoC;
using Renaissance.Auth.Manager;
using Renaissance.Protocol.messages.queues;
using Renaissance.Threading;

namespace Renaissance.Auth.Networking
{
    public class AuthServer : DofusServer
    {
        private QueueManager m_queue;

        public List<AuthClient> Clients { get; }


        public AuthServer(IContextHandler taskPool) : base(IPAddress.Parse("127.0.0.1"), 443, taskPool)
        {
            this.m_queue = new QueueManager();
            this.Clients = new List<AuthClient>();
        }


        public override Task Initialize()
        {
            Logger.Instance.Log(LogLevel.Warn, "THREADING", "Initialize IO Task Pool.", true);
            Logger.Instance.Log(LogLevel.Warn, "AUTHENTICATION SERVER", "Server Initialized.\n", true);

            base.IOTaskPool.ExecutePeriodically(m_queue.Process, 3000);
            base.IOTaskPool.Start();
            return base.Setup();
        }

        protected override async ValueTask OnClientAcceptedAsync(DofusConnection client)
        {
            var authClient = new AuthClient(client);
            short position = (short)(m_queue.Queue.Count + 1);

            authClient.Connection.Initialize(ServiceLocator.Provider.GetService<FrameDispatcher>(),
                (dispatcher, frame) => dispatcher.Dispatch(authClient, frame),
                 onClosed: () => authClient.OnDisconnected());

            await client.Send(new LoginQueueStatusMessage()
                                           .InitLoginQueueStatusMessage(position, position));
           
            m_queue.Queue.Enqueue(authClient);
        }
    }
}
