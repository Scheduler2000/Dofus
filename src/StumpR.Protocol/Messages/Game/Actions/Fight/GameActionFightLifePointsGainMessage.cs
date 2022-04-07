using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightLifePointsGainMessage : AbstractGameActionMessage
{
    public new const uint Id = 6777;

    public GameActionFightLifePointsGainMessage(ushort actionId, double sourceId, double targetId, uint delta)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        Delta = delta;
    }

    public GameActionFightLifePointsGainMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public uint Delta { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
        writer.WriteVarUInt(Delta);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
        Delta = reader.ReadVarUInt();
    }
}