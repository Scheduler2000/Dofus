using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class UpdateLifePointsMessage : Message
{
    public const uint Id = 1857;

    public UpdateLifePointsMessage(uint lifePoints, uint maxLifePoints)
    {
        LifePoints = lifePoints;
        MaxLifePoints = maxLifePoints;
    }

    public UpdateLifePointsMessage()
    {
    }

    public override uint MessageId => Id;

    public uint LifePoints { get; set; }

    public uint MaxLifePoints { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(LifePoints);
        writer.WriteVarUInt(MaxLifePoints);
    }

    public override void Deserialize(IDataReader reader)
    {
        LifePoints = reader.ReadVarUInt();
        MaxLifePoints = reader.ReadVarUInt();
    }
}