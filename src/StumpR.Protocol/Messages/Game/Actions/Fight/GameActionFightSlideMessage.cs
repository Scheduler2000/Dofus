using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightSlideMessage : AbstractGameActionMessage
{
    public new const uint Id = 914;

    public GameActionFightSlideMessage(ushort actionId, double sourceId, double targetId, short startCellId, short endCellId)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        StartCellId = startCellId;
        EndCellId = endCellId;
    }

    public GameActionFightSlideMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public short StartCellId { get; set; }

    public short EndCellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
        writer.WriteShort(StartCellId);
        writer.WriteShort(EndCellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
        StartCellId = reader.ReadShort();
        EndCellId = reader.ReadShort();
    }
}