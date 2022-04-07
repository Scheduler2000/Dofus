using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightReflectSpellMessage : AbstractGameActionMessage
{
    public new const uint Id = 8272;

    public GameActionFightReflectSpellMessage(ushort actionId, double sourceId, double targetId)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
    }

    public GameActionFightReflectSpellMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
    }
}