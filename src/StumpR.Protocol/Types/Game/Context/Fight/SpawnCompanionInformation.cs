using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class SpawnCompanionInformation : SpawnInformation
{
    public new const short Id = 8892;

    public SpawnCompanionInformation(sbyte modelId, ushort level, double summonerId, double ownerId)
    {
        ModelId = modelId;
        Level = level;
        SummonerId = summonerId;
        OwnerId = ownerId;
    }

    public SpawnCompanionInformation()
    {
    }

    public override short TypeId => Id;

    public sbyte ModelId { get; set; }

    public ushort Level { get; set; }

    public double SummonerId { get; set; }

    public double OwnerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(ModelId);
        writer.WriteVarUShort(Level);
        writer.WriteDouble(SummonerId);
        writer.WriteDouble(OwnerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ModelId = reader.ReadSByte();
        Level = reader.ReadVarUShort();
        SummonerId = reader.ReadDouble();
        OwnerId = reader.ReadDouble();
    }
}