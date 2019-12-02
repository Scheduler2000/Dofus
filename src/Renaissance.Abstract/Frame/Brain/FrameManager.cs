using System;
using System.Collections.Immutable;
using Atarax.Threading;
using Renaissance.Abstract.Network.Interface;
using Renaissance.Protocol;

namespace Renaissance.Abstract.Frame.Brain
{
    public class FrameManager<TClient> : IFrameManager where TClient : class, IDofusClient
    {
        private readonly ImmutableDictionary<int, Action<TClient, IDofusMessage>> m_frames;
        private IContextHandler m_threading;

        public FrameManager(ImmutableDictionary<int, Action<TClient, IDofusMessage>> frames,
            IContextHandler threading)
        {
            this.m_frames = frames;
            this.m_threading = threading;
        }

        public void Execute<TMessage>(IDofusClient client, TMessage message) where TMessage : IDofusMessage
        {
            if (!m_frames.TryGetValue(message.ProtocolId, out var method))
                Logger.Instance.Log(LogLevel.Warn, "NETWORK-FRAME", $"Message id {message.ProtocolId} exists but isn't listed on frames.");
            else
            {
                Logger.Instance.Log(LogLevel.Info, "NETWORK-FRAME", $"Message Id {message.ProtocolId} has been parsed and treated.");
                m_threading.ExecuteInContext(() => method(client as TClient, message));
            }
        }
    }
}
