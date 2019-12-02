using System.Net;
using System.Threading.Tasks;
using Atarax.Threading;
using Microsoft.Extensions.DependencyInjection;
using Renaissance.Abstract;
using Renaissance.Abstract.Network;
using Renaissance.Abstract.Network.Distribution;
using Renaissance.Auth.IoC;
using Renaissance.Auth.Patch;
using Renaissance.Protocol.messages.handshake;
using Renaissance.Protocol.messages.security;

namespace Renaissance.Auth.Networking
{
    public class AuthServer : DofusServer
    {
        public AuthServer(IContextHandler taskPool) : base(IPAddress.Parse("127.0.0.1"), 443, taskPool)
        { }

        public override Task Initialize()
        {
            Logger.Instance.Log(LogLevel.Warn, "THREADING", "Initialize IO Task Pool.", true);
            Logger.Instance.Log(LogLevel.Warn, "AUTHENTICATION SERVER", "Server Initialized.\n", true);

            base.IOTaskPool.Start();
            return base.Setup();
        }

        protected override async ValueTask OnClientAcceptedAsync(DofusConnection client)
        {
            var authClient = new AuthClient(client);

            authClient.Connection.Initialize(ServiceLocator.Provider.GetService<FrameDispatcher>(),
                (dispatcher, frame) => dispatcher.Dispatch(authClient, frame));

            await client.SendMessageAsync(new ProtocolRequired().InitProtocolRequired(1945, 1945));
            await client.SendMessageAsync(new RawDataMessage().InitRawDataMessage(PatchDataAccess.PatchBuffer));
        }
    }
}
