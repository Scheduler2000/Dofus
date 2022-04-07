using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightStealKamaMessage : AbstractGameActionMessage
{
    public new const uint Id = 8847;

    public GameActionFightStealKamaMessage(ushort actionId, double sourceId, double targetId, ulong amount)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        Amount = amount;
    }

    public GameActionFightStealKamaMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public ulong Amount { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
        writer.WriteVarULong(Amount);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
        Amount = reader.ReadVarULong();
    }
}