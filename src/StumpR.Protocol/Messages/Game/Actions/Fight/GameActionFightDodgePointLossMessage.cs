using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightDodgePointLossMessage : AbstractGameActionMessage
{
    public new const uint Id = 7629;

    public GameActionFightDodgePointLossMessage(ushort actionId, double sourceId, double targetId, ushort amount)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        Amount = amount;
    }

    public GameActionFightDodgePointLossMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public ushort Amount { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
        writer.WriteVarUShort(Amount);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
        Amount = reader.ReadVarUShort();
    }
}