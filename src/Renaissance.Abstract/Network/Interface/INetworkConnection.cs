using System;
using System.Threading.Tasks;
using Astron.Network.Framing;
using Renaissance.Abstract.Network.Distribution;
using Renaissance.Abstract.Network.Framing;
using Renaissance.Protocol;

namespace Renaissance.Abstract.Network.Interface
{
    public interface INetworkConnection
    {
        void Initialize(FrameDispatcher dispatcher, Action<FrameDispatcher, Frame<DofusMetadata>> dispatching);
        ValueTask SendMessageAsync<TMessage>(TMessage message) where TMessage : IDofusMessage;
    }
}
