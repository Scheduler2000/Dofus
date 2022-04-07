using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightExchangePositionsMessage : AbstractGameActionMessage
{
    public new const uint Id = 8844;

    public GameActionFightExchangePositionsMessage(ushort actionId,
        double sourceId,
        double targetId,
        short casterCellId,
        short targetCellId)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        CasterCellId = casterCellId;
        TargetCellId = targetCellId;
    }

    public GameActionFightExchangePositionsMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public short CasterCellId { get; set; }

    public short TargetCellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
        writer.WriteShort(CasterCellId);
        writer.WriteShort(TargetCellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
        CasterCellId = reader.ReadShort();
        TargetCellId = reader.ReadShort();
    }
}