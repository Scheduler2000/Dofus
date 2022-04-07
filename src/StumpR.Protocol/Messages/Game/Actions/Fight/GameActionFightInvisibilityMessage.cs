using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightInvisibilityMessage : AbstractGameActionMessage
{
    public new const uint Id = 7441;

    public GameActionFightInvisibilityMessage(ushort actionId, double sourceId, double targetId, sbyte state)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        State = state;
    }

    public GameActionFightInvisibilityMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public sbyte State { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
        writer.WriteSByte(State);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
        State = reader.ReadSByte();
    }
}