using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightLifeAndShieldPointsLostMessage : GameActionFightLifePointsLostMessage
{
    public new const uint Id = 6816;

    public GameActionFightLifeAndShieldPointsLostMessage(ushort actionId,
        double sourceId,
        double targetId,
        uint loss,
        uint permanentDamages,
        int elementId,
        ushort shieldLoss)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        Loss = loss;
        PermanentDamages = permanentDamages;
        ElementId = elementId;
        ShieldLoss = shieldLoss;
    }

    public GameActionFightLifeAndShieldPointsLostMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort ShieldLoss { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(ShieldLoss);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ShieldLoss = reader.ReadVarUShort();
    }
}