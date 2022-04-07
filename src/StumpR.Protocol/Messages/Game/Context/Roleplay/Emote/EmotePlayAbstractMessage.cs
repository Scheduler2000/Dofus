using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EmotePlayAbstractMessage : Message
{
    public const uint Id = 4497;

    public EmotePlayAbstractMessage(ushort emoteId, double emoteStartTime)
    {
        EmoteId = emoteId;
        EmoteStartTime = emoteStartTime;
    }

    public EmotePlayAbstractMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort EmoteId { get; set; }

    public double EmoteStartTime { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUShort(EmoteId);
        writer.WriteDouble(EmoteStartTime);
    }

    public override void Deserialize(IDataReader reader)
    {
        EmoteId = reader.ReadUShort();
        EmoteStartTime = reader.ReadDouble();
    }
}