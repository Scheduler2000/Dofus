using System.IO.Pipelines;
using System.Net;
using System.Threading.Tasks;

using Astron.Network;
using Astron.Network.Abstractions;

using Renaissance.Abstract.Network.Framing;
using Renaissance.Threading;

namespace Renaissance.Abstract.Network
{
    public class NetworkSocketManager : SocketManager
    {
        public NetworkSocketManager(int backlog, int capacity, IPAddress address, int port)
            : base(backlog, new IPEndPoint(address, port), new TcpSocketFactory(),
                new SocketCluster(capacity))
        { }
    }

    public abstract class DofusServer : SocketServer<DofusConnection, DofusMetadata>
    {

        public IContextHandler IOTaskPool { get; protected set; }


        public DofusServer(IPAddress address, int port, IContextHandler taskPool)
            : base(new NetworkSocketManager(0, 100, address, port), new DofusFrameParser(),
                  (exception) => Logger.Instance.Log(LogLevel.Error, "NETWORK-SERVER", exception.ToString()))
        { this.IOTaskPool = taskPool; }


        protected override IDuplexPipe CreatePipe(ISocketClient socket)
        {
            Logger.Instance.Log(LogLevel.Debug, "NETWORK-SERVER", $"New client connected : {socket.RemoteEndPoint}.");
            return (socket as SocketProxy).CreatePipe();
        }

        protected override ValueTask OnClientAccepted(DofusConnection client)
        {
            return this.OnClientAcceptedAsync(client);
        }
        protected abstract ValueTask OnClientAcceptedAsync(DofusConnection client);

        public abstract Task Initialize();

    }
}
