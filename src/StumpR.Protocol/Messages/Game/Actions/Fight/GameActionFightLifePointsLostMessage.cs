using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightLifePointsLostMessage : AbstractGameActionMessage
{
    public new const uint Id = 4520;

    public GameActionFightLifePointsLostMessage(ushort actionId,
        double sourceId,
        double targetId,
        uint loss,
        uint permanentDamages,
        int elementId)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        Loss = loss;
        PermanentDamages = permanentDamages;
        ElementId = elementId;
    }

    public GameActionFightLifePointsLostMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public uint Loss { get; set; }

    public uint PermanentDamages { get; set; }

    public int ElementId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
        writer.WriteVarUInt(Loss);
        writer.WriteVarUInt(PermanentDamages);
        writer.WriteVarInt(ElementId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
        Loss = reader.ReadVarUInt();
        PermanentDamages = reader.ReadVarUInt();
        ElementId = reader.ReadVarInt();
    }
}