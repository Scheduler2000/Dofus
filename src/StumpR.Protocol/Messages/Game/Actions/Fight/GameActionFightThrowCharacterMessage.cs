using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightThrowCharacterMessage : AbstractGameActionMessage
{
    public new const uint Id = 1069;

    public GameActionFightThrowCharacterMessage(ushort actionId, double sourceId, double targetId, short cellId)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        CellId = cellId;
    }

    public GameActionFightThrowCharacterMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public short CellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
        writer.WriteShort(CellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
        CellId = reader.ReadShort();
    }
}