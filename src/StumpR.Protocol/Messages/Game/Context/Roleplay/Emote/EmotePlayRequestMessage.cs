using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EmotePlayRequestMessage : Message
{
    public const uint Id = 5775;

    public EmotePlayRequestMessage(ushort emoteId)
    {
        EmoteId = emoteId;
    }

    public EmotePlayRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort EmoteId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUShort(EmoteId);
    }

    public override void Deserialize(IDataReader reader)
    {
        EmoteId = reader.ReadUShort();
    }
}