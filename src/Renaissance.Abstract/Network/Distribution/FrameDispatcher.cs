using System;
using System.Collections.Immutable;
using Astron.Network.Framing;
using Renaissance.Abstract.Frame.Brain;
using Renaissance.Abstract.Network.Framing;
using Renaissance.Abstract.Network.Interface;
using Renaissance.Binary;
using Renaissance.Protocol;

namespace Renaissance.Abstract.Network.Distribution
{
    public class FrameDispatcher
    {
        private readonly ImmutableDictionary<int, Func<IDofusMessage>> m_messageProvider;
        private readonly IFrameManager m_frameManager;

        public FrameDispatcher(ImmutableDictionary<int, Func<IDofusMessage>> messageProvider, IFrameManager frameManager)
        {
            this.m_messageProvider = messageProvider;
            this.m_frameManager = frameManager;
        }

        public void Dispatch(IDofusClient client, Frame<DofusMetadata> frame)
        {
            int key = frame.Metadata.MessageId;

            if (!m_messageProvider.TryGetValue(key, out var msgCtor))
                Logger.Instance.Log(LogLevel.Warn, "[NETWORK]", $"The message received isn't in the protocol : {key}.");
            else
            {
                IDofusMessage message = msgCtor();
                var reader = new DofusReader(frame.Payload);

                message.Deserialize(reader);
                m_frameManager.Execute(client, message);
            }

        }
    }
}
