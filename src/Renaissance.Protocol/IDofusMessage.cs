
using Renaissance.Binary;

namespace Renaissance.Protocol
{
    public interface IDofusMessage
    {
        int ProtocolId { get; }

        byte[] Serialize();

        void Deserialize(DofusReader reader);
    }
}
