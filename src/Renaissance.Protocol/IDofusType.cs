using Renaissance.Binary;

namespace Renaissance.Protocol
{
    public interface IDofusType
    {
        int ProtocolId { get; }

        byte[] Serialize();

        void Deserialize(DofusReader reader);
    }
}
