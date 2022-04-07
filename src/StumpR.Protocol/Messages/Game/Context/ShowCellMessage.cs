using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ShowCellMessage : Message
{
    public const uint Id = 2286;

    public ShowCellMessage(double sourceId, ushort cellId)
    {
        SourceId = sourceId;
        CellId = cellId;
    }

    public ShowCellMessage()
    {
    }

    public override uint MessageId => Id;

    public double SourceId { get; set; }

    public ushort CellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(SourceId);
        writer.WriteVarUShort(CellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        SourceId = reader.ReadDouble();
        CellId = reader.ReadVarUShort();
    }
}