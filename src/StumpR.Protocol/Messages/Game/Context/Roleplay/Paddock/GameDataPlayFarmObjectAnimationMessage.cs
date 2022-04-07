using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameDataPlayFarmObjectAnimationMessage : Message
{
    public const uint Id = 7212;

    public GameDataPlayFarmObjectAnimationMessage(IEnumerable<ushort> cellId)
    {
        CellId = cellId;
    }

    public GameDataPlayFarmObjectAnimationMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> CellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) CellId.Count());
        foreach (ushort objectToSend in CellId) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort cellIdCount = reader.ReadUShort();
        var cellId_ = new ushort[cellIdCount];
        for (var cellIdIndex = 0; cellIdIndex < cellIdCount; cellIdIndex++) cellId_[cellIdIndex] = reader.ReadVarUShort();
        CellId = cellId_;
    }
}