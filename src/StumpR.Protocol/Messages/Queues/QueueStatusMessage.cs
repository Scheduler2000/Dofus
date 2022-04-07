using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class QueueStatusMessage : Message
{
    public const uint Id = 2197;

    public QueueStatusMessage(ushort position, ushort total)
    {
        Position = position;
        Total = total;
    }

    public QueueStatusMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort Position { get; set; }

    public ushort Total { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUShort(Position);
        writer.WriteUShort(Total);
    }

    public override void Deserialize(IDataReader reader)
    {
        Position = reader.ReadUShort();
        Total = reader.ReadUShort();
    }
}