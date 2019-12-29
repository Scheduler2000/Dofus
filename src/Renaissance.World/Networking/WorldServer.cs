using System.Net;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Renaissance.Abstract;
using Renaissance.Abstract.Network;
using Renaissance.Abstract.Network.Distribution;
using Renaissance.Protocol.messages.game.approach;
using Renaissance.Protocol.messages.handshake;
using Renaissance.Threading;
using Renaissance.Threading.Synchronization.List;
using Renaissance.World.IoC;

namespace Renaissance.World.Networking
{
    public class WorldServer : DofusServer
    {
        public SyncList<WorldClient> Clients { get; }


        public WorldServer(IContextHandler taskPool) : base(IPAddress.Parse("127.0.0.1"), 5555, taskPool)
        { this.Clients = new SyncList<WorldClient>(); }

        public override Task Initialize()
        {
            Logger.Instance.Log(LogLevel.Warn, "THREADING", "Initialize IO Task Pool.", true);
            Logger.Instance.Log(LogLevel.Warn, "WORLD SERVER", "Server Initialized.\n", true);

            base.IOTaskPool.Start();
            return base.Setup();
        }

        protected override async ValueTask OnClientAcceptedAsync(DofusConnection client)
        {
            var worldClient = new WorldClient(client);

            worldClient.Connection.Initialize(ServiceLocator.Provider.GetService<FrameDispatcher>(),
                (dispatcher, frame) => dispatcher.Dispatch(worldClient, frame),
                 onClosed: () => worldClient.OnDisconnected());

            await worldClient.Connection.Send(new ProtocolRequired()
                             .InitProtocolRequired(1945, 1945));

            await worldClient.Connection.Send(new HelloGameMessage());
        }
    }
}
