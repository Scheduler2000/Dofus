using System;
using System.Buffers;
using System.Threading.Tasks;
using Astron.Network;
using Astron.Network.Framing;
using Renaissance.Abstract.Network.Distribution;
using Renaissance.Abstract.Network.Framing;
using Renaissance.Abstract.Network.Interface;
using Renaissance.Protocol;

namespace Renaissance.Abstract.Network
{
    public class DofusConnection : SocketConnection<DofusMetadata>, INetworkConnection
    {
        private FrameDispatcher m_dispatcher;
        private Action<FrameDispatcher, Frame<DofusMetadata>> m_dispatching;

        public DofusConnection() : base() { }

        public void Initialize(FrameDispatcher dispatcher, Action<FrameDispatcher, Frame<DofusMetadata>> dispatching)
        {
            this.m_dispatcher = dispatcher;
            this.m_dispatching = dispatching;
        }

        protected override async ValueTask OnReceiveAsync(Frame<DofusMetadata> frame)
        { await Task.Run(() => m_dispatching(m_dispatcher, frame)); }

        public async ValueTask SendMessageAsync<TMessage>(TMessage message) where TMessage : IDofusMessage
        {
            var payload = new ReadOnlySequence<byte>(message.Serialize());
            var metadata = new DofusMetadata(message.ProtocolId, (int)payload.Length);
            var frame = new Frame<DofusMetadata>(payload, metadata);

            await SendAsync(frame);
            Logger.Instance.Log(LogLevel.Info, "NETWORK-CLIENT", $"Message Id : {message.ProtocolId} successfully sent.");
        }

        protected override ValueTask OnDestroyAsync()
        {
            Logger.Instance.Log(LogLevel.Debug, "NETWORK-CLIENT", "Client disconnected !");
            return base.OnDestroyAsync();
        }

    }
}
