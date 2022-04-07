using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightDispellMessage : AbstractGameActionMessage
{
    public new const uint Id = 4560;

    public GameActionFightDispellMessage(ushort actionId, double sourceId, double targetId, bool verboseCast)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        VerboseCast = verboseCast;
    }

    public GameActionFightDispellMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public bool VerboseCast { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
        writer.WriteBoolean(VerboseCast);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
        VerboseCast = reader.ReadBoolean();
    }
}