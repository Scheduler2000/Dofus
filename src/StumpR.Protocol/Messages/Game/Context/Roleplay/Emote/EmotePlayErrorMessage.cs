using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EmotePlayErrorMessage : Message
{
    public const uint Id = 9167;

    public EmotePlayErrorMessage(ushort emoteId)
    {
        EmoteId = emoteId;
    }

    public EmotePlayErrorMessage()
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