using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PartyEntityMemberInformation : PartyEntityBaseInformation
{
    public new const short Id = 2136;

    public PartyEntityMemberInformation(sbyte indexId,
        sbyte entityModelId,
        EntityLook entityLook,
        ushort initiative,
        uint lifePoints,
        uint maxLifePoints,
        ushort prospecting,
        byte regenRate)
    {
        IndexId = indexId;
        EntityModelId = entityModelId;
        EntityLook = entityLook;
        Initiative = initiative;
        LifePoints = lifePoints;
        MaxLifePoints = maxLifePoints;
        Prospecting = prospecting;
        RegenRate = regenRate;
    }

    public PartyEntityMemberInformation()
    {
    }

    public override short TypeId => Id;

    public ushort Initiative { get; set; }

    public uint LifePoints { get; set; }

    public uint MaxLifePoints { get; set; }

    public ushort Prospecting { get; set; }

    public byte RegenRate { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(Initiative);
        writer.WriteVarUInt(LifePoints);
        writer.WriteVarUInt(MaxLifePoints);
        writer.WriteVarUShort(Prospecting);
        writer.WriteByte(RegenRate);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Initiative = reader.ReadVarUShort();
        LifePoints = reader.ReadVarUInt();
        MaxLifePoints = reader.ReadVarUInt();
        Prospecting = reader.ReadVarUShort();
        RegenRate = reader.ReadByte();
    }
}