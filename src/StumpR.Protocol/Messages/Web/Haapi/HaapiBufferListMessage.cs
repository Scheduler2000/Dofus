using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiBufferListMessage : Message
{
    public const uint Id = 518;

    public HaapiBufferListMessage(IEnumerable<BufferInformation> buffers)
    {
        Buffers = buffers;
    }

    public HaapiBufferListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<BufferInformation> Buffers { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Buffers.Count());
        foreach (BufferInformation objectToSend in Buffers) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort buffersCount = reader.ReadUShort();
        var buffers_ = new BufferInformation[buffersCount];

        for (var buffersIndex = 0; buffersIndex < buffersCount; buffersIndex++)
        {
            var objectToAdd = new BufferInformation();
            objectToAdd.Deserialize(reader);
            buffers_[buffersIndex] = objectToAdd;
        }
        Buffers = buffers_;
    }
}