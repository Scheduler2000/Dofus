using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChallengeTargetsListMessage : Message
{
    public const uint Id = 7386;

    public ChallengeTargetsListMessage(IEnumerable<double> targetIds, IEnumerable<short> targetCells)
    {
        TargetIds = targetIds;
        TargetCells = targetCells;
    }

    public ChallengeTargetsListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<double> TargetIds { get; set; }

    public IEnumerable<short> TargetCells { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) TargetIds.Count());
        foreach (double objectToSend in TargetIds) writer.WriteDouble(objectToSend);
        writer.WriteShort((short) TargetCells.Count());
        foreach (short objectToSend in TargetCells) writer.WriteShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort targetIdsCount = reader.ReadUShort();
        var targetIds_ = new double[targetIdsCount];
        for (var targetIdsIndex = 0; targetIdsIndex < targetIdsCount; targetIdsIndex++) targetIds_[targetIdsIndex] = reader.ReadDouble();
        TargetIds = targetIds_;
        ushort targetCellsCount = reader.ReadUShort();
        var targetCells_ = new short[targetCellsCount];

        for (var targetCellsIndex = 0; targetCellsIndex < targetCellsCount; targetCellsIndex++)
            targetCells_[targetCellsIndex] = reader.ReadShort();
        TargetCells = targetCells_;
    }
}