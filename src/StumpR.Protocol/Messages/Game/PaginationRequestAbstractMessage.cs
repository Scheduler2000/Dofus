using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PaginationRequestAbstractMessage : Message
{
    public const uint Id = 789;

    public PaginationRequestAbstractMessage(double offset, uint count)
    {
        Offset = offset;
        Count = count;
    }

    public PaginationRequestAbstractMessage()
    {
    }

    public override uint MessageId => Id;

    public double Offset { get; set; }

    public uint Count { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(Offset);
        writer.WriteUInt(Count);
    }

    public override void Deserialize(IDataReader reader)
    {
        Offset = reader.ReadDouble();
        Count = reader.ReadUInt();
    }
}