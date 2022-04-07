using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ShowCellRequestMessage : Message
{
    public const uint Id = 4305;

    public ShowCellRequestMessage(ushort cellId)
    {
        CellId = cellId;
    }

    public ShowCellRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort CellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(CellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        CellId = reader.ReadVarUShort();
    }
}