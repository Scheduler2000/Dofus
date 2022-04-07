using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EmoteAddMessage : Message
{
    public const uint Id = 8736;

    public EmoteAddMessage(ushort emoteId)
    {
        EmoteId = emoteId;
    }

    public EmoteAddMessage()
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