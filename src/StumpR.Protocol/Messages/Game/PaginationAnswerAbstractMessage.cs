using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PaginationAnswerAbstractMessage : Message
{
    public const uint Id = 2864;

    public PaginationAnswerAbstractMessage(double offset, uint count, uint total)
    {
        Offset = offset;
        Count = count;
        Total = total;
    }

    public PaginationAnswerAbstractMessage()
    {
    }

    public override uint MessageId => Id;

    public double Offset { get; set; }

    public uint Count { get; set; }

    public uint Total { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(Offset);
        writer.WriteUInt(Count);
        writer.WriteUInt(Total);
    }

    public override void Deserialize(IDataReader reader)
    {
        Offset = reader.ReadDouble();
        Count = reader.ReadUInt();
        Total = reader.ReadUInt();
    }
}