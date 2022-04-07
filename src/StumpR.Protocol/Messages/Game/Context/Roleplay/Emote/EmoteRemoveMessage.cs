using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EmoteRemoveMessage : Message
{
    public const uint Id = 8124;

    public EmoteRemoveMessage(ushort emoteId)
    {
        EmoteId = emoteId;
    }

    public EmoteRemoveMessage()
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