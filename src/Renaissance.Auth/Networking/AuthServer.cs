using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Renaissance.Abstract;
using Renaissance.Abstract.Database.Share;
using Renaissance.Abstract.Network;
using Renaissance.Abstract.Network.Distribution;
using Renaissance.Auth.IoC;
using Renaissance.Auth.Patch;
using Renaissance.Protocol.messages.handshake;
using Renaissance.Protocol.messages.security;
using Renaissance.Threading;

namespace Renaissance.Auth.Networking
{
    public class AuthServer : DofusServer
    {
        public List<AuthClient> Clients { get; }

        public AuthServer(IContextHandler taskPool) : base(IPAddress.Parse("127.0.0.1"), 443, taskPool)
        { this.Clients = new List<AuthClient>(); }

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
                (dispatcher, frame) => dispatcher.Dispatch(authClient, frame),
                 onClosed: () => authClient.Disconnect());

            await client.Send(new ProtocolRequired().InitProtocolRequired(1945, 1945));
            await client.Send(new RawDataMessage().InitRawDataMessage(PatchDataAccess.PatchBuffer));
        }
    }
}
