using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectGroundRemovedMultipleMessage : Message
{
    public const uint Id = 6993;

    public ObjectGroundRemovedMultipleMessage(IEnumerable<ushort> cells)
    {
        Cells = cells;
    }

    public ObjectGroundRemovedMultipleMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> Cells { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Cells.Count());
        foreach (ushort objectToSend in Cells) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort cellsCount = reader.ReadUShort();
        var cells_ = new ushort[cellsCount];
        for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++) cells_[cellsIndex] = reader.ReadVarUShort();
        Cells = cells_;
    }
}