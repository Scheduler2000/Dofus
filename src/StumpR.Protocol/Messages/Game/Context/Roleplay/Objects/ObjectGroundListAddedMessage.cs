using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectGroundListAddedMessage : Message
{
    public const uint Id = 6617;

    public ObjectGroundListAddedMessage(IEnumerable<ushort> cells, IEnumerable<ushort> referenceIds)
    {
        Cells = cells;
        ReferenceIds = referenceIds;
    }

    public ObjectGroundListAddedMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> Cells { get; set; }

    public IEnumerable<ushort> ReferenceIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Cells.Count());
        foreach (ushort objectToSend in Cells) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) ReferenceIds.Count());
        foreach (ushort objectToSend in ReferenceIds) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort cellsCount = reader.ReadUShort();
        var cells_ = new ushort[cellsCount];
        for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++) cells_[cellsIndex] = reader.ReadVarUShort();
        Cells = cells_;
        ushort referenceIdsCount = reader.ReadUShort();
        var referenceIds_ = new ushort[referenceIdsCount];

        for (var referenceIdsIndex = 0; referenceIdsIndex < referenceIdsCount; referenceIdsIndex++)
            referenceIds_[referenceIdsIndex] = reader.ReadVarUShort();
        ReferenceIds = referenceIds_;
    }
}