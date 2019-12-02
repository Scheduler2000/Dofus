using Renaissance.Abstract.Network;
using Renaissance.Abstract.Network.Interface;
using Renaissance.Protocol;

namespace Renaissance.Abstract.Frame.Brain
{
    public interface IFrameManager
    {
        void Execute<TMessage>(IDofusClient client, TMessage message) where TMessage : IDofusMessage;
    }
}