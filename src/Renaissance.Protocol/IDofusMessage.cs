
using System;
using Renaissance.Binary;

namespace Renaissance.Protocol
{
    public interface IDofusMessage
    {
        int ProtocolId { get; }

        Memory<byte> Serialize();

        void Deserialize(DofusReader reader);
    }
}
