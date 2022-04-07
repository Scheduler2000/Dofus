using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightModifyEffectsDurationMessage : AbstractGameActionMessage
{
    public new const uint Id = 7980;

    public GameActionFightModifyEffectsDurationMessage(ushort actionId, double sourceId, double targetId, short delta)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        Delta = delta;
    }

    public GameActionFightModifyEffectsDurationMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public short Delta { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
        writer.WriteShort(Delta);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
        Delta = reader.ReadShort();
    }
}